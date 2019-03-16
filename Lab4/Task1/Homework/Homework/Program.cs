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

                using (StreamReader sr = new StreamReader("TestFile.txt"))
                {
                    expression = sr.ReadToEnd();
                }


                Console.WriteLine($"Полученное из файла выражение: {expression}");
                Console.WriteLine($"Подсчитанное значение выражения: {ParseTree.IParseTree.Calculate(expression)}");
            }
            catch (IOException e)
            {
                Console.WriteLine("Не удаётся открыть файл:");
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message + "/n" + e.StackTrace);
            }
            finally
            {
                Console.WriteLine("Что-то пошло не так");
            }
        }
    }
}
