using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class Game
    {
        private Map map;

        private class Player
        {
            public (int, int) Coordinates;

            public Player((int, int) initialCoordinates)
            {
                Coordinates = initialCoordinates;
            }

            public void PrintPlayer()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(Coordinates.Item1, Coordinates.Item2);
                Console.Write("@");
            }
        }

        private Player player;

        public Game()
        {
            Console.CursorVisible = false;
            map = new Map();
            player = new Player(map.InitialPlayerCoordinates);
            map.PrintMap();
            player.PrintPlayer();
        }

        #region Обработка нажатия клавиш

        public void OnLeft(object sender, EventArgs args)
        {
            if (player.Coordinates.Item1 == 0)
            {
                return;
            }

            player.Coordinates.Item1--;

            if (map.IsWall(player.Coordinates))
            {
                Console.WriteLine("AHAHAHAHAHAHAHA");
            }

            map.PrintMap();

            player.PrintPlayer();
        }

        public void OnRight(object sender, EventArgs args)
        {
            player.Coordinates.Item1++;

            player.PrintPlayer();
        }

        public void OnUp(object sender, EventArgs args)
        {
            if (player.Coordinates.Item2 == 0)
            {
                return;
            }

            map.PrintMap();

            player.Coordinates.Item2--;
            player.PrintPlayer();
        }

        public void OnDown(object sender, EventArgs args)
        {
            player.Coordinates.Item2++;

            map.PrintMap();

            player.PrintPlayer();
        }

        public void OnEscape(object sender, EventArgs args)
        {
            Console.Clear();
        }

        #endregion
    }
}
