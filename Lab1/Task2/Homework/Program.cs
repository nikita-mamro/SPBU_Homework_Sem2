using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
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
}
