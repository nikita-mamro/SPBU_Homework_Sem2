using System;
using System.Text;

namespace Homework
{
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
