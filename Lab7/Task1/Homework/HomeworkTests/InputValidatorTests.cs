using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.Tests
{
    [TestClass]
    public class InputValidatorTests
    {
        /// <summary>
        /// Тест метода, проверяющего, является ли символ оператором
        /// </summary>
        [TestMethod]
        public void IsOperatorTest()
        {
            for (var c = char.MinValue; c < char.MaxValue; ++c)
            {
                Assert.AreEqual((c == '+' || c == '-' || c == '×' || c == '÷'), InputValidator.IsOperator(c));
            }
        }

        /// <summary>
        /// Тесты метода, проверяющего, можно ли добавить в конец выражения оператор, не нарушив корректности
        /// </summary>
        [TestMethod]
        [DataRow("", true, true)]
        [DataRow("", false, false)]
        [DataRow("1", true, true)]
        [DataRow("1", false, true)]
        [DataRow("1+1", true, true)]
        [DataRow("1+1", false, true)]
        [DataRow("(2-3", true, true)]
        [DataRow("(2-3", false, true)]
        [DataRow("(2+2)", true, true)]
        [DataRow("(2+2)", false, true)]
        [DataRow("0,", true, false)]
        [DataRow("0,", false, false)]
        [DataRow("100,", true, false)]
        [DataRow("100,", false, false)]
        [DataRow("1+", true, true)]
        [DataRow("1+", false, false)]
        [DataRow("3-", true, true)]
        [DataRow("3-", false, false)]
        [DataRow("5×", true, true)]
        [DataRow("5×", false, false)]
        [DataRow("7÷", true, true)]
        [DataRow("7÷", false, false)]
        [DataRow("(", true, true)]
        [DataRow("(", false, false)]
        [DataRow("--", true, false)]
        [DataRow("--", false, false)]
        [DataRow("(2+2)--", true, false)]
        [DataRow("(2+2)--", false, false)]
        [DataRow("(-", true, false)]
        [DataRow("(-", false, false)]
        public void CanOperatorBeAddedTest(string expression, bool isMinus, bool expected)
        {
            Assert.AreEqual(expected, InputValidator.CanOperatorBeAdded(expression, isMinus));
        }

        /// <summary>
        /// Тесты метода, проверяющего, можно ли добавить в конец выражения цифру, не нарушив корректности
        /// </summary>
        [DataRow("", true)]
        [DataRow("-", true)]
        [DataRow("1", true)]
        [DataRow("1+", true)]
        [DataRow("3-", true)]
        [DataRow("5×", true)]
        [DataRow("7÷", true)]
        [DataRow("(", true)]
        [DataRow("(2", true)]
        [DataRow("(-", true)]
        [DataRow("(0)", false)]
        [TestMethod]
        public void CanDigitBeAddedTest(string expression, bool expected)
        {
            Assert.AreEqual(expected, InputValidator.CanDigitBeAdded(expression));
        }

        /// <summary>
        /// Тесты метода, проверяющего, можно ли добавить в конец выражения запятую, не нарушив корректности
        /// </summary>
        [DataRow("", true)]
        [DataRow(",", false)]
        [DataRow("23,24352", false)]
        [DataRow("1", true)]
        [DataRow("0", true)]
        [DataRow("(", true)]
        [DataRow("1+", true)]
        [DataRow("3-", true)]
        [DataRow("5×", true)]
        [DataRow("7÷", true)]
        [DataRow("(-", true)]
        [DataRow("(2+2)", false)]
        [TestMethod]
        public void CanCommaBeAddedTest(string expression, bool expected)
        {
            Assert.AreEqual(expected, InputValidator.CanCommaBeAdded(expression));
        }

        /// <summary>
        /// Тесты метода, проверяющего, нужно ли перед введённой запятой добавить 0
        /// </summary>
        [DataRow("", true)]
        [DataRow("(", true)]
        [DataRow("+", true)]
        [DataRow("-", true)]
        [DataRow("×", true)]
        [DataRow("÷", true)]
        [DataRow("1", false)]
        [DataRow("93487", false)]
        [TestMethod]
        public void ShouldZeroBeAddedBeforeCommaTest(string expression, bool expected)
        {
            Assert.AreEqual(expected, InputValidator.ShouldZeroBeAddedBeforeComma(expression));
        }

        /// <summary>
        /// Тесты метода, проверяющего, можно ли добавить в конец выражения открывающую круглую скобку, не нарушив корректности
        /// </summary>
        [DataRow("", true)]
        [DataRow("1", false)]
        [DataRow(",", false)]
        [DataRow("+", true)]
        [DataRow("-", true)]
        [DataRow("×", true)]
        [DataRow("÷", true)]
        [TestMethod]
        public void CanLeftBracketBeAddedTest(string expression, bool expected)
        {
            Assert.AreEqual(expected, InputValidator.CanLeftBracketBeAdded(expression));
        }

        /// <summary>
        /// Тесты метода, проверяющего, можно ли добавить в конец выражения закрывающую круглую скобку, не нарушив корректности
        /// </summary>
        [DataRow("", false)]
        [DataRow("(1", true)]
        [DataRow("(1 + 1", true)]
        [DataRow("1", false)]
        [DataRow("(", false)]
        [DataRow("((((((", false)]
        [DataRow("((((((3", true)]
        [DataRow(",", false)]
        [DataRow("+", false)]
        [DataRow("-", false)]
        [DataRow("×", false)]
        [DataRow("÷", false)]
        [TestMethod]
        public void CanRightBracketBeAddedTest(string expression, bool expected)
        {
            Assert.AreEqual(expected, InputValidator.CanRightBracketBeAdded(expression));
        }

        /// <summary>
        /// Тесты метода, проверяющего, не умудрился ои пользователь накосячить 
        /// даже с учётом старающегося этого не допустить помощника ввода
        /// </summary>
        [DataRow("", false)]
        [DataRow("1", true)]
        [DataRow("1+1", true)]
        [DataRow("(1", false)]
        [DataRow("(1+(1+1)", false)]
        [DataRow("(1+(1+1))", true)]
        [DataRow("1,", false)]
        [DataRow("1+", false)]
        [DataRow("1-", false)]
        [DataRow("1×", false)]
        [DataRow("1÷", false)]
        [TestMethod]
        public void CanExpressionBeCalculatedTest(string expression, bool expected)
        {
            Assert.AreEqual(expected, InputValidator.CanExpressionBeCalculated(expression));
        }
    }
}