using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;
using System.Collections.Generic;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты стека на массиве
    /// </summary>
    [TestClass]
    public class StackTests
    {
        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void PushElementToEmptyStackTest(IStack stack)
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Count);
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void PushToResizeTest(IStack stack)
        {
            for (var i = 0; i < 3; ++i)
            {
                stack.Push(i);
            }

            Assert.AreEqual(3, stack.Count);
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void PushUpdateCountTest(IStack stack)
        {
            for (var i = 0; i < 322; ++i)
            {
                stack.Push(i);
            }

            Assert.AreEqual(322, stack.Count);
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopFromEmptyStackExceptionTest(IStack stack)
        {
            stack.Pop();
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekFromEmptyStackExceptionTest(IStack stack)
        {
            stack.Peek();
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void PopReturnValueTest(IStack stack)
        {
            for (var i = 0; i < 10; ++i)
            {
                stack.Push(i);
            }

            Assert.AreEqual(9, stack.Pop());
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void PopUpdateCountTest(IStack stack)
        {
            for (var i = 0; i < 322; ++i)
            {
                stack.Push(i);
            }

            var countBeforePop = stack.Count;

            stack.Pop();

            Assert.AreEqual(countBeforePop - 1, stack.Count);
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void PeekReturnTest(IStack stack)
        {
            for (var i = 0; i < 10; ++i)
            {
                stack.Push(i);
            }

            Assert.AreEqual(9, stack.Peek());
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void PeekMustNotUpdateCountTest(IStack stack)
        {
            for (var i = 0; i < 322; ++i)
            {
                stack.Push(i);
            }

            var countBeforePeek = stack.Count;

            stack.Peek();

            Assert.AreEqual(countBeforePeek, stack.Count);
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void ClearStackTest(IStack stack)
        {
            for (var i = 0; i < 322; ++i)
            {
                stack.Push(i);
            }

            stack.Clear();

            Assert.AreEqual(0, stack.Count);
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void IsEmptyOnEmptyStackTest(IStack stack)
        {
            for (var i = 0; i < 322; ++i)
            {
                stack.Push(i);
            }

            stack.Clear();

            Assert.IsTrue(stack.IsEmpty);
        }

        [DynamicData("TestMethodInput")]
        [TestMethod]
        public void IsEmptyOnNotEmptyStackTest(IStack stack)
        {
            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty);
        }

        public static IEnumerable<object[]> TestMethodInput
            => new[] { new object[] { new ArrayStack() }, new object[] { new ListStack() } };
    }
}