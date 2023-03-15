using GameComponents.FactoryPlayerShip;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AppTesting
{
    /// <summary>
    /// Тестирование классов фабричного метода с игровыми кораблями.
    /// </summary>
    [TestClass()]
    public class FactoryPlayerShip_Tests
    {
        /// <summary>
        /// Создание скоростного корабля.
        /// </summary>
        [TestMethod()]
        public void SpeedShip_Test()
        {
            // Arrang.
            var player = new SpeedShip();

            // Act.
            var creatorPlayer = new ChooseSpeedShip();
            var ship = creatorPlayer.CreateShip();

            // Assert.
            Assert.AreEqual(player.GetType(), ship.GetType());
        }

        /// <summary>
        /// Создание защитного корабля.
        /// </summary>
        [TestMethod()]
        public void ArmorShip_Test()
        {
            // Arrang.
            var player = new ArmorShip();

            // Act.
            var creatorPlayer = new ChooseArmorShip();
            var ship = creatorPlayer.CreateShip();

            // Assert.
            Assert.AreEqual(player.GetType(), ship.GetType());
        }

        /// <summary>
        /// Создание базового корабля.
        /// </summary>
        [TestMethod()]
        public void BasicShip_Test()
        {
            // Arrang.
            var player = new BasicShip();

            // Act.
            var creatorPlayer = new ChooseBasicShip();
            var ship = creatorPlayer.CreateShip();

            // Assert.
            Assert.AreEqual(player.GetType(), ship.GetType());
        }
    }
}
