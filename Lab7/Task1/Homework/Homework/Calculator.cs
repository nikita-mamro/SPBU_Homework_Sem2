using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    /// <summary>
    /// Класс, который считает значение выражения в инфиксной форме
    /// </summary>
    static public class Calculator
    {
        /// <summary>
        /// Считает результат бинарной операции
        /// </summary>
        /// <param name="a">Первый операнд</param>
        /// <param name="b">Второй операнд</param>
        /// <param name="theOperator">Оператор</param>
        /// <returns>Результат операции</returns>
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

        /// <summary>
        /// Считает значение данного выражения в инфиксной форме
        /// </summary>
        /// <param name="expression">Выражение в инфиксной форме</param>
        /// <returns>Значение выражения</returns>
        static public float Calculate(string expression)
        {
            var expressionTokens = Convertors.NotationConverter.InfixToReversePolishNotation(expression);
            var stack = new Stack<float>();

            foreach (var token in expressionTokens)
            {
                if (token == "-" || token == "+" || token == "×" || token == "÷")
                {
                    var numberB = stack.Pop();
                    var numberA = stack.Pop();
                    stack.Push(proceedOperator(numberA, numberB, token));
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
