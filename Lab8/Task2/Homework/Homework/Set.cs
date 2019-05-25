using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework
{
    /// <summary>
    /// Класс, реализующий АТД "Множество", реализующее интерфейс ISet
    /// </summary>
    /// <typeparam name="T">Тип хранимых значений</typeparam>
    public class Set<T> : ISet<T>
    {
        /// <summary>
        /// Класс, реализующий элемент множества
        /// </summary>
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

        /// <summary>
        /// Корневой элемент
        /// </summary>
        private Node root;

        /// <summary>
        /// Количество элементов в множестве
        /// </summary>
        public int Count { get; private set; }

        /// <summary>
        /// Модификатор доступа к элементам множества
        /// </summary>
        public bool IsReadOnly { get; private set; }

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Set()
        {

        }

        /// <summary>
        /// Конуструктор, сразу заполняющий множество элементами переданного массива
        /// </summary>
        public Set(T[] elements)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }
        
        /// <summary>
        /// Конструктор, сразу заполняющий множество элементами переданного массива 
        /// и устанавливающий переданный модификатор доступа 
        /// </summary>
        public Set(T[] elements, bool isReadOnly)
        {
            foreach (var element in elements)
            {
                Add(element);
            }

            IsReadOnly = isReadOnly;
        }

        /// <summary>
        /// Методы интерфейса ISet, а также вспомогательные методы
        /// </summary>

        /// <summary>
        /// Добавляет элемент в множество, если он ещё там не содержится
        /// </summary>
        /// <returns>True, если элемента не было в множестве, иначе false</returns>
        private bool AddIfNotPresent(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Calling Add() for ReadOnly set");
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
        /// <see cref="ISet{T}.Add(T)"/>
        /// </summary>
        public bool Add(T item)
        {
            return AddIfNotPresent(item);
        }

        /// <summary>
        /// <see cref="ICollection{T}.Add(T)"
        /// </summary>
        void ICollection<T>.Add(T item)
        {
            AddIfNotPresent(item);
        }

        /// <summary>
        /// <see cref="ICollection{T}.Clear()"/>
        /// </summary>
        public void Clear()
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Calling Clear() for ReadOnly set");
            }

            root = null;
            Count = 0;
        }

        /// <summary>
        /// <see cref="ICollection{T}.Contains(T)"/>
        /// </summary>
        public bool Contains(T item)
        {
            var tmp = root;

            while (tmp != null && Comparer<T>.Default.Compare(tmp.Data, item) != 0)
            {
                if (Comparer<T>.Default.Compare(tmp.Data, item) < 0)
                {
                    tmp = tmp.Right;
                }
                else
                {
                    tmp = tmp.Left;
                }

            }

            return tmp != null && Comparer<T>.Default.Compare(tmp.Data, item) == 0;
        }

        /// <summary>
        /// <see cref="ICollection{T}.CopyTo(T[], int)"/>
        /// </summary>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0)
            {
                throw new ArgumentOutOfRangeException("Array index can't be negative.");
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
                ++index;
            }
        }

        /// <summary>
        /// <see cref="ISet{T}.ExceptWith(IEnumerable{T})"/>
        /// </summary>
        public void ExceptWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Переданная коллекция - null");
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

        /// <summary>
        /// <see cref="IEnumerable{T}.GetEnumerator()"/>
        /// </summary>
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

        /// <summary>
        /// Пересекает данное множество с переданным множеством этого же типа
        /// </summary>
        private void IntersectWithAnotherSet(Set<T> other)
        {
            var elementsToBeRemoved = new List<T>();

            foreach (var element in this)
            {
                if (!other.Contains(element))
                {
                    elementsToBeRemoved.Add(element);
                }
            }

            foreach (var element in elementsToBeRemoved)
            {
                Remove(element);
            }
        }

        /// <summary>
        /// Пересекает данное множество с переданной коллекцией
        /// </summary>
        private void IntersectWithEnumerable(IEnumerable<T> other)
        {
            var set = new Set<T>();

            foreach (var element in other)
            {
                set.Add(element);
            }

            IntersectWithAnotherSet(set);
        }

        /// <summary>
        /// <see cref="ISet{T}.IntersectWith(IEnumerable{T})"/>
        /// </summary>
        public void IntersectWith(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Переданная коллекция - null");
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
                    return;
                }
            }

            IntersectWithEnumerable(other);
        }

        /// <summary>
        /// <see cref="ISet{T}.IsProperSubsetOf(IEnumerable{T})"/>
        /// </summary>
        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Переданная коллекция - null");
            }

            var otherCount = 0;

            foreach (var element in other)
            {
                ++otherCount;
            }

            return otherCount > Count && IsSubsetOf(other);
        }

        /// <summary>
        /// <see cref="ISet{T}.IsProperSupersetOf(IEnumerable{T})"/>
        /// </summary>
        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Переданная коллекция - null");
            }

            var otherCount = 0;

            foreach (var element in other)
            {
                ++otherCount;
            }

            return otherCount < Count && IsSupersetOf(other);
        }

        /// <summary>
        /// Проверяет, является ли данное множество подмножеством переданного множества этого же типа
        /// </summary>
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

        /// <summary>
        /// Проверяет, является ли данное множество подмножеством переданного Enumerable
        /// </summary>
        private bool IsSubsetOfEnumerable(IEnumerable<T> other)
        {
            var set = new Set<T>();

            foreach (var element in other)
            {
                set.Add(element);
            }

            return IsSubsetOfAnotherSet(set);
        }

        /// <summary>
        /// <see cref="ISet{T}.IsSubsetOf(IEnumerable{T})"/>
        /// </summary>
        public bool IsSubsetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Переданная коллекция - null");
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

        /// <summary>
        /// <see cref="ISet{T}.IsSupersetOf(IEnumerable{T})"/>
        /// </summary>
        public bool IsSupersetOf(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Переданная коллекция - null");
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

        /// <summary>
        /// <see cref="ISet{T}.Overlaps(IEnumerable{T})"/>
        /// </summary>
        public bool Overlaps(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Переданная коллекция - null");
            }

            foreach (var element in other)
            {
                if (Contains(element))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// <see cref="ICollection{T}.Remove(T)"/>
        /// </summary>
        public bool Remove(T item)
        {
            if (IsReadOnly)
            {
                throw new NotSupportedException("Calling Remove() for ReadOnly set");
            }

            if (Count == 0)
            {
                throw new NotSupportedException("Calling Remove() for empty set");
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

        /// <summary>
        /// <see cref="ISet{T}.SetEquals(IEnumerable{T})"/>
        /// </summary>
        public bool SetEquals(IEnumerable<T> other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("Переданная коллекция - null");
            }

            var otherCount = 0;

            foreach (var element in other)
            {
                if (!Contains(element))
                {
                    return false;
                }

                ++otherCount;
            }

            return otherCount == Count;
        }

        /// <summary>
        /// <see cref="ISet{T}.SymmetricExceptWith(IEnumerable{T})"/>
        /// </summary>
        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            foreach (var element in other)
            {
                if (Contains(element))
                {
                    Remove(element);
                    continue;
                }

                Add(element);
            }
        }

        /// <summary>
        /// <see cref="ISet{T}.UnionWith(IEnumerable{T})"/>
        /// </summary>
        public void UnionWith(IEnumerable<T> other)
        {
            foreach (var element in other)
            {
                if (!Contains(element))
                {
                    Add(element);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
