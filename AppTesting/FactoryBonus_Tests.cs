using System;
using GameComponents;
using GameComponents.Decorator;
using GameComponents.FactoryBonus;
using GameComponents.FactoryPlayerShip;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppTesting
{
    /// <summary>
    /// Тестирование классов фабричного метода с бонусами.
    /// </summary>
    [TestClass()]
    public class FactoryBonus_Tests
    {
        /// <summary>
        /// Создание бонуса брони.
        /// </summary>
        [TestMethod()]
        public void ArmorBonus_Test()
        {
            // Arrang.
            var player = new ArmorShip();
            var playerDecorator = new PlayerDecorator(player);
            var expectedPlayer = new AdditionalArmor(player);

            // Act.
            var creatorArmor = new CreatorArmor();
            var armorBonus = creatorArmor.CreateBonus();
            var newPlayer = armorBonus.Activation(playerDecorator);

            // Assert.
            Assert.AreEqual(newPlayer.GetType(), expectedPlayer.GetType());
        }

        /// <summary>
        /// Создание бонуса скорости.
        /// </summary>
        [TestMethod()]
        public void SpeedBonus_Test()
        {
            // Arrang.
            var player = new SpeedShip();
            var playerDecorator = new PlayerDecorator(player);
            var expectedPlayer = new AdditionalSpeed(player);

            // Act.
            var creatorSpeed = new CreatorSpeed();
            var speedBonus = creatorSpeed.CreateBonus();
            var newPlayer = speedBonus.Activation(playerDecorator);

            // Assert.
            Assert.AreEqual(newPlayer.GetType(), expectedPlayer.GetType());
        }
    }
}
