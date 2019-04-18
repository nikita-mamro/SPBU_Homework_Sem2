using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    public class Validator
    {
        public bool IsOperator(string c)
            => c == "+" || c == "-" || c == "×" || c == "÷";

        public bool CanOperatorBeAdded(List<string> expression, string op)
        {
            var length = expression.Count;

            if (length == 0)
            {
                return op == "-";
            }

            if (length == 1 && IsOperator(expression[length - 1]))
            {
                return false;
            }

            if (op != "-")
            {
                return expression[length - 1] != "(" && !IsOperator(expression[length - 1]);
            }

            if (length > 1 && IsOperator(expression[length - 1]) && IsOperator(expression[length - 2]))
            {
                return false;
            }

            return true;
        }
    }
}
