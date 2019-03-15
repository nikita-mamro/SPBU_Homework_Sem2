using System;
using System.IO;

namespace Homework
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
        }

        private class Operand : Node
        {
            private int Data;

            public override int Calculate()
            {
                
            }

            /// <summary>
            /// Конструктор класса Operand
            /// </summary>
            /// <param name="data"></param>
            public Operand(string data)
            {
                if (!int.TryParse(data, out int addableData))
                {
                    throw new ArgumentException("Выражение задано в неверном формате :( \n Проверьте правильность введённых данных.");
                }

                Data = addableData;
            }
        }

        /// <summary>
        /// Класс, реализующий оператор как элемент дерева разбора
        /// </summary>
        private class Operator : Node
        {
            private char data;
            private Node left;
            private Node right;

            public override int Calculate()
            {

            }

            public Operator(string data)
            {

            }
        }

        /// <summary>
        /// Узел-корень дерева
        /// </summary>
        private Node root;

        public int Calculate()
        {
            return 0;
        }
    }
}
