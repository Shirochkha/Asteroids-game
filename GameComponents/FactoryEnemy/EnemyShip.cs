using GameComponents.Objects;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents
{
    /// <summary>
    /// Вражеский корабль.
    /// </summary>
    public class EnemyShip : Enemy
    {
        /// <summary>
        /// Инициализатор вражеского корабля.
        /// </summary>
        /// <param name="speedMotion"> Скорость вражеского корабля. </param>
        public EnemyShip(float speedMotion) : base (speedMotion)
        {
            W = 0.7f;
            H = 0.5f;
        }

        /// <summary>
        /// Получение текстурных координат вражеского корабля.
        /// </summary>
        /// <returns> Двухэлементая структура текстурных координат вражеского корабля. </returns>
        public override Vector2[] GetTextures()
        {
            Vector2[] cubeTexCoords =
            {
                new Vector2(0, 0), new Vector2(82, 0), new Vector2(0, 84),
                new Vector2(82, 0), new Vector2(82, 84), new Vector2(0, 84)
            };

            return cubeTexCoords;
        }
    }
}
