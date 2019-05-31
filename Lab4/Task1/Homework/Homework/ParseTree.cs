using System;

namespace ParseTree
{
    /// <summary>
    /// Класс, реализующий дерево арифметического разбора
    /// </summary>
    public class ParseTree : IParseTree
    {
        /// <summary>
        /// Класс реализующий узел-операнд дерева разбора
        /// </summary>
        private class Operand : INode
        {
            private int data;

            public int Calculate()
                => this.data;

            /// <summary>
            /// Конструктор класса Operand
            /// </summary>
            /// <param name="data">Число из арифметического выражения</param>
            public Operand(int data)
            {
                this.data = data;
            }

            public override string ToString()
                => data.ToString();
        }

        /// <summary>
        /// Класс, реализующий узел-оператор дерева разбора
        /// </summary>
        private abstract class Operator : INode
        {
            public abstract int Calculate();
            public INode Left { get; set; }
            public INode Right { get; set; }
        }

        /// <summary>
        /// Класс, реализующий оператор сложения
        /// </summary>
        private class OperatorAdd : Operator
        {
            public override int Calculate()
                => Left.Calculate() + Right.Calculate();

            public override string ToString()
                => $"({Left.ToString()} + {Right.ToString()})";
        }

        /// <summary>
        /// Класс, реализующий оператор вычитания
        /// </summary>
        private class OperatorSubstract : Operator
        {
            public override int Calculate()
                => Left.Calculate() - Right.Calculate();

            public override string ToString()
                => $"({Left.ToString()} - {Right.ToString()})";
        }

        /// <summary>
        /// Класс, реализующий оператор умножения
        /// </summary>
        private class OperatorMultiply : Operator
        {
            public override int Calculate()
                => Left.Calculate() * Right.Calculate();

            public override string ToString()
                => $"({Left.ToString()} * {Right.ToString()})";
        }

        /// <summary>
        /// Класс, реализующий оператор деления
        /// </summary>
        private class OperatorDivide : Operator
        {
            public override int Calculate()
                => Left.Calculate() / Right.Calculate();

            public override string ToString()
                => $"({Left.ToString()} / {Right.ToString()})";
        }

        /// <summary>
        /// Узел-корень дерева
        /// </summary>
        private INode root;

        public ParseTree(string expression)
        {
            BuildTree(expression);
        }

        /// <summary>
        /// Строит дерево разбора переданного выражения
        /// </summary>
        /// <param name="expression">Арифметическое выражение</param>
        private void BuildTree(string expression)
        {
            if (!BracketBalanceChecker.BracketBalanceChecker.IsBalanced(expression))
            {
                throw new ArgumentException("Введёно некорректное выражение, проверьте баланс скобок.");
            }

            int index = 0;
            root = CreateNode(expression.Split(' '), ref index);
        }

        /// <summary>
        /// Возвращает ноду, являющуюся корнем дерева, построенного по выражению
        /// </summary>
        /// <param name="expression">Арифметическое выражение</param>
        /// <param name="index">Номер символа в выражении, на котором мы находимся в текущий момент</param>
        /// <returns></returns>
        private INode CreateNode(string[] expression, ref int index)
        {
            if (expression[index] == "(")
            {
                ++index;

                Operator node;

                switch (expression[index])
                {
                    case "+":
                        node = new OperatorAdd();
                        break;
                    case "-":
                        node = new OperatorSubstract();
                        break;
                    case "*":
                        node = new OperatorMultiply();
                        break;
                    case "/":
                        node = new OperatorDivide();
                        break;
                    default:
                        throw new ArgumentException("Выражение задано в некорректном формате :(\nПроверьте правильность введённых данных.");
                }

                ++index;
                node.Left = CreateNode(expression, ref index);

                ++index;
                node.Right = CreateNode(expression, ref index);

                return node;
            }
            else if (int.TryParse(expression[index], out int number))
            {
                var node = new Operand(number);
                return node;
            }
            else if (expression[index] == ")")
            {
                ++index;

                return CreateNode(expression, ref index);
            }

            throw new ArgumentException("Выражение задано в некорректном формате :(\nПроверьте правильность введённых данных.");
        }

        public int Calculate()
            => root.Calculate();

        public string GetExpression()
            => root.ToString();
    }
}
