using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lists;
using System;

namespace Lists.Tests
{
    /// <summary>
    /// Тесты класса UniqueList
    /// </summary>
    [TestClass]
    public class UniqueListTests
    {
        private IList uList;

        [TestInitialize]
        public void Initialize()
        {
            uList = new UniqueList();
        }

        /// <summary>
        /// Тесты методов добавления на бросание исключений при попытке добавить существующий элемент 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exceptions.ElementAlreadyInListException))]
        public void AddToHeadToOneExistingElementExceptionTest()
        {
            uList.AddToHead(1);
            uList.AddToHead(1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.ElementAlreadyInListException))]
        public void AddExistingElementToHeadOfListOfManyElementsExceptionTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                uList.AddToHead(i);
            }

            uList.AddToHead(1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.ElementAlreadyInListException))]
        public void AddToOneExistingElementExceptionTest()
        {
            uList.Add(1, 0);
            uList.Add(1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.ElementAlreadyInListException))]
        public void AddExistingElementToListOfManyElementsExceptionTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                uList.Add(i, i);
            }

            uList.Add(1, 10);
        }
    }
}