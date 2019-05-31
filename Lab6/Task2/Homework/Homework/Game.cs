using System;
using System.Collections.Generic;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий игру-ходилку
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Карта, которую считаем из файла и по которой будет перемещаться персонаж
        /// </summary>
        private Map map;

        /// <summary>
        /// Сам персонаж
        /// </summary>
        private Player player;

        public Game(string mapPath)
        {
            Console.CursorVisible = false;
            map = new Map(mapPath);
            player = new Player(map.InitialPlayerCoordinates);
            map.PrintMap();
            player.PrintPlayer();
        }

        public void ProceedMovement(Action action)
        {
            try
            {
                map.RenderCell(player.Coordinates);

                action();

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

        /// <summary>
        /// Методы-обработчики нажатий на клавиши
        /// </summary>
        public void OnLeft(object sender, EventArgs args)
            => ProceedMovement(() => player.GoLeft(map));

        public void OnRight(object sender, EventArgs args)
            => ProceedMovement(() => player.GoRight(map));

        public void OnUp(object sender, EventArgs args)
            => ProceedMovement(() => player.GoUp(map));

        public void OnDown(object sender, EventArgs args)
            => ProceedMovement(() => player.GoDown(map));
    }
}
