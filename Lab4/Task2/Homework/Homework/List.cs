using System;

namespace List
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

        private Node GetNodeByData(int data)
        {
            var current = Head;

            while (current != null && current.Data != data)
            {
                current = current.Next;
            }

            return current;
        }

        private Node GetNodeBeforeByData(int data)
        {
            var current = Head;

            while (current.Next != null && current.Next.Data != data)
            {
                current = current.Next;
            }

            return current.Next == null ? null : current;
        }

        public virtual void AddToHead(int data)
        {
            Head = new Node(data, Head);
            ++Count;
        }

        public virtual void Add(int data, int position)
        {
            if (!IsPositionValidToAdd(position))
            {
                throw new ArgumentException("Попытка добавления на недопустимую позицию");
            }

            if (position == 0)
            {
                AddToHead(data);
                return;
            }

            var nodeBefore = GetNodeByPosition(position - 1);

            var newNode = new Node(data, nodeBefore.Next);

            nodeBefore.Next = newNode;

            ++Count;
        }

        public bool Exists(int data)
        {
            return GetNodeByData(data) != null;
        }

        private void RemoveFromHead()
        {
            Head = Head.Next;
            --Count;
        }

        public void Remove(int data)
        {
            if (!Exists(data))
            {
                throw new Exceptions.ElementNotInListException();
            }

            var nodeBefore = GetNodeBeforeByData(data);

            nodeBefore.Next = nodeBefore.Next.Next;

            --Count;
        }

        public bool IsEmpty()
            => Count == 0;

        public int GetDataByPosition(int position)
        {
            if (!IsPositionValidToRemove(position))
            {
                throw new ArgumentException("Введён недопустимый номер позиции");
            }

            var node = GetNodeByPosition(position);
            return node.Data;
        }

        public void SetDataByPosition(int data, int position)
        {
            if (!IsPositionValidToRemove(position))
            {
                throw new ArgumentException("Введён недопустимый номер позиции");
            }

            var node = GetNodeByPosition(position);
            node.Data = data;
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
    }
}
