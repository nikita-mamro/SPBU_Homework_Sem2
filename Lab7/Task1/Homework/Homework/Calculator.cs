using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    static public class Calculator
    {
        static private float proceedOperator(float a, float b, string theOperator)
        {
            switch (theOperator)
            {
                case "-":
                    return a - b;
                case "+":
                    return a + b;
                case "×":
                    return a * b;
                case "÷":
                    return a / b;
                default:
                    throw new Exception();
            }
        }

        static public float Calculate(string expression)
        {
            var expressionTokens = Convertors.NotationConverter.InfixToReversePolishNotation(expression);
            var stack = new Stack<float>();

            foreach (var token in expressionTokens)
            {
                if (token == "-" || token == "+" || token == "×" || token == "÷")
                {
                    stack.Push(proceedOperator(stack.Pop(), stack.Pop(), token));
                    continue;
                }

                if (float.TryParse(token, out float number))
                {
                    stack.Push(number);
                    continue;
                }

                throw new Exception();
            }

            return stack.Pop();
        }
    }
}
