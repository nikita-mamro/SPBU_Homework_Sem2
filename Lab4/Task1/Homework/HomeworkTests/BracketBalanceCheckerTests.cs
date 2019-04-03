using Microsoft.VisualStudio.TestTools.UnitTesting;
using BracketBalanceChecker;
using System;
using System.IO;

namespace BracketBalanceChecker.Tests
{
    /// <summary>
    /// Тесты проверяльщика скобок
    /// </summary>
    [TestClass()]
    public class BracketBalanceCheckerTests
    {
        private IBracketBalanceChecker checker;

        [TestInitialize()]
        public void Initialize()
        {
            checker = new BracketBalanceChecker();
        }

        /// <summary>
        /// Общий метод проверки корректности работы, в файле череда строк "выражение\n(1/0)"
        /// </summary>
        [TestMethod()]
        public void IsBalancedTest()
        {
            string line;

            using (StreamReader sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), "BracketBalanceTests.txt")))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    Assert.AreEqual(checker.IsBalanced(line), (bool.Parse(sr.ReadLine())));
                }
            }
        }
    }
}