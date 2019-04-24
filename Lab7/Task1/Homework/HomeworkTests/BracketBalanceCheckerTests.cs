using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Validators.Tests
{
    /// <summary>
    /// Тесты класса проверяльщика баланса круглых скобок
    /// </summary>
    [TestClass]
    public class BracketBalanceCheckerTests
    {
        /// <summary>
        /// Тесты метода, проверяющего данное выражение на баланс круглых скобок
        /// </summary>
        /// <param name="expression">Передаваемое выражение</param>
        /// <param name="expected">Ожидаемый результат работы метода (true/false)</param>
        [TestMethod]
        [DataRow("", true)]
        [DataRow("hello", true)]
        [DataRow("veryveryverylongstringforreal", true)]
        [DataRow("(", false)]
        [DataRow(")", false)]
        [DataRow("(a", false)]
        [DataRow(")z", false)]
        [DataRow("d(", false)]
        [DataRow("c)", false)]
        [DataRow("()", true)]
        [DataRow("(a)", true)]
        [DataRow("(olololo)", true)]
        [DataRow("(((())))", true)]
        [DataRow("((((word))))", true)]
        [DataRow("a(b(.(t(h);)k)l)z", true)]
        [DataRow("v(x(/).),l(a(f)]);", true)]
        [DataRow("(((())", false)]
        [DataRow("v(d(a(dc(v)d)e", false)]
        [DataRow(")(", false)]
        [DataRow("c)z(cv", false)]
        [DataRow(")()()(", false)]
        [DataRow("vf)f(ads)re(qe)fd(v", false)]
        [DataRow("))()((", false)]
        [DataRow("d)t)h(y)53(r(e", false)]
        [DataRow(")))))(((((", false)]
        [DataRow("v)d)s)c)b)gf(r(e(q(r(d", false)]
        public void IsBalancedTest(string expression, bool expected)
        {
            Assert.AreEqual(expected, BracketBalanceChecker.IsBalanced(expression));
        }
    }
}