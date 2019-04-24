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

        [TestMethod]
        public void CanDigitBeAddedTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CanCommaBeAddedTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldZeroBeAddedBeforeCommaTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CanLeftBracketBeAddedTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CanRightBracketBeAddedTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void CanExpressionBeCalculatedTest()
        {
            Assert.Fail();
        }
    }
}