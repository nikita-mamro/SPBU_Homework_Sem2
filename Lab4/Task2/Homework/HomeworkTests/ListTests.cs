using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists.Tests
{
    /// <summary>
    /// Тесты обычного односвязного списка
    /// </summary>
    [TestClass()]
    public class ListTests
    {
        private IList list;

        [TestInitialize()]
        public void Initialize()
        {
            list = new List();
        }

        /// <summary>
        /// Тесты методов добавления элементов
        /// </summary>
        [TestMethod()]
        public void AddToHeadOnceTest()
        {
            bool initialIsEmpty = list.IsEmpty;

            list.AddToHead(10000000);
            Assert.IsTrue(initialIsEmpty == true && list.IsEmpty == false);
        }

        [TestMethod()]
        public void AddToHeadManyTimesUpdatesCounterTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.AddToHead(i);
            }

            Assert.AreEqual(100, list.Count);
        }

        [TestMethod()]
        public void AddToFirstPositionTest()
        {
            list.Add(1, 0);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod()]
        public void ExistsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetDataByPositionTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SetDataByPositionTest()
        {
            Assert.Fail();
        }
    }
}