using System;
using System.Text;

namespace Homework
{
    class ArrayUI
    {
        private static int GetLength()
        {
            Console.Write("Введите длину массива: ");
            var inputString = Console.ReadLine();

            if (!int.TryParse(inputString, out int length) || length < 0)
            {
                Console.WriteLine("Длина массива должна быть неотрицательным числом.");
                return GetLength();
            }

            return length;
        }

        public static int[] InitArray()
        {
            var length = GetLength();

            var res = new int[length];

            Console.WriteLine("Введите поочерёдно элементы массива:");

            for (int i = 0; i < length; ++i)
            {
                var inputElement = Console.ReadLine();

                if (!int.TryParse(inputElement, out int element))
                {
                    Console.WriteLine("Элемент массива должен быть числом.");
                    --i;
                    continue;
                }

                res[i] = element;
            }

            return res;
        }

        public static void PrintArray(int[] theArray)
        {
            foreach (var element in theArray)
            {
                Console.Write($"{element} ");
            }
        }
    }
}
