using System;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий игрока, как персонажа
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Координаты точки, в которых находится игрок
        /// </summary>
        public (int, int) Coordinates;

        /// <summary>
        /// Выводит на экран персонажа ('@') в его текущей позиции
        /// </summary>
        public void PrintPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Coordinates.Item1, Coordinates.Item2);
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Конструктор игрока как персонажа
        /// </summary>
        /// <param name="initialCoordinates">Координаты спауна</param>
        public Player((int, int) initialCoordinates)
        {
            Coordinates = initialCoordinates;
        }

        #region Методы, отвечающие за логику передвижение персонажа влево-вправо вверх-вниз по данной карте

        public void GoLeft(Map map)
        {
            if (Coordinates.Item1 == 0)
            {
                throw new Exceptions.GoingOutOfScreenException("Вы выходите за пределы экрана!");
            }

            Coordinates.Item1--;

            if (map.IsWall(Coordinates))
            {
                throw new Exceptions.HitWallException("Вы убились об стену! Как так? :(");
            }

            if (Coordinates.Equals(map.DestinationCoordinates)) // Not == because of appveyor
            {
                throw new Exceptions.GotBonesException("Косточки ваши! :3");
            }
        }

        public void GoRight(Map map)
        {
            Coordinates.Item1++;

            if (map.IsWall(Coordinates))
            {
                throw new Exceptions.HitWallException("Вы убились об стену! Как так? :(");
            }

            if (Coordinates.Equals(map.DestinationCoordinates)) // Not == because of appveyor
            {
                throw new Exceptions.GotBonesException("Косточки ваши! :3");
            }
        }

        public void GoUp(Map map)
        {
            if (Coordinates.Item2 == 0)
            {
                throw new Exceptions.GoingOutOfScreenException("Вы выходите за пределы экрана!");
            }

            Coordinates.Item2--;

            if (map.IsWall(Coordinates))
            {
                throw new Exceptions.HitWallException("Вы убились об стену! Как так? :(");
            }

            if (Coordinates.Equals(map.DestinationCoordinates)) // Not == because of appveyor
            {
                throw new Exceptions.GotBonesException("Косточки ваши! :3");
            }
        }

        public void GoDown(Map map)
        {
            Coordinates.Item2++;

            if (map.IsWall(Coordinates))
            {
                throw new Exceptions.HitWallException("Вы убились об стену! Как так? :(");
            }

            if (Coordinates.Equals(map.DestinationCoordinates)) // Not == because of appveyor
            {
                throw new Exceptions.GotBonesException("Косточки ваши! :3");
            }
        }

        #endregion
    }
}
