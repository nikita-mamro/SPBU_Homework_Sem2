using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class ListStack : IStack
    {
        private class ListStackElement
        {
            public int Data { get; set; }
            public ListStackElement Next { get; set; }
            public ListStackElement(int data, ListStackElement next)
            {
                Data = data;
                Next = next;
            }
        }

        public int Count { get; private set; }
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
            => head.Data;

        public bool IsEmpty
            => Count == 0;
        
        public void Clear()
        {
            head = null;
            Count = 0;
        }
    }
}
