namespace ParseTree
{
    /// <summary>
    /// Интерфейс дерева разбора арифметического выражения
    /// </summary>
    public interface IParseTree
    {
        /// <summary>
        /// Считает значение переданного в виде строки в конструктор дерева арифметического выражения
        /// </summary>
        /// <returns>Значение выражения</returns>
        int Calculate();

        /// <summary>
        /// Распечатывает переданное в виде строки в конструктор дерева выражение с помощью обхода дерева
        /// </summary>
        string GetExpression();
    }
}
