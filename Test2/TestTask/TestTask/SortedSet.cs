using System;
using System.Collections.Generic;

namespace TestTask
{
    /// <summary>
    /// Класс, реализующий множество SortedSet, хранящий упорядоченные по длине списки элементов данного типа
    /// </summary>
    public class SortedSet<T>
    {
        /// <summary>
        /// Класс, реализующий элемент множества SortedSet
        /// </summary>
        private class Node
        {
            /// <summary>
            /// Данные, хранящиеся в элементе множества
            /// </summary>
            public List<T> Data { get; set; }
            /// <summary>
            /// Левый сын элемента
            /// </summary>
            public Node Left { get; set; }
            /// <summary>
            /// Правый сын элемента
            /// </summary>
            public Node Right { get; set; }

            /// <summary>
            /// Конструктор элемента множества
            /// </summary>
            /// <param name="data">Данные, которые будет хранить элемент</param>
            public Node(List<T> data)
            {
                Data = data;
            }
        }

        /// <summary>
        /// Корневой элемент множества
        /// </summary>
        private Node root;

        /// <summary>
        /// Конструктор множества, принимающий массив списков элементов данного типа
        /// </summary>
        public SortedSet(List<List<T>> elements)
        {
            foreach (var element in elements)
            {
                Add(element);
            }
        }

        /// <summary>
        /// Добавление элемента в множество
        /// </summary>
        public void Add(List<T> item)
        {
            if (root == null)
            {
                root = new Node(item);
                return;
            }

            var listComparer = new ListComparer<T>();
            var tmp = root;

            while (true)
            {
                if (listComparer.Compare(item, tmp.Data) >= 0)
                {
                    if (tmp.Right == null)
                    {
                        tmp.Right = new Node(item);
                        return;
                    }

                    tmp = tmp.Right;
                    continue;
                }

                if (tmp.Left == null)
                {
                    tmp.Left = new Node(item);
                    return;
                }

                tmp = tmp.Left;
            }
        }

        /// <summary>
        /// Получение элементов из множества
        /// </summary>
        /// <returns>Отсортированный список данных, хранящихся в множестве</returns>
        public List<List<T>> GetSortedElements()
        {
            var res = new List<List<T>>();
            var stack = new Stack<Node>();
            var node = root;

            while (node != null || stack.Count != 0)
            {
                while (node != null)
                {
                    stack.Push(node);
                    node = node.Left;
                }

                node = stack.Peek();
                stack.Pop();

                res.Add(node.Data);

                node = node.Right;
            }

            return res;
        }
    }
}
