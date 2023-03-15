using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents
{
    /// <summary>
    /// Астероид.
    /// </summary>
    public class Asteroid : Enemy
    {
        /// <summary>
        /// Инициализатор астероида.
        /// </summary>
        /// <param name="speedMotion"> Скорость астероида. </param>
        /// <param name="k"> Переменная для рандомного размера астероида. </param>
        public Asteroid(float speedMotion, float k) : base(speedMotion)
        {
            W = 0.6f * k;
            H = 0.5f * k;
        }

        /// <summary>
        /// Получение текстурных координат астероида.
        /// </summary>
        /// <returns> Двухэлементая структура текстурных координат астероида. </returns>
        public override Vector2[] GetTextures()
        {
            Vector2[] cubeTexCoords =
            {
                new Vector2(0, 0), new Vector2(96, 0), new Vector2(0, 95),
                new Vector2(96, 0), new Vector2(96, 95), new Vector2(0, 95)
            };

            return cubeTexCoords;
        }
    }
}
