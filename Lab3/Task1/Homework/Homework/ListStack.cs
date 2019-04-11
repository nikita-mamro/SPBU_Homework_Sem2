using System;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий стек на односвязном списке
    /// </summary>
    public class ListStack : IStack
    {
        /// <summary>
        /// Класс, реализующий элемент стека
        /// </summary>
        private class ListStackElement
        {
            /// <summary>
            /// Значение элемента стека
            /// </summary>
            public int Data { get; set; }
            /// <summary>
            /// Ссылка на следующий за текущим элемент
            /// </summary>
            public ListStackElement Next { get; set; }
            public ListStackElement(int data, ListStackElement next)
            {
                Data = data;
                Next = next;
            }
        }

        public int Count { get; private set; }
        /// <summary>
        /// Ссылка на элемент, лежащий на вершине стека
        /// </summary>
        private ListStackElement head;

        public void Push(int data)
        {
            head = new ListStackElement(data, head);
            ++Count;
        }

        public int Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Вызов Pop() для пустого стека!");
            }

            int popped = head.Data;
            head = head.Next;
            --Count;

            return popped;
        }

        public int Peek()
            => IsEmpty ? throw new InvalidOperationException("Ошибка в вызове Peek()! В стеке нет элементов") : head.Data;

        public bool IsEmpty
            => Count == 0;

        public void Clear()
        {
            head = null;
            Count = 0;
        }
    }
}
