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
        public void UndefinedPostfixExpressionTest()
        {
            calculator.GetPostfixExpressionValue("1 1 + 4");
        }
    }
}