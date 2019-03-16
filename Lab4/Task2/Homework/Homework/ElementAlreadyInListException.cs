using System;

namespace Exceptions
{
    /// <summary>
    /// Исключение, которое выбрасывается при попытке добавления существующего значения в UniqueList
    /// </summary>
    [Serializable]
    public class ElementAlreadyInListException : Exception
    {
        public ElementAlreadyInListException() { }
        public ElementAlreadyInListException(string message) : base(message) { }
        public ElementAlreadyInListException(string message, Exception inner)
        : base(message, inner) { }
    }
}
