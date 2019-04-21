using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convertors
{
    static public class NotationConverter
    {
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
                }

                if (float.TryParse(token, out float tmp))
                {
                    stack.Push(token);
                }

                if (token == "-" || token == "+" || token == "×" || token == "÷")
                {
                    while (stack.Count > 0 && ( stack.Peek() == "-" || stack.Peek() == "+" || stack.Peek() == "×" || stack.Peek() == "÷"))
                    {
                        if (OperatorPriority(stack.Peek()) >= OperatorPriority(token))
                        {
                            res.Add(stack.Pop());
                        }
                    }

                    stack.Push(token);
                }

                if (token == ")")
                {
                    while (stack.Peek() != "(")
                    {
                        res.Add(stack.Pop());
                    }

                    stack.Pop(); //иначе ошибка в выражении
                }
            }

            while (stack.Count != 0)
            {
                res.Add(stack.Pop()); //если )(, ошибка в выр
            }

            return res;
        }

        static public List<string> SeparateCorrectExpression(string expression)
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

                #region TODO minus
                
                if (expression[currentPosition] == '-')
                {
                    if (currentPosition == 0 || expression[currentPosition - 1] == '(' || Validators.InputValidator.IsOperator(expression[currentPosition - 1]))
                    {
                        string number = "-";
                        ++currentPosition;

                        while (char.IsDigit(expression[currentPosition]) || expression[currentPosition] == ',')
                        {
                            number += expression[currentPosition].ToString();

                            if (currentPosition == expression.Length - 1)
                            {
                                break;
                            }

                            ++currentPosition;
                        }

                        res.Add(number);
                    }

                    res.Add(expression[currentPosition].ToString());
                    continue;
                }

                #endregion

                if (char.IsDigit(expression[currentPosition]))
                {
                    string number = null;

                    while (currentPosition < expression.Length - 1 && (char.IsDigit(expression[currentPosition + 1]) || expression[currentPosition + 1] == ','))
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
