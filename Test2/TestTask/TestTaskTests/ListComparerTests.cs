using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask;
using System;
using System.Collections.Generic;

namespace TestTask.Tests
{
    /// <summary>
    /// Тесты сравнивалки списков
    /// </summary>
    [TestClass]
    public class ListComparerTests
    {
        [TestMethod]
        public void CompareSameLengthTest()
        {
            var listAint = new List<int>();
            var listBint = new List<int>();
            var listAstring = new List<string>();
            var listBstring = new List<string>();

            for (var i = 0; i < 10; ++i)
            {
                listAint.Add(i);
                listBint.Add(100 - i);
                listAstring.Add(i.ToString());
                listBstring.Add((100 - i).ToString());
            }

            var comparerInt = new ListComparer<int>();
            var comparerString = new ListComparer<string>();

            Assert.IsTrue(comparerInt.Compare(listAint, listBint) == 0 && comparerString.Compare(listAstring, listBstring) == 0);
        }

        [TestMethod]
        public void CompareFirstIsBiggerTest()
        {
            var listAint = new List<int>();
            var listBint = new List<int>();
            var listAstring = new List<string>();
            var listBstring = new List<string>();

            for (var i = 0; i < 10; ++i)
            {
                listAint.Add(i);
                listAint.Add(i);
                listBint.Add(100 - i);
                listAstring.Add(i.ToString());
                listAstring.Add(i.ToString());
                listBstring.Add((100 - i).ToString());
            }

            var comparerInt = new ListComparer<int>();
            var comparerString = new ListComparer<string>();

            Assert.IsTrue(comparerInt.Compare(listAint, listBint) > 0 && comparerString.Compare(listAstring, listBstring) > 0);
        }

        [TestMethod]
        public void CompareSecondIsBiggerTest()
        {
            var listAint = new List<int>();
            var listBint = new List<int>();
            var listAstring = new List<string>();
            var listBstring = new List<string>();

            for (var i = 0; i < 10; ++i)
            {
                listAint.Add(i);
                listBint.Add(i);
                listBint.Add(100 - i);
                listAstring.Add(i.ToString());
                listBstring.Add(i.ToString());
                listBstring.Add((100 - i).ToString());
            }

            var comparerInt = new ListComparer<int>();
            var comparerString = new ListComparer<string>();

            Assert.IsTrue(comparerInt.Compare(listAint, listBint) < 0 && comparerString.Compare(listAstring, listBstring) < 0);
        }
    }
}