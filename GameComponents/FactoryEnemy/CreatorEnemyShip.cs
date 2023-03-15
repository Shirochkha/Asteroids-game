using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryEnemy
{
    /// <summary>
    /// Создатель вражеского корабля.
    /// </summary>
    public class CreatorEnemyShip : EnemyCreator
    {
        /// <summary>
        /// Создание вражеского корабля.
        /// </summary>
        public override Enemy CreateEnemy()
        {
            return new EnemyShip(0.01f);
        }
    }
}
