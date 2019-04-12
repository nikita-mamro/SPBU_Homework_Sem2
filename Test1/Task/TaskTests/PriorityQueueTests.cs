using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Tests
{
    /// <summary>
    /// Тесты очереди с приоритетами
    /// </summary>
    [TestClass]
    public class PriorityQueueTests
    {
        PriorityQueue pQueue;

        [TestInitialize]
        public void Initialize()
        {
            pQueue = new PriorityQueue();
        }

        /// <summary>
        /// Тесты метода добавления значения в очередь с приоритетами
        /// </summary>
        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 10)]
        [DataRow(10, 0)]
        [DataRow(0, int.MaxValue)]
        [DataRow(int.MaxValue, 0)]
        [DataRow(0, -10)]
        [DataRow(-10, 0)]
        [DataRow(0, -int.MaxValue)]
        [DataRow(-int.MaxValue, 0)]
        [DataRow(10, 10)]
        [DataRow(10, int.MaxValue)]
        [DataRow(int.MaxValue, 10)]
        [DataRow(int.MaxValue, int.MaxValue)]
        [DataRow(-10, -10)]
        [DataRow(-int.MaxValue, -10)]
        [DataRow(10, -int.MaxValue)]
        [DataRow(-int.MaxValue, -int.MaxValue)]
        [DataRow(10, -10)]
        [DataRow(10, -10)]
        [DataRow(10, -10)]
        public void EnqueueOneElementTest(int data, int priority)
        {
            pQueue.Enqueue(data, priority);
            Assert.IsTrue(!pQueue.IsEmpty && pQueue.Contatins(data));
        }

        [TestMethod]
        public void EnqueueManyElementsDifferentPriorityTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                pQueue.Enqueue(i, 100 - i);
            }

            for (var i = 0; i < 100; ++i)
            {
                Assert.IsTrue(pQueue.Contatins(i));
            }
        }

        [TestMethod]
        public void EnqueueManyElementsSamePriorityTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                pQueue.Enqueue(i, 0);
            }

            for (var i = 0; i < 100; ++i)
            {
                Assert.IsTrue(pQueue.Contatins(i));
            }
        }

        /// <summary>
        /// Тесты удаления элемента с максимальным приоритетом
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exceptions.DequeueCallForEmptyPriorityQueueException))]
        public void DequeueFromEmptyQueueExceptionTest()
        {
            pQueue.Dequeue();
        }

        [TestMethod]
        public void DequeueFromOneElementsTest()
        {
            pQueue.Enqueue(0, 0);
            Assert.IsTrue(pQueue.Dequeue() == 0 && pQueue.IsEmpty);
        }

        [TestMethod]
        public void DequeueOneFromManyDifferentPriorityElementsTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                pQueue.Enqueue(i, 100 - i);
            }

            Assert.AreEqual(pQueue.Dequeue(), 0);
        }

        [TestMethod]
        public void DequeueOneFromManySamePriorityElementsTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                pQueue.Enqueue(i, 1);
            }

            Assert.AreEqual(pQueue.Dequeue(), 99);
        }

        [TestMethod]
        public void DequeueManyFromMoreDifferentPriorityElementsTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                pQueue.Enqueue(i, 100 - i);
            }

            for (var i = 0; i < 20; ++i)
            {
                Assert.IsTrue(pQueue.Dequeue() == i && !pQueue.IsEmpty);
            }
        }

        [TestMethod]
        public void DequeueManyFromMoreSamePriorityElementsTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                pQueue.Enqueue(i, 100);
            }

            for (var i = 0; i < 20; ++i)
            {
                Assert.IsTrue(pQueue.Dequeue() == 99 - i && !pQueue.IsEmpty);
            }
        }

        [TestMethod]
        public void DequeueAllFromManyDifferentPriorityElementsTest()
        {
            for (var i = 0; i < 100; ++i)
            {
                pQueue.Enqueue(i, i);
            }

            for (var i = 0; i < 100; ++i)
            {
                Assert.IsTrue(pQueue.Dequeue() == 99 - i);
            }

            Assert.IsTrue(pQueue.IsEmpty);
        }

        /// <summary>
        /// Тесты очистки очереди
        /// </summary>
        [TestMethod]
        public void ClearEmptyQueueTest()
        {
            pQueue.Clear();
            Assert.IsTrue(pQueue.IsEmpty);
        }

        [TestMethod]
        public void ClearOneElementQueueTest()
        {
            pQueue.Enqueue(1, 1);
            pQueue.Clear();
            Assert.IsTrue(pQueue.IsEmpty);
        }

        [TestMethod]
        public void ClearManyElementsQueueTest()
        {
            for (var i = 0; i < 500; ++i)
            {
                pQueue.Enqueue(i, i);
            }

            pQueue.Clear();
            Assert.IsTrue(pQueue.IsEmpty);
        }
    }
}