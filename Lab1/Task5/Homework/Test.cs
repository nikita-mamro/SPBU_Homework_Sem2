using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class Test
    {
        public static bool TestMatrixSort()
        {
            var testMatrix = new List<List<int>>();

            const int numberOfColumns = 10;

            for (int i = 0; i < numberOfColumns; ++i)
            {
                testMatrix.Add(new List<int>());
            }

            for (int i = 0; i < 13; ++i)
            {
                for (int j = 0; j < numberOfColumns; ++j)
                {
                    testMatrix[j].Add(-j);
                }
            }

            var testMatrixRandom = new List<List<int>>();

            var rand = new Random();

            int randomNumberOfColumns = rand.Next(1, 50);

            for (int i = 0; i < randomNumberOfColumns; ++i)
            {
                testMatrixRandom.Add(new List<int>());
            }

            for (int i = 0; i < rand.Next(1, 50); ++i)
            {
                for (int j = 0; j < randomNumberOfColumns; ++j)
                {
                    testMatrixRandom[j].Add(rand.Next(-999, 1000));
                }
            }

            Task.SortByColumns(testMatrix);
            Task.SortByColumns(testMatrixRandom);

            return (IsSorted(testMatrix) && IsSorted(testMatrixRandom));
        }

        private static bool IsSorted(List<List<int>> theMatrix)
        {
            for (int i = 0; i < theMatrix.Count - 1; ++i)
            {
                if (theMatrix[i][0] > theMatrix[i + 1][0])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
