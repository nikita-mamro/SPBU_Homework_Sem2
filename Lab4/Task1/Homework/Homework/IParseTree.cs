namespace ParseTree
{
    /// <summary>
    /// Интерфейс дерева разбора арифметического выражения
    /// </summary>
    public interface IParseTree
    {
        /// <summary>
        /// Считает значение переданного в виде строки арифметического выражения
        /// </summary>
        /// <param name="expression">Арифметическое выражение</param>
        /// <returns>Значение выражения</returns>
        int Calculate(string expression);
    }
}
