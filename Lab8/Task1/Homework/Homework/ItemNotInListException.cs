using System;

namespace Exceptions
{
    /// <summary>
    /// Исключение, выбрасываемое при попытке удалить несуществующий элемент
    /// </summary>
    [Serializable]
    public class ItemNotInListException : Exception
    {
        public ItemNotInListException() { }
        public ItemNotInListException(string message) : base(message) { }
        public ItemNotInListException(string message, Exception inner)
            : base(message, inner) { }
    }
}
