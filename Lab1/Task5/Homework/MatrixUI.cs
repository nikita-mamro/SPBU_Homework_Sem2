using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class MatrixUI
    {
        private static Tuple<int, int> GetSize()
        {
            Console.Write("Введите M - количество строк: ");
            var inputStringM = Console.ReadLine();

            if (!int.TryParse(inputStringM, out int M) || M <= 0)
            {
                Console.WriteLine("M должно быть положительным числом.");
                return GetSize();
            }

            Console.Write("Введите N - количество столбцов: ");
            var inputStringN = Console.ReadLine();

            if (!int.TryParse(inputStringN, out int N) || N <= 0)
            {
                Console.WriteLine("N должно быть положительным числом.");
                return GetSize();
            }

            var res = new Tuple<int, int>(M, N);

            return res;
        }

        public static List<List<int>> InitMatrix()
        {
            var MxN = GetSize();

            var result = new List<List<int>>();

            for (int i = 0; i < MxN.Item2; ++i)
            {
                result.Add(new List<int>());
            }

            for (int i = 0; i < MxN.Item1; ++i)
            {
                Console.WriteLine($"Введите поочерёдно элементы {i + 1}-й строки.");

                for (int j = 0; j < MxN.Item2; ++j)
                {
                    var inputElement = Console.ReadLine();

                    if (!int.TryParse(inputElement, out int element))
                    {
                        Console.WriteLine("Элемент матрицы должен быть числом.");
                        --j;
                        continue;
                    }

                    result[j].Add(element);
                }
            }

            return result;
        }

        public static void PrintMatrixSquare(List<List<int>>  theMatrix)
        {
            for (int i = 0; i < theMatrix[0].Count; ++i)
            {
                for (int j = 0; j < theMatrix.Count; ++j)
                {
                    Console.Write(String.Format("{0,4}", theMatrix[j][i]));
                }

                Console.WriteLine();
            }
        }
    }
}
