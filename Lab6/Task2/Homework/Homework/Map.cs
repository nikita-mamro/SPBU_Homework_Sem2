using System;
using System.Collections.Generic;
using System.IO;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий карту, по которой перемещается персонаж
    /// </summary>
    class Map
    {
        private List<List<char>> field;
        private (int, int) playerCoords;

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
                    field = new List<List<char>>();

                    string line;
                    var y = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        var x = 0;

                        field.Add(new List<char>());
                        foreach (var symbol in line)
                        {
                            if (symbol == '@')
                            {
                                playerCoords = (x, y);
                            }

                            ++x;
                            field[y].Add(symbol);
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

        public void PrintMap()
        {
            foreach (var line in field)
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
