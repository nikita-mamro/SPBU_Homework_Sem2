
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
            var list = new List<int>();

            list.Add(1);
            list.Add(2);
            list.Add(3);

            foreach (var e in list)
            {
                Console.Write(e);
            }

            Console.WriteLine();

            list.Remove(1);

            foreach (var e in list)
            {
                Console.Write(e);
            }
        }
    }
}
