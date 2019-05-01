using System;

namespace Homework
{
    [Serializable]
    class ItemNotInListException : Exception
    {
        public ItemNotInListException() { }
        public ItemNotInListException(string message) : base(message) { }
        public ItemNotInListException(string message, Exception inner)
            : base(message, inner) { }
    }
}
