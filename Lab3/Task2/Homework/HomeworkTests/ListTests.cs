using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты односвязного списка
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
        /// Тесты на добавление элементов
        /// </summary>
        [TestMethod()]
        public void AddOnelementTest()
        {
            list.Add("hello");
            Assert.AreEqual(1, list.Size);
        }

        [TestMethod()]
        public void SizeUpdatesWhenAnotherElementAddedTest()
        {
            list.Add("hello");
            int oldSize = list.Size;
            list.Add("bye");

            Assert.AreEqual(oldSize + 1, list.Size);
        }

        [TestMethod()]
        public void AddManyElementsTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                list.Add(i.ToString());
            }

            Assert.AreEqual(50, list.Size);
        }

        [TestMethod()]
        public void AddTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RemoveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetWordsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ClearTest()
        {
            Assert.Fail();
        }
    }
}