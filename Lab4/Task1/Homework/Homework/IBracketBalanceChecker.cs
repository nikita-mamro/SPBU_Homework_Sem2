using System;

namespace BracketBalanceChecker
{
    /// <summary>
    /// Интерфейс проверяльщика баланса скобок
    /// </summary>
    public interface IBracketBalanceChecker
    {
        /// <summary>
        /// Проверяет выражение на баланс круглых скобок 
        /// </summary>
        /// <param name="expression">Выражение</param>
        /// <returns>True, если баланс соблюдён, иначе False</returns>
        bool IsBalanced(string expression);
    }
}
