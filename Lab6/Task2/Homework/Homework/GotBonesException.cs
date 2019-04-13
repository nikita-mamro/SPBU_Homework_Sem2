using System;

namespace Exceptions
{
    [Serializable]
    class GotBonesException : Exception
    {
        public GotBonesException() { }
        public GotBonesException(string message) : base(message){ }
        public GotBonesException(string message, Exception inner)
            : base(message, inner) { }
    }
}
