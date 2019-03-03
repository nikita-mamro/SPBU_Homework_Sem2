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
        public void NoSizeUpdatedWhenAddingExistentTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                list.Add(i.ToString());
                list.Add(i.ToString());
            }

            Assert.AreEqual(50, list.Size);
        }

        /// <summary>
        /// Тест свойства Contains
        /// </summary>
        [TestMethod()]
        public void AddedElementBecomesContainedTest()
        {
            list.Add("hello");
            Assert.IsTrue(list.Contains("hello") && !list.Contains("HELLO"));
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
        /// Тест удаления
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

            var oldSize = list.Size;
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

            var oldSize = list.Size;
            list.Remove("hello");

            Assert.AreEqual(oldSize, list.Size);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void RemoveFromEmptyListExceptionTest()
        {
            list.Remove("haha");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveElementWhichDoesNotExistExceptionTest()
        {
            list.Add("hello");
            list.Remove("haha");
        }

        /// <summary>
        /// Тест метода GetWords()
        /// </summary>
        [TestMethod()]
        public void GetWordsDifferentElementsTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                list.Add(i.ToString());
            }

            List<string> words = list.GetWords();

            var expected = new List<string>();

            for (var i = 0; i < 50; ++i)
            {
                expected.Add(i.ToString());
            }

            bool res = true;

            for (var i = 0; i < 50; ++i)
            {
                if (expected[i] != words[i])
                {
                    res = false;
                }
            }

            Assert.IsTrue(res);
        }

        [TestMethod()]
        public void GetWordsRepeatingElementsTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                list.Add(i.ToString());
                list.Add(i.ToString());
            }

            List<string> words = list.GetWords();

            var expected = new List<string>();

            for (var i = 0; i < 50; ++i)
            {
                expected.Add(i.ToString());
                expected.Add(i.ToString());
            }

            bool res = true;

            for (var i = 0; i < 100; ++i)
            {
                if (expected[i] != words[i])
                {
                    res = false;
                }
            }

            Assert.IsTrue(res);
        }

        /// <summary>
        /// Тест очистки
        /// </summary>
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