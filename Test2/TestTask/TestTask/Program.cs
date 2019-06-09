using System;
using System.Collections;
using System.Collections.Generic;

namespace TestTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Положим в множество строки: \"One two three\",\"One two\", \"One\" ");
            
            var strings = new List<string>();

            strings.Add("One two three");
            strings.Add("One two");
            strings.Add("One");

            var lists = new List<List<string>>();

            foreach (var str in strings)
            {
                lists.Add(StringSeparator.GetListOfWords(str));
            }

            var set = new SortedSet<string>(lists);

            var sortedStrings = set.GetSortedElements();

            Console.WriteLine("Вывод элементов SortedSet:");

            foreach (var element in sortedStrings)
            {
                foreach (var word in element)
                {
                    Console.Write($"{word} ");
                }

                Console.WriteLine();
            }
        }
    }
}
