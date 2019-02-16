using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск тестов...");

            if (!Test.TestQuickSort())
            {
                Console.WriteLine("Тесты не пройдены!");
                return;
            }

            Console.WriteLine("Тесты пройдены!");

            int[] myArray = ArrayUI.InitArray();

            Console.Write("Введённый массив: ");
            ArrayUI.PrintArray(myArray);
            Console.WriteLine();

            Task.QuickSort(myArray, 0, myArray.Length - 1);

            Console.Write("Отсортированный массив: ");
            ArrayUI.PrintArray(myArray);
            Console.WriteLine();
        }
    }
}
