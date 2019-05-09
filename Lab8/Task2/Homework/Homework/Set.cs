using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework
{
    public class Set<T> : ISet<T>
    {
        private class Node<T>
        {
            public T Data { get; set; }

            public Node<T> Left { get; set; }

            public Node<T> Right { get; set; }

            public Node()
            {

            }

            public Node(T data)
            {
                this.Data = data;
            }

            public Node(Node<T> left, Node<T> right)
            {
                this.Left = left;
                this.Right = right;
            }

            public Node(T data, Node<T> left, Node<T> right)
            {
                this.Data = data;
                this.Left = left;
                this.Right = right;
            }
        }

        private Node<T> root;

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
                root = new Node<T>(item);
                return true;
            }

            var tmp = root;

            while (true)
            {
                if (Comparer<T>.Default.Compare(item, tmp.Data) > 0)
                {
                    if (tmp.Right == null)
                    {
                        tmp.Right = new Node<T>(item);
                        return true;
                    }

                    tmp = tmp.Right;
                    continue;
                }

                if (Comparer<T>.Default.Compare(item, tmp.Data) < 0)
                {
                    if (tmp.Left == null)
                    {
                        tmp.Left = new Node<T>(item);
                        return true;
                    }

                    tmp = tmp.Left;
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

            while (tmp != null && Comparer<T>.Default.Compare(tmp.Data, item) != 0)
            {
                if (Comparer<T>.Default.Compare(tmp.Data, item) > 0)
                {
                    tmp = tmp.Right;
                    continue;
                }

                tmp = tmp.Left;
            }

            return tmp != null && Comparer<T>.Default.Compare(tmp.Data, item) == 0;
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
            if (root == null)
            {
                yield break;
            }

            var node = root;
            var stack = new Stack<Node<T>>();

            while (node != null && stack.Count > 0)
            {
                if (node == null)
                {
                    node = stack.Pop();
                    yield return node.Data;
                    node = node.Right;
                }
                else
                {
                    stack.Push(node);
                    node = node.Left;
                }
            }
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
                root = new Node<T>(item);
                return;
            }

            var tmp = root;

            while (true)
            {
                if (Comparer<T>.Default.Compare(item, tmp.Data) >= 0)
                {
                    if (tmp.Right == null)
                    {
                        tmp.Right = new Node<T>(item);
                        return;
                    }

                    tmp = tmp.Right;
                    continue;
                }

                if (tmp.Left == null)
                {
                    tmp.Left = new Node<T>(item);
                    return;
                }

                tmp = tmp.Left;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
