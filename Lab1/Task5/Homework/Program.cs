using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск тестов...");

            if (!Test.TestMatrixSort())
            {
                Console.WriteLine("Тесты не пройдены!");
                return;
            }

            Console.WriteLine("Тесты пройдены!");

            var theMatrix = MatrixUI.InitMatrix();

            Console.WriteLine("Ваша матрица:");
            MatrixUI.PrintMatrixSquare(theMatrix);

            Task.SortByColumns(theMatrix);

            Console.WriteLine("Матрица, отсортированная по столбцам:");
            MatrixUI.PrintMatrixSquare(theMatrix);
        }
    }
}
