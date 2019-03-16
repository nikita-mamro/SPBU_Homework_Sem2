using System;

namespace ParseTree
{
    /// <summary>
    /// Класс, реализующий дерево арифметического разбора
    /// </summary>
    public class ParseTree : IParseTree
    {
        /// <summary>
        /// Класс, реализующий узел дерева
        /// </summary>
        private abstract class Node
        {
            /// <summary>
            /// Возвращает значение арифметического выражения, представимого в виде дерева разбора с корнем в данном узле
            /// </summary>
            /// <returns></returns>
            abstract public int Calculate();
            abstract public void CreateNode();
        }

        /// <summary>
        /// Класс реализующий узел-операнд дерева разбора
        /// </summary>
        private class Operand : Node
        {
            private int data;

            public override int Calculate()
                => this.data;

            public override void CreateNode()
            {
                throw new NotImplementedException();
            }

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
        private class Operator : Node
        {
            private string data;
            public Node Left { get; set; }
            public Node Right { get; set; }

            public override int Calculate()
            {
                try
                {
                    return OperationHandler.OperationHandler.ProceedOperation(Left.Calculate(), data, Right.Calculate());
                }
                catch (DivideByZeroException)
                {
                    throw;
                }
                catch (ArgumentException)
                {
                    throw;
                }
            }

            public override void CreateNode()
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Конструктор класса Operator
            /// </summary>
            /// <param name="data">Строка из 1 символа-оператор(+ или - или * или /)</param>
            public Operator(string data)
            {
                if (!Validators.OperatorsValidator.IsOperator(data))
                {
                    throw new ArgumentException("Выражение задано в некорректном формате :(\nПроверьте правильность введённых данных.");
                }

                this.data = data;
            }

            public override string ToString()
                => $"({Left.ToString()} {data} {Right.ToString()})";
        }

        /// <summary>
        /// Узел-корень дерева
        /// </summary>
        private Node root;

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
            int index = 0;
            root = CreateNode(expression.Split(' '), ref index);
        }

        private Node CreateNode(string[] expression, ref int index)
        {
            Node node = null;

            if (expression[index] == "(")
            {
                ++index;
                node = new Operator(expression[index]);

                ++index;
                (node as Operator).Left = CreateNode(expression, ref index);

                ++index;
                (node as Operator).Right = CreateNode(expression, ref index);

                return node;
            }
            else if (int.TryParse(expression[index], out int number))
            {
                node = new Operand(number);
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
        {
            return root.Calculate();
        }

        public string GetExpression()
        {
            return root.ToString();
        }
    }
}
