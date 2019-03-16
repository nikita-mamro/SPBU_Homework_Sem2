using System;

namespace OperationHandler
{
    /// <summary>
    /// Класс, реализующий подсчёт результата бинарной операции
    /// </summary>
    public static class OperationHandler
    {
        /// <summary>
        /// Метод, ищущий результат бинарной операции.
        /// </summary>
        /// <param name="operandA">Первый операнд</param>
        /// <param name="theOperator">Оператор</param>
        /// <param name="operandB">Второй операнд</param>
        /// <returns>Результат применения оператора к паре операндов</returns>
        public static int ProceedOperation(int operandA, string theOperator, int operandB)
        {
            if (!Validators.OperatorsValidator.IsOperator(theOperator))
            {
                throw new ArgumentException("Непредвиденный символ там, где ожидался оператор :( \n Проверьте правильность введённых данных.");
            }

            switch (theOperator[0])
            {
                case '+':
                    return operandA + operandB;
                case '-':
                    return operandA - operandB;
                case '*':
                    return operandA * operandB;
                case '/':
                    return operandA / operandB;
                default:
                    throw new ArgumentException("Непредвиденный символ там, где ожидался оператор :( \n Проверьте правильность введённых данных.");
            }
        }
    }
}
