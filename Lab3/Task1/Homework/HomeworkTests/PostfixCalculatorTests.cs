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
        public void PostfixCalculatorTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPostfixExpressionValueTest()
        {
            Assert.Fail();
        }
    }
}