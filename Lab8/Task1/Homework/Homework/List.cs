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

        public T GetDataByPosition(int position)
        {
            if (position < 0 || position > Count - 1)
            {
                throw new IndexOutOfRangeException();
            }

            var tmp = head;

            for (var i = 0; i < position; ++i)
            {
                tmp = tmp.Next;
            }

            return tmp.Data;
        }

        public T this[int position]
        {
            get
            {
                
            }
            set
            {

            }
        }

        public int IndexOf(T item)
        {
            if (!Contains(item))
            {
                throw new ItemNotInListException();
            }
        }

        public void Insert(int position, T value)
        {

        }

        public void RemoveAt(int position)
        {

        }

        public void Add(T value)
        {

        }

        public void Clear()
        {

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
            throw new NotImplementedException();
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
