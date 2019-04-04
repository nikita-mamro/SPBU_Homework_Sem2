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
                Console.SetCursorPosition(Coordinates.Item1, Coordinates.Item2);
                Console.Write("@");
            }
        }

        private Player player;

        public Game()
        {
            Console.CursorVisible = false;
            map = new Map();
            player = new Player(map.InitialPlayerCoords);
            map.PrintMap();
            Console.ForegroundColor = ConsoleColor.Yellow;
            player.PrintPlayer();
        }

        public void OnLeft(object sender, EventArgs args)
        {
            if (player.Coordinates.Item1 == 0)
            {
                return;
            }

            player.Coordinates.Item1--;
            player.PrintPlayer();
        }

        public void OnRight(object sender, EventArgs args)
        {
            player.Coordinates.Item1++;
            player.PrintPlayer();
        }

        public void OnUp(object sender, EventArgs args)
        {
            player.Coordinates.Item2--;
            player.PrintPlayer();
        }

        public void OnDown(object sender, EventArgs args)
        {
            player.Coordinates.Item2++;
            player.PrintPlayer();
        }
    }
}
