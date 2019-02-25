using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class List : IList
    {
        private class Node
        {
            public int data { get; set; }
            public Node next { get; set; }
            public Node(int data, Node next)
            {
                this.data = data;
                this.next = next;
            }
        }

        private Node head = null;
        private int size = 0;

        public List()
        {
            head = null;
            size = 0;
        }

        private bool IsPositionValidToAdd(int position)
        {
            return position >= 0 && position <= size;
        }

        private bool IsPositionValidToRemove(int position)
        {
            return position >= 0 && position < size;
        }

        private Node GetNodeByPosition(int position)
        {
            Node current = head;

            for (var i = 0; i < position; ++i)
            {
                current = current.next;
            }

            return current;
        }

        private void AddToHead(int data)
        {
            head = new Node(data, head);
            ++size;
        }

        public bool Add(int data, int position)
        {
            if (!IsPositionValidToAdd(position))
            {
                Console.WriteLine("Введите допустимый номер позиции!");
                return false;
            }

            if (position == 0)
            {
                AddToHead(data);
                return true;
            }

            Node nodeBefore = GetNodeByPosition(position - 1);

            Node newNode = new Node(data, nodeBefore.next);

            nodeBefore.next = newNode;

            ++size;

            return true;
        }

        private void RemoveFromHead()
        {
            head = head.next;
            --size;
        }

        public bool Remove(int position)
        {
            if (!IsPositionValidToRemove(position))
            {
                Console.WriteLine("Введён недопустимый номер позиции!");
                return false;
            }

            if (position == 0)
            {
                RemoveFromHead();
                return true;
            }

            Node nodeBefore = GetNodeByPosition(position - 1);

            nodeBefore.next = nodeBefore.next.next;

            --size;

            return true;
        }

        public int Size()
        {
            return size;
        }

        public bool isEmpty()
        {
            return size == 0;
        }

        public int GetDataByPosition(int position)
        {
            if (!IsPositionValidToRemove(position))
            {
                Console.WriteLine("Введён недопустимый номер позиции!");
                return -1;
            }

            Node node = GetNodeByPosition(position);
            return node.data;
        }

        public bool SetDataByPosition(int data, int position)
        {
            if (!IsPositionValidToRemove(position))
            {
                Console.WriteLine("Введён недопустимый номер позиции!");
                return false;
            }

            Node node = GetNodeByPosition(position);
            node.data = data;

            return true;
        }

        public void Print()
        {
            if (isEmpty())
            {
                Console.WriteLine("EMPTY");
                return;
            }

            Node current = head;

            for (var i = 0; i < size - 1; ++i)
            {
                Console.Write($"{current.data}->");
                current = current.next;
            }

            Console.WriteLine($"{current.data}");
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
