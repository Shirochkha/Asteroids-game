using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryPlayerShip
{
    /// <summary>
    /// Выбор скоростного корабля.
    /// </summary>
    public class ChooseSpeedShip : ShipChoose
    {
        /// <summary>
        /// Создание скоростного корабля.
        /// </summary>
        public override PlayerShip CreateShip()
        {
            return new SpeedShip();
        }
    }
}
