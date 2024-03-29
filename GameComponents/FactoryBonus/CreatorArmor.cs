﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryBonus
{
    /// <summary>
    /// Создатель бонуса защиты.
    /// </summary>
    public class CreatorArmor : BonusCreator
    {
        /// <summary>
        /// Создание бонуса защиты.
        /// </summary>
        public override Bonus CreateBonus()
        {
            return new ArmorBonus();
        }
    }
}
