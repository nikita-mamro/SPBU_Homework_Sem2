using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    /// <summary>
    /// Класс, реализующий методы, которые не дают пользователю вводить заведомо некоррректные выражения
    /// </summary>
    static public class InputValidator
    {
        /// <summary>
        /// Проверяет, является ли данный символ одним из операторов + - × ÷
        /// </summary>
        /// <param name="c">Проверяемый символ</param>
        static public bool IsOperator(char c)
            => c == '+' || c == '-' || c == '×' || c == '÷';

        /// <summary>
        /// Проверяет, можно ли добавить в конец выражения оператор, сохранив корректность
        /// </summary>
        /// <param name="expression">Текущее выражение</param>
        /// <param name="isMinus">Индикатор того, является ли оператор минусом</param>
        static public bool CanOperatorBeAdded(string expression, bool isMinus)
        {
            var length = expression.Length;

            if (length == 0)
            {
                return isMinus;
            }

            if (length == 1 && IsOperator(expression[length - 1]))
            {
                return false;
            }

            if (length > 1 && expression[length - 1] == ',')
            {
                return false;
            }

            if (!isMinus)
            {
                return expression[length - 1] != '(' && !IsOperator(expression[length - 1]);
            }

            if (isMinus && length > 1 && expression[length - 2] == '(' && expression[length - 1] == '-')
            {
                return false;
            }

            if (length > 1 && IsOperator(expression[length - 1]) && IsOperator(expression[length - 2]))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Проверяет, можно ли добавить в конец выражения цифру, сохранив корректность
        /// </summary>
        /// <param name="expression">Текущее выражение</param>
        static public bool CanDigitBeAdded(string expression)
        {
            if (expression.Length == 0)
            {
                return true;
            }

            if (expression[expression.Length - 1] == ')')
            {
                return false;
            }

            if (expression[expression.Length - 1] == '0')
            {
                if (expression.Length == 1)
                {
                    return false;
                }

                for (var i = expression.Length - 1; i >= 0; --i)
                {
                    if (expression[i] == ',')
                    {
                        return true;
                    }
                    if (IsOperator(expression[i]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Проверяет, можно ли добавить в конец выражения запятую, сохранив корректность
        /// </summary>
        /// <param name="expression">Текущее выражение</param>
        static public bool CanCommaBeAdded(string expression)
        {
            if (expression.Length == 0)
            {
                return true;
            }

            if (expression[expression.Length - 1] == ')')
            {
                return false;
            }

            for (var i = expression.Length - 1; i >= 0; i--)
            {
                if (IsOperator(expression[i]))
                {
                    return true;
                }
                if (expression[i] == ',')
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Проверяет, нужно ли добавлять 0, когда пользователь вводит
        /// </summary>
        /// <param name="expression">Текущее выражение</param>
        static public bool ShouldZeroBeAddedBeforeComma(string expression)
            => expression.Length == 0 || IsOperator(expression[expression.Length - 1]) || expression[expression.Length - 1] == '(';

        /// <summary>
        /// Проверяет, можно ли добавить в выражение открывающую скобку
        /// </summary>
        /// <param name="expression">Теукщее выражение</param>
        static public bool CanLeftBracketBeAdded(string expression)
            => expression.Length == 0 || IsOperator(expression[expression.Length - 1]) || expression[expression.Length - 1] == '(';

        /// <summary>
        /// Проверяет, можно ли добавить в выражение закрывающую скобку
        /// </summary>
        /// <param name="expression">Теукщее выражение</param>
        static public bool CanRightBracketBeAdded(string expression)
        {
            var leftCount = 0;
            var rightCount = 0;

            foreach (var symbol in expression)
            {
                if (symbol == '(')
                {
                    ++leftCount;
                    continue;
                }
                if (symbol == ')')
                {
                    ++rightCount;
                }
            }

            return expression.Length != 0 && rightCount < leftCount
                && expression[expression.Length - 1] != '(' && !IsOperator(expression[expression.Length - 1])
                && expression[expression.Length - 1] != '.';
        }

        /// <summary>
        /// Проверяет, задано ли выражение в корректном для подсчёта значения виде
        /// </summary>
        /// <param name="expression">Текущее выражение</param>
        static public bool CanExpressionBeCalculated(string expression)
        {
            if (expression.Length == 0 || !BracketBalanceChecker.IsBalanced(expression))
            {
                return false;
            }

            char lastSymbol = expression[expression.Length - 1];

            return lastSymbol != ',' && !Validators.InputValidator.IsOperator(lastSymbol);
        }
    }
}
