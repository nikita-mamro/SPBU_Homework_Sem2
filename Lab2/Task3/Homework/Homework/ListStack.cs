using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class ListStack : IStack
    {
        private class ListStackElement
        {
            public int data;
            public ListStackElement next;
            public ListStackElement(int data, ListStackElement next)
            {
                this.data = data;
                this.next = next;
            }
        }

        private int count;
        private ListStackElement head;

        public ListStack()
        {
            head = null;
            count = 0;
        }

        public void Push(int data)
        {
            head = new ListStackElement(data, head);
            ++count;
        }

        public int Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Вызов Pop() для пустого стека!");
            }

            int popped = head.data;
            head = head.next;
            --count;

            return popped;
        }

        public int Peek()
        {
            return head.data;
        }

        public bool IsEmpty
        {
            get { return count == 0; }
        }
        
        public void Clear()
        {
            while (count > 0)
            {
                Pop();
            }
        }

        public int Count
        {
            get { return count; }
        }
    }
}
