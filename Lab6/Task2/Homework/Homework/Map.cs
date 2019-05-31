using System;
using System.Collections.Generic;
using System.IO;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий карту, по которой перемещается персонаж
    /// </summary>
    public class Map
    {
        /// <summary>
        /// Поле (стенки и свободное пространство)
        /// </summary>
        public List<List<char>> Field { get; private set; }

        /// <summary>
        /// Координаты, в которых находится игрок при спауне
        /// </summary>
        public (int, int) InitialPlayerCoordinates { get; private set; }

        /// <summary>
        /// Координаты косточек, до которых нужно дойти игроку
        /// </summary>
        public (int, int) DestinationCoordinates { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mapPath">Имя файла с картой</param>
        public Map(string mapPath)
            => GenerateMap(mapPath);

        /// <summary>
        /// Генерирует карту из файла
        /// </summary>
        /// <param name="mapPath">Имя файла с картой</param>
        private void GenerateMap(string mapPath)
        {
            using (var sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), mapPath)))
            {
                Field = new List<List<char>>();

                string line;
                var y = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    var x = 0;

                    Field.Add(new List<char>());
                    foreach (var symbol in line)
                    {
                        if (symbol == '@')
                        {
                            InitialPlayerCoordinates = (x, y);
                            ++x;
                            Field[y].Add(' ');
                            continue;
                        }

                        if (symbol == 'X')
                        {
                            DestinationCoordinates = (x, y);
                        }

                        ++x;
                        Field[y].Add(symbol);
                    }

                    ++y;
                }
            }
        }

        /// <summary>
        /// Проверяет, есть ли стена на данных координатах
        /// </summary>
        /// <param name="coordinates">Проверяемые координаты</param>
        /// <returns>True, если стена есть, иначе false</returns>
        public bool IsWall((int,  int) coordinates)
            => Field[coordinates.Item2][coordinates.Item1] == '#';

        /// <summary>
        /// Выводит на экран карту (стены, свободное пространство и косточки)
        /// </summary>
        public void PrintMap()
        {
            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var line in Field)
            {
                foreach (var cell in line)
                {
                    Console.Write(cell);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Приводит данную точку в первоначальный вид (как была считана из файла)
        /// </summary>
        /// <param name="coordinates">Координаты нужной точки</param>
        public void RenderCell((int, int) coordinates)
        {
            Console.SetCursorPosition(coordinates.Item1, coordinates.Item2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Field[coordinates.Item2][coordinates.Item1]);
        }
    }
}
