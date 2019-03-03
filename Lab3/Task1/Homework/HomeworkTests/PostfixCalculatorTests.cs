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
        /// Тесты на исключения, выкидываемые при некорректном вводе
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

        /// <summary>
        /// Тесты правильности непосредственно вычисления значения выражения
        /// </summary>
        private void OneAdditionTest(int a, int b, int expected)
        {
            var calculated = calculator.GetPostfixExpressionValue(a.ToString() + " + " + b.ToString());
            Assert.AreEqual(expected, calculated);
        }

        private void OneSubstrationTest(int a, int b, int expected)
        {
            var calculated = calculator.GetPostfixExpressionValue(a.ToString() + " - " + b.ToString());
            Assert.AreEqual(expected, calculated);
        }

        private void OneMultiplicationTest(int a, int b, int expected)
        {
            var calculated = calculator.GetPostfixExpressionValue(a.ToString() + " * " + b.ToString());
            Assert.AreEqual(expected, calculated);
        }

        private void OneDivisionTest(int a, int b, int expected)
        {
            var calculated = calculator.GetPostfixExpressionValue(a.ToString() + " / " + b.ToString());
            Assert.AreEqual(expected, calculated);
        }

        [TestMethod()]
        public void TwoOperandsCalculationsTest()
        {
            for (var i = -1000000; i < 1000000; ++i)
            {
                for (var j = -1000000; j > 1000000; ++j)
                {
                    OneAdditionTest(i, j, i + j);
                    OneSubstrationTest(i, j, i - j);
                    OneMultiplicationTest(i, j, i * j);
                    OneDivisionTest(i, j, i / j);
                }
            }
        }

        /// <summary>
        /// Тесты длинных выражений
        /// </summary>
        [TestMethod()]
        public void LongExpressionTest1()
        {
            var calculated = calculator.GetPostfixExpressionValue("2 2 + 47 * 15 15 + 10 - *");
            Assert.AreEqual(3760 , calculated);
        }

        [TestMethod()]
        public void LongExpressionTest2()
        {
            var calculated = calculator.GetPostfixExpressionValue("43 12 + 6 * 7 + 3 + 34 /");
            Assert.AreEqual(10, calculated);
        }
        
        [TestMethod()]
        public void LongExpressionTest3()
        {
            var calculated = calculator.GetPostfixExpressionValue("28 13 * 6 7 + 3 5 - * *");
            Assert.AreEqual(-9464, calculated);
        }
        
        [TestMethod()]
        public void LongExpressionTest4()
        {
            var calculated = calculator.GetPostfixExpressionValue("2 15 - 3 6 - *");
            Assert.AreEqual(39, calculated);
        }
        
        [TestMethod()]
        public void LongExpressionTest5()
        {
            var calculated = calculator.GetPostfixExpressionValue("85 13 * 5 / 25 15 + 5 / -");
            Assert.AreEqual(213, calculated);
        }
    }
}