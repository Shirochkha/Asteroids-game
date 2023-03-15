using GameComponents.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryPlayerShip
{
    /// <summary>
    /// Защитный корабль.
    /// </summary>
    public class ArmorShip : PlayerShip
    {
        /// <summary>
        /// Инициализатор защитного корабля.
        /// </summary>
        public ArmorShip()
        {
            Armor = 20;
            SpeedMotion = 0.04f;
        }
    }
}
