using System;
using System.Collections.Generic;

namespace Homework
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
            /// <summary>
            /// Значение, которое хранит элемент списка
            /// </summary>
            public string Data { get; set; }
            /// <summary>
            /// Количество вхождений данного значения в список
            /// </summary>
            public int Count { get; set; }
            /// <summary>
            /// Указатель на следующий элемент
            /// </summary>
            public Node Next { get; set; }
            /// <summary>
            /// Конструктор для элемента списка
            /// </summary>
            /// <param name="data">Хранимое значение</param>
            /// <param name="count">Количество вхождений значения</param>
            public Node(string data, int count)
            {
                Data = data;
                Next = null;
                Count = count;
            }
        }

        private Node head;
        private Node tail;
        public int Size { get; private set; }

        public string this[int index]
        {
            get
            {
                var current = head;

                for (var i = 0; i < index; ++i)
                {
                    current = current.Next;
                }

                return current.Data;
            }
        }

        public bool Contains(string word)
        {
            return GetNodeByWord(word) != null;
        }

        private Node GetNodeByWord(string word)
        {
            if (IsEmpty)
            {
                return null;
            }

            if (head.Data == word)
            {
                return head;
            }

            return GetPreviousByWord(word) == null ? null : GetPreviousByWord(word).Next;
        }

        private Node GetPreviousByWord(string word)
        {
            if (IsEmpty)
            {
                return head;
            }

            var current = head;

            while (current.Next != null && current.Next.Data != word)
            {
                current = current.Next;
            }

            return current.Next != null ? current : null;
        }

        private void UpdateCounter(Node node, bool add)
        {
            if (add)
            {
                ++node.Count;
                return;
            }

            --node.Count;
        }

        public void Add(string word)
        {
            if (Contains(word))
            {
                UpdateCounter(GetNodeByWord(word), true);
                return;
            }

            if (IsEmpty)
            {
                var node = new Node(word, 1);
                head = node;
                tail = node;
                ++Size;
                return;
            }

            tail.Next = new Node(word, 1);
            tail = tail.Next;
            ++Size;
        }

        public bool Remove(string word)
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Удаление из пустого списка невозможно!");
            }

            if (!Contains(word))
            {
                throw new ArgumentException("Элемент не найден!");
            }

            if (head.Data == word)
            {
                if (head.Count > 1)
                {
                    --head.Count;
                    return true;
                }

                head = null;
                tail = null;
                Size = 0;
                return true;
            }

            var node = GetPreviousByWord(word);

            if (node.Next.Count > 1)
            {
                --node.Next.Count;
                Console.WriteLine($"Обновлено количество вхождений элемента {word} в набор!");
                return true;
            }

            if (node.Next == tail)
            {
                --Size;
                node.Next = null;
                tail = node;
                Console.WriteLine($"Элемент {word} удалён");
                return true;
            }

            --Size;
            node.Next = node.Next.Next;
            Console.WriteLine($"Элемент {word} удалён");

            return true;
        }

        private void RemoveFromHead()
        {
            head = head.Next;
            --Size;
        }

        public List<string> GetWords()
        {
            var words = new List<string>();

            Node current = head;

            while (current != null)
            {
                for (var i = 0; i < current.Count; ++i)
                {
                    words.Add(current.Data);
                }
                current = current.Next;
            }

            return words;
        }

        public bool IsEmpty
            => Size == 0;

        public void Clear()
        {
            head = null;
            Size = 0;
        }
    }
}
