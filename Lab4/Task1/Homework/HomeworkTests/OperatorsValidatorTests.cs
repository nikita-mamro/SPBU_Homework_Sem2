using Microsoft.VisualStudio.TestTools.UnitTesting;
using Validators;
using System;

namespace Validators.Tests
{
    /// <summary>
    /// Тесты "проверяльщика", является ли символ арифметическим оператором
    /// </summary>
    [TestClass()]
    public class OperatorsValidatorTests
    {
        /// <summary>
        /// Тест, который проверяет, что IsOperator() вернёт True только в том случае, если ему передан символ-оператор из списка {+ , - , * , /}, иначе False 
        /// </summary>
        [TestMethod()]
        public void IsOneSymbolStringOperatorTest()
        {
            for (var i = 0; i < 256; ++i)
            {
                if (i == 42 || i == 43 || i == 45 || i == 47)
                {
                    Assert.IsTrue(OperatorsValidator.IsOperator(((char)i).ToString()));

                    continue;
                }

                Assert.IsFalse(OperatorsValidator.IsOperator(((char)i).ToString()));
            }
        }

        /// <summary>
        /// Проверяем, что пустая строка - не оператор из списка {+ , - , * , /}
        /// </summary>
        [TestMethod()]
        public void EmptyStringIsNotAnOperatorTest()
        {
            Assert.IsFalse(OperatorsValidator.IsOperator(String.Empty));
        }

        /// <summary>
        /// Проверяем, что последовательность >1 символов - не оператор из списка {+ , - , * , /}
        /// </summary>
        [TestMethod()]
        public void MoreThanOneSymbolIsNotAnOperatortest()
        {
            Random random = new Random();

            string testSrting = String.Empty;

            for (var i = 2; i < 100; ++i)
            {
                for (var j = 0; j < i; ++j)
                {
                    testSrting += (char)random.Next(0, 255);
                }

                Assert.IsFalse(OperatorsValidator.IsOperator(testSrting));

                testSrting = String.Empty;
            }
        }
    }
}