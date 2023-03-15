using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Objects
{
    /// <summary>
    /// Первый тип лазера.
    /// </summary>
    public class FirstLazer : Lazer
    {
        /// <summary>
        /// Инициализатор первого типа лазера.
        /// </summary>
        /// <param name="speedMotion"> Скорость перемещения первого типа лазера. </param>
        public FirstLazer(float speedMotion) : base(speedMotion)
        {
        }
 
    }
}