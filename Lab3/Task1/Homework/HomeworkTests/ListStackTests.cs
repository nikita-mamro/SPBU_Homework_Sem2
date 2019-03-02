using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты стека на односвязном списке
    /// </summary>
    [TestClass()]
    public class ListStackTests
    {
        private IStack stack;

        [TestInitialize()]
        public void Initialize()
        {
            stack = new ListStack();
        }

        [TestMethod()]
        public void PushElementToEmptyStackTest()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
        }

        [TestMethod()]
        public void PushToResizeTest()
        {
            for (var i = 0; i < 3; ++i)
            {
                stack.Push(i);
            }

            Assert.AreEqual(3, stack.Count);
        }

        [TestMethod()]
        public void PushUpdateCountTest()
        {
            for (var i = 0; i < 322; ++i)
            {
                stack.Push(i);
            }

            Assert.AreEqual(322, stack.Count);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStackExceptionTest()
        {
            stack.Pop();
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromEmptyStackExceptionTest()
        {
            stack.Peek();
        }

        [TestMethod()]
        public void PopReturnValueTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                stack.Push(i);
            }

            Assert.AreEqual(9, stack.Pop());
        }

        [TestMethod()]
        public void PopUpdateCountTest()
        {
            for (var i = 0; i < 322; ++i)
            {
                stack.Push(i);
            }

            var countBeforePop = stack.Count;

            stack.Pop();

            Assert.AreEqual(countBeforePop - 1, stack.Count);
        }

        [TestMethod()]
        public void PeekReturnTest()
        {
            for (var i = 0; i < 10; ++i)
            {
                stack.Push(i);
            }

            Assert.AreEqual(9, stack.Peek());
        }

        [TestMethod()]
        public void PeekMustNotUpdateCountTest()
        {
            for (var i = 0; i < 322; ++i)
            {
                stack.Push(i);
            }

            var countBeforePeek = stack.Count;

            stack.Peek();

            Assert.AreEqual(countBeforePeek, stack.Count);
        }

        [TestMethod()]
        public void ClearStackTest()
        {
            for (var i = 0; i < 322; ++i)
            {
                stack.Push(i);
            }

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
        }

        [TestMethod()]
        public void IsEmptyOnEmptyStackTest()
        {
            for (var i = 0; i < 322; ++i)
            {
                stack.Push(i);
            }

            stack.Clear();

            Assert.IsTrue(stack.IsEmpty);
        }

        [TestMethod()]
        public void IsEmptyOnNotEmptyStackTest()
        {
            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty);
        }
    }
}