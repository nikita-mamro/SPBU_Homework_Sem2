using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class List<T> : IList<T>
    {
        private class Node
        {
            public T Data { get; set; }
            public Node Next { get; set; }
            public Node(T data)
            {
                Data = data;
                Next = null;
            }
            public Node(T data, Node next)
            {
                Data = data;
                Next = next;
            }
        }

        private Node head;

        public int Count { get; set; }

        public bool IsReadOnly { get; private set; }

        public List()
        {

        }

        public List(bool isReadOnly)
        {
            IsReadOnly = isReadOnly;
        }

        private bool IsIndexValid(int index)
        {
            return index >= 0 && index < Count;
        }

        private T GetDataByIndex(int index)
        {
            if (!IsIndexValid(index))
            {
                throw new IndexOutOfRangeException();
            }

            var tmp = head;

            for (var i = 0; i < index; ++i)
            {
                tmp = tmp.Next;
            }

            return tmp.Data;
        }

        private void SetDataByIndex(int index, T data)
        {
            if (!IsIndexValid(index))
            {
                throw new IndexOutOfRangeException();
            }

            var tmp = head;

            for (var i = 0; i < index; ++i)
            {
                tmp = tmp.Next;
            }

            tmp.Data = data;
        }

        public T this[int index]
        {
            get
                => GetDataByIndex(index);
            set
                => SetDataByIndex(index, value);
        }

        public int IndexOf(T item)
        {
            var tmp = head;
            var index = 0;

            while (tmp != null && Comparer<T>.Default.Compare(tmp.Data, item) != 0)
            {
                tmp = tmp.Next;
                ++index;
            }

            if (index > Count - 1)
            {
                throw new ItemNotInListException();
            }

            return index;
        }

        public void Insert(int index, T value)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                head = new Node(value, head);
                ++Count;
                return;
            }

            var tmp = head;

            for (var i = 0; i < index - 1; ++i)
            {
                tmp = tmp.Next;
            }

            tmp.Next = new Node(value, tmp.Next);
            ++Count;
        }

        public void RemoveAt(int index)
        {
            if (!IsIndexValid(index))
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                head = head.Next;
                --Count;
                return;
            }

            var tmp = head;

            for (var i = 0; i < index - 1; ++i)
            {
                tmp = tmp.Next;
            }

            tmp.Next = tmp.Next.Next;
            --Count;
            return;
        }

        public void Add(T value)
        {
            Insert(Count, value);
        }

        public void Clear()
        {
            head = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var tmp = head;

            while (tmp != null)
            {
                if (Comparer<T>.Default.Compare(tmp.Data, item) == 0)
                {
                    return true;
                }

                tmp = tmp.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new IndexOutOfRangeException();
            }

            if (array.Rank > 1)
            {
                throw new ArgumentException();
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Недостаточно места в массиве.");
            }

            for (var i = 0; i < Count; ++i)
            {
                array[i + arrayIndex] = this[i];
            }
        }

        public bool Remove(T item)
        {
            if (!Contains(item))
            {
                return false;
            }

            var index = IndexOf(item);

            if (index == 0)
            {
                head = head.Next;
                --Count;
                return true;
            }

            var tmp = head;

            for (var i = 0; i < index - 1; ++i)
            {
                tmp = tmp.Next;
            }

            tmp.Next = tmp.Next.Next;
            --Count;
            return true;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var tmp = head;

            while (tmp != null)
            {
                yield return tmp.Data;
                tmp = tmp.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
