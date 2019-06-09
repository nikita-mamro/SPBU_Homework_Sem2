using System;

namespace Exceptions
{
    /// <summary>
    /// Исключние, выбрасываемое при попытке обработать бинарный оператор, для которого не определён метод вычисления
    /// </summary>
    [Serializable]
    public class ProceedingInvalidOperatorException : Exception
    {
        public ProceedingInvalidOperatorException() { }
        public ProceedingInvalidOperatorException(string message) : base(message) { }
        public ProceedingInvalidOperatorException(string message, Exception inner)
            : base(message, inner) { }
    }
}
