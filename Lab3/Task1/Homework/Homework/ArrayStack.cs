using System;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий стек на массиве
    /// </summary>
    public class ArrayStack : IStack
    {
        /// <summary>
        /// Массив, хранящий элементы стека
        /// </summary>
        private int[] items;
        public int Count { get; private set; }
        /// <summary>
        /// Размер массива items при создании стека
        /// </summary>
        const int defaultSize = 2;

        public ArrayStack()
        {
            items = new int[defaultSize];
        }

        public void Push(int data)
        {
            if (Count == items.Length)
            {
                int[] newStorage = new int[items.Length * 2];

                for (var i = 0; i < items.Length; ++i)
                {
                    newStorage[i] = items[i];
                }

                this.items = newStorage;
            }

            items[Count] = data;

            ++Count;
        }

        public int Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Вызов Pop() для пустого стека!");
            }

            --Count;
            int popped = items[Count];

            return popped;
        }

        public int Peek()
            => IsEmpty ? throw new InvalidOperationException("Ошибка в вызове Peek()! В стеке нет элементов") : items[Count - 1];

        public bool IsEmpty
            => Count == 0;

        public void Clear()
        {
            items = new int[defaultSize];
            Count = 0;
        }
    }
}
