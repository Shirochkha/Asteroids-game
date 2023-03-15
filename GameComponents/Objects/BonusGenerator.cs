using GameComponents.FactoryBonus;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Objects
{
    /// <summary>
    /// Генератор бонусов.
    /// </summary>
    public class BonusGenerator : GameObject
    {
        private int randomBonus;
        private float speedMotion;

        /// <summary>
        /// Скорость падения бонуса.
        /// </summary>
        public float SpeedMotion => speedMotion;

        /// <summary>
        /// Инициализатор бонуса.
        /// </summary>
        public BonusGenerator()
        {
            Random random = new Random();
            this.randomBonus = random.Next(0, 5);
            W = 0.3f;
            H = 0.3f;
            speedMotion = 0.03f;
        }

        /// <summary>
        /// Номер бонуса.
        /// </summary>
        public int RandomBonus
        {
            get { return randomBonus; }
            set { randomBonus = value; }
        }

        /// <summary>
        /// Генерация бонуса.
        /// </summary>
        /// <returns> Бонус. </returns>
        public Bonus GenerateBonus()
        {
            BonusCreator bonusCreator = null;

            switch (randomBonus)
            {
                case 0:
                    bonusCreator = new CreatorSpeed();
                    break;
                case 1:
                    bonusCreator = new CreatorArmor();
                    break;
                default:
                    break;
            }

            return bonusCreator.CreateBonus();
        }


        /// <summary>
        /// Перемещение бонуса вниз.
        /// </summary>
        public void Move()
        {
            Y -= speedMotion;
        }

        /// <summary>
        /// Получение текстурных координат бонуса.
        /// </summary>
        /// <returns> Двухэлементая структура текстурных координат бонуса. </returns>
        public override Vector2[] GetTextures()
        {
            Vector2[] cubeTexCoords =
            {
                new Vector2(0, 0), new Vector2(64, 0), new Vector2(0, 64),
                new Vector2(64, 0), new Vector2(64, 64), new Vector2(0, 64)
            };

            return cubeTexCoords;
        }
    }
}
