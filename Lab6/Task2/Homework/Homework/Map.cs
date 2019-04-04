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

        public Map()
        {
            GenerateMap();
        }

        private void GenerateMap()
        {
            try
            {
                using (StreamReader sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), "map.txt")))
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
        {
            return Field[coordinates.Item1][coordinates.Item2] == '#';
        }

        public void PrintMap()
        {
            foreach (var line in Field)
            {
                foreach (var cell in line)
                {
                    Console.Write(cell);
                }
                Console.WriteLine();
            }
        }
    }
}
