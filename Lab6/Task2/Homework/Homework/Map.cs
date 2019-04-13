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
        public List<List<char>> Field { get; private set; }
        public (int, int) InitialPlayerCoordinates { get; private set; }
        public (int, int) DestinationCoordinates { get; private set; }

        public Map(string mapPath)
        {
            GenerateMap(mapPath);
        }

        private void GenerateMap(string mapPath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), mapPath)))
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
            catch (FileNotFoundException e)
            {
                throw e;
            }
            catch (IOException e)
            {
                throw e;
            }
        }

        public bool IsWall((int,  int) coordinates)
            => Field[coordinates.Item2][coordinates.Item1] == '#';

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

        public void RenderCell((int, int) coordinates)
        {
            Console.SetCursorPosition(coordinates.Item1, coordinates.Item2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(Field[coordinates.Item2][coordinates.Item1]);
        }
    }
}
