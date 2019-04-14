using System;

namespace Exceptions
{
    class GoingOutOfScreenException : Exception
    {
        public GoingOutOfScreenException() { }
        public GoingOutOfScreenException(string message) : base(message) { }
        public GoingOutOfScreenException(string message, Exception inner)
            : base(message, inner) { }
    }
}
