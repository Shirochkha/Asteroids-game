using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryPlayerShip
{
    /// <summary>
    /// Выбор защитного корабля.
    /// </summary>
    public class ChooseArmorShip : ShipChoose
    {
        /// <summary>
        /// Создание защитного корабля.
        /// </summary>
        public override PlayerShip CreateShip()
        {
            return new ArmorShip();
        }
    }
}
