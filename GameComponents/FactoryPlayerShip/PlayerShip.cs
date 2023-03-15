using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents.Objects;
using OpenTK;

namespace GameComponents
{
    /// <summary>
    /// Корабль игрока.
    /// </summary>
    public abstract class PlayerShip : GameObject
    {
        /// <summary>
        /// Скорость корабля.
        /// </summary>
        public virtual float SpeedMotion { get; set; }

        /// <summary>
        /// Запас брони.
        /// </summary>
        public virtual int Armor { get; set; }

        /// <summary>
        /// Настоящий тип лодки, до декарирования.
        /// </summary>
        public Type BasicType { get; protected set; }

        /// <summary>
        /// Инициализатор корабля игрока.
        /// </summary>
        public PlayerShip()
        {
            Y = -3.0f;
            W = 1.0f;
            H = 0.5f;
            BasicType = this.GetType();
        }

        /// <summary>
        /// Перемещение влево.
        /// </summary>
        public void MoveLeft()
        {
            X -= SpeedMotion;
        }

        /// <summary>
        /// Перемещение вправо.
        /// </summary>
        public void MoveRight()
        {
            X += SpeedMotion;
        }

        /// <summary>
        /// Получение текстурных координат корабля игрока.
        /// </summary>
        /// <returns> Двухэлементая структура текстурных координат корабля игрока. </returns>
        public override Vector2[] GetTextures()
        {
            Vector2[] cubeTexCoords =
             {
                new Vector2(0, 0), new Vector2(112, 0), new Vector2(0, 75),
                new Vector2(112, 0), new Vector2(112, 75), new Vector2(0, 75)
            };

            return cubeTexCoords;
        }
    }
}
