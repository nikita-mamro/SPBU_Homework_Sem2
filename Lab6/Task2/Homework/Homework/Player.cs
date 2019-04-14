using System;

namespace Homework
{
    public class Player
    {
        public (int, int) Coordinates;

        public void PrintPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Coordinates.Item1, Coordinates.Item2);
            Console.Write("@");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public Player((int, int) initialCoordinates)
        {
            Coordinates = initialCoordinates;
        }

        public void GoLeft(Map map)
        {
            if (this.Coordinates.Item1 == 0)
            {
                throw new Exceptions.GoingOutOfScreenException("Вы выходите за пределы экрана!");
            }

            this.Coordinates.Item1--;

            if (map.IsWall(this.Coordinates))
            {
                throw new Exceptions.HitWallException("Вы убились об стену! Как так? :(");
            }

            if (this.Coordinates == map.DestinationCoordinates)
            {
                throw new Exceptions.GotBonesException("Косточки ваши! :3");
            }
        }

        public void GoRight(Map map)
        {
            this.Coordinates.Item1++;

            if (map.IsWall(this.Coordinates))
            {
                throw new Exceptions.HitWallException("Вы убились об стену! Как так? :(");
            }

            if (this.Coordinates == map.DestinationCoordinates)
            {
                throw new Exceptions.GotBonesException("Косточки ваши! :3");
            }
        }

        public void GoUp(Map map)
        {
            if (this.Coordinates.Item2 == 0)
            {
                throw new Exceptions.GoingOutOfScreenException("Вы выходите за пределы экрана!");
            }

            this.Coordinates.Item2--;

            if (map.IsWall(this.Coordinates))
            {
                throw new Exceptions.HitWallException("Вы убились об стену! Как так? :(");
            }

            if (this.Coordinates == map.DestinationCoordinates)
            {
                throw new Exceptions.GotBonesException("Косточки ваши! :3");
            }
        }

        public void GoDown(Map map)
        {
            this.Coordinates.Item2++;

            if (map.IsWall(this.Coordinates))
            {
                throw new Exceptions.HitWallException("Вы убились об стену! Как так? :(");
            }

            if (this.Coordinates == map.DestinationCoordinates)
            {
                throw new Exceptions.GotBonesException("Косточки ваши! :3");
            }
        }
    }
}
