using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = new int[] { 1, 2, 3, 4, 5 };

            #region demo
            var anotherElements = new int[] { 5, 6, 7, 8, 9 };
            
            var set = new Set<int>(elements);
            //
            //var anotherSet = new Set<int>(anotherElements);
            //
            //foreach (var element in set)
            //{
            //    Console.Write($"{element} ");
            //}
            //
            //Console.WriteLine();
            //
            //set.IntersectWith(anotherSet);
            //
            //foreach (var element in set)
            //{
            //    Console.Write($"{element} ");
            //}
            #endregion

            var q = new Queue<int>(anotherElements);

            set.IntersectWith(q);

            foreach (var element in set)
            {
                Console.Write($"{element} ");
            }

            Console.WriteLine();
        }
    }
}
