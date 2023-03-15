using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryBonus
{
    /// <summary>
    /// Создатель бонуса.
    /// </summary>
    public abstract class BonusCreator
    {
        /// <summary>
        /// Создание бонуса.
        /// </summary>
        public abstract Bonus CreateBonus();
    }
}
