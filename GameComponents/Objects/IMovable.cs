using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents
{
    /// <summary>
    /// Скорость объекта.
    /// </summary>
    public interface IMovable
    {
        /// <summary>
        /// Перемещение объекта по вертикали.
        /// </summary>
        /// <param name="marker"> Флаг перемещения вверх или вниз по вертикали. </param>
        void MoveVertical(bool marker);
    }
}
