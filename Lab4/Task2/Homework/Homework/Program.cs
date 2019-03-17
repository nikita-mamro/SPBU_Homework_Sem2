using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Lists.IList uList = new Lists.UniqueList();
                uList.Add(2, 0);
                uList.Add(3, 1);
                uList.Add(4, 2);
                uList.Add(5, 3);
                uList.Add(10, 0);
                uList.Add(2, 1);
                uList.Print();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Вызвано исключение!");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (Exceptions.ElementNotInListException e)
            {
                Console.WriteLine("Вызвано исключение!");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch (Exceptions.ElementAlreadyInListException e)
            {
                Console.WriteLine("Вызвано исключение!");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
