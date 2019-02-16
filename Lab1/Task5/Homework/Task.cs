using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class Task
    {
        public static void SortByColumns(List<List<int>> theMatrix)
        {
            QuickSortMatrixByColumns(theMatrix, 0, theMatrix.Count - 1);
        }

        private static void QuickSortMatrixByColumns(List<List<int>> unsortedMatrix, int firstIndex, int lastIndex)
        {
            if (firstIndex >= lastIndex)
            {
                return;
            }

            int index = firstIndex;
            var element = unsortedMatrix[firstIndex];

            for (int i = firstIndex; i <= lastIndex; ++i)
            {
                if (unsortedMatrix[i][0] < element[0])
                {
                    swap(unsortedMatrix, i, index);
                    ++index;
                }
            }

            if (index == firstIndex)
            {
                ++index;
            }

            QuickSortMatrixByColumns(unsortedMatrix, firstIndex, index - 1);
            QuickSortMatrixByColumns(unsortedMatrix, index, lastIndex);
        }

        private static void swap(List<List<int>> theMatrix, int indexA, int indexB)
        {
            List<int> tmp = theMatrix[indexA];
            theMatrix[indexA] = theMatrix[indexB];
            theMatrix[indexB] = tmp;
        }
    }
}
