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
        {
            calculator = new PostfixCalculator(new ListStack());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DivisionByZeroExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1 0 /");
        }

        /// <summary>
        /// Тесты на исключения, выкидываемые при некорректном вводе
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoSpacesInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("2 2+");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OneNumberOnlyInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OneOperatorOnlyInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("+");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoOperatorsInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1 2 42 5 4");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NoNumbersInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("+ - * / +");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OneNumberOneOperatorInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1+");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TooManyNumbersInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1 3 2 4 2 3 2 1 24 12 41 + - * /");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TooManyOperatorsInputExceptionTest()
        {
            calculator.GetPostfixExpressionValue("1 2 / * - +");
        }

        [TestMethod]
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
        /// Под "big"("bigger") подразумевается большая(больше) абсолютная величина
        /// </summary>

        [TestMethod]
        public void PositivePositiveAdditionTest()
        {
            OneAdditionTest(134, 500, 634);
        }

        [TestMethod]
        public void PositiveBigPositiveAdditionTest()
        {
            OneAdditionTest(15, 1000000, 1000015);
        }

        [TestMethod]
        public void BigPositivePositiveAdditionTest()
        {
            OneAdditionTest(1000000, 10, 1000010);
        }

        [TestMethod]
        public void BigPositiveBigPositiveAdditionTest()
        {
            OneAdditionTest(1234567, 1234567, 2469134);
        }

        [TestMethod]
        public void ZeroPositiveAdditionTest()
        {
            OneAdditionTest(0, 133, 133);
        }

        [TestMethod]
        public void ZeroBigPositiveAdditionTest()
        {
            OneAdditionTest(0, int.MaxValue, int.MaxValue);
        }

        [TestMethod]
        public void ZeroZeroAdditionTest()
        {
            OneAdditionTest(0, 0, 0);
        }

        [TestMethod]
        public void ZeroNegativeAdditionTest()
        {
            OneAdditionTest(0, -124, -124);
        }

        [TestMethod]
        public void ZeroBigNegativeAdditionTest()
        {
            OneAdditionTest(0, -int.MaxValue, -int.MaxValue);
        }

        [TestMethod]
        public void PositiveNegativeAdditionTest()
        {
            OneAdditionTest(210, -100, 110);
        }

        [TestMethod]
        public void PositiveBiggerNegativeAdditionTest()
        {
            OneAdditionTest(210, -1000, -790);
        }

        [TestMethod]
        public void PositiveBigNegativeAdditionTest()
        {
            OneAdditionTest(1000, -int.MaxValue, 1000 - int.MaxValue);
        }

        [TestMethod]
        public void BigPositiveNegativeAdditionTest()
        {
            OneAdditionTest(int.MaxValue, -1242, int.MaxValue - 1242);
        }

        [TestMethod]
        public void NegativeNegativeAdditionTest()
        {
            OneAdditionTest(-100, -13, -113);
        }

        [TestMethod]
        public void NegativeBigNegativeAdditionTest()
        {
            OneAdditionTest(-12, -1234567, -1234579);
        }

        [TestMethod]
        public void BigNegativeNegativeAdditionTest()
        {
            OneAdditionTest(-222222, -10, -222232);
        }

        [TestMethod]
        public void BigNegativeBigNegativeAdditionTest()
        {
            OneAdditionTest(-333333, -111111, -444444);
        }

        [TestMethod]
        public void PositivePositiveSubstractionTest()
        {
            OneSubstractionTest(200, 14, 186);
        }

        [TestMethod]
        public void PositiveBiggerPositiveSubstractionTest()
        {
            OneSubstractionTest(134, 500, -366);
        }

        [TestMethod]
        public void PositiveBigPositiveSubstractionTest()
        {
            OneSubstractionTest(15, 1000000, -999985);
        }

        [TestMethod]
        public void BigPositivePositiveSubstractionTest()
        {
            OneSubstractionTest(1000000, 10, 999990);
        }

        [TestMethod]
        public void BigPositiveBigPositiveSubstractionTest()
        {
            OneSubstractionTest(4127429, 1241245, 2886184);
        }

        [TestMethod]
        public void ZeroPositiveSubstractionTest()
        {
            OneSubstractionTest(0, 133, -133);
        }

        [TestMethod]
        public void ZeroBigPositiveSubstractionTest()
        {
            OneSubstractionTest(0, int.MaxValue, -int.MaxValue);
        }

        [TestMethod]
        public void ZeroZeroSubstractionTest()
        {
            OneSubstractionTest(0, 0, 0);
        }

        [TestMethod]
        public void ZeroNegativeSubstractionTest()
        {
            OneSubstractionTest(0, -124, 124);
        }

        [TestMethod]
        public void ZeroBigNegativeSubstractionTest()
        {
            OneSubstractionTest(0, -int.MaxValue, int.MaxValue);
        }

        [TestMethod]
        public void PositiveNegativeSubstractionTest()
        {
            OneSubstractionTest(210, -100, 310);
        }

        [TestMethod]
        public void PositiveBigNegativeSubstractionTest()
        {
            OneSubstractionTest(1000, -666666, 667666);
        }

        [TestMethod]
        public void BigPositiveNegativeSubstractionTest()
        {
            OneSubstractionTest(4155123, -1242, 4156365);
        }

        [TestMethod]
        public void NegativeNegativeSubstractionTest()
        {
            OneSubstractionTest(-100, -13, -87);
        }

        [TestMethod]
        public void NegativeBigNegativeSubstractionTest()
        {
            OneSubstractionTest(-12, -1234567, 1234555);
        }

        [TestMethod]
        public void BigNegativeNegativeSubstractionTest()
        {
            OneSubstractionTest(-222222, -10, -222212);
        }

        [TestMethod]
        public void BigNegativeBigNegativeSubstractionTest()
        {
            OneSubstractionTest(-333333, -111111, -222222);
        }

        [TestMethod]
        public void PositivePositiveMultiplicationTest()
        {
            OneMultiplicationTest(134, 500, 67000);
        }

        [TestMethod]
        public void PositiveBigPositiveMultiplicationTest()
        {
            OneMultiplicationTest(15, 1000000, 15000000);
        }

        [TestMethod]
        public void BigPositivePositiveMultiplicationTest()
        {
            OneMultiplicationTest(1000000, 10, 10000000);
        }

        [TestMethod]
        public void BigPositiveBigPositiveMultiplicationTest()
        {
            OneMultiplicationTest(12345, 12345, 152399025);
        }

        [TestMethod]
        public void ZeroPositiveMultiplicationTest()
        {
            OneMultiplicationTest(0, 133, 0);
        }

        [TestMethod]
        public void PositiveZeroMultiplicationTest()
        {
            OneMultiplicationTest(133, 0, 0);
        }

        [TestMethod]
        public void ZeroBigPositiveMultiplicationTest()
        {
            OneMultiplicationTest(0, int.MaxValue, 0);
        }

        [TestMethod]
        public void ZeroZeroMultiplicationTest()
        {
            OneMultiplicationTest(0, 0, 0);
        }

        [TestMethod]
        public void ZeroNegativeMultiplicationTest()
        {
            OneMultiplicationTest(0, -124, 0);
        }

        [TestMethod]
        public void ZeroBigNegativeMultiplicationTest()
        {
            OneMultiplicationTest(0, -int.MaxValue, 0);
        }

        [TestMethod]
        public void PositiveNegativeMultiplicationTest()
        {
            OneMultiplicationTest(210, -100, -21000);
        }

        [TestMethod]
        public void PositiveBigNegativeMultiplicationTest()
        {
            OneMultiplicationTest(123, -124125, -15267375);
        }

        [TestMethod]
        public void BigPositiveNegativeMultiplicationTest()
        {
            OneMultiplicationTest(5123521, -124, -635316604);
        }

        [TestMethod]
        public void NegativeNegativeMultiplicationTest()
        {
            OneMultiplicationTest(-100, -13, 1300);
        }

        [TestMethod]
        public void NegativeBigNegativeMultiplicationTest()
        {
            OneMultiplicationTest(-12, -1234567, 14814804);
        }

        [TestMethod]
        public void BigNegativeNegativeMultiplicationTest()
        {
            OneMultiplicationTest(-222222, -10, 2222220);
        }

        [TestMethod]
        public void BigNegativeBigNegativeMultiplicationTest()
        {
            OneMultiplicationTest(-33333, -11111, 370362963);
        }

        [TestMethod]
        public void BiggerPositivePositiveDivisionTest()
        {
            OneDivisionTest(1000, 500, 2);
        }

        [TestMethod]
        public void BiggerPositiveNotDivisiblePositiveDivisionTest()
        {
            OneDivisionTest(14251, 123, 115);
        }

        [TestMethod]
        public void PositiveBiggerPositiveDivisionTest()
        {
            OneDivisionTest(12, 500, 0);
        }

        [TestMethod]
        public void PositiveBigPositiveDivisionTest()
        {
            OneDivisionTest(15, 1000000, 0);
        }

        [TestMethod]
        public void BigPositivePositiveDivisionTest()
        {
            OneDivisionTest(1000000, 10, 100000);
        }

        [TestMethod]
        public void BigPositiveBigPositiveDivisionTest()
        {
            OneDivisionTest(1241241, 154154, 8);
        }

        [TestMethod]
        public void BigPositiveBiggerPositiveDivisionTest()
        {
            OneDivisionTest(1254162, 33427880, 0);
        }

        [TestMethod]
        public void ZeroPositiveDivisionTest()
        {
            OneDivisionTest(0, 133, 0);
        }

        [TestMethod]
        public void ZeroBigPositiveDivisionTest()
        {
            OneDivisionTest(0, int.MaxValue, 0);
        }

        [TestMethod]
        public void ZeroNegativeDivisionTest()
        {
            OneDivisionTest(0, -124, 0);
        }

        [TestMethod]
        public void ZeroBigNegativeDivisionTest()
        {
            OneDivisionTest(0, -int.MaxValue, 0);
        }

        [TestMethod]
        public void PositiveDivisibleNegativeDivisionTest()
        {
            OneDivisionTest(1500, -300, -5);
        }

        [TestMethod]
        public void PositiveNotDivisibleNegativeDivisionTest()
        {
            OneDivisionTest(14152, -124, -114);
        }

        [TestMethod]
        public void PositiveBiggerNegativeDivisionTest()
        {
            OneDivisionTest(210, -1000, 0);
        }

        [TestMethod]
        public void PositiveBigNegativeDivisionTest()
        {
            OneDivisionTest(1000, -int.MaxValue, 0);
        }

        [TestMethod]
        public void BigPositiveDivisableNegativeDivisionTest()
        {
            OneDivisionTest(110603750, -4657, -23750);
        }

        [TestMethod]
        public void BigPositiveNotDivisableNegativeDivisionTest()
        {
            OneDivisionTest(543721387, -10334, -52614);
        }

        [TestMethod]
        public void NegativeDivisableNegativeAdditionTest()
        {
            OneDivisionTest(-128, -4, 32);
        }

        [TestMethod]
        public void NegativeNotDivisableNegativeAdditionTest()
        {
            OneDivisionTest(-100, -13, 7);
        }

        [TestMethod]
        public void NegativeBigNegativDivisionTest()
        {
            OneDivisionTest(-12, -1234567, 0);
        }

        [TestMethod]
        public void BigNegativeDivisableNegativeAdditionTest()
        {
            OneDivisionTest(-113508795, -13521, 8395);
        }

        [TestMethod]
        public void BigNegativeNotDivisableNegativeAdditionTest()
        {
            OneDivisionTest(-222222, -10, 22222);
        }

        [TestMethod]
        public void BigNegativeDivisableBigNegativeDivisionTest()
        {
            OneDivisionTest(-333333, -111111, 3);
        }

        [TestMethod]
        public void BigNegativeNotDivisableBigNegativeDivisionTest()
        {
            OneDivisionTest(-6754172, -35871, 188);
        }

        [TestMethod]
        public void BigNegativeBiggerNegativeDivisionTest()
        {
            OneDivisionTest(-357681254, -935723523, 0);
        }

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