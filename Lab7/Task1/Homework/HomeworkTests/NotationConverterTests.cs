using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Convertors.Tests
{
    /// <summary>
    /// Тесты класса, конвертирущего корректную строку в инфиксной записи в токены строки в обратной польской нотации
    /// </summary>
    [TestClass]
    public class NotationConverterTests
    {
        /// <summary>
        /// Тесты основного метода-конвертора
        /// </summary>
        [DataRow("1", "1")]
        [DataRow("1+2", "12+")]
        [DataRow("1-2", "12-")]
        [DataRow("1×2", "12×")]
        [DataRow("1÷2", "12÷")]
        [DataRow("1+2+3", "12+3+")]
        [DataRow("1-2-3", "12-3-")]
        [DataRow("1×2×3", "12×3×")]
        [DataRow("1÷2÷3", "12÷3÷")]
        [DataRow("(1+2)×3", "12+3×")]
        [DataRow("1+2×3", "123×+")]
        [DataRow("(1+2)÷3", "12+3÷")]
        [DataRow("1+2÷3", "123÷+")]
        [TestMethod]
        public void InfixToReversePolishNotationTest(string expression, string expected)
        {
            var res = NotationConverter.InfixToReversePolishNotation(expression);
            string resString = "";

            foreach (var token in res)
            {
                resString += token;
            }

            Assert.AreEqual(expected, resString);
        }
    }
}