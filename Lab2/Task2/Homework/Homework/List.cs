using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class List : IList
    {
        private class Node
        {
            public string data { get; set; }
            public int count { get; set; }
            public Node next { get; set; }
            public Node(ref string data, Node next, int count)
            {
                this.data = data;
                this.next = next;
                this.count = count;
            }
        }

        private Node head;
        private int size;

        public List()
        {
            head = null;
            size = 0;
        }

        

        public int Size
        {
            get { return size; }
        }

        public bool isEmpty
        {
            get { return size == 0; }
        }

        public void Clear()
        {
            for (var i = 0; i < size; ++i)
            {
                RemoveFromHead();
            }
        }
    }
}
