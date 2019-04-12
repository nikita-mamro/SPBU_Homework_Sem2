using System;

namespace Task
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ShowExample();
            }
            catch (Exceptions.DequeueCallForEmptyPriorityQueueException e)
            {
                Console.WriteLine("Вызвано исключениe!");
                Console.WriteLine(e.Message);
            }
        }

        static void ShowExample()
        {
            Console.WriteLine("Создаем новую очередь с приоритетом pQ");
            var pQ = new PriorityQueue();
            Console.WriteLine("Вызов pQ.Enqueue(1, 10)");
            pQ.Enqueue(1, 10);
            Console.WriteLine("Вызов pQ.Enqueue(2, 1)");
            pQ.Enqueue(2, 1);
            Console.WriteLine("Вызов pQ.Enqueue(10, 11)");
            pQ.Enqueue(10, 11);
            Console.WriteLine("Вызов pQ.Enqueue(100, 11)");
            pQ.Enqueue(100, 11);
            Console.WriteLine("Вызов pQ.Enqueue(-8, -100)");
            pQ.Enqueue(-8, -100);
            Console.WriteLine("Вызов pQ.Enqueue(-10, -10)");
            pQ.Enqueue(-10, -10);
            Console.WriteLine("Вызов pQ.Enqueue(-11, -10)");
            pQ.Enqueue(-11, -10);
            Console.WriteLine();
            Console.WriteLine("Полученная очередь:");
            pQ.Print();
            Console.WriteLine("Вызов Pq.Dequeue()");
            Console.WriteLine($"pQ.Dequeue() вернул {pQ.Dequeue()}");
            Console.WriteLine("Полученная очередь:");
            pQ.Print();
        }
    }
}
