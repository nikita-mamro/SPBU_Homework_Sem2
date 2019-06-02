using System;

namespace Lists
{
    /// <summary>
    /// Класс, реализующий односвязный список
    /// </summary>
    public class List : IList
    {
        /// <summary>
        /// Класс, реализующий элемент списка
        /// </summary>
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

        private Node head;

        public int Count { get; private set; }

        private bool IsPositionValidToAdd(int position)
            => position >= 0 && position <= Count;

        private bool IsPositionValidToRemove(int position)
            => position >= 0 && position < Count;

        private Node GetNodeByPosition(int position)
        {
            var current = head;

            for (var i = 0; i < position; ++i)
            {
                current = current.Next;
            }

            return current;
        }

        private Node GetNodeByData(int data)
        {
            var current = head;

            while (current != null && current.Data != data)
            {
                current = current.Next;
            }

            return current;
        }

        private Node GetNodeBeforeByData(int data)
        {
            var current = head;

            while (current.Next != null && current.Next.Data != data)
            {
                current = current.Next;
            }

            return current.Next == null ? null : current;
        }

        public virtual void AddToHead(int data)
        {
            head = new Node(data, head);
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
            => GetNodeByData(data) != null;

        private void RemoveFromHead()
        {
            head = head.Next;
            --Count;
        }

        public void Remove(int data)
        {
            if (!Exists(data))
            {
                throw new Exceptions.ElementNotInListException("Попытка удаления несуществующего элемента");
            }

            if (head.Data == data)
            {
                RemoveFromHead();
                return;
            }

            var nodeBefore = GetNodeBeforeByData(data);

            nodeBefore.Next = nodeBefore.Next.Next;

            --Count;
        }

        public bool IsEmpty
            => Count == 0;

        public int GetDataByPosition(int position)
        {
            if (!IsPositionValidToRemove(position))
            {
                throw new ArgumentException("Введён недопустимый номер позиции при попытке получения значения по позиции");
            }

            var node = GetNodeByPosition(position);
            return node.Data;
        }

        public virtual void SetDataByPosition(int data, int position)
        {
            if (!IsPositionValidToRemove(position))
            {
                throw new ArgumentException("Введён недопустимый номер позиции при попытке изменения значения по позиции");
            }

            var node = GetNodeByPosition(position);
            node.Data = data;
        }

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        public void Print()
        {
            if (IsEmpty)
            {
                Console.WriteLine("EMPTY");
                return;
            }

            var current = head;

            for (var i = 0; i < Count - 1; ++i)
            {
                Console.Write($"{current.Data}->");
                current = current.Next;
            }

            Console.WriteLine($"{current.Data}");
        }
    }
}
