using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class List : IList
    {
        private class Node
        {
            public string Data { get; set; }
            public int Count { get; set; }
            public Node Next { get; set; }
            public Node(string data, int count)
            {
                Data = data;
                Next = null;
                Count = count;
            }
        }

        private Node Head;
        private Node Tail;
        public int Size { get; private set; }

        public string this[int index]
        {
            get
            {
                var current = Head;

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
            if (Size == 1 && Head.Data == word)
            {
                return Head;
            }

            return GetPreviousByWord(word) == null ? null : GetPreviousByWord(word).Next;
        }

        private Node GetPreviousByWord(string word)
        {
            if (IsEmpty)
            {
                return Head;
            }

            var current = Head;

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
                Console.WriteLine($"Обновлено количество вхождений элемента {word} в набор!");
                return;
            }

            if (IsEmpty)
            {
                var node = new Node(word, 1);
                Head = node;
                Tail = node;
                ++Size;
                Console.WriteLine($"Элемент {word} добавлен!");
                return;
            }

            Tail.Next = new Node(word, 1);
            Tail = Tail.Next;
            Console.WriteLine($"Элемент {word} добавлен!");
        }

        public bool Remove(string word)
        {
            if (!Contains(word))
            {
                Console.WriteLine($"Элемент {word} не найден!");
                return false;
            }

            if (Head.Data == word)
            {
                if (Head.Count > 1)
                {
                    --Head.Count;
                    Console.WriteLine($"Обновлено количество вхождений элемента {word} в набор!");
                    return true;
                }

                Head = null;
                Tail = null;
                Size = 0;
                Console.WriteLine($"Элемент {word} удалён");
                return true;
            }

            var node = GetPreviousByWord(word);

            if (node.Next.Count > 1)
            {
                --node.Next.Count;
                Console.WriteLine($"Обновлено количество вхождений элемента {word} в набор!");
                return true;
            }

            if (node.Next == Tail)
            {
                node.Next = null;
                Tail = node;
            }

            node.Next = node.Next.Next;
            Console.WriteLine($"Элемент {word} удалён");

            return true;
        }

        private void RemoveFromHead()
        {
            Head = Head.Next;
            --Size;
        }

        public List<string> GetWords()
        {
            var words = new List<string>(); 

            for (int i = 0; i < Size; ++i)
            {
                words.Add(this[i]);
            }

            return words;
        }

        public bool IsEmpty
            => Size == 0;

        public void Clear()
        {
            Head = null;
            Size = 0;
        }
    }
}
