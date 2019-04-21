using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators
{
    static public class InputValidator
    {
        static public bool IsOperator(char c)
            => c == '+' || c == '-' || c == '×' || c == '÷';

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

        static public bool CanNumberBeAdded(string expression)
            => expression.Length == 0 || expression[expression.Length - 1] != ')' && expression[expression.Length - 1] != '0';

        static public bool CanCommaBeAdded(string expression)
        {
            if (expression.Length == 0)
            {
                return true;
            }

            for (var i = expression.Length - 1; i >= 0; i--)
            {
                if (IsOperator(expression[i]))
                {
                    return true;
                }
                if (expression[i] == '.')
                {
                    return false;
                }
            }

            return true;
        }

        static public bool ShouldZeroBeAddedBeforeComma(string expression)
            => expression.Length == 0 || IsOperator(expression[expression.Length - 1]) || expression[expression.Length - 1] == '(';

        static public bool CanLeftBracketBeAdded(string expression)
            => expression.Length == 0 || IsOperator(expression[expression.Length - 1]) || expression[expression.Length - 1] == '(';

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
    }
}
