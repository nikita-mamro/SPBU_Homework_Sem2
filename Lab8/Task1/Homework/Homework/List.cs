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
            return index < 0 || index > Count - 1;
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

        public void Insert(int position, T value)
        {

        }

        public void RemoveAt(int position)
        {

        }

        public void Add(T value)
        {
            if (head == null)
            {
                head = new Node(value);
                ++Count;
                return;
            }

            var tmp = head;
            
            while (tmp.Next != null)
            {
                tmp = tmp.Next;
            }

            tmp.Next = new Node(value);
            ++Count;
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
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
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
