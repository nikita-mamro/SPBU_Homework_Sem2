using System.Collections.Generic;
using System.Globalization;

namespace Convertors
{
    /// <summary>
    /// Класс, реализующий преобразование инфиксной записи в обратную польскую нотацию
    /// </summary>
    static public class NotationConverter
    {
        /// <summary>
        /// Проверяет, является ли строка оператором + - × ÷
        /// </summary>
        /// <param name="op">Проверяемая строка</param>
        static private int OperatorPriority(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "×":
                case "÷":
                    return 2;
                default:
                    return 0;
            }
        }

        /// <summary>
        /// Переводит выражение в инфиксной форме во множество элементов этого выражения в обратной польской нотации
        /// </summary>
        /// <param name="infixExpression">Выражение в инфиксной форме</param>
        /// <returns>Множество элементов этого выражения в обратной польской нотации</returns>
        static public List<string> InfixToReversePolishNotation(string infixExpression)
        {
            var stack = new Stack<string>();
            var res = new List<string>();
            var tokens = SeparateCorrectExpression(infixExpression);

            foreach (var token in tokens)
            {
                if (token == "(")
                {
                    stack.Push(token);
                    continue;
                }

                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double tmp))
                {
                    res.Add(token);
                    continue;
                }

                if (token == "-" || token == "+" || token == "×" || token == "÷")
                {
                    while (stack.Count > 0 && ( stack.Peek() == "-" || stack.Peek() == "+" || stack.Peek() == "×" || stack.Peek() == "÷") 
                        && OperatorPriority(stack.Peek()) >= OperatorPriority(token))
                    {
                        res.Add(stack.Pop());
                    }

                    stack.Push(token);
                    continue;
                }

                if (token == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        res.Add(stack.Pop());
                    }

                    stack.Pop(); //иначе ошибка в выражении
                    continue;
                }
            }

            while (stack.Count != 0)
            {
                res.Add(stack.Pop()); //если )(, ошибка в выр
            }

            return res;
        }

        /// <summary>
        /// Разделяет данное выражение в инфиксной форме на его элементы (числа, скобки, операторы)
        /// </summary>
        /// <param name="expression">Выражение в инфиксной форме</param>
        /// <returns>Множество элементов выражения</returns>
        static private List<string> SeparateCorrectExpression(string expression)
        {
            List<string> res = new List<string>();

            for (var currentPosition = 0; currentPosition < expression.Length; ++currentPosition)
            {
                if (expression[currentPosition] == '+' || expression[currentPosition] == '×' 
                    || expression[currentPosition] == '÷' || expression[currentPosition] == '(' || expression[currentPosition] == ')')
                {
                    res.Add(expression[currentPosition].ToString());
                    continue;
                }
                
                if (expression[currentPosition] == '-')
                {
                    if (currentPosition != 0 && expression[currentPosition - 1] != '(' 
                        && !Validators.InputValidator.IsOperator(expression[currentPosition - 1]))
                    {
                        res.Add(expression[currentPosition].ToString());
                        continue;
                    }

                    var number = "-";
                    ++currentPosition;

                    while (currentPosition < expression.Length && (char.IsDigit(expression[currentPosition]) || expression[currentPosition] == '.'))
                    {
                        number += expression[currentPosition];
                        ++currentPosition;
                    }

                    res.Add(number);

                    if (currentPosition == expression.Length)
                    {
                        return res;
                    }

                    --currentPosition;
                    continue;
                }

                if (char.IsDigit(expression[currentPosition]))
                {
                    string number = null;

                    while (currentPosition < expression.Length - 1 && (char.IsDigit(expression[currentPosition + 1]) || expression[currentPosition + 1] == '.'))
                    {
                        number += expression[currentPosition];
                        ++currentPosition;
                    }

                    if (char.IsDigit(expression[currentPosition]))
                    {
                        number += expression[currentPosition];
                    }

                    res.Add(number);
                }
            }

            return res;
        }
    }
}
