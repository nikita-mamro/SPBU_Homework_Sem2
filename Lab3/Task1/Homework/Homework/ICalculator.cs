using System;

namespace Homework
{
    /// <summary>
    /// Интерфейс калькулятора для целочисленных постфиксных выражений
    /// </summary>
    public interface ICalculator
    {
        /// <summary>
        /// Вычисляет значение передаваемого в постфиксной форме целочисленного выражения
        /// </summary>
        /// <param name="expression">Выражение в постфиксной форме (операнды отделяются пробелами)</param>
        /// <returns>Значение переданного выражения</returns>
        int GetPostfixExpressionValue(string expression);
    }
}
