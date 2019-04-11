using Microsoft.VisualStudio.TestTools.UnitTesting;
using ParseTree;
using System;
using System.IO;

namespace ParseTree.Tests
{
    /// <summary>
    /// Тесты дерева разбора
    /// </summary>
    [TestClass]
    public class ParseTreeTests
    {
        /// <summary>
        /// Тесты правильности подсчётов результата арифметического выражения
        /// </summary>
        [TestMethod]
        public void CalculateTest()
        {
            string line;

            using (var sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), "CalculateTests.txt")))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    IParseTree tree = new ParseTree(line);

                    if (tree.Calculate() != int.Parse(sr.ReadLine()))
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        /// <summary>
        /// Тесты корректности построения арифметического выражения обходом дерева
        /// </summary>
        [TestMethod]
        public void GetExpressionTest()
        {
            string line;

            using (var sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), "GetExpressionTests.txt")))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    IParseTree tree = new ParseTree(line);

                    if (tree.GetExpression() != sr.ReadLine())
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        /// <summary>
        /// Тесты бросания исключений
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OperatorWrongSymbolExceptionTest()
        {
            IParseTree tree = new ParseTree("( @ 1 1 )");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OperandWrongFormatExceptionTest()
        {
            IParseTree tree = new ParseTree("( + 1 a )");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OperatorManySymbolsExceptionTest()
        {
            IParseTree tree = new ParseTree("( +++ 1 1 )");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void DivideByZeroExceptionTest()
        {
            IParseTree tree = new ParseTree("( / 1 0 )");
            tree.Calculate();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckForSpacesExceptionTest()
        {
            IParseTree tree = new ParseTree("(+11)");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckForBracketsExceptionTest()
        {
            IParseTree tree = new ParseTree("+ + 1 1 1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckForBracketsBalanceExceptionTest()
        {
            IParseTree tree = new ParseTree("( + ( + 1 1  1");
        }
    }
}