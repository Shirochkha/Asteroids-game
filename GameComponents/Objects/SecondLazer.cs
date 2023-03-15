using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Objects
{
    /// <summary>
    /// Второй тип лазера.
    /// </summary>
    public class SecondLazer : Lazer
    {
        /// <summary>
        /// Инициализатор второго типа лазера.
        /// </summary>
        /// <param name="speedMotion"> Скорость перемещения второго типа лазера. </param>
        public SecondLazer(float speedMotion) : base(speedMotion)
        {
        }
    }
}
