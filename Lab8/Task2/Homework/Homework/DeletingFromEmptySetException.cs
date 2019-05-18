using System;

namespace Exceptions
{
    [Serializable]
    public class DeletingFromEmptySetException : Exception
    {
        public DeletingFromEmptySetException() { }
        public DeletingFromEmptySetException(string message) : base(message) { }
        public DeletingFromEmptySetException(string message, Exception inner)
            : base(message, inner) { }
    }
}
