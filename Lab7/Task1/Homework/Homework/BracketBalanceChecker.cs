using System;
using System.Collections.Generic;

namespace Validators
{
    /// <summary>
    /// Класс, реализующий проверяльщика баланса скобок
    /// </summary>
    public class BracketBalanceChecker
    {
        /// <summary>
        /// Проверяет выражение на баланс круглых скобок 
        /// </summary>
        /// <param name="expression">Выражение</param>
        /// <returns>True, если баланс соблюдён, иначе False</returns>
        public static bool IsBalanced(string expression)
        {
            var stack = new Stack<char>();

            foreach (var symbol in expression)
            {
                if (symbol == '(')
                {
                    stack.Push(symbol);
                }

                if (symbol == ')')
                {
                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    stack.Pop();
                }
            }

            return stack.Count == 0;
        }
    }
}