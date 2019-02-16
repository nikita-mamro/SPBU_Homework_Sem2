using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class Test
    {
        public static bool TestTraversal()
        {
            var listCWFor3x3 = new List<int>();
            var listCCWFor3x3 = new List<int>();

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

            listCWFor3x3.Add(5);
            listCWFor3x3.Add(6);
            listCWFor3x3.Add(9);
            listCWFor3x3.Add(8);
            listCWFor3x3.Add(7);
            listCWFor3x3.Add(4);
            listCWFor3x3.Add(1);
            listCWFor3x3.Add(2);
            listCWFor3x3.Add(3);

            listCCWFor3x3.Add(5);
            listCCWFor3x3.Add(4);
            listCCWFor3x3.Add(7);
            listCCWFor3x3.Add(8);
            listCCWFor3x3.Add(9);
            listCCWFor3x3.Add(6);
            listCCWFor3x3.Add(3);
            listCCWFor3x3.Add(2);
            listCCWFor3x3.Add(1);

            var resCW3x3 = Task.GetMatrixSpiralTraversal(matrix3x3, 1);
            var resCCW3x3 = Task.GetMatrixSpiralTraversal(matrix3x3, -1);

            if (listCWFor3x3.Count != resCW3x3.Count || listCCWFor3x3.Count != resCCW3x3.Count)
            {
                return false;
            }

            for (int i = 0; i < listCWFor3x3.Count; ++i)
            {
                if (listCWFor3x3[i] != listCWFor3x3[i])
                {
                    return false;
                }
            }

            for (int i = 0; i < listCCWFor3x3.Count; ++i)
            {
                if (listCCWFor3x3[i] != resCCW3x3[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
