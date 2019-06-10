using System;

namespace Exceptions
{
    /// <summary>
    /// Исключение, которое выбрасывается при попытке удаления несуществующего элемента
    /// </summary>
    [Serializable]
    public class ElementNotInListException : Exception
    {
        public ElementNotInListException() { }
        public ElementNotInListException(string message) : base(message) { }
        public ElementNotInListException(string message, Exception inner)
        : base(message, inner) { }
    }
}
