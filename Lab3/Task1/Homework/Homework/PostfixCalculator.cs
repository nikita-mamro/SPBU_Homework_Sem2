using System;

namespace Homework
{
    public class PostfixCalculator : ICalculator
    {
        /// <summary>
        /// Стек
        /// </summary>
        private IStack stack;

        public PostfixCalculator(IStack stack)
        {
            this.stack = stack;
        }

        /// <summary>
        /// Проверка на то, является ли слово оператором
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private bool IsOperator(string word)
            => (word == "+" || word == "-" || word == "*" || word == "/");

        /// <summary>
        /// Выполняет заданную операцию над двумя целыми числами
        /// </summary>
        /// <param name="a">Первое число</param>
        /// <param name="b">Второе число</param>
        /// <param name="theOperator">Оператор</param>
        /// <returns>Результат операции</returns>
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

        /// <summary>
        /// Вычисляет значение целочисленного выражения в постфиксной форме
        /// </summary>
        /// <param name="expression">Целочисленное выражение в постфиксной форме</param>
        /// <returns>Значение переданного выражение</returns>
        public int GetPostfixExpressionValue(string expression)
        {
            try
            {
                string[] words = expression.Split(' ');

                foreach (var word in words)
                {
                    if (int.TryParse(word, out int number))
                    {
                        stack.Push(number);
                        continue;
                    }

                    if (IsOperator(word))
                    {
                        var numberA = stack.Pop();
                        var numberB = stack.Pop();

                        if (numberA == 0 && word == "/")
                        {
                            throw new ArgumentException("Деление на 0!");
                        }

                        var result = ProceedOperator(numberB, numberA, word);
                        stack.Push(result);
                        continue;
                    }

                    throw new ArgumentException("Непредвиденный символ на вводе!", $"{word}");
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
