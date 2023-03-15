using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryPlayerShip
{
    /// <summary>
    /// Выбор корабля.
    /// </summary>
    public abstract class ShipChoose
    {
        /// <summary>
        /// Создание корабля.
        /// </summary>
        public abstract PlayerShip CreateShip();
    }
}
