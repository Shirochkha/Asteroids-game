using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryBonus
{
    /// <summary>
    /// Удаление бонуса скорости.
    /// </summary>
    public class RemoverSpeed : BonusCreator
    {
        /// <summary>
        /// Удаление бонуса скорости.
        /// </summary>
        public override Bonus CreateBonus()
        {
            return new RemoveBonus();
        }
    }
}
