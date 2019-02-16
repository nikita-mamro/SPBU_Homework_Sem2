using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class MatrixUI
    {
        private static int GetSize()
        {
            Console.Write("Введите нечётное N - размер матрицы NxN: ");
            var inputString = Console.ReadLine();

            if (!int.TryParse(inputString, out int N) || N < 0 || N % 2 == 0)
            {
                Console.WriteLine("N должно быть нечётным неотрицательным числом.");
                return GetSize();
            }

            return N;
        }

        public static int[,] InitMatrix()
        {
            var N = GetSize();

            var res = new int[N,N];

            for (int i = 0; i < N; ++i)
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

                    res[i, j] = element;
                }
            }

            return res;
        }

        public static void PrintMatrixSquare(int[,] theMatrix)
        {
            for (int i = 0; i < theMatrix.GetLength(0); ++i)
            {
                for (int j = 0; j < theMatrix.GetLength(1); ++j)
                {
                    Console.Write(String.Format("{0,4}", theMatrix[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}
