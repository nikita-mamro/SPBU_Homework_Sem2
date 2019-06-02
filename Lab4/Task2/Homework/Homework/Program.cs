using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Демонстрация работы класса UniqueList:");
                Lists.IList uList = new Lists.UniqueList();
                Console.WriteLine("\nДобавляем 2 на 0-ую позицию");
                uList.Add(2, 0);
                Console.WriteLine("Список:");
                uList.Print();
                Console.WriteLine("\nДобавляем 3 на 1-ую позицию");
                uList.Add(3, 1);
                Console.WriteLine("Список:");
                uList.Print();
                Console.WriteLine("\nДобавляем 4 на 2-ую позицию");
                uList.Add(4, 2);
                Console.WriteLine("Список:");
                uList.Print();
                Console.WriteLine("\nДобавляем 5 на 3-ю позицию");
                uList.Add(5, 3);
                Console.WriteLine("Список:");
                uList.Print();
                Console.WriteLine("\nДобавляем 10 на 0-ую позицию");
                uList.Add(10, 0);
                Console.WriteLine("Список:");
                uList.Print();
                Console.WriteLine("\nДобавляем 2 (существующее значение) на 0-ую позицию");
                Console.WriteLine("\nДолжно вызываться исключение\n");
                uList.Add(2, 1);
                Console.WriteLine();
            }
            catch (Exception e)
                when (
                e is ArgumentException 
                || e is Exceptions.ElementNotInListException 
                || e is Exceptions.ElementAlreadyInListException)
            {
                Console.WriteLine("Вызвано исключение!");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
