using GameComponents.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryPlayerShip
{
    /// <summary>
    /// Скоростной корабль.
    /// </summary>
    public class SpeedShip : PlayerShip
    {
        /// <summary>
        /// Инициализатор скоростного корабля.
        /// </summary>
        public SpeedShip()
        {
            Armor = 0;
            SpeedMotion = 0.07f;
        }
    }
}
