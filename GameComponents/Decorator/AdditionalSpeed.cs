using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Decorator
{
    /// <summary>
    /// Увеличение скорости корабля.
    /// </summary>
    public class AdditionalSpeed : PlayerDecorator
    {
        private float boostSpeed = 0.05f;

        /// <summary>
        /// Добавление скорости корабля.
        /// </summary>
        public override float SpeedMotion => player.SpeedMotion + boostSpeed;

        /// <summary>
        /// Инициализатор бонуса скорости корабля.
        /// </summary>
        /// <param name="player"> Декорируемый корабль. </param>
        public AdditionalSpeed(PlayerShip player) : base(player)
        {
        }

        /// <summary>
        /// Значение дополнительной скорости, свойство необходимо для тестов.
        /// </summary>
        public float BoostSpeed
        {
            get { return boostSpeed; }
        }

    }
}
