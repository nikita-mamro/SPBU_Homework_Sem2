using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты стекового калькулятора
    /// </summary>
    [TestClass()]
    public class PostfixCalculatorTests
    {
        private ICalculator calculator;

        [TestInitialize()]
        public void Initialize()
        {
            calculator = new PostfixCalculator(new ListStack());
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void DivisionByZeroExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1 0 /");
        }

        /// <summary>
        /// Testing throwing exceptions when input format is incorrect
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void NoSpacesInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("2 2+");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void OneNumberOnlyInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void OneOperatorOnlyInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("+");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void NoOperatorsInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1 2 42 5 4");
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NoNumbersInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("+ - * / +");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void OneNumberOneOperatorInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1+");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void TooManyNumbersInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1 3 2 4 2 3 2 1 24 12 41 + - * /");
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TooManyOperatorsInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1 2 / * - +");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void UnexpectedSymbolInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("2 2 a a v");
        }
    }
}