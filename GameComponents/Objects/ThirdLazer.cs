using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Objects
{
    /// <summary>
    /// Третий тип лазера.
    /// </summary>
    public class ThirdLazer : Lazer
    {
        /// <summary>
        /// Инициализатор третьего типа лазера.
        /// </summary>
        /// <param name="speedMotion"> Скорость перемещения третьего типа лазера. </param>
        public ThirdLazer(float speedMotion) : base(speedMotion)
        {
        }
    }
}
