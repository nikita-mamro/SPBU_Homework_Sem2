using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class Task
    {
        // it's public for tests
        public static List<int> GetMatrixSpiralTraversal(int[,] theMatrix, int direction)
        {
            var result = new List<int>();

            var x = theMatrix.GetLength(0) / 2;
            var y = x;

            result.Add(theMatrix[y, x]);

            int directionY = 1;
            int steps = 1;

            while (steps < theMatrix.GetLength(0))
            {
                for(int i = 0; i < steps; ++i)
                {
                    x = x + 1 * direction;
                    result.Add(theMatrix[y, x]);
                }

                for (int j = 0; j < steps; ++j)
                {
                    y = y + 1 * directionY;
                    result.Add(theMatrix[y, x]);
                }

                direction = -direction;
                directionY = -directionY;
                ++steps;
            }

            for (int i = 0; i < theMatrix.GetLength(0) - 1; ++i)
            {
                x = x + 1 * direction;
                result.Add(theMatrix[y, x]);
            }

            return result;
        }

        public static void PrintMatrixSpiralClockwise(int[,] theMatrix)
        {
            var spiralTraversal = GetMatrixSpiralTraversal(theMatrix, 1);
            spiralTraversal.ForEach(Console.WriteLine);
        }

        public static void PrintMatrixSpiralCounterClockwise(int[,] theMatrix)
        {
            var spiralTraversal = GetMatrixSpiralTraversal(theMatrix, -1);
            spiralTraversal.ForEach(Console.WriteLine);
        }
    }
}
