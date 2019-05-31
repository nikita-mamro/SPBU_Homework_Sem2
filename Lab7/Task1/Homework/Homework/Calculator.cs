using System;
using System.Collections.Generic;
using System.Globalization;

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
        static private double ProceedOperator(double a, double b, string theOperator)
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
                    if (b == 0)
                    {
                        throw new DivideByZeroException();
                    }
                    return a / b;
                default:
                    throw new Exceptions.ProceedingInvalidOperatorException();
            }
        }

        /// <summary>
        /// Считает значение данного выражения в инфиксной форме
        /// </summary>
        /// <param name="expression">Выражение в инфиксной форме</param>
        /// <returns>Значение выражения</returns>
        static public double Calculate(string expression)
        {
            var expressionTokens = Convertors.NotationConverter.InfixToReversePolishNotation(expression);
            var stack = new Stack<double>();

            foreach (var token in expressionTokens)
            {
                if (token == "-" || token == "+" || token == "×" || token == "÷")
                {
                    var numberB = stack.Pop();
                    var numberA = stack.Pop();
                    stack.Push(ProceedOperator(numberA, numberB, token));
                    continue;
                }

                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture,  out double number))
                {
                    stack.Push(number);
                    continue;
                }

                System.Diagnostics.Debug.Assert(false, "Что-то пошло не так");
            }

            return Math.Round(stack.Pop(), 4);
        }
    }
}
