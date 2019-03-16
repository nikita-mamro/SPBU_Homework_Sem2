using System;
using System.IO;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string expression;

                Console.WriteLine(Environment.CurrentDirectory);

                using (StreamReader sr = new StreamReader("input.txt"))
                {
                    expression = sr.ReadToEnd();
                }

                ParseTree.IParseTree tree = new ParseTree.ParseTree();

                Console.WriteLine($"Полученное из файла выражение: {expression}");
                Console.WriteLine($"Подсчитанное значение выражения: {tree.Calculate(expression)}");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("Файл не найден:");
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine("Не удаётся открыть файл:");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
        }
    }
}
