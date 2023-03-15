using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryPlayerShip
{
    /// <summary>
    /// Выбор базового корабля.
    /// </summary>
    public class ChooseBasicShip : ShipChoose
    {
        /// <summary>
        /// Создание базового корабля.
        /// </summary>
        public override PlayerShip CreateShip()
        {
            return new BasicShip();
        }
    }
}
