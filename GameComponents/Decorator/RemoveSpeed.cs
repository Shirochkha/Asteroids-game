using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Decorator
{
    /// <summary>
    /// Удаление бонуса скорости.
    /// </summary>
    public class RemoveSpeed : PlayerDecorator
    {
        private float removeSpeed = 0.05f;

        /// <summary>
        /// Снижение скорости корабля.
        /// </summary>
        public override float SpeedMotion => player.SpeedMotion - removeSpeed;

        /// <summary>
        /// Инициализация удаления бонуса скорости.
        /// </summary>
        /// <param name="player"> Декорируемый корабль. </param>
        public RemoveSpeed(PlayerShip player) : base(player)
        {
        }

    }
}
