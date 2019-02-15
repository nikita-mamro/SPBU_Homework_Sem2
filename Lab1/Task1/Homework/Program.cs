using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = Task.GetNumber();

            Console.WriteLine($"{number}! = {Task.Factorial(number)}");
        }
    }

    class Task
    {
        public static int GetNumber()
        {
            Console.Write("Введите число, факториал которого будем искать: ");
            var inputString = Console.ReadLine();

            int number;
            if (!int.TryParse(inputString, out number))
            {
                Console.WriteLine("Введите число.");
                return GetNumber();
            }

            return number;
        }
        public static long Factorial(int n)
        {
            if (n <= 1)
            {
                return 1;
            }
            return n * Factorial(n - 1);
        }
    }
}
