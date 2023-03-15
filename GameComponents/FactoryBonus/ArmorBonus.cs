using GameComponents.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryBonus
{
    /// <summary>
    /// Бонус защиты.
    /// </summary>
    public class ArmorBonus : Bonus
    {
        /// <summary>
        /// Активация бонуса защиты.
        /// </summary>
        /// <param name="ship"> Декоратор декорируемого корабля. </param>
        public override PlayerShip Activation(PlayerDecorator ship)
        {
            return new AdditionalArmor(ship.Player);
        }
    }
}
