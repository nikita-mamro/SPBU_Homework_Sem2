namespace Validators
{
    /// <summary>
    /// Класс, реализующий проверку, является ли строка оператором
    /// </summary>
    public static class OperatorsValidator
    {
        /// <summary>
        /// Проверяет, является ли данная строка оператором
        /// </summary>
        /// <param name="input">Передаваемый символ</param>
        /// <returns>True, если строка состоит из 1 символа-оператора. В противном случае False</returns>
        public static bool IsOperator(string input)
            => input.Length == 1 && (input[0] == '+' || input[0] == '-' || input[0] == '*' || input[0] == '/');
    }
}
