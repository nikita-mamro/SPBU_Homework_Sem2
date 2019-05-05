using System;

namespace Exceptions
{
    /// <summary>
    /// Исключение, выбрасываемое при попытки отредактировать список, доступный только для чтения
    /// </summary>
    [Serializable]
    public class EditingReadOnlyListException : Exception
    {
        public EditingReadOnlyListException() { }
        public EditingReadOnlyListException(string message) : base(message) { }
        public EditingReadOnlyListException(string message, Exception inner)
            : base(message, inner) { }
    }
}
