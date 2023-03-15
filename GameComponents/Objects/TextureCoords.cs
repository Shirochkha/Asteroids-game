using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents
{
    /// <summary>
    /// Текстурных координаты.
    /// </summary>
    public abstract class TextureCoords
    {
        /// <summary>
        /// Получение текстурных координат.
        /// </summary>
        public abstract Vector2[] GetTextures();
    }
}
