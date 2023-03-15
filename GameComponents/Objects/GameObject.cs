using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace GameComponents
{
    /// <summary>
    /// Игровой объект.
    /// </summary>
    public abstract class GameObject : TextureCoords
    {
        /// <summary>
        /// Координата X игрового объекта.
        /// </summary>
        public float X { get; set; }

        /// <summary>
        /// Координата Y игрового объекта.
        /// </summary>
        public float Y { get; set; }

        /// <summary>
        /// Ширина текстуры игрового объекта.
        /// </summary>
        public float W { get; set; }

        /// <summary>
        /// Высота текстуры игрового объекта.
        /// </summary>
        public float H { get; set; }

        /// <summary>
        /// Получение вершин игрового объекта.
        /// </summary>
        /// <returns> Четырехэлементая структура вершин игрового объекта. </returns>
        public Vector4[] GetVertices()
        {
            Vector4[] cubeVertices =
            {
                new Vector4(X-W, Y+H, -1.0f, 1.0f), //0
                new Vector4(X+W, Y+H, -1.0f, 1.0f), //1
                new Vector4(X+W, Y-H, -1.0f, 1.0f), //2
                new Vector4(X-W, Y-H, -1.0f, 1.0f) //3
            };
            Vector4[] vertices =
                {
                    cubeVertices[0],cubeVertices[1],cubeVertices[3],
                    cubeVertices[1],cubeVertices[2],cubeVertices[3]
                };
            return vertices;
        }

    }
}
