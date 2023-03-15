using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents
{
    /// <summary>
    /// Враг.
    /// </summary>
    public abstract class Enemy : GameObject, IMovable
    {
        /// <summary>
        /// Скорость врага.
        /// </summary>
        protected float speedMotion;

        /// <summary>
        /// Скорость врага.
        /// </summary>
        public float SpeedMotion => speedMotion;

        /// <summary>
        /// Инициализатор врага.
        /// </summary>
        /// <param name="speedMotion"> Скорость врага. </param>
        public Enemy(float speedMotion)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            Y = 3.0f;
            X = (float)(random.Next(-6, 6));
            this.speedMotion = speedMotion;
        }

        /// <summary>
        /// Перемещение врага по вертикали.
        /// </summary>
        /// <param name="marker"> Флаг перемещения врага по вертикали. </param>
        public void MoveVertical(bool marker)
        {
            if (marker == true) Y += speedMotion;
            else Y -= speedMotion;
        }
    }
}
