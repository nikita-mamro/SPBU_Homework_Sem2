using System;

namespace Exceptions
{
    /// <summary>
    /// Исключение, выбрасываемое при попытке удаления элемента из пустого списка
    /// </summary>
    [Serializable]
    public class DeletingFromEmptyListException : Exception
    {
        public DeletingFromEmptyListException() { }
        public DeletingFromEmptyListException(string message) : base(message) { }
        public DeletingFromEmptyListException(string message, Exception inner)
            : base(message, inner) { }
    }
}
