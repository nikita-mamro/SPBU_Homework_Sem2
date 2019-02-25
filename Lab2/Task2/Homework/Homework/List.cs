using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class List : IList
    {
        private class Node
        {
            public string data { get; set; }
            public int count { get; set; }
            public Node next { get; set; }
            public Node(string data, int count)
            {
                this.data = data;
                this.next = null;
                this.count = count;
            }
        }

        private Node head;
        private Node tail;
        private int size;

        public List()
        {
            head = null;
            tail = null;
            size = 0;
        }

        public string this[int index]
        {
            get
            {
                var current = head;

                for (var i = 0; i < index; ++i)
                {
                    current = current.next;
                }

                return current.data;
            }
        }

        public bool Contains(string word)
        {
            return GetNodeByWord(word) != null;
        }

        private Node GetNodeByWord(string word)
        {
            if (size == 1 && head.data == word)
            {
                return head;
            }

            return GetPreviousByWord(word) == null ? null : GetPreviousByWord(word).next;
        }

        private Node GetPreviousByWord(string word)
        {
            if (isEmpty)
            {
                return head;
            }

            var current = head;

            while (current.next != null && current.next.data != word)
            {
                current = current.next;
            }

            return current.next != null ? current : null;
        }

        private void UpdateCounter(Node node, bool add)
        {
            if (add)
            {
                ++node.count;
                return;
            }

            --node.count;
        }

        public void Add(string word)
        {
            if (Contains(word))
            {
                UpdateCounter(GetNodeByWord(word), true);
                Console.WriteLine($"Обновлено количество вхождений элемента {word} в набор!");
                return;
            }

            if (isEmpty)
            {
                var node = new Node(word, 1);
                head = node;
                tail = node;
                ++size;
                Console.WriteLine($"Элемент {word} добавлен!");
                return;
            }

            tail.next = new Node(word, 1);
            tail = tail.next;
            Console.WriteLine($"Элемент {word} добавлен!");
        }

        public void Remove(string word)
        {
            if (!Contains(word))
            {
                Console.WriteLine($"Элемент {word} не найден!");
                return;
            }

            if (head.data == word)
            {
                if (head.count > 1)
                {
                    --head.count;
                    Console.WriteLine($"Обновлено количество вхождений элемента {word} в набор!");
                    return;
                }

                head = null;
                tail = null;
                size = 0;
                Console.WriteLine($"Элемент {word} удалён");
                return;
            }

            var node = GetPreviousByWord(word);

            if (node.next.count > 1)
            {
                --node.next.count;
                Console.WriteLine($"Обновлено количество вхождений элемента {word} в набор!");
                return;
            }

            if (node.next == tail)
            {
                node.next = null;
                tail = node;
            }

            node.next = node.next.next;
            Console.WriteLine($"Элемент {word} удалён");
        }

        private void RemoveFromHead()
        {
            head = head.next;
            --size;
        }

        public List<string> GetWords()
        {
            var words = new List<string>(); 

            for (int i = 0; i < size; ++i)
            {
                words.Add(this[i]);
            }

            return words;
        }

        public int Size
        {
            get { return size; }
        }

        public bool isEmpty
        {
            get { return size == 0; }
        }

        public void Clear()
        {
            for (var i = 0; i < size; ++i)
            {
                RemoveFromHead();
            }
        }
    }
}
