using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class MatrixUI
    {
        private static (int, int) GetSize()
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

            return (M, N);
        }

        public static List<List<int>> InitMatrix()
        {
            var (M, N) = GetSize();

            var result = new List<List<int>>();

            for (int i = 0; i < N; ++i)
            {
                result.Add(new List<int>());
            }

            for (int i = 0; i < M; ++i)
            {
                Console.WriteLine($"Введите поочерёдно элементы {i + 1}-й строки.");

                for (int j = 0; j < N; ++j)
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
