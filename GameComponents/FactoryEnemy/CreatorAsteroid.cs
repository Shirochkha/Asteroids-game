using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.FactoryEnemy
{
    /// <summary>
    /// Создатель астероида.
    /// </summary>
    public class CreatorAsteroid : EnemyCreator
    {
        /// <summary>
        /// Создание астероида.
        /// </summary>
        public override Enemy CreateEnemy()
        {
            Random random = new Random();
            float k = (float)(0.5 + Math.Round(random.NextDouble(), 3));
            return new Asteroid(0.01f / k, k);
        }
    }
}
