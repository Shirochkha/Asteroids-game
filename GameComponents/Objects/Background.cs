using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameComponents.Objects;
using OpenTK;

namespace GameComponents.Objects
{
    /// <summary>
    /// Фон игры.
    /// </summary>
    public class Background : GameObject
    {
        /// <summary>
        ///  Инициализация фона игры.
        /// </summary>
        public Background()
        {
            Y = 0.0f;
            W = 6.5f;
            H = 4.1f;
        }

        /// <summary>
        /// Получение текстурных координат фона.
        /// </summary>
        /// <returns> Двухэлементая структура текстурных координат фона. </returns>
        public override Vector2[] GetTextures()
        {
            Vector2[] cubeTexCoords =
            {
                new Vector2(0, 0), new Vector2(256, 0), new Vector2(0, 256),
                new Vector2(256, 0), new Vector2(256, 256), new Vector2(0, 256)
            };

            return cubeTexCoords;
        }
    }
}
