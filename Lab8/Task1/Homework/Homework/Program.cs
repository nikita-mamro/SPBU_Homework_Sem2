using System;

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
            list.Insert(1, 9);
            list.Insert(0, 0);
            list.Insert(5, 7);

            foreach (var e in list)
            {
                Console.Write(e + "->");
            }

            Console.WriteLine();

            list.Remove(1);
            list.RemoveAt(3);

            foreach (var e in list)
            {
                Console.Write(e + "->");
            }

            list.Clear();
        }
    }
}
