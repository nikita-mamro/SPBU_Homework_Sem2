using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск тестов...");

            if (!Test.TestFactorial())
            {
                Console.WriteLine("Тесты не пройдены!");
                return;
            }

            Console.WriteLine("Тесты пройдены!");

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

    class Test
    {
        public static bool TestFactorial()
        {
            if (Task.Factorial(0) != 1)
            {
                return false;
            }
            if (Task.Factorial(9) != 362880)
            {
                return false;
            }
            if (Task.Factorial(5) != 120)
            {
                return false;
            }
            if (Task.Factorial(15) != 1307674368000)
            {
                return false;
            }
            if (Task.Factorial(12) != 479001600)
            {
                return false;
            }
            return true;
        }
    }
}
