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

        private bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }

        private int ProceedOperator(int a, int b, char theOperator)
        {
            switch (theOperator)
            {
                case '+':
                    return a + b;
                case '-':
                    return a - b;
                case '*':
                    return a * b;
                case '/':
                    return a / b;
            }

            return 0;
        }
        
        public int GetPostfixExpressionValue(string expression)
        {
            try
            {
                // Variable which makes it possible to use not only digits, but also numbers 
                int numbersHandler = 0;

                for (var i = 0; i < expression.Length;  ++i)
                {
                    if (expression[i] == ' ')
                    {
                        continue;
                    }
                    if (char.IsDigit(expression[i]))
                    {
                        numbersHandler += int.Parse(expression[i].ToString());

                        if (i < expression.Length - 1 && char.IsDigit(expression[i + 1]))
                        {
                            numbersHandler *= 10;
                            continue;
                        }

                        stack.Push(numbersHandler);
                        numbersHandler = 0;

                        continue;
                    }
                    if(IsOperator(expression[i]))
                    {
                        var numberA = stack.Pop();
                        var numberB = stack.Pop();
                        var result = ProceedOperator(numberB, numberA, expression[i]);
                        stack.Push(result);
                        continue;
                    }

                    throw new ArgumentException("Непредвиденный символ на вводе!", $"{expression[i]}");
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
