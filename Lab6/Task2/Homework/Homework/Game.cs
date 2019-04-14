using System;
using System.Collections.Generic;

namespace Homework
{
    public class Game
    {
        private Map map;

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
            try
            {
                map.RenderCell(player.Coordinates);

                player.GoLeft(map);

                player.PrintPlayer();
            }
            catch (Exception e)
                when (
                e is Exceptions.GotBonesException
                || e is Exceptions.HitWallException
                || e is Exceptions.GoingOutOfScreenException)
            {
                Console.Clear();
                throw;
            }
        }

        public void OnRight(object sender, EventArgs args)
        {
            try
            {
                map.RenderCell(player.Coordinates);

                player.GoRight(map);

                player.PrintPlayer();
            }
            catch (Exception e)
                when (
                e is Exceptions.GotBonesException
                || e is Exceptions.HitWallException
                || e is Exceptions.GoingOutOfScreenException)
            {
                Console.Clear();
                throw;
            }
        }

        public void OnUp(object sender, EventArgs args)
        {
            try
            {
                map.RenderCell(player.Coordinates);

                player.GoUp(map);

                player.PrintPlayer();
            }
            catch (Exception e)
                when (
                e is Exceptions.GotBonesException
                || e is Exceptions.HitWallException
                || e is Exceptions.GoingOutOfScreenException)
            {
                Console.Clear();
                throw;
            }
        }

        public void OnDown(object sender, EventArgs args)
        {
            try
            {
                map.RenderCell(player.Coordinates);

                player.GoDown(map);

                player.PrintPlayer();
            }
            catch (Exception e)
                when (
                e is Exceptions.GotBonesException
                || e is Exceptions.HitWallException
                || e is Exceptions.GoingOutOfScreenException)
            {
                Console.Clear();
                throw;
            }
        }

        #endregion
    }
}
