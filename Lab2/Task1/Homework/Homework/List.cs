using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class List : IList
    {
        private class Node
        {
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node(int data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node Head;
        public int Count { get; private set; }

        private bool IsPositionValidToAdd(int position)
            => position >= 0 && position <= Count;

        private bool IsPositionValidToRemove(int position)
            => position >= 0 && position < Count;

        private Node GetNodeByPosition(int position)
        {
            var current = Head;

            for (var i = 0; i < position; ++i)
            {
                current = current.Next;
            }

            return current;
        }

        private void AddToHead(int data)
        {
            Head = new Node(data, Head);
            ++Count;
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

            var nodeBefore = GetNodeByPosition(position - 1);

            var newNode = new Node(data, nodeBefore.Next);

            nodeBefore.Next = newNode;

            ++Count;

            return true;
        }

        private void RemoveFromHead()
        {
            Head = Head.Next;
            --Count;
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

            var nodeBefore = GetNodeByPosition(position - 1);

            nodeBefore.Next = nodeBefore.Next.Next;

            --Count;

            return true;
        }

        public bool IsEmpty()
            => Count == 0;

        public int GetDataByPosition(int position)
        {
            if (!IsPositionValidToRemove(position))
            {
                Console.WriteLine("Введён недопустимый номер позиции!");
                return -1;
            }

            var node = GetNodeByPosition(position);
            return node.Data;
        }

        public bool SetDataByPosition(int data, int position)
        {
            if (!IsPositionValidToRemove(position))
            {
                Console.WriteLine("Введён недопустимый номер позиции!");
                return false;
            }

            var node = GetNodeByPosition(position);
            node.Data = data;

            return true;
        }

        public void Print()
        {
            if (IsEmpty())
            {
                Console.WriteLine("EMPTY");
                return;
            }

            var current = Head;

            for (var i = 0; i < Count - 1; ++i)
            {
                Console.Write($"{current.Data}->");
                current = current.Next;
            }

            Console.WriteLine($"{current.Data}");
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }
    }
}
