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
                Console.WriteLine("Данная программа читает из файла input.txt арифметическое выражение вида ( * ( + 1 1 ) 2 ) и считает его значение.");
                Console.WriteLine("На данный момент во входном файле записано: ( / ( * ( + 3 27 ) ( + -18 28 ) ) ( + ( * 13 3 ) -9 ) )");
                Console.WriteLine("\nВы можете заменить его собственное выражение с соблюдением правил записи\nвыражения в префиксном виде и разделения элементов пробелами.\n");
                Console.WriteLine("Допустимые операторы: + - * /");
                Console.WriteLine("Допустимые операнды: целые числа\n");

                string expression;

                using (StreamReader sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), "input.txt")))
                {
                    expression = sr.ReadToEnd();
                }

                ParseTree.IParseTree tree = new ParseTree.ParseTree(expression);

                Console.WriteLine($"Полученное из файла выражение: {tree.GetExpression()}");
                Console.WriteLine($"Подсчитанное значение выражения: {tree.Calculate()}\n");
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
                Console.WriteLine("Невозможно получить значение выражения");
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Невозможно получить значение выражения");
                Console.WriteLine(e.Message);
            }
        }
    }
}
