using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Objects
{
    /// <summary>
    /// Лазер.
    /// </summary>
    public abstract class Lazer : GameObject, IMovable
    {
        /// <summary>
        /// Скорость перемещения лазера.
        /// </summary>
        protected float speedMotion;

        /// <summary>
        /// Скорость перемещения лазера.
        /// </summary>
        public float SpeedMotion => speedMotion;

        /// <summary>
        /// Инициализация лазера.
        /// </summary>
        /// <param name="speedMotion"> Скорость лазера. </param>
        public Lazer(float speedMotion)
        {
            W = 0.1f;
            H = 0.3f;
            this.speedMotion = speedMotion;
        }

        /// <summary>
        /// Перемещение лазера по вертикали.
        /// </summary>
        /// <param name="marker"> Флаг перемещения лазера вверх или вниз по вертикали. </param>
        public void MoveVertical(bool marker)
        {
            if(marker == true) Y += speedMotion;
            else Y -= speedMotion;
        }

        /// <summary>
        /// Получение текстурных координат лазера.
        /// </summary>
        /// <returns> Двухэлементая структура текстурных координат лазера. </returns>
        public override Vector2[] GetTextures()
        {
            Vector2[] cubeTexCoords =
            {
                new Vector2(0, 0), new Vector2(37, 0), new Vector2(0, 172),
                new Vector2(37, 0), new Vector2(37, 172), new Vector2(0, 172)
            };

            return cubeTexCoords;
        }
    }
}
