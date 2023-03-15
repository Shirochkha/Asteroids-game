using GameComponents.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryBonus
{
    /// <summary>
    /// Бонус скорости.
    /// </summary>
    public class SpeedBonus : Bonus
    {
        /// <summary>
        /// Активация бонуса скорости.
        /// </summary>
        /// <param name="ship"> Декоратор декорируемого корабля. </param>
        public override PlayerShip Activation(PlayerDecorator ship)
        {
            return new AdditionalSpeed(ship.Player);
        }
    }
}
