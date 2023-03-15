using GameComponents;
using GameComponents.FactoryEnemy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AppTesting
{
    /// <summary>
    /// Тестирование классов фабричного метода с врагами.
    /// </summary>
    [TestClass()]
    public class FactoryEnemy_Tests
    {
        /// <summary>
        /// Создание астероида.
        /// </summary>
        [TestMethod()]
        public void Asteroid_Test()
        {
            // Arrang.
            var enemy = new Asteroid(0.1f, 0.2f);

            // Act.
            var creatorAsteroid = new CreatorAsteroid();
            var aster = creatorAsteroid.CreateEnemy();

            // Assert.
            Assert.AreEqual(enemy.GetType(), aster.GetType());
        }

        /// <summary>
        /// Создание вражеского корабля.
        /// </summary>
        [TestMethod()]
        public void EnemyShip_Test()
        {
            // Arrang.
            var enemy = new EnemyShip(0.1f);

            // Act.
            var creatorEnemy = new CreatorEnemyShip();
            var ship = creatorEnemy.CreateEnemy();

            // Assert.
            Assert.AreEqual(enemy.GetType(), ship.GetType());
        }
    }
}
