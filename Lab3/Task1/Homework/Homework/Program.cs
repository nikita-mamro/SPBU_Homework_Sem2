using System;

namespace Homework
{
    class Program
    {
        static void Main(string[] args)
        {
            ICalculator calculator = GetStackType();

            Console.WriteLine("Для корректной работы разделяйте все операнды и операторы пробелами");
            Console.WriteLine("Введите целочисленное выражение в постфиксной форме:");

            var inputExpression = Console.ReadLine();

            try
            {
                Console.WriteLine($"Значение выражения: {calculator.GetPostfixExpressionValue(inputExpression)}");
            }
            catch (InvalidOperationException operationError)
            {
                Console.WriteLine(operationError.Message);
            }
            catch (ArgumentException argumentError)
            {
                Console.WriteLine(argumentError.Message);
            }
        }

        private static ICalculator GetStackType()
        {
            while (true)
            {
                Console.WriteLine("Выберите используемый тип стека:");
                Console.WriteLine("1 - На массиве");
                Console.WriteLine("2 - На списке");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("Выбранная реализация стека: на массиве");
                            return new PostfixCalculator(new ArrayStack());
                        case 2:
                            Console.WriteLine("Выбранная реализация стека: на односвязномм списке");
                            return new PostfixCalculator(new ListStack());
                        default:
                            Console.WriteLine("Выберете один из двух типов стека.");
                            continue;
                    }
                }
                Console.WriteLine("Выберете один из двух типов стека.");
            }
        }
    }
}
