using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UList.UniqueList uList = new UList.UniqueList();
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

            }
            catch (Exceptions.ElementNotInListException e)
            {

            }
            catch (Exceptions.ElementAlreadyInListException e)
            {

            }
        }
    }
}
