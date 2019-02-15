using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
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

    class ArrayUI
    {
        private static int GetLength()
        {
            Console.Write("Введите длину массива: ");
            var inputString = Console.ReadLine();

            int length;
            if (!int.TryParse(inputString, out length) || length < 0)
            {
                Console.WriteLine("Длина массива должна быть неотрицательным числом.");
                return GetLength();
            }

            return length;
        }
        public static int[] InitArray()
        {
            int length = GetLength();

            int[] res = new int[length];

            Console.WriteLine("Введите поочерёдно элементы массива:");

            for (int i = 0; i < length; ++i)
            {
                var inputElement = Console.ReadLine();
                int element;

                if (!int.TryParse(inputElement, out element))
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
            for (int i = 0; i < theArray.Length; ++i)
            {
                Console.Write($"{theArray[i]} ");
            }
        }
    }

    class Task
    {
        public static void QuickSort(int[] unsortedArray, int firstIndex, int lastIndex)
        {
            if (firstIndex >= lastIndex)
            {
                return;
            }

            int index = firstIndex;
            int element = unsortedArray[firstIndex];
            
            for (int i = firstIndex; i <= lastIndex; ++i)
            {
                if (unsortedArray[i] < element)
                {
                    swap(unsortedArray, i, index);
                    ++index;
                }
            }

            if (index == firstIndex)
            {
                ++index;
            }

            QuickSort(unsortedArray, firstIndex, index - 1);
            QuickSort(unsortedArray, index, lastIndex);
        }

        private static void swap(int[] theArray, int indexA, int indexB)
        {
            theArray[indexA] = theArray[indexA] + theArray[indexB];
            theArray[indexB] = theArray[indexA] - theArray[indexB];
            theArray[indexA] = theArray[indexA] - theArray[indexB];
        }
    }
}
