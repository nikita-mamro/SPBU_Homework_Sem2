using System;
using System.Collections.Generic;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            List<char> list = Functions.Map(new List<int>() { 100, 201, 230 }, x => (char)x);

            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}
