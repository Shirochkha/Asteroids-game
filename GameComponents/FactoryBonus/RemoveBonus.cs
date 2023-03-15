using GameComponents.Decorator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryBonus
{
    /// <summary>
    /// Удалитель бонуса скорости.
    /// </summary>
    public class RemoveBonus : Bonus
    {
        /// <summary>
        /// Активация удаления бонуса скорости.
        /// </summary>
        /// <param name="ship"> Декоратор декорируемого корабля. </param>
        public override PlayerShip Activation(PlayerDecorator ship)
        {
            return new RemoveSpeed(ship.Player);
        }
    }
}
