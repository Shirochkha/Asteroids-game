using GameComponents;
using GameComponents.FactoryBonus;
using GameComponents.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenTK;
using System;

namespace AppTesting
{
    /// <summary>
    /// Тестирование классов объектов.
    /// </summary>
    [TestClass]
    public class Objects_Tests
    {
        /// <summary>
        /// Генерация бонуса скорости.
        /// </summary>
        [TestMethod]
        public void BonusGeneratorSpeed_Test()
        {
            // Arrang.
            var bonus = new SpeedBonus();
            var bon = new BonusGenerator();
            bon.RandomBonus = 0; 

            // Act.
            var creatorBonus = bon.GenerateBonus();

            // Assert.
            Assert.AreEqual(creatorBonus.GetType(), bonus.GetType());
        }

        /// <summary>
        /// Вершины коллайдера фона.
        /// </summary>
        [TestMethod]
        public void BackgroundVertices_Test()
        {
            // Arrang.
            var back = new Background();
            Vector4[] vec =
            {
                new Vector4(back.X-back.W, back.Y+back.H, -1.0f, 1.0f), //0
                new Vector4(back.X+back.W, back.Y+back.H, -1.0f, 1.0f), //1
                new Vector4(back.X+back.W, back.Y-back.H, -1.0f, 1.0f), //2
                new Vector4(back.X-back.W, back.Y-back.H, -1.0f, 1.0f) //3
            };
            Vector4[] vert =
                {
                    vec[0],vec[1],vec[3],
                    vec[1],vec[2],vec[3]
                };

            // Act.
            var verte = back.GetVertices();

            // Assert.
            Assert.AreEqual(verte.GetType(), vert.GetType());
        }

        /// <summary>
        /// Текстурные координаты фона.
        /// </summary>
        [TestMethod]
        public void BackgroundCoords_Test()
        {
            // Arrang.
            var back = new Background();
            Vector2[] texCoords =
            {
                new Vector2(0, 0), new Vector2(256, 0), new Vector2(0, 256),
                new Vector2(256, 0), new Vector2(256, 256), new Vector2(0, 256)
            };

            // Act.
            var coord = back.GetTextures();

            // Assert.
            Assert.AreEqual(coord.GetType(), texCoords.GetType());
        }

        /// <summary>
        /// Текстурные координаты лазера.
        /// </summary>
        [TestMethod]
        public void LazerCoords_Test()
        {
            // Arrang.
            var laz = new FirstLazer(0.1f);
            Vector2[] texCoords =
            {
                new Vector2(0, 0), new Vector2(37, 0), new Vector2(0, 172),
                new Vector2(37, 0), new Vector2(37, 172), new Vector2(0, 172)
            };

            // Act.
            var coord = laz.GetTextures();

            // Assert.
            Assert.AreEqual(coord.GetType(), texCoords.GetType());
        }

        /// <summary>
        /// Текстурные координаты лазеров.
        /// </summary>
        [TestMethod]
        public void LazersTexCoords_Test()
        {
            // Arrang.
            var laz1 = new FirstLazer(0.1f);
            var laz2 = new SecondLazer(0.1f);
            var laz3 = new ThirdLazer(0.1f);

            // Act.
            var coord1 = laz1.GetTextures();
            var coord2 = laz1.GetTextures();
            var coord3 = laz1.GetTextures();

            // Assert.
            Assert.AreEqual(coord1.GetType(), coord2.GetType());
            Assert.AreEqual(coord2.GetType(), coord3.GetType());
            Assert.AreEqual(coord1.GetType(), coord3.GetType());
        }
    }
}
