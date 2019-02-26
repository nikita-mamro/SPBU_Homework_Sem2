using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class ArrayStack : IStack
    {
        private int[] Items;
        public int Count { get; private set; }
        private bool IsFull { get; set; }
        const int DefaultSize = 2;

        public ArrayStack()
        {
            Items = new int[DefaultSize];
        }

        public void Push(int data)
        {
            if (IsFull)
            {
                int[] newStorage = new int[Items.Length + 2];

                for (var i = 0; i < Items.Length; ++i)
                {
                    newStorage[i] = Items[i];
                }

                this.Items = newStorage;
            }

            Items[Count++] = data;
        }

        public int Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Вызов Pop() для пустого стека!");
            }

            int popped = Items[--Count];
            Items[Count] = default(int);

            return popped;
        }

        public int Peek()
            => Items[Count - 1];

        public bool IsEmpty
            => Count == 0;
        
        public void Clear()
        {
            for (var i = 0; i < Items.Length; ++i)
            {
                Items[i] = default(int);
            }
        }
    }
}
