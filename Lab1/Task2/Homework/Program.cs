using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Запуск тестов...");

            if (!Test.TestFibonacci())
            {
                Console.WriteLine("Тесты не пройдены!");
                return;
            }

            Console.WriteLine("Тесты пройдены!");

            int position = Task.GetPosition();

            Console.WriteLine($"Число Фибоначчи на позиции {position}: {Task.Fibonacci(position)}");
        }
    }
    class Task
    {
        public static int GetPosition()
        {
            Console.Write("Введите номер числа Фибоначчи: ");
            var inputString = Console.ReadLine();

            int position;
            if (!int.TryParse(inputString, out position))
            {
                Console.WriteLine("Введите число.");
                return GetPosition();
            }

            return position;
        }
        public static long Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n < 0)
            {
                return n % 2 == 0 ? -Fibonacci(-n) : Fibonacci(-n);
            }

            long firstElement = 1;
            long secondElement = 1;
            long nextElement = 1;

            for (int i = 2; i < n; ++i)
            {
                nextElement = firstElement + secondElement;
                firstElement = secondElement;
                secondElement = nextElement;
            }

            return nextElement;
        }
    }

    class Test
    {
        public static bool TestFibonacci()
        {
            if (Task.Fibonacci(0) != 0)
            {
                return false;
            }
            if (Task.Fibonacci(-10) != -55)
            {
                return false;
            }
            if (Task.Fibonacci(5) != 5)
            {
                return false;
            }
            if (Task.Fibonacci(20) != 6765)
            {
                return false;
            }
            if (Task.Fibonacci(29) != 514229)
            {
                return false;
            }
            return true;
        }
    }
}
