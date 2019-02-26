using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class ListStack : IStack
    {
        private class ListStackElement
        {
            public int Data;
            public ListStackElement Next;
            public ListStackElement(int data, ListStackElement next)
            {
                Data = data;
                Next = next;
            }
        }

        public int Count { get; private set; }
        private ListStackElement Head;

        public void Push(int data)
        {
            Head = new ListStackElement(data, Head);
            ++Count;
        }

        public int Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Вызов Pop() для пустого стека!");
            }

            int popped = Head.Data;
            Head = Head.Next;
            --Count;

            return popped;
        }

        public int Peek()
            => Head.Data;

        public bool IsEmpty
            => Count == 0;
        
        public void Clear()
        {
            Head = null;
            Count = 0;
        }
    }
}
