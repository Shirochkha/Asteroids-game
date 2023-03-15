using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents.Decorator
{
    /// <summary>
    /// Увеличение брони корабля.
    /// </summary>
    public class AdditionalArmor : PlayerDecorator
    {
        private static int boostArmor = 20;

        /// <summary>
        /// Добавление защиты корабля.
        /// </summary>
        public override int Armor
        {
            get { return player.Armor + boostArmor; }
            set { player.Armor = value - 20; }
        }

        /// <summary>
        /// Инициализатор бонуса защиты корабля.
        /// </summary>
        /// <param name="player"> Декорируемый корабль. </param>
        public AdditionalArmor(PlayerShip player) : base(player)
        {
        }

        /// <summary>
        /// Значение дополнительной брони, свойство необходимо для тестов.
        /// </summary>
        public int BoostArmor
        {
            get { return boostArmor; }
        }

    }
}
