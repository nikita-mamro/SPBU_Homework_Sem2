using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск тестов...");

            if (!Test.TestTraversal())
            {
                Console.WriteLine("Тесты не пройдены!");
                return;
            }

            Console.WriteLine("Тесты пройдены!");

            var theMatrix = MatrixUI.InitMatrix();

            Console.WriteLine("Полученная матрица:");
            MatrixUI.PrintMatrixSquare(theMatrix);

            Console.WriteLine("Обход по спирали по часовой:");
            Task.PrintMatrixSpiralClockwise(theMatrix);

            Console.WriteLine();

            Console.WriteLine("Обход по спирали против часовой:");
            Task.PrintMatrixSpiralCounterClockwise(theMatrix);
        }
    }
}
