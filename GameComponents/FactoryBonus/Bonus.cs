using GameComponents.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents
{
    /// <summary>
    /// Бонус.
    /// </summary>
    public abstract class Bonus
    {
        /// <summary>
        /// Активация бонуса.
        /// </summary>
        /// <param name="ship"> Декоратор декорируемого корабля. </param>
        public abstract PlayerShip Activation(PlayerDecorator ship);
    }
}
