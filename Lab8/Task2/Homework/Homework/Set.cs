using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework
{
    public class Set<T> : ISet<T>
    {
        private class Node
        {
            public T data { get; set; }

            public Node left { get; set; }

            public Node right { get; set; }

            public Node()
            {

            }

            public Node(T data)
            {
                this.data = data;
            }

            public Node(Node left, Node right)
            {
                this.left = left;
                this.right = right;
            }

            public Node(T data, Node left, Node right)
            {
                this.data = data;
                this.left = left;
                this.right = right;
            }
        }

        private Node root;

        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; }

        public Set()
        {

        }

        public Set(T[] elements, bool isReadOnly)
        {
            foreach (var element in elements)
            {
                Add(element);
            }

            IsReadOnly = isReadOnly;
        }

        public bool Add(T item)
        {
            if (root == null)
            {
                root = new Node(item);
                return true;
            }

            var tmp = root;

            while (true)
            {
                if (Comparer<T>.Default.Compare(item, tmp.data) > 0)
                {
                    if (tmp.right == null)
                    {
                        tmp.right = new Node(item);
                        return true;
                    }

                    tmp = tmp.right;
                    continue;
                }

                if (Comparer<T>.Default.Compare(item, tmp.data) < 0)
                {
                    if (tmp.left == null)
                    {
                        tmp.left = new Node(item);
                        return true;
                    }

                    tmp = tmp.left;
                    continue;
                }

                return false;
            }
        }

        public void Clear()
        {
            root = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var tmp = root;

            while (tmp != null && Comparer<T>.Default.Compare(tmp.data, item) != 0)
            {
                if (Comparer<T>.Default.Compare(tmp.data, item) > 0)
                {
                    tmp = tmp.right;
                    continue;
                }

                tmp = tmp.left;
            }

            return tmp != null && Comparer<T>.Default.Compare(tmp.data, item) == 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            /// TODO
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Add(T item)
        {
            if (root == null)
            {
                root = new Node(item);
                return;
            }

            var tmp = root;

            while (true)
            {
                if (Comparer<T>.Default.Compare(item, tmp.data) >= 0)
                {
                    if (tmp.right == null)
                    {
                        tmp.right = new Node(item);
                        return;
                    }

                    tmp = tmp.right;
                    continue;
                }

                if (tmp.left == null)
                {
                    tmp.left = new Node(item);
                    return;
                }

                tmp = tmp.left;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
