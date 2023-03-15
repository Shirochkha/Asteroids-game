using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryBonus
{
    /// <summary>
    /// Создатель бонуса скорости.
    /// </summary>
    public class CreatorSpeed : BonusCreator
    {
        /// <summary>
        /// Создание бонуса скорости.
        /// </summary>
        public override Bonus CreateBonus()
        {
            return new SpeedBonus();
        }
    }
}
