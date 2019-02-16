using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var theMatrix = MatrixUI.InitMatrix();
            MatrixUI.PrintMatrixSquare(theMatrix);
        }
    }
}
