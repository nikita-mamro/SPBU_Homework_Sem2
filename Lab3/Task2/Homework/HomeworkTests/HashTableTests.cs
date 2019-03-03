using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты хэш-таблицы для каждой из реализаций хэш-функции
    /// </summary>
    [TestClass()]
    public class HashTableTests
    {
        private IHashTable tableAdler;
        private IHashTable tableJenkins;
        private IHashTable tableMurmur2;

        [TestInitialize()]
        public void Initialize()
        {
            tableAdler = new HashTable(new AdlerHash());
            tableJenkins = new HashTable(new JenkinsHash());
            tableMurmur2 = new HashTable(new Murmur2Hash());
        }

        /// <summary>
        /// Тесты добавления
        /// </summary>
        [TestMethod()]
        public void AddToEmptyAdlerTest()
        {
            tableAdler.Add("hello");
            Assert.AreEqual(1, tableAdler.Count);
        }

        [TestMethod()]
        public void AddToEmptyJenkinsTest()
        {
            tableJenkins.Add("hello");
            Assert.AreEqual(1, tableJenkins.Count);
        }

        [TestMethod()]
        public void AddToEmptyMurmur2Test()
        {
            tableMurmur2.Add("hello");
            Assert.AreEqual(1, tableMurmur2.Count);
        }

        [TestMethod()]
        public void CountUpdatesWhenElementAddedAdlerTest()
        {
            tableAdler.Add("hello");
            var oldCount = tableAdler.Count;
            tableAdler.Add("bye");

            Assert.AreEqual(oldCount + 1, tableAdler.Count);
        }

        [TestMethod()]
        public void CountUpdatesWhenElementAddedJenkinsTest()
        {
            tableJenkins.Add("hello");
            var oldCount = tableJenkins.Count;
            tableJenkins.Add("bye");

            Assert.AreEqual(oldCount + 1, tableJenkins.Count);
        }

        [TestMethod()]
        public void CountUpdatesWhenElementAddedMurmur2Test()
        {
            tableMurmur2.Add("hello");
            var oldCount = tableMurmur2.Count;
            tableMurmur2.Add("bye");

            Assert.AreEqual(oldCount + 1, tableMurmur2.Count);
        }

        [TestMethod()]
        public void AddManyElementsAdlerTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableAdler.Add(i.ToString());
            }

            Assert.AreEqual(50, tableAdler.Count);
        }

        [TestMethod()]
        public void AddManyElementsJenkinsTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableJenkins.Add(i.ToString());
            }

            Assert.AreEqual(50, tableJenkins.Count);
        }

        [TestMethod()]
        public void AddManyElementsMurmur2Test()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableMurmur2.Add(i.ToString());
            }

            Assert.AreEqual(50, tableMurmur2.Count);
        }

        [TestMethod()]
        public void CountUpdatesWhenAddingExistingAdlerTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableAdler.Add(i.ToString());
                tableAdler.Add(i.ToString());
            }

            Assert.AreEqual(100, tableAdler.Count);
        }

        [TestMethod()]
        public void CountUpdatesWhenAddingExistingJenkinsTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableJenkins.Add(i.ToString());
                tableJenkins.Add(i.ToString());
            }

            Assert.AreEqual(100, tableJenkins.Count);
        }

        [TestMethod()]
        public void CountUpdatesWhenAddingExistingMurmur2Test()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableMurmur2.Add(i.ToString());
                tableMurmur2.Add(i.ToString());
            }

            Assert.AreEqual(100, tableMurmur2.Count);
        }

        /// <summary>
        /// Тесты IsContained
        /// </summary>
        [TestMethod()]
        public void IsContainedAdlerTest()
        {
            tableAdler.Add("hello");
            Assert.IsTrue(tableAdler.IsContained("hello") && !tableAdler.IsContained("HELLO"));
        }

        [TestMethod()]
        public void IsContainedJenkinsTest()
        {
            tableJenkins.Add("hello");
            Assert.IsTrue(tableJenkins.IsContained("hello") && !tableJenkins.IsContained("HELLO"));
        }

        [TestMethod()]
        public void IsContainedMurmur2Test()
        {
            tableMurmur2.Add("hello");
            Assert.IsTrue(tableMurmur2.IsContained("hello") && !tableMurmur2.IsContained("HELLO"));
        }

        /// <summary>
        /// Тест удаления
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveFromEmptyExceptionAdlerTest()
        {
            tableAdler.Remove("hello");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveFromEmptyExceptionJenkinsTest()
        {
            tableJenkins.Remove("hello");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveFromEmptyExceptionMurmur2Test()
        {
            tableMurmur2.Remove("hello");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveElementWhichDoesNotExistExceptionAdlerTest()
        {
            tableAdler.Add("hello");
            tableAdler.Remove("haha");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveElementWhichDoesNotExistExceptionJenkinsTest()
        {
            tableJenkins.Add("hello");
            tableJenkins.Remove("haha");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveElementWhichDoesNotExistExceptionMurmur2Test()
        {
            tableMurmur2.Add("hello");
            tableMurmur2.Remove("haha");
        }

        [TestMethod()]
        public void CountUpdateRemoveFromTableOfManyDifferentElementsAdlerTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableAdler.Add(i.ToString());
            }

            var oldCount = tableAdler.Count;
            tableAdler.Remove("10");

            Assert.AreEqual(oldCount - 1, tableAdler.Count);
        }

        [TestMethod()]
        public void CountUpdateRemoveFromTableOfManyDifferentElementsJenkinsTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableJenkins.Add(i.ToString());
            }

            var oldCount = tableJenkins.Count;
            tableJenkins.Remove("10");

            Assert.AreEqual(oldCount - 1, tableJenkins.Count);
        }

        [TestMethod()]
        public void CountUpdateRemoveFromTableOfManyDifferentElementsMurmur2Test()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableMurmur2.Add(i.ToString());
            }

            var oldCount = tableMurmur2.Count;
            tableMurmur2.Remove("10");

            Assert.AreEqual(oldCount - 1, tableMurmur2.Count);
        }

        [TestMethod()]
        public void CountUpdateRemoveFromTableOfManySameElementsAdlerTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableAdler.Add("same thing");
            }

            var oldCount = tableAdler.Count;
            tableAdler.Remove("same thing");

            Assert.AreEqual(oldCount - 1, tableAdler.Count);
        }

        [TestMethod()]
        public void CountUpdateRemoveFromTableOfManySameElementsJenkinsTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableJenkins.Add("same thing");
            }

            var oldCount = tableJenkins.Count;
            tableJenkins.Remove("same thing");

            Assert.AreEqual(oldCount - 1, tableJenkins.Count);
        }

        [TestMethod()]
        public void CountUpdateRemoveFromTableOfManySameElementsMurmur2Test()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableMurmur2.Add("same thing");
            }

            var oldCount = tableMurmur2.Count;
            tableMurmur2.Remove("same thing");

            Assert.AreEqual(oldCount - 1, tableMurmur2.Count);
        }

        /// <summary>
        /// Тест метода Clear()
        /// </summary>
        [TestMethod()]
        public void ClearAdlerTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableAdler.Add(i.ToString());
            }

            tableAdler.Clear();

            Assert.AreEqual(0, tableAdler.Count);
        }

        [TestMethod()]
        public void ClearJenkinsTest()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableJenkins.Add(i.ToString());
            }

            tableJenkins.Clear();

            Assert.AreEqual(0, tableJenkins.Count);
        }

        [TestMethod()]
        public void ClearMurmur2Test()
        {
            for (var i = 0; i < 50; ++i)
            {
                tableMurmur2.Add(i.ToString());
            }

            tableMurmur2.Clear();

            Assert.AreEqual(0, tableMurmur2.Count);
        }
    }
}