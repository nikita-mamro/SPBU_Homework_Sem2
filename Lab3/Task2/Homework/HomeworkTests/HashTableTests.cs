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
            Assert.Fail();
        }

        [TestMethod()]
        public void CountUpdatesWhenElementAddedJenkinsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CountUpdatesWhenElementAddedMurmur2Test()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddManyElementsAdlerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddManyElementsJenkinsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void AddManyElementsMurmur2Test()
        {
            Assert.Fail();
        }

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