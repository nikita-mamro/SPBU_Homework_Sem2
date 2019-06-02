using System;
using System.Collections.Generic;

namespace Homework
{
    class Description
    {
        public static void PrintInfo()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Данная программа реализует функции Map(), Filter(), Fold()");
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Map");
            Console.ResetColor();
            Console.WriteLine("Map принимает список и функцию, преобразующую элемент списка.");
            Console.WriteLine("Возвращает список, полученный применением переданной функции к каждому элементу переданного списка.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Filter");
            Console.ResetColor();
            Console.WriteLine("Filter принимает список и функцию, возвращающую булевое значение по элементу списка.");
            Console.WriteLine("Возвращает список, составленный из тех элементов переданного списка, для которых переданная функция вернула true.");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Fold");
            Console.ResetColor();
            Console.WriteLine("Fold принимает список, начальное значение и функцию.");
            Console.WriteLine("Функция берёт текущее накопленное значение, текущий элемент списка, возвращает следующее накопленное значение.");
            Console.WriteLine("Возвращается накопленное значение, получившееся после всего прохода списка.");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void PrintExamples()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Примеры");
            Console.ResetColor();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Map");
            Console.ResetColor();

            Console.WriteLine("Результат исполнения Map(new List<int>() { 100, 101, 102 }, x => (char)x):");
            var listMap = Functions.Map(new List<int>() { 100, 101, 102 }, x => (char)x);
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var element in listMap)
            {
                Console.Write($"{element} ");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Filter");
            Console.ResetColor();

            Console.WriteLine("Результат исполнения Filter(new List<int>() { 1, 2, 3, 4, 5 }, x => x < 4):");
            var listFilter = Functions.Filter(new List<int>() { 1, 2, 3, 4, 5 }, x => x < 4);
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var element in listFilter)
            {
                Console.Write($"{element} ");
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Fold");
            Console.ResetColor();

            Console.WriteLine("Результат исполнения Fold(new List<int>() { 1, 2, 3 }, 1, (acc, elem) => acc * elem):");
            var resFold = Functions.Fold(new List<int>() { 1, 2, 3 }, 1, (acc, elem) => acc * elem);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(resFold);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
