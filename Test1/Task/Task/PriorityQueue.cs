using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    /// <summary>
    /// Класс, реализующий очередь с приоритетами
    /// </summary>
    public class PriorityQueue
    {
        /// <summary>
        /// Класс, реализующий элемент очереди
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Целочисленное значение, хранящееся в ноде
            /// </summary>
            public int Data { get; private set; }

            /// <summary>
            /// Численный приоритет
            /// </summary>
            public int Priority { get; private set; }

            /// <summary>
            /// Следующий элемент очереди
            /// </summary>
            public Node Next { get; set; }

            public Node(int data, int priority)
            {
                Data = data;
                Priority = priority;
            }
        }

        /// <summary>
        /// Голова очереди
        /// </summary>
        private Node head;

        /// <summary>
        /// Добавление значения в очередь
        /// </summary>
        /// <param name="data">Значение</param>
        /// <param name="priority">Численный приоритет</param>
        public void Enqueue(int data, int priority)
        {
            Node node = new Node(data, priority);

            if (IsEmpty || priority >= head.Priority)
            {
                node.Next = head;
                head = node;
                return;
            }

            Node tmp = head;

            while (tmp.Next != null && tmp.Next.Priority >= priority)
            {
                tmp = tmp.Next;
            }

            node.Next = tmp.Next;
            tmp.Next = node;
        }

        /// <summary>
        /// Удаляет  из очереди значение с наивысшим приоритетом
        /// </summary>
        /// <returns>Удалённое значение</returns>
        public int Dequeue()
        {
            if (IsEmpty)
            {
                throw new Exceptions.DequeueCallForEmptyPriorityQueueException("Попытка вызова Dequeue() для пустой очереди!");
            }

            int returnValue = head.Data;

            head = head.Next;

            return returnValue;
        }

        /// <summary>
        /// Метод, который очищает очередь
        /// </summary>
        public void Clear()
            => head = null;

        /// <summary>
        /// Индикатор пустоты очереди
        /// </summary>
        public bool IsEmpty
            => head == null;

        /// <summary>
        /// Проверяет значение на наличие в очереди
        /// </summary>
        /// <param name="data">Проверяемое значение</param>
        /// <returns>True, если содержится, иначе false</returns>
        public bool Contatins(int data)
        {
            Node tmp = head;

            while (tmp != null && tmp.Data != data)
            {
                tmp = tmp.Next;
            }

            return tmp != null;
        }

        /// <summary>
        /// Метод для  вывода очереди в консоль
        /// </summary>
        public void Print()
        {
            if (IsEmpty)
            {
                Console.WriteLine("Очередь пуста!");
            }

            Node tmp = head;

            while (tmp.Next != null)
            {
                Console.Write($"( {tmp.Data} , {tmp.Priority})->");
                tmp = tmp.Next;
            }

            Console.WriteLine($"( {tmp.Data} , {tmp.Priority})");
        }
    }
}
