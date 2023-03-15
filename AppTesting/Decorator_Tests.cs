using GameComponents;
using GameComponents.Decorator;
using GameComponents.FactoryPlayerShip;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace AppTesting
{
    /// <summary>
    /// Тестирование классов декоратора.
    /// </summary>
    [TestClass()]
    public class Decorator_Tests
    {
        /// <summary>
        /// Тестирование класса декоратора с изменением брони корабля.
        /// </summary>
        [TestMethod()]
        public void AdditionalArmor_Test()
        {
            // Arrang.
            var player = new ArmorShip();

            // Act.
            var decoratedPlayer = new AdditionalArmor(player);
            var difference = decoratedPlayer.BoostArmor;

            // Assert.
            Assert.AreEqual(decoratedPlayer.Armor, player.Armor + difference);
        }

        /// <summary>
        /// Тестирование класса декоратора с изменением скорости корабля.
        /// </summary>
        [TestMethod()]
        public void AdditionalSpeed_Test()
        {
            // Arrang.
            var player = new SpeedShip();

            // Act.
            var decoratedPlayer = new AdditionalSpeed(player);
            var difference = decoratedPlayer.BoostSpeed;

            // Assert.
            Assert.AreEqual(decoratedPlayer.SpeedMotion, player.SpeedMotion + difference);
        }
    }
}
