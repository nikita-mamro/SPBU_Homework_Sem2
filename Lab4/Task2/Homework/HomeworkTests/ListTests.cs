using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lists;
using System;

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
        public void AddToFirstPositionManyTimesTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, 0);
            }

            Assert.AreEqual(100, list.Count);
        }

        [TestMethod()]
        public void AddToPositionsInOrderTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, i);
            }

            Assert.AreEqual(100, list.Count);
        }

        [TestMethod()]
        public void AddToExistingPositionTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, i);
            }

            for (var i = 0; i < 100; i += 2)
            {
                list.Add(100 + i, i);
            }

            Assert.AreEqual(150, list.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToInvalidPositionEmptyListExceptionTest()
        {
            list.Add(1, 1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToInvalidNegativePositionEmptyListExceptionTest()
        {
            list.Add(1, -1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToInvalidNegativePositionExceptionTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, i);
            }

            list.Add(-1, -1);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToInvalidOutOfRangePositivePositionExceptionTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, i);
            }

            list.Add(-1, 101);
        }

        /// <summary>
        /// Тесты метода удаления
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(Exceptions.ElementNotInListException))]
        public void RemoveFromEmptyTest()
        {
            list.Remove(1);
        }

        [TestMethod()]
        public void RemoveFromOneElementSizeTest()
        {
            list.Add(1, 0);
            list.Remove(1);
            Assert.IsTrue(list.IsEmpty);
        }

        [TestMethod()]
        public void RemoveOneFromManyElementsSizeTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, i);
            }

            list.Remove(1);
            Assert.AreEqual(99, list.Count);
        }

        [TestMethod()]
        public void RemoveManyFromManyElementsSizeTest()
        {
            for (var i = 0; i < 101; ++i)
            {
                list.Add(i, i);
            }

            for (var i = 0; i < 101; i += 5)
            {
                list.Remove(i);
            }

            Assert.AreEqual(80, list.Count);
        }

        [TestMethod()]
        public void RemoveAllElementsTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, i);
            }

            for (var i = 0; i < 100; ++i)
            {
                list.Remove(i);
            }

            Assert.IsTrue(list.IsEmpty);
        }

        [TestMethod()]
        [ExpectedException(typeof(Exceptions.ElementNotInListException))]
        public void RemoveUnexistingElementExceptionTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, i);
            }

            list.Remove(1000);
        }

        /// <summary>
        /// Тесты проверки значения на существование
        /// </summary>
        [TestMethod()]
        public void ExistsAfterAddingOneTest()
        {
            list.AddToHead(1);
            Assert.IsTrue(list.Exists(1));
        }

        [TestMethod()]
        public void ExistsAfterAddingManyTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, i);
            }

            for (var i = 0; i < 100; ++i)
            {
                if (!list.Exists(i))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void ExistsAfterRemovingAnotherTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, i);
            }

            list.Remove(50);

            Assert.IsTrue(list.Exists(1));
        }

        [TestMethod()]
        public void DoesNotExistAfterRemovingTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, i);
            }

            list.Remove(50);

            Assert.IsFalse(list.Exists(50));
        }

        /// <summary>
        /// Тесты метода очистки теста
        /// </summary>
        [TestMethod()]
        public void ClearEmptyListTest()
        {
            list.Clear();
            Assert.IsTrue(list.IsEmpty);
        }

        [TestMethod()]
        public void ClearListOfManyElementsTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i, i);
            }

            list.Clear();
            Assert.IsTrue(list.IsEmpty);
        }
    }
}