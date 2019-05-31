using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    public class List
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

        private Node head;
        private Node tail;
        public int Size { get; private set; }

        public bool Contains(string word)
            => GetNodeByWord(word) != null;

        private Node GetNodeByWord(string word)
        {
            if (head == null)
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
            if (!Contains(word))
            {
                return false;
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
                return true;
            }

            if (node.Next == tail)
            {
                --Size;
                node.Next = null;
                tail = node;
                return true;
            }

            --Size;
            node.Next = node.Next.Next;

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
