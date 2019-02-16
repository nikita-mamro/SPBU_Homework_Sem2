using System;
using System.Text;

namespace Homework
{
    class Test
    {
        public static bool TestQuickSort()
        {
            int[] testArray = new int[10] { 1124, 412, 302, 254, 239, 200, 189, 140, 10, -12 };

            Task.QuickSort(testArray, 0, testArray.Length - 1);

            if (!TestAscOrder(testArray))
            {
                return false;
            }

            int[] testArrayRandom = new int[100];

            var rand = new Random();

            for (int i = 0; i < testArrayRandom.Length; ++i)
            {
                testArrayRandom[i] = rand.Next(-999, 1000);
            }

            Task.QuickSort(testArrayRandom, 0, testArrayRandom.Length - 1);

            return TestAscOrder(testArrayRandom);
        }

        private static bool TestAscOrder(int[] theArray)
        {
            for (int i = 0; i < theArray.Length - 1; ++i)
            {
                if (theArray[i] > theArray[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
