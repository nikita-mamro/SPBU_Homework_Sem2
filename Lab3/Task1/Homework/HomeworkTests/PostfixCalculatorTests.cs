using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты стекового калькулятора
    /// </summary>
    [TestClass]
    public class PostfixCalculatorTests
    {
        private ICalculator calculator;

        [TestInitialize]
        public void Initialize()
            => calculator = new PostfixCalculator(new ListStack());

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DivisionByZeroExceptionTest()
            => calculator.GetPostfixExpressionValue("1 0 /");

        /// <summary>
        /// Тесты на исключения, выкидываемые при некорректном вводе
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoSpacesInputExceptionTest()
            => calculator.GetPostfixExpressionValue("2 2+");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OneNumberOnlyInputExceptionTest()
            => calculator.GetPostfixExpressionValue("1");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OneOperatorOnlyInputExceptionTest()
            => calculator.GetPostfixExpressionValue("+");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoOperatorsInputExceptionTest()
            => calculator.GetPostfixExpressionValue("1 2 42 5 4");

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NoNumbersInputExceptionTest()
            => calculator.GetPostfixExpressionValue("+ - * / +");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OneNumberOneOperatorInputExceptionTest()
            => calculator.GetPostfixExpressionValue("1+");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TooManyNumbersInputExceptionTest()
            => calculator.GetPostfixExpressionValue("1 3 2 4 2 3 2 1 24 12 41 + - * /");

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TooManyOperatorsInputExceptionTest()
            => calculator.GetPostfixExpressionValue("1 2 / * - +");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UnexpectedSymbolInputExceptionTest()
            => calculator.GetPostfixExpressionValue("2 2 a a v");

        /// <summary>
        /// Тесты правильности непосредственно вычисления значения выражения
        /// </summary>
        private void OneAdditionTest(int a, int b, int expected)
        {
            var calculated = calculator.GetPostfixExpressionValue(a.ToString() + " " + b.ToString() + " +");
            Assert.AreEqual(expected, calculated);
        }

        private void OneSubstractionTest(int a, int b, int expected)
        {
            var calculated = calculator.GetPostfixExpressionValue(a.ToString() + " " + b.ToString() + " -");
            Assert.AreEqual(expected, calculated);
        }

        private void OneMultiplicationTest(int a, int b, int expected)
        {
            var calculated = calculator.GetPostfixExpressionValue(a.ToString() + " " + b.ToString() + " *");
            Assert.AreEqual(expected, calculated);
        }

        private void OneDivisionTest(int a, int b, int expected)
        {
            var calculated = calculator.GetPostfixExpressionValue(a.ToString() + " " + b.ToString() + " /");
            Assert.AreEqual(expected, calculated);
        }

        /// <summary>
        /// Тесты сложения
        /// </summary>
        /// <param name="a">Первое слагаемое</param>
        /// <param name="b">Второе слагаемое</param>
        /// <param name="expected">Ожидаемый результат сложения</param>
        [TestMethod]
        [DataRow(134, 500, 634)]
        [DataRow(15, 1000000, 1000015)]
        [DataRow(1234567, 1234567, 2469134)]
        [DataRow(0, 133, 133)]
        [DataRow(0, int.MaxValue, int.MaxValue)]
        [DataRow(0, 0, 0)]
        [DataRow(0, -124, -124)]
        [DataRow(0, -int.MaxValue, -int.MaxValue)]
        [DataRow(210, -100, 110)]
        [DataRow(210, -1000, -790)]
        [DataRow(1000, -int.MaxValue, 1000 - int.MaxValue)]
        [DataRow(int.MaxValue, -1242, int.MaxValue - 1242)]
        [DataRow(-100, -13, -113)]
        [DataRow(-12, -1234567, -1234579)]
        [DataRow(-222222, -10, -222232)]
        [DataRow(-333333, -111111, -444444)]
        public void AdditionTest(int a, int b, int expected)
            => OneAdditionTest(a, b, expected);

        /// <summary>
        /// Тесты вычитания
        /// </summary>
        /// <param name="a">Уменьшаемое</param>
        /// <param name="b">Вычитаемое</param>
        /// <param name="expected">Ожидаемая разность</param>
        [TestMethod]
        [DataRow(200, 14, 186)]
        [DataRow(134, 500, -366)]
        [DataRow(15, 1000000, -999985)]
        [DataRow(1000000, 10, 999990)]
        [DataRow(4127429, 1241245, 2886184)]
        [DataRow(0, 133, -133)]
        [DataRow(0, int.MaxValue, -int.MaxValue)]
        [DataRow(0, 0, 0)]
        [DataRow(0, -124, 124)]
        [DataRow(0, -int.MaxValue, int.MaxValue)]
        [DataRow(210, -100, 310)]
        [DataRow(1000, -666666, 667666)]
        [DataRow(4155123, -1242, 4156365)]
        [DataRow(-100, -13, -87)]
        [DataRow(-12, -1234567, 1234555)]
        [DataRow(-222222, -10, -222212)]
        [DataRow(-333333, -111111, -222222)]
        public void SubstractionTest(int a, int b, int expected)
            => OneSubstractionTest(a, b, expected);

        /// <summary>
        /// Тесты умножения
        /// </summary>
        /// <param name="a">Первый сомножитель</param>
        /// <param name="b">Второй сомножитель</param>
        /// <param name="expected">Ожидаемый резултат произведения</param>
        [TestMethod]
        [DataRow(134, 500, 67000)]
        [DataRow(15, 1000000, 15000000)]
        [DataRow(1000000, 10, 10000000)]
        [DataRow(12345, 12345, 152399025)]
        [DataRow(0, 133, 0)]
        [DataRow(133, 0, 0)]
        [DataRow(0, int.MaxValue, 0)]
        [DataRow(0, 0, 0)]
        [DataRow(0, -124, 0)]
        [DataRow(0, -int.MaxValue, 0)]
        [DataRow(210, -100, -21000)]
        [DataRow(123, -124125, -15267375)]
        [DataRow(5123521, -124, -635316604)]
        [DataRow(-100, -13, 1300)]
        [DataRow(-12, -1234567, 14814804)]
        [DataRow(-222222, -10, 2222220)]
        [DataRow(-33333, -11111, 370362963)]
        public void MultiplicationTest(int a, int b, int expected)
            => OneMultiplicationTest(a, b, expected);

        /// <summary>
        /// Тесты деления
        /// </summary>
        /// <param name="a">Делимое</param>
        /// <param name="b">Делитель</param>
        /// <param name="expected">Ожидаемое частное</param>
        [TestMethod]
        [DataRow(1000, 500, 2)]
        [DataRow(14251, 123, 115)]
        [DataRow(12, 500, 0)]
        [DataRow(15, 1000000, 0)]
        [DataRow(1000000, 10, 100000)]
        [DataRow(1241241, 154154, 8)]
        [DataRow(1254162, 33427880, 0)]
        [DataRow(0, 133, 0)]
        [DataRow(0, int.MaxValue, 0)]
        [DataRow(0, -124, 0)]
        [DataRow(0, -int.MaxValue, 0)]
        [DataRow(1500, -300, -5)]
        [DataRow(14152, -124, -114)]
        [DataRow(210, -1000, 0)]
        [DataRow(1000, -int.MaxValue, 0)]
        [DataRow(110603750, -4657, -23750)]
        [DataRow(543721387, -10334, -52614)]
        [DataRow(-128, -4, 32)]
        [DataRow(-100, -13, 7)]
        [DataRow(-12, -1234567, 0)]
        [DataRow(-113508795, -13521, 8395)]
        [DataRow(-222222, -10, 22222)]
        [DataRow(-333333, -111111, 3)]
        [DataRow(-6754172, -35871, 188)]
        [DataRow(-357681254, -935723523, 0)]
        public void DivisionTest(int a, int b, int expected)
            => OneDivisionTest(a, b, expected);

        /// <summary>
        /// Тесты длинных выражений
        /// </summary>
        [TestMethod]
        public void LongExpressionTest1()
        {
            var calculated = calculator.GetPostfixExpressionValue("2 2 + 47 * 15 15 + 10 - *");
            Assert.AreEqual(3760 , calculated);
        }

        [TestMethod]
        public void LongExpressionTest2()
        {
            var calculated = calculator.GetPostfixExpressionValue("43 12 + 6 * 7 + 3 + 34 /");
            Assert.AreEqual(10, calculated);
        }
        
        [TestMethod]
        public void LongExpressionTest3()
        {
            var calculated = calculator.GetPostfixExpressionValue("28 13 * 6 7 + 3 5 - * *");
            Assert.AreEqual(-9464, calculated);
        }
        
        [TestMethod]
        public void LongExpressionTest4()
        {
            var calculated = calculator.GetPostfixExpressionValue("2 15 - 3 6 - *");
            Assert.AreEqual(39, calculated);
        }
        
        [TestMethod]
        public void LongExpressionTest5()
        {
            var calculated = calculator.GetPostfixExpressionValue("85 13 * 5 / 25 15 + 5 / -");
            Assert.AreEqual(213, calculated);
        }
    }
}