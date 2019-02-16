using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class Test
    {
        public static bool TestTraversal()
        {
            var listClockwiseFor3x3 = new List<int>();
            var listCounterClockwiseFor3x3 = new List<int>();

            var matrix3x3 = new int[3,3];

            int number = 1;

            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    matrix3x3[i, j] = number;
                    ++number;
                }
            }

            listClockwiseFor3x3.Add(5);
            listClockwiseFor3x3.Add(6);
            listClockwiseFor3x3.Add(9);
            listClockwiseFor3x3.Add(8);
            listClockwiseFor3x3.Add(7);
            listClockwiseFor3x3.Add(4);
            listClockwiseFor3x3.Add(1);
            listClockwiseFor3x3.Add(2);
            listClockwiseFor3x3.Add(3);

            listCounterClockwiseFor3x3.Add(5);
            listCounterClockwiseFor3x3.Add(4);
            listCounterClockwiseFor3x3.Add(7);
            listCounterClockwiseFor3x3.Add(8);
            listCounterClockwiseFor3x3.Add(9);
            listCounterClockwiseFor3x3.Add(6);
            listCounterClockwiseFor3x3.Add(3);
            listCounterClockwiseFor3x3.Add(2);
            listCounterClockwiseFor3x3.Add(1);

            var resClockWise3x3 = Task.GetMatrixSpiralTraversal(matrix3x3, 1);
            var resCounterClockWise3x3 = Task.GetMatrixSpiralTraversal(matrix3x3, -1);

            if (listClockwiseFor3x3.Count != resClockWise3x3.Count || listCounterClockwiseFor3x3.Count != resCounterClockWise3x3.Count)
            {
                return false;
            }

            for (int i = 0; i < listClockwiseFor3x3.Count; ++i)
            {
                if (listClockwiseFor3x3[i] != resClockWise3x3[i])
                {
                    return false;
                }
            }

            for (int i = 0; i < listCounterClockwiseFor3x3.Count; ++i)
            {
                if (listCounterClockwiseFor3x3[i] != resCounterClockWise3x3[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
