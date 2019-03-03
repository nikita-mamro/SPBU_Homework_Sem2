using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;
using System.Collections.Generic;

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
        public void NoSizeUpdatedWhenAddingExistent()
        {
            for (var i = 0; i < 50; ++i)
            {
                list.Add(i.ToString());
                list.Add(i.ToString());
            }

            Assert.AreEqual(50, list.Size);
        }

        /// <summary>
        /// Contains boolean tests
        /// </summary>
        [TestMethod()]
        public void AddedElementBecomesContainedTest()
        {
            list.Add("hello");
            Assert.IsTrue(list.Contains("hello"));
        }

        [TestMethod()]
        public void AddedElementToManyElementsBecomesContainedTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                list.Add(i.ToString());
            }

            list.Add("hello");

            Assert.IsTrue(list.Contains("hello"));
        }

        /// <summary>
        /// Removing elements tests
        /// </summary>
        [TestMethod()]
        public void RemoveFromListOfOneElementSizeChangeTest()
        {
            list.Add("One");
            list.Remove("One");

            Assert.AreEqual(0, list.Size);
        }

        [TestMethod()]
        public void RemoveFromListOfManyElementsSizeChangeTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                list.Add(i.ToString());
            }

            int oldSize = list.Size;
            list.Remove("3");

            Assert.AreEqual(oldSize - 1, list.Size);
        }

        [TestMethod()]
        public void RemoveFromListOfManyCopiesOfOneElementTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                list.Add("hello");
            }

            int oldSize = list.Size;
            list.Remove("hello");

            Assert.AreEqual(oldSize, list.Size);
        }

        [TestMethod()]
        public void GetWordsTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                list.Add(i.ToString());
            }

            List<string> words = ;
        }

        [TestMethod()]
        public void ClearTest()
        {
            for (var i = 0; i < 322; ++i)
            {
                list.Add(i.ToString());
            }

            list.Clear();

            Assert.IsTrue(list.IsEmpty);
        }
    }
}