using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameComponents
{
    /// <summary>
    /// Декоратор корабля игрока.
    /// </summary>
    public class PlayerDecorator : PlayerShip
    {
        /// <summary>
        /// Корабль игрока.
        /// </summary>
        protected PlayerShip player;

        /// <summary>
        /// Корабль игрока.
        /// </summary>
        public PlayerShip Player => player;

        /// <summary>
        /// Скорость корабля.
        /// </summary>
        public override float SpeedMotion => player.SpeedMotion;

        /// <summary>
        /// Защита корабля.
        /// </summary>
        public override int Armor
        {
            get { return player.Armor; }
            set { player.Armor = value; }
        }

        /// <summary>
        /// Инициализатор.
        /// </summary>
        /// <param name="player"> Декорируемый корабль. </param>
        public PlayerDecorator(PlayerShip player)
        {
            if (player == null)
            {
                throw new ArgumentNullException();
            }

            this.player = player;
        }

        /// <summary>
        /// Декорирование корабля.
        /// </summary>
        /// <param name="player"> Декорируемый корабль игрока. </param>
        public void SetPlayerShip(PlayerShip player)
        {
            this.player = player;
        }

    }
}
