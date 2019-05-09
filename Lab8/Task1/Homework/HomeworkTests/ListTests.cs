using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты класса, реализующего список
    /// </summary>
    [TestClass]
    public class ListTests
    {
        private List<int> list;
        private List<int> readOnlyList;

        [TestInitialize]
        public void Initialize()
        {
            list = new List<int>();

            var readOnlyElements = new int[5] { 1, 2, 3, 4, 5 };
            readOnlyList = new List<int>(readOnlyElements, true);
        }

        [TestMethod]
        public void IndexOfReadOnlyTest()
        {
            for (var i = 0; i < readOnlyList.Count; ++i)
            {
                Assert.AreEqual(i, readOnlyList.IndexOf(i + 1));
            }
        }

        [TestMethod]
        public void IndexOfTest()
        {
            for (var i = 0; i < 30; ++i)
            {
                list.Add(i);
            }

            for (var i = 0; i < 30; ++i)
            {
                Assert.AreEqual(i, list.IndexOf(i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.EditingReadOnlyListException))]
        public void InsertReadOnlyExceptionTest()
        {
            readOnlyList.Insert(0, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertTooBigIndexException()
        {
            list.Insert(1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InsertNegativeIndexException()
        {
            list.Insert(-1, 1);
        }

        [TestMethod]
        public void InsertTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                list.Add(i);
            }

            list.Insert(4, 100);

            Assert.AreEqual(100, list[4]);
        }

        [TestMethod]
        public void ForeachReadOnlyTest()
        {
            var value = 0;

            foreach (var element in readOnlyList)
            {
                ++value;
                Assert.AreEqual(value, element);
            }
        }

        [TestMethod]
        public void ForeachTest()
        {
            for (var i = 1; i < 15; ++i)
            {
                list.Add(i * 3);
            }

            var index = 1;
            int expected;

            foreach (var element in list)
            {
                expected = index * 3;
                ++index;
                Assert.AreEqual(expected, element);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.EditingReadOnlyListException))]
        public void RemoveAtReadOnlyException()
        {
            readOnlyList.RemoveAt(0);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.DeletingFromEmptyListException))]
        public void RemoveAtEmptyListException()
        {
            list.RemoveAt(0);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAtIncorrectBigIndexException()
        {
            list.Add(1);
            list.RemoveAt(100);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void RemoveAtIncorrectNegativeIndexException()
        {
            list.Add(1);
            list.RemoveAt(-1);
        }

        [TestMethod]
        public void RemoveAtTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                list.Add(i);
            }

            list.RemoveAt(3);
            list.RemoveAt(1);

            foreach (var element in list)
            {
                Assert.IsTrue(element != 1 && element != 3);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.EditingReadOnlyListException))]
        public void AddToReadOnlyException()
        {
            readOnlyList.Add(1);
        }

        [TestMethod]
        public void AddTest()
        {
            list.Add(1);
            Assert.AreEqual(1, list.Count);
        }

        [TestMethod]
        public void AddManyTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                list.Add(i);
            }

            Assert.AreEqual(50, list.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.EditingReadOnlyListException))]
        public void ClearReadOnlyListException()
        {
            readOnlyList.Clear();
        }

        [TestMethod]
        public void ClearTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                list.Add(i);
            }

            list.Clear();

            Assert.IsTrue(list.Count == 0);
        }

        [TestMethod]
        public void ContainsReadOnlyTest()
        {
            for (var i = 1; i < 6; ++i)
            {
                Assert.IsTrue(readOnlyList.Contains(i));
            }
        }

        [TestMethod]
        public void ContainsTest()
        {
            for (var i = 0; i < 30; ++i)
            {
                list.Add(i * 3);
            }

            for (var i = 0; i < 90; i += 3)
            {
                Assert.IsTrue(list.Contains(i));
            }
        }

        [TestMethod]
        public void CopyToEmptyPositionZeroReadOnlyTest()
        {
            var array = new int[readOnlyList.Count];

            readOnlyList.CopyTo(array, 0);

            for (var i = 0; i < array.Length; ++i)
            {
                Assert.AreEqual(i + 1, array[i]);
            }
        }

        [TestMethod]
        public void CopyToEmptyPositionNotZeroReadOnlyTest()
        {
            var array = new int[readOnlyList.Count * 2];

            readOnlyList.CopyTo(array, readOnlyList.Count);

            var value = 0;

            for (var i = readOnlyList.Count; i < array.Length; ++i)
            {
                ++value;
                Assert.AreEqual(value, array[i]);
            }
        }

        [TestMethod]
        public void CopyToNotEmptyReadOnlyTest()
        {
            var array = new int[readOnlyList.Count * 2];

            for (var i = 0; i < readOnlyList.Count; ++i)
            {
                array[i] = 10;
            }

            readOnlyList.CopyTo(array, readOnlyList.Count);
        }

        [TestMethod]
        public void CopyEmptyToArrayTest()
        {
            var array = new int[10];
            
            for (var i = 0; i < 10; ++i)
            {
                array[i] = i + 100;
            }

            list.CopyTo(array, 0);

            for (var i = 0; i < 10; ++i)
            {
                Assert.AreEqual(i + 100, array[i]);
            }
        }

        [TestMethod]
        public void CopyToFromPositionZeroTest()
        {
            var array = new int[10];

            for (var i = 0; i < 10; ++i)
            {
                list.Add(i);
            }

            list.CopyTo(array, 0);

            for (var i = 0; i < 10; ++i)
            {
                Assert.AreEqual(i, array[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.EditingReadOnlyListException))]
        public void RemoveReadOnlyExceptionTest()
        {
            readOnlyList.Remove(1);
        }

        [TestMethod]
        public void RemoveFromemptyListTest()
        {
            var removed = list.Remove(1);

            Assert.IsFalse(removed);
        }

        [TestMethod]
        public void RemoveOneElementListOfOneElementTest()
        {
            list.Add(1);
            var removedExpectedFalse = list.Remove(2);
            var removedExpectedTrue = list.Remove(1);

            Assert.IsTrue(!removedExpectedFalse && removedExpectedTrue && 0 == list.Count);
        }

        [TestMethod]
        public void RemoveOneElementListOfManyTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                list.Add(i);
            }

            var removedExpectedFalse = list.Remove(100);
            var removedExpectedTrue = list.Remove(5);

            bool result = true;

            foreach (var element in list)
            {
                if (element == 5)
                {
                    result = false;
                }
            }

            Assert.IsTrue(result && removedExpectedTrue && !removedExpectedFalse);
        }

        [TestMethod]
        public void RemoveManyElementsFromListOfManyTest()
        {
            for  (var i = 0; i < 10; ++i)
            {
                list.Add(i);
            }

            var removedFirstTrue = list.Remove(3);
            var removedSecondTrue = list.Remove(8);

            var removedExpectedFalse = list.Remove(15);

            var result = true;

            foreach (var element in list)
            {
                if (element == 3 || element == 8)
                {
                    result = false;
                }
            }

            Assert.IsTrue(removedFirstTrue && removedSecondTrue && !removedExpectedFalse && result);
        }
    }
}