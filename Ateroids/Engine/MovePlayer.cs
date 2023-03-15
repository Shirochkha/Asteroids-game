using GameComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ateroids
{
    /// <summary>
    /// Перемещение игрока.
    /// </summary>
    public class MovePlayer
    {
        private bool ml1;
        private bool ml2;
        private bool mr1;
        private bool mr2;
        private Engine.GameObj[] arr;

        /// <summary>
        /// Инициализатор перемещения игрока.
        /// </summary>
        /// <param name="m1"> Перемещение первого игрока влево. </param>
        /// <param name="m2"> Перемещение второго игрока влево. </param>
        /// <param name="r1"> Перемещение первого игрока вправо. </param>
        /// <param name="r2"> Перемещение второго игрока вправо. </param>
        /// <param name="gameObjs"> Массив кораблей. </param>
        public MovePlayer(bool m1, bool m2, bool r1, bool r2, Engine.GameObj[] gameObjs)
        {
            ml1 = m1;
            ml2 = m2;
            mr1 = r1;
            mr2 = r2;
            arr = gameObjs;
        }

        /// <summary>
        /// Задание границ экрану.
        /// </summary>
        public void CheckKeysPlayer()
        {
            if (ml1 == true)
            {
                PlayerShip ship = (PlayerShip)arr[0].gameObject;
                if (ship.X > -6.3) ship.MoveLeft();
            }
            if (ml2 == true)
            {
                PlayerShip ship = (PlayerShip)arr[1].gameObject;
                if (ship.X > -6.3) ship.MoveLeft();
            }
            if (mr1 == true)
            {
                PlayerShip ship = (PlayerShip)arr[0].gameObject;
                if (ship.X < 6.3) ship.MoveRight();
            }
            if (mr2 == true)
            {
                PlayerShip ship = (PlayerShip)arr[1].gameObject;
                if (ship.X < 6.3) ship.MoveRight();
            }
        }
    }
}
