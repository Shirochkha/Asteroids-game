using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using GameComponents.Objects;
using System.Windows;
using GameComponents.FactoryBonus;
using GameComponents.Decorator;
using GameComponents.FactoryPlayerShip;
using static GameComponents.Shaders;
using GameComponents;
using GameComponents.FactoryEnemy;

namespace Ateroids
{
    /// <summary>
    /// Игровая логика.
    /// </summary>
    public class Engine : GameWindow
    {
        private int armor = 0;
        private int health = 100;
        private int score = 0;
        private int c = 0;
        private int meteorCount = 0;
        private int enemyCount = 0;
        private double time = -1;
        private int speedBonus = 0;
        private double time2 = -1;
        private int speedBonus2 = 0;
        private bool shoot;
        private bool shoot2;
        /// <summary>
        /// Флаг для перемещения первого игрока влево.
        /// </summary>
        public bool moveLeft;
        /// <summary>
        /// Флаг для перемещения второго игрока влево.
        /// </summary>
        public bool moveLeft2;
        /// <summary>
        /// Флаг для перемещения первого игрока вправо.
        /// </summary>
        public bool moveRight;
        /// <summary>
        /// Флаг для перемещения второго игрока вправо.
        /// </summary>
        public bool moveRight2;
        /// <summary>
        /// Тип корабля первого игрока.
        /// </summary>
        public int typeShip1 = 0;
        /// <summary>
        /// Тип корабля второго игрока.
        /// </summary>
        public int typeShip2 = 0;

        private Color4 _backColor = new Color4(0.0f, 0.6f, 1.0f, 1.0f);
        private int _program;
        private const float NearDistance = 0.1f;
        private const float FarDistance = 100.0f;

        private Dictionary<int, string> _tex = new Dictionary<int, string>()
        {
            {1, "1.png" },
            {2, "5.png" },
            {3, "player.png" },
            {4, "Red.jpg" },
            {5, "Asteroid.png" },
            {6, "4.png" },
            {7, "purple.png" },
            {8, "Speed.png" },
            {9, "Armor.png" },
            {10, "Green.jpg" }
        };

        /// <summary>
        /// Структура объекта.
        /// </summary>
        public struct GameObj
        {
            /// <summary>
            /// Тип объекта.
            /// </summary>
            public GameObject gameObject;
            /// <summary>
            /// Массив координат вершин объекта.
            /// </summary>
            public int _cubeVertexArray;
            /// <summary>
            /// Объект буффера вершин.
            /// </summary>
            public int _cubeVertexBuffer;
            /// <summary>
            /// Объект буффера текстурных координат.
            /// </summary>
            public int _cubeTextureCoordsBuffer;
            /// <summary>
            /// Текстурные координаты.
            /// </summary>
            public int _texture;
        }

        private List<GameObj> ObjectList;
        private List<GameObj> EnemyList;
        private List<GameObj> LazersList;

        /// <summary>
        /// Массив кораблей и фона.
        /// </summary>
        public GameObj[] ObjectArray;
        private GameObj[] EnemyArray;
        private GameObj[] LazersArray;

        private Matrix4 _modelMatrix;
        private Matrix4 _viewMatrix;
        private Matrix4 _projectionMatrix;
        private Matrix4 _mvpMatrix;
        private int _mvpMatrixLocation;

        /// <summary>
        /// Инициализатор GameWindow.
        /// </summary>
        public Engine() :
            base(1000, 590, GraphicsMode.Default, "Asteroids", GameWindowFlags.Default,
                DisplayDevice.Default, 4, 3, GraphicsContextFlags.Debug)
        {
            VSync = VSyncMode.On;
            Load += MainWindow_Load;
            Resize += MainWindow_Resize;
            KeyDown += MainWindow_KeyDown;
            KeyUp += MainWindow_KeyUp;
            UpdateFrame += MainWindow_UpdateFrame;
            RenderFrame += MainWindow_RenderFrame;
            this.Location = new System.Drawing.Point(320, 100);
        }

        private void UpdateMatrices()
        {
            _modelMatrix = Matrix4.Identity;
            _viewMatrix = Matrix4.Identity;
            _mvpMatrix = _modelMatrix * _viewMatrix * _projectionMatrix;
        }

        private void MakeLazersMove()
        {
            for (int i = 0; i < LazersArray.Length; i++)
            {
                if (LazersArray[i].gameObject is FirstLazer)
                {
                    ((FirstLazer)LazersArray[i].gameObject).MoveVertical(true);
                }
                if (LazersArray[i].gameObject is SecondLazer)
                {
                    ((SecondLazer)LazersArray[i].gameObject).MoveVertical(false);
                }

            }
        }

        private void MakeEnemyMove()
        {
            for (int i = 0; i < EnemyArray.Length; i++)
            {
                ((Enemy)EnemyArray[i].gameObject).MoveVertical(false);
            }
        }

        private void MakeBonuseMove()
        {
            for (int i = 0; i < LazersArray.Length; i++)
            {
                if (LazersArray[i].gameObject is BonusGenerator)
                {
                    ((BonusGenerator)LazersArray[i].gameObject).Move();
                }

            }
        }

        private void CreatePlayerShip1()
        {
            GameObject player = new PlayerDecorator(new BasicShip());
            switch (typeShip1)
            {
                case 1:
                    player = new PlayerDecorator(new BasicShip());
                    ObjectList.Add(new GameObj()
                    {
                        gameObject = player,
                        _texture = Tex(_tex[3])
                    });
                    break;
                case 2:
                    player = new PlayerDecorator(new SpeedShip());
                    ObjectList.Add(new GameObj()
                    {
                        gameObject = player,
                        _texture = Tex(_tex[2])
                    });
                    break;
                case 3:
                    player = new PlayerDecorator(new ArmorShip());
                    ObjectList.Add(new GameObj()
                    {
                        gameObject = player,
                        _texture = Tex(_tex[1])
                    });
                    break;
            }
            player.X = -5.0f;
        }

        private void CreatePlayerShip2()
        {
            GameObject player = new PlayerDecorator(new BasicShip());
            switch (typeShip2)
            {
                case 1:
                    player = new PlayerDecorator(new BasicShip());
                    ObjectList.Add(new GameObj()
                    {
                        gameObject = player,
                        _texture = Tex(_tex[3])
                    });
                    break;
                case 2:
                    player = new PlayerDecorator(new SpeedShip());
                    ObjectList.Add(new GameObj()
                    {
                        gameObject = player,
                        _texture = Tex(_tex[2])
                    });
                    break;
                case 3:
                    player = new PlayerDecorator(new ArmorShip());
                    ObjectList.Add(new GameObj()
                    {
                        gameObject = player,
                        _texture = Tex(_tex[1])
                    });
                    break;
            }
            player.X = 5.0f;
        }

        private void CreateAsteroid()
        {
            EnemyCreator asteroid = new CreatorAsteroid();
            EnemyList.Add(new GameObj()
            {
                gameObject = asteroid.CreateEnemy(),
                _texture = Tex(_tex[5])
            });
        }

        private void CreateEnemyShip()
        {
            SecondLazer laser2 = new SecondLazer(0.1f);
            EnemyCreator enemy = new CreatorEnemyShip();
            EnemyShip en = (EnemyShip)enemy.CreateEnemy();

            laser2.X = en.X;
            laser2.Y = en.Y - 0.2f;

            EnemyList.Add(new GameObj()
            {
                gameObject = en,
                _texture = Tex(_tex[6])
            });
;
            LazersList.Add(new GameObj()
            {
                gameObject = laser2,
                _texture = Tex(_tex[10])
            });
        }

        /// <summary>
        /// Генерация бонусов.
        /// </summary>
        private void CreateBonus()
        {
            var bonus = new BonusGenerator();

            var random = new Random(DateTime.Now.Millisecond);
            bonus.X = random.Next(-6, 6);
            bonus.Y = random.Next(2, 3);

            switch (bonus.RandomBonus)
            {
                case 0:
                    LazersList.Add(new GameObj()
                    {
                        gameObject = bonus,
                        _texture = Tex(_tex[8])
                    });
                    break;
                case 1:
                    LazersList.Add(new GameObj()
                    {
                        gameObject = bonus,
                        _texture = Tex(_tex[9])
                    });
                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Декарирование корабля.
        /// </summary>
        /// <param name="player"> Корабль. </param>
        /// <param name="boost"> Бонус. </param>
        /// <returns> Декарированный корабль.</returns>
        private PlayerDecorator DecorationPlayerShip(GameObject player, GameObject boost)
        {
            var ship = (PlayerDecorator)player;
            var bonusGenerator = (BonusGenerator)boost;

            var oldX = ship.X;
            var oldY = ship.Y;
            var oldW = ship.W;
            var oldH = ship.H;

            var bonus = bonusGenerator.GenerateBonus();
            ship.SetPlayerShip(bonus.Activation(ship));
            ship.X = oldX;
            ship.Y = oldY;
            ship.W = oldW;
            ship.H = oldH;

            return ship;
        }

        private PlayerDecorator DecorationPlayerShip(GameObject player)
        {
            var ship = (PlayerDecorator)player;
            BonusCreator rem = new RemoverSpeed();
            var bon = rem.CreateBonus();
            ship.SetPlayerShip(bon.Activation(ship));

            return ship;
        }

        private void Collision()
        {
            var player1 = new RectangleF(ObjectArray[0].gameObject.X,
                                         ObjectArray[0].gameObject.Y,
                                         ObjectArray[0].gameObject.W,
                                         ObjectArray[0].gameObject.H);

            var player2 = new RectangleF(ObjectArray[1].gameObject.X,
                                         ObjectArray[1].gameObject.Y,
                                         ObjectArray[1].gameObject.W,
                                         ObjectArray[1].gameObject.H);

            for (int i = 0; i < EnemyArray.Length; i++)
            {
                for (int j = 0; j < LazersArray.Length; j++)
                {
                    //враги с игроками
                    RectangleF ship = new RectangleF(0,0,0,0);
                    RectangleF aster = new RectangleF(0,0,0,0);

                    if (EnemyArray[i].gameObject is EnemyShip)
                    {
                        ship = new System.Drawing.RectangleF(((EnemyShip)EnemyArray[i].gameObject).X - 0.5f,
                                                              ((EnemyShip)EnemyArray[i].gameObject).Y,
                                                            2 * ((EnemyShip)EnemyArray[i].gameObject).W,
                                                          ((EnemyShip)EnemyArray[i].gameObject).H);

                    }
                    if (EnemyArray[i].gameObject is Asteroid)
                    {
                        aster = new System.Drawing.RectangleF(((Asteroid)EnemyArray[i].gameObject).X - 0.5f,
                                                              ((Asteroid)EnemyArray[i].gameObject).Y,
                                                            2 * ((Asteroid)EnemyArray[i].gameObject).W,
                                                          ((Asteroid)EnemyArray[i].gameObject).H);
                    }

                    
                    if(player1.IntersectsWith(ship) || player2.IntersectsWith(ship) ||
                        player1.IntersectsWith(aster) || player2.IntersectsWith(aster))
                    {
                        ((Enemy)EnemyArray[i].gameObject).Y = 4.0f;
                        if (((PlayerShip)ObjectArray[0].gameObject).Armor > 0) ((PlayerShip)ObjectArray[0].gameObject).Armor -= 10;
                        else if (((PlayerShip)ObjectArray[1].gameObject).Armor > 0) ((PlayerShip)ObjectArray[1].gameObject).Armor -= 10;
                        else health -= 5;
                    }

                    if (LazersArray[j].gameObject is FirstLazer)
                    {
                        var lazers1 = new System.Drawing.RectangleF(((FirstLazer)LazersArray[j].gameObject).X,
                                                                      ((FirstLazer)LazersArray[j].gameObject).Y,
                                                                  ((FirstLazer)LazersArray[j].gameObject).W,
                                                                  ((FirstLazer)LazersArray[j].gameObject).H);

                        //дружественный лазер и враги
                        if (ship.IntersectsWith(lazers1) == true)
                        {
                            ((FirstLazer)LazersArray[j].gameObject).Y = 4.0f;
                            ((Enemy)EnemyArray[i].gameObject).Y = 4.0f;

                            score += 3;
                        }
                        if (aster.IntersectsWith(lazers1) == true)
                        {
                            ((FirstLazer)LazersArray[j].gameObject).Y = 4.0f;
                            ((Enemy)EnemyArray[i].gameObject).Y = 4.0f;

                            if (EnemyArray[i].gameObject is Asteroid)
                            {
                                if (((Asteroid)EnemyArray[i].gameObject).W <= 0.49f) score += 5;
                                if (((Asteroid)EnemyArray[i].gameObject).W <= 0.59f && ((Asteroid)EnemyArray[i].gameObject).W > 0.49f) score += 2;
                                if (((Asteroid)EnemyArray[i].gameObject).W > 0.59f) score += 1;
                            }

                            CreateBonus();

                        }
                    }

                    //бонусы
                    if (LazersArray[j].gameObject is BonusGenerator && ObjectArray[0].gameObject is PlayerShip)
                    {
                        var bonus = new System.Drawing.RectangleF(((BonusGenerator)LazersArray[j].gameObject).X,
                                                                  ((BonusGenerator)LazersArray[j].gameObject).Y,
                                                                  ((BonusGenerator)LazersArray[j].gameObject).W,
                                                                  ((BonusGenerator)LazersArray[j].gameObject).H);

                        if (player1.IntersectsWith(bonus))
                        {
                            if (((BonusGenerator)LazersArray[j].gameObject).RandomBonus == 0)
                            {
                                time = 0;
                                speedBonus++;
                            }
                            ObjectArray[0].gameObject = DecorationPlayerShip(ObjectArray[0].gameObject, LazersArray[j].gameObject);
                            ((BonusGenerator)LazersArray[j].gameObject).Y = 4.0f;
                        }


                        if (player2.IntersectsWith(bonus))
                        {
                            if (((BonusGenerator)LazersArray[j].gameObject).RandomBonus == 0)
                            {
                                time2 = 0;
                                speedBonus2++;
                            }
                            ObjectArray[1].gameObject = DecorationPlayerShip(ObjectArray[1].gameObject, LazersArray[j].gameObject);
                            ((BonusGenerator)LazersArray[j].gameObject).Y = 4.0f;
                        }
                        
                    }


                    if (LazersArray[j].gameObject is SecondLazer)
                    {
                        var lazers2 = new System.Drawing.RectangleF(((SecondLazer)LazersArray[j].gameObject).X,
                                                                     ((SecondLazer)LazersArray[j].gameObject).Y,
                                                                 ((SecondLazer)LazersArray[j].gameObject).W,
                                                                 ((SecondLazer)LazersArray[j].gameObject).H);

                        //вражеский лазер и игрок
                        if (player1.IntersectsWith(lazers2) == true || player2.IntersectsWith(lazers2) == true)
                        {
                            ((SecondLazer)LazersArray[j].gameObject).Y = 4.0f;
                            if (((PlayerShip)ObjectArray[0].gameObject).Armor > 0) ((PlayerShip)ObjectArray[0].gameObject).Armor -= 10;
                            else if (((PlayerShip)ObjectArray[1].gameObject).Armor > 0) ((PlayerShip)ObjectArray[1].gameObject).Armor -= 10;
                            else health -= 10;
                        }
                    }

                }
            }

        }
        private void MainWindow_UpdateFrame(object sender, FrameEventArgs e)
        {
            Counts();   
            DeleteDecorator();
            Collision();
            DeleteObjsOut();
            MakeLazersMove();
            MakeEnemyMove();
            MakeBonuseMove();
            DisposeAll();

            armor = ((PlayerShip)ObjectArray[0].gameObject).Armor + ((PlayerShip)ObjectArray[1].gameObject).Armor;
            Title = $"Asteroids  Жизни: {health}  Cчет: {score} Броня: {armor}";

        }
        private void MainWindow_RenderFrame(object sender, FrameEventArgs e)
        {
            UpdateMatrices();
            GL.ClearColor(_backColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            MovePlayer pl = new MovePlayer(moveLeft, moveLeft2, moveRight, moveRight2, ObjectArray);
            pl.CheckKeysPlayer();
            UpdateAll();
            GL.UseProgram(_program);
            GL.UniformMatrix4(_mvpMatrixLocation, false, ref _mvpMatrix);
            DrawAll();
            SwapBuffers();
            if (health == 0 || health == -5)
            {
                GameOver gameOver = new GameOver();
                gameOver.textOver.Text = "Счёт: " + score.ToString();
                gameOver.Show();
                CursorVisible = true;
                this.Close();
            }
        }
        private void Counts()
        {
            if (time >= 0)
            {
                time++;
            }
            if (time2 >= 0)
            {
                time2++;
            }
            meteorCount++;
            if (meteorCount > 120)
            {
                CreateAsteroid();
                meteorCount = 0;
            }
            enemyCount++;
            if (enemyCount > 80)
            {
                CreateEnemyShip();
                enemyCount = 0;
            }
        }
        private void DeleteDecorator()
        {
            if (time == 300)
            {
                switch (speedBonus)
                {
                    case 1:
                        ObjectArray[0].gameObject = DecorationPlayerShip(ObjectArray[0].gameObject);
                        break;
                    case 2:
                        ObjectArray[0].gameObject = DecorationPlayerShip(ObjectArray[0].gameObject);
                        ObjectArray[0].gameObject = DecorationPlayerShip(ObjectArray[0].gameObject);
                        break;
                }
                speedBonus = 0;
            }
            if (time2 == 300)
            {
                switch (speedBonus2)
                {
                    case 1:
                        ObjectArray[1].gameObject = DecorationPlayerShip(ObjectArray[1].gameObject);
                        break;
                    case 2:
                        ObjectArray[1].gameObject = DecorationPlayerShip(ObjectArray[1].gameObject);
                        ObjectArray[1].gameObject = DecorationPlayerShip(ObjectArray[1].gameObject);
                        break;
                }
                speedBonus2 = 0;
            }
        }

        private void MainWindow_KeyDown(object sender, KeyboardKeyEventArgs e)
         {
            switch (e.Key)
            {
                case Key.A:
                    {
                        moveLeft = true;
                        break;
                    }
                case Key.Left:
                    {
                        moveLeft2 = true;
                        break;
                    }
                case Key.D:
                    {
                        moveRight = true;
                        break;
                    }
                case Key.Right:
                    {
                        moveRight2 = true;
                        break;
                    }
                case Key.W:
                    {
                        shoot = true;

                        if (shoot == true)
                        {
                            Lazer laser1 = new FirstLazer(0.15f)
                            {
                                Y = ObjectArray[0].gameObject.Y + 0.8f,
                                X = ObjectArray[0].gameObject.X
                            };
                            LazersList.Add(new GameObj()
                            {
                                gameObject = laser1,
                                _texture = Tex(_tex[4])
                            });
                        }
                        break;
                    }
                case Key.Up:
                    {
                        shoot2 = true;

                        if (shoot2 == true)
                        {
                            Lazer laser2 = new FirstLazer(0.15f)
                            {
                                Y = ObjectArray[1].gameObject.Y + 0.8f,
                                X = ObjectArray[1].gameObject.X
                            };
                            LazersList.Add(new GameObj()
                            {
                                gameObject = laser2,
                                _texture = Tex(_tex[4])
                            });
                        }
                        break;
                    }
                case Key.Escape:
                    {
                        Exit();
                        Application.Current.Shutdown();
                        break;
                    }
            }
         }

        private void MainWindow_KeyUp(object sender, KeyboardKeyEventArgs e)
        {

            switch (e.Key)
            {
                case Key.A:
                    {
                        moveLeft = false;
                        break;
                    }
                case Key.Left:
                    {
                        moveLeft2 = false;
                        break;
                    }
                case Key.D:
                    {
                        moveRight = false;
                        break;
                    }
                case Key.Right:
                    {
                        moveRight2 = false;
                        break;
                    }
                case Key.W:
                    {
                        shoot = false;
                        break;
                    }
                case Key.Up:
                    {
                        shoot2 = false;
                        break;
                    }
            }
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            float aspect = (float)Width / Height;
            _projectionMatrix = Matrix4.CreateOrthographic(13.0f, 13.0f / aspect, NearDistance, FarDistance);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            _program = CreateProgram();
            _mvpMatrixLocation = GL.GetUniformLocation(_program, "mvpMatrix");
            moveLeft = false;
            moveLeft2 = false;
            moveRight = false;
            moveRight2 = false;
            shoot = false;
            shoot2 = false;
            ObjectList = new List<GameObj>();
            EnemyList = new List<GameObj>(); 
            LazersList = new List<GameObj>();
            //1 игрок
            CreatePlayerShip1();
            //2 игрок
            CreatePlayerShip2();
            //фон
            GameObject background = new Background();
            ObjectList.Add(new GameObj()
            {
                gameObject = background,
                _texture = Tex(_tex[7])
            });
            CreateAsteroid();
            UpdateAll();
            CursorVisible = false;
            GL.PolygonMode(MaterialFace.Front, PolygonMode.Fill);
            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Less);
        }
        private void UpdateAll()
        {
            ObjectArray = ObjectList.ToArray();
            for (int i = 0; i < ObjectArray.Length; i++)
            {
                InitObj(ref ObjectArray[i]);
            }
            EnemyArray = EnemyList.ToArray();
            for (int j = 0; j < EnemyArray.Length; j++)
            {
                InitObj(ref EnemyArray[j]);
            }
            LazersArray = LazersList.ToArray();
            for (int k = 0; k < LazersArray.Length; k++)
            {
                InitObj(ref LazersArray[k]);
            }
        }
        private void DrawAll()
        {
            for (int j = 0; j < EnemyArray.Length; j++)
            {
                DrawObj(EnemyArray[j]);
            }
            for (int k = 0; k < LazersArray.Length; k++)
            {
                DrawObj(LazersArray[k]);
            }
            for (int i = 0; i < ObjectArray.Length; i++)
            {
                DrawObj(ObjectArray[i]);
            }
        }
        private void DeleteObjsOut()
        {
            int i = 0;
            while (i < ObjectList.Count)
            {
                if (ObjectList[i].gameObject.Y > 3.5f || ObjectList[i].gameObject.Y < -3.5f)
                {
                    ObjectList.RemoveAt(i);
                    i--;
                }
                i++;
            }

            int j = 0;
            while (j < EnemyList.Count)
            {
                if (EnemyList[j].gameObject.Y > 3.5f || EnemyList[j].gameObject.Y < -3.5f)
                {
                    EnemyList.RemoveAt(j);
                    j--;
                }
                j++;
            }
            int k = 0;
            while (k < LazersList.Count)
            {
                if (LazersList[k].gameObject.Y > 3.5f || LazersList[k].gameObject.Y < -3.5f)
                {
                    LazersList.RemoveAt(k);
                    k--;
                }
                k++;
            }
        }
        private void DisposeAll()
        {
            c++;
            if (c > 1500)
            {
                if (EnemyArray.Length > 20 && LazersArray.Length > 10)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        for (int j = 0; j < 13; j++)
                        {
                            DisposeObj(ref EnemyArray[i]);
                            DisposeObj(ref LazersArray[j]);
                        }
                    }
                }

                c = 0;
            }
        }
        private void DisposeObj(ref GameObj obj)
        {
            GL.DeleteTexture(obj._texture);
            GL.DeleteBuffer(obj._cubeTextureCoordsBuffer);
            GL.DeleteBuffer(obj._cubeVertexBuffer);
            GL.DeleteVertexArray(obj._cubeVertexArray);
        }
        private void DrawObj(GameObj obj)
        {
            GL.BindTexture(TextureTarget.Texture2D, obj._texture);
            GL.BindVertexArray(obj._cubeVertexArray);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 6);
        }
        private void InitObj(ref GameObj obj)
        {
            obj._cubeVertexArray = GL.GenVertexArray();
            GL.BindVertexArray(obj._cubeVertexArray);
            obj._cubeVertexBuffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, obj._cubeVertexBuffer);
            Vector4[] vertices = obj.gameObject.GetVertices();
            GL.BufferData(BufferTarget.ArrayBuffer, Vector4.SizeInBytes * vertices.Length, vertices, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 4, VertexAttribPointerType.Float, false, 0, 0);
            Vector2[] cubeTexCoords = obj.gameObject.GetTextures();
            obj._cubeTextureCoordsBuffer = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, obj._cubeTextureCoordsBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, Vector2.SizeInBytes * cubeTexCoords.Length,
            cubeTexCoords, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 0, 0);
        }
        int Tex(string path)
        {
            Bitmap _bitmap = new Bitmap(path);
            Vector4[] textureData = new Vector4[_bitmap.Height * _bitmap.Width];
            int i = 0;
            for (int y = 0; y < _bitmap.Height; ++y)
                for (int x = 0; x < _bitmap.Width; ++x)
                {
                    Color p = _bitmap.GetPixel(x, y);
                    textureData[i++] = new Vector4(p.R / 255.0f, p.G / 255.0f, p.B / 255.0f, p.A / 255.0f);
                }
            int _texture = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, _texture);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba32f,
            _bitmap.Width, _bitmap.Height, 0, PixelFormat.Rgba, PixelType.Float, textureData);
            GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter,
            new int[] { (int)TextureMagFilter.Nearest });
            GL.TexParameterI(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,
            new int[] { (int)TextureMinFilter.Nearest });
            return _texture;
        }
        private int CreateProgram()
        {
            var program = GL.CreateProgram();
            var shaders = new List<int>();
            shaders.Add(CompileShader(ShaderType.VertexShader, "Engine/vertexShader.glsl"));
            shaders.Add(CompileShader(ShaderType.FragmentShader, "Engine/fragmentShader.glsl"));
            foreach (var shader in shaders)
            {
                GL.AttachShader(program, shader);
            }
            GL.LinkProgram(program); ;
            var info = GL.GetProgramInfoLog(program);
            if (!string.IsNullOrEmpty(info))
            {
                Debug.WriteLine($"GL.LinkProgram had info log {info}");
            }
            foreach (var shader in shaders)
            {
                GL.DetachShader(program, shader);
                GL.DeleteShader(shader);
            }
            return program;
        }

    }
}