using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;
using System.Collections.Generic;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты хэш-таблицы для каждой из реализаций хэш-функции
    /// </summary>
    [TestClass()]
    public class HashTableTests
    {
        /// <summary>
        /// Тесты добавления
        /// </summary>
        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void AddToEmptyTest(IHashTable table)
        {
            table.Add("hello");
            Assert.AreEqual(1, table.Count);
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void CountUpdatesWhenElementAddedTest(IHashTable table)
        {
            table.Add("hello");
            var oldCount = table.Count;
            table.Add("bye");

            Assert.AreEqual(oldCount + 1, table.Count);
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void AddManyElementsTest(IHashTable table)
        {
            for (var i = 0; i < 50; ++i)
            {
                table.Add(i.ToString());
            }

            Assert.AreEqual(50, table.Count);
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void CountUpdatesWhenAddingExistingTest(IHashTable table)
        {
            for (var i = 0; i < 50; ++i)
            {
                table.Add(i.ToString());
                table.Add(i.ToString());
            }

            Assert.AreEqual(100, table.Count);
        }

        /// <summary>
        /// Тест IsContained
        /// </summary>
        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void IsContainedTest(IHashTable table)
        {
            table.Add("hello");
            Assert.IsTrue(table.IsContained("hello") && !table.IsContained("HELLO"));
        }

        /// <summary>
        /// Тест удаления
        /// </summary>
        [DynamicData("TestMethodInput")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveFromEmptyExceptionTest(IHashTable table)
        {
            table.Remove("hello");
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveElementWhichDoesNotExistExceptionTest(IHashTable table)
        {
            table.Add("hello");
            table.Remove("haha");
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void CountUpdateRemoveFromTableOfManyDifferentElementsTest(IHashTable table)
        {
            for (var i = 0; i < 50; ++i)
            {
                table.Add(i.ToString());
            }

            var oldCount = table.Count;
            table.Remove("10");

            Assert.AreEqual(oldCount - 1, table.Count);
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void CountUpdateRemoveFromTableOfManySameElementsTest(IHashTable table)
        {
            for (var i = 0; i < 50; ++i)
            {
                table.Add("same thing");
            }

            var oldCount = table.Count;
            table.Remove("same thing");

            Assert.AreEqual(oldCount - 1, table.Count);
        }

        /// <summary>
        /// Тест метода Clear()
        /// </summary>
        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void ClearTest(IHashTable table)
        {
            for (var i = 0; i < 50; ++i)
            {
                table.Add(i.ToString());
            }

            table.Clear();

            Assert.AreEqual(0, table.Count);
        }

        public static IEnumerable<object[]> TestMethodInput
            => new[] { new object[] { new HashTable(new AdlerHash()) }, new object[] { new HashTable(new Murmur2Hash()) }, new object[] { new HashTable(new JenkinsHash()) } };
    }
}