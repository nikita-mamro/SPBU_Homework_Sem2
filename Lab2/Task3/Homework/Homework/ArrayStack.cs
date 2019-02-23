using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class ArrayStack : IStack
    {
        private int[] items;
        private int count;
        private bool isFull { get; }
        const int defaultSize = 2;

        public ArrayStack()
        {
            items = new int[defaultSize];
        }

        private bool IsFull
        {
            get { return count == items.Length; }
        }

        public void Push(int data)
        {
            if (IsFull)
            {
                int[] newStorage = new int[items.Length + 2];

                for (var i = 0; i < items.Length; ++i)
                {
                    newStorage[i] = items[i];
                }

                this.items = newStorage;
            }

            items[count++] = data;
        }

        public int Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Вызов Pop() для пустого стека!");
            }

            int popped = items[--count];
            items[count] = default(int);

            return popped;
        }

        public int Peek()
        {
            return items[count - 1];
        }

        public bool IsEmpty
        {
            get { return count == 0; }
        }
        
        public void Clear()
        {
            for (var i = 0; i < items.Length; ++i)
            {
                items[i] = default(int);
            }
        }

        public int Count
        {
            get { return count; }
        }
    }
}
