using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework
{
    public class Set<T> : ISet<T>
    {
        private class Node
        {
            public T Data { get; set; }

            public Node Left { get; set; }

            public Node Right { get; set; }

            public Node(T data)
            {
                this.Data = data;
            }

            public Node(Node left, Node right)
            {
                this.Left = left;
                this.Right = right;
            }

            public Node(T data, Node left, Node right)
            {
                this.Data = data;
                this.Left = left;
                this.Right = right;
            }
        }

        private Node root;

        public int Count { get; private set; }

        public bool IsReadOnly { get; private set; }

        public Set()
        {

        }

        public Set(T[] elements)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }

        public Set(T[] elements, bool isReadOnly)
        {
            foreach (var element in elements)
            {
                Add(element);
            }

            IsReadOnly = isReadOnly;
        }

        public bool AddIfNotPresent(T item)
        {
            if (IsReadOnly)
            {
                throw new Exceptions.EditingReadOnlySetException("Calling Add() for ReadOnly set");
            }

            if (root == null)
            {
                root = new Node(item);
                ++Count;
                return true;
            }

            var tmp = root;

            while (true)
            {
                if (Comparer<T>.Default.Compare(item, tmp.Data) > 0)
                {
                    if (tmp.Right == null)
                    {
                        tmp.Right = new Node(item);
                        ++Count;
                        return true;
                    }

                    tmp = tmp.Right;
                    continue;
                }

                if (Comparer<T>.Default.Compare(item, tmp.Data) < 0)
                {
                    if (tmp.Left == null)
                    {
                        tmp.Left = new Node(item);
                        ++Count;
                        return true;
                    }

                    tmp = tmp.Left;
                    continue;
                }

                return false;
            }
        }

        /// <summary>
        /// Методы интерфейса ISet
        /// </summary>

        public bool Add(T item)
        {
            return AddIfNotPresent(item);
        }

        void ICollection<T>.Add(T item)
        {
            AddIfNotPresent(item);
        }

        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new Exceptions.EditingReadOnlySetException("Calling Clear() for ReadOnly set");
            }

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
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new IndexOutOfRangeException("Array index can't be negative.");
            }

            if (array.Rank > 1)
            {
                throw new ArgumentException("Copying to multidimensional array.");
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new ArgumentException("Not enough space in the array.");
            }

            var index = 0;

            foreach (var element in this)
            {
                array[index + arrayIndex] = element;
            }
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            if (Count == 0)
            {
                throw new Exceptions.DeletingFromEmptySetException();
            }

            if (other == this)
            {
                Clear();
            }

            foreach (T element in other)
            {
                Remove(element);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (root == null)
            {
                yield break;
            }

            var node = root;
            var stack = new Stack<Node>();

            while (node != null || stack.Count != 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                node = stack.Peek();
                stack.Pop();

                yield return node.Data;

                node = node.Right;
            }
        }

        private void IntersectWithAnotherSet(Set<T> other)
        {
            foreach (var element in this)
            {
                if (!other.Contains(element))
                {
                    Remove(element);
                }
            }
        }

        private void IntersectWithEnumerable(IEnumerable<T> other)
        {
            var set = new Set<T>();

            foreach (var element in other)
            {
                set.Add(element);
            }

            IntersectWithAnotherSet(set);
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            if (Count == 0)
            {
                return;
            }

            var otherAsCollection = other as ICollection<T>;

            if (otherAsCollection != null)
            {
                if (otherAsCollection.Count == 0)
                {
                    Clear();
                    return;
                }

                var otherAsSet = other as Set<T>;

                if (otherAsSet != null)
                {
                    IntersectWithAnotherSet(otherAsSet);
                }

                return;
            }

            IntersectWithEnumerable(other);
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        private bool IsSubsetOfAnotherSet(Set<T> other)
        {
            foreach (var element in this)
            {
                if (!other.Contains(element))
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsSubsetOfEnumerable(IEnumerable<T> other)
        {
            var set = new Set<T>();

            foreach (var element in other)
            {
                set.Add(element);
            }

            return IsSubsetOfAnotherSet(set);
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            if (Count == 0)
            {
                return true;
            }

            var otherAsSet = other as Set<T>;

            if (otherAsSet != null)
            {
                return IsSubsetOfAnotherSet(otherAsSet);
            }

            return IsSubsetOfEnumerable(other);
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("other");
            }

            foreach (var element in other)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }

            return true;
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new Exceptions.EditingReadOnlySetException("Calling Remove() for ReadOnly set");
            }

            if (Count == 0)
            {
                throw new Exceptions.DeletingFromEmptySetException("Calling Remove() for empty set");
            }

            if (Comparer<T>.Default.Compare(item, root.Data) == 0)
            {
                if (Count == 1)
                {
                    root = null;

                    --Count;
                    return true;
                }

                if (root.Left == null)
                {
                    root = root.Right;

                    --Count;
                    return true;
                }

                if (root.Right == null)
                {
                    root = root.Left;

                    --Count;
                    return true;
                }

                var tmp = root.Left;

                while (tmp.Right != null)
                {
                    tmp = tmp.Right;
                }

                tmp.Right = root.Right.Left;
                root.Right.Left = root.Left;
                root = root.Right;

                --Count;
                return true;
            }

            var parent = root;

            while (parent != null)
            {
                if (Comparer<T>.Default.Compare(item, parent.Data) > 0)
                {
                    if (parent.Right == null)
                    {
                        return false;
                    }

                    if (Comparer<T>.Default.Compare(item, parent.Right.Data) == 0)
                    {
                        if (parent.Right.Left == null)
                        {
                            parent.Right = parent.Right.Right;

                            --Count;
                            return true;
                        }

                        var tmp = parent.Right.Left;

                        while (tmp.Right != null)
                        {
                            tmp = tmp.Right;
                        }

                        tmp.Right = parent.Right.Right;
                        parent.Right = parent.Right.Left;

                        --Count;
                        return true;
                    }

                    parent = parent.Right;
                    continue;
                }

                if (parent.Left == null)
                {
                    return false;
                }

                if (Comparer<T>.Default.Compare(item, parent.Left.Data) == 0)
                {
                    if (parent.Left.Right == null)
                    {
                        parent.Left = parent.Left.Left;

                        --Count;
                        return true;
                    }

                    var tmp = parent.Left.Right;

                    while (tmp.Left != null)
                    {
                        tmp = tmp.Left;
                    }

                    tmp.Left = parent.Left.Left;
                    parent.Left = parent.Left.Right;

                    --Count;
                    return true;
                }

                parent = parent.Left;
            }

            return false;
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

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
