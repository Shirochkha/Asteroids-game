using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryEnemy
{
    /// <summary>
    /// Создатель врага.
    /// </summary>
    public abstract class EnemyCreator
    {
        /// <summary>
        /// Создание врага.
        /// </summary>
        public abstract Enemy CreateEnemy();
    }
}
