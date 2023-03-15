using GameComponents.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryPlayerShip
{
    /// <summary>
    /// Базовый корабль корабль.
    /// </summary>
    public class BasicShip : PlayerShip
    {
        /// <summary>
        /// Инициализатор базового корабля.
        /// </summary>
        public BasicShip()
        {
            Armor = 10;
            SpeedMotion = 0.05f;
        }
    }
}
