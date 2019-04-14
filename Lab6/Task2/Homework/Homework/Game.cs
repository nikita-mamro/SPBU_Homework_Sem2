using System;
using System.Collections.Generic;

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

        public Game(string mapPath)
        {
            Console.CursorVisible = false;
            map = new Map(mapPath);
            player = new Player(map.InitialPlayerCoordinates);
            map.PrintMap();
            player.PrintPlayer();
        }

        #region Обработка нажатий клавиш

        public void OnLeft(object sender, EventArgs args)
        {
            if (player.Coordinates.Item1 == 0)
            {
                return;
            }

            map.RenderCell(player.Coordinates);

            player.Coordinates.Item1--;

            if (map.IsWall(player.Coordinates))
            {
                Console.Clear();
                throw new Exceptions.HitWallException("Вы убились об стену! Как так? :(");
            }
            
            if (player.Coordinates == map.DestinationCoordinates)
            {
                Console.Clear();
                throw new Exceptions.GotBonesException("Косточки ваши! :3");
            }

            player.PrintPlayer();
        }

        public void OnRight(object sender, EventArgs args)
        {
            map.RenderCell(player.Coordinates);

            player.Coordinates.Item1++;

            if (map.IsWall(player.Coordinates))
            {
                Console.Clear();
                throw new Exceptions.HitWallException("Вы убились об стену! Как так?");
            }

            if (player.Coordinates == map.DestinationCoordinates)
            {
                Console.Clear();
                throw new Exceptions.GotBonesException("Косточки ваши!");
            }

            player.PrintPlayer();
        }

        public void OnUp(object sender, EventArgs args)
        {
            if (player.Coordinates.Item2 == 0)
            {
                return;
            }

            map.RenderCell(player.Coordinates);

            player.Coordinates.Item2--;

            if (map.IsWall(player.Coordinates))
            {
                Console.Clear();
                throw new Exceptions.HitWallException("Вы убились об стену! Как так?");
            }

            if (player.Coordinates == map.DestinationCoordinates)
            {
                Console.Clear();
                throw new Exceptions.GotBonesException("Косточки ваши!");
            }

            player.PrintPlayer();
        }

        public void OnDown(object sender, EventArgs args)
        {
            map.RenderCell(player.Coordinates);

            player.Coordinates.Item2++;

            if (map.IsWall(player.Coordinates))
            {
                Console.Clear();
                throw new Exceptions.HitWallException("Вы убились об стену! Как так?");
            }

            if (player.Coordinates == map.DestinationCoordinates)
            {
                Console.Clear();
                throw new Exceptions.GotBonesException("Косточки ваши!");
            }

            player.PrintPlayer();
        }

        #endregion
    }
}
