using System;

namespace Exceptions
{
    [Serializable]
    public class EditingReadOnlySetException : Exception
    {
        public EditingReadOnlySetException() { }
        public EditingReadOnlySetException(string message) : base(message) { }
        public EditingReadOnlySetException(string message, Exception inner)
            : base(message, inner) { }
    }
}
