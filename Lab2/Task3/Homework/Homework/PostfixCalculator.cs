using System;
using System.Collections.Generic;
using System.Text;

namespace Homework
{
    class PostfixCalculator : ICalculator
    {
        private IStack stack;

        public PostfixCalculator(IStack stack)
        {
            this.stack = stack;
        }

        private bool IsOperator(string c)
        {
            return c == "+" || c == "-" || c == "*" || c == "/";
        }

        private int ProceedOperator(int a, int b, string theOperator)
        {
            switch (theOperator)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
            }

            return 0;
        }
        
        public int GetPostfixExpressionValue(string expression)
        {
            try
            {
                string[] elements = expression.Split(' ');

                foreach (var element in elements)
                {
                    if (int.TryParse(element, out int number))
                    {
                        stack.Push(number);
                        continue;
                    }

                    if (IsOperator(element))
                    {
                        var numberA = stack.Pop();
                        var numberB = stack.Pop();
                        var result = ProceedOperator(numberB, numberA, element);
                        stack.Push(result);
                        continue;
                    }

                    throw new ArgumentException("Непредвиденный символ на вводе!", $"{element}");
                }

                var answer = stack.Pop();

                stack.Clear();
                return answer;
            }
            catch (InvalidOperationException stackError)
            {
                Console.WriteLine(stackError.Message);
                throw new InvalidOperationException("Невозможно посчитать значение выражения!");
            }
        }
    }
}
