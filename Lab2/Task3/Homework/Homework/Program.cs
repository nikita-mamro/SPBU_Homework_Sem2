using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Для корректной работы разделяйте все операнды и операторы пробелами");
            Console.WriteLine("Введите выражение в постфиксной форме:");

            var inputExpression = Console.ReadLine();

            try
            {
                Console.WriteLine($"Значение выражения: {PostfixCalculator.GetPostfixExpressionValue(inputExpression)}");
            }
            catch (InvalidOperationException calculatingError)
            {
                Console.WriteLine(calculatingError.Message);
            }
        }
    }
}
