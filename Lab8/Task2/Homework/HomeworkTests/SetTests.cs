using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты класса, реализующего АТД "Множество"
    /// </summary>
    [TestClass]
    public class SetTests
    {
        private Set<int> set;
        private Set<int> readOnlySet;
        private List<int> list;

        [TestInitialize]
        public void Initialize()
        {
            set = new Set<int>();

            var elements = new int[] { -2, -1, 0, 1, 2 };
            readOnlySet = new Set<int>(elements, true);

            list = new List<int>();
        }

        [TestMethod]
        public void SetArrayConstructorTest()
        {
            var elements = new int[] { -2,-1, 0, 1, 2 };
            var arraySet = new Set<int>(elements);

            foreach (var element in elements)
            {
                Assert.IsTrue(arraySet.Contains(element));
            }
        }

        [TestMethod]
        public void SetArrayReadOnlyConstructorTest()
        {
            var expected = -2;

            foreach (var element in readOnlySet)
            {
                Assert.AreEqual(expected, element);
                ++expected;
            }
        }

        [TestMethod]
        public void AddTest()
        {
            set.Add(1);
            Assert.AreEqual(1, set.Count);
        }

        [TestMethod]
        public void AddManyTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                set.Add(i);
            }

            Assert.AreEqual(5, set.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void AddReadOnlyExceptionTest()
        {
            readOnlySet.Add(1);
        }

        [TestMethod]
        public void ContainsTest()
        {
            set.Add(1);

            Assert.IsTrue(set.Contains(1));
        }

        [TestMethod]
        public void ContainsManyTest()
        {
            for (var i = -5; i <= 5; ++i)
            {
                set.Add(i);
            }

            for (var i = -5; i <= 5; ++i)
            {
                Assert.IsTrue(set.Contains(i));
            }
        }

        [TestMethod]
        public void ForeachTest()
        {
            for (var i = -5; i < 5; ++i)
            {
                set.Add(i);
            }

            var expected = -5;

            foreach (var element in set)
            {
                Assert.AreEqual(expected, element);
                ++expected;
            }
        }

        [TestMethod]
        public void ClearTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                set.Add(i);
            }

            set.Clear();

            for (var i = -2; i <= 2; ++i)
            {
                if (set.Contains(i))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ClearReadOnlyExceptionTest()
        {
            readOnlySet.Clear();
        }

        [TestMethod]
        public void RemoveFromOneElementSetTest()
        {
            set.Add(1);
            set.Remove(1);
            Assert.AreEqual(0, set.Count);
        }

        [TestMethod]
        public void RemoveOneFromManyTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                set.Add(i);
            }

            var oldCount = set.Count;
            var isRemoved = set.Remove(0);


        }

        [TestMethod]
        public void RemoveManyTest()
        {
            for (var i = -5; i <= 5; ++i)
            {
                set.Add(i);
            }

            for (var i = -5; i <=5; i += 2)
            {
                set.Remove(i);
            }

            foreach (var element in set)
            {
                Assert.IsTrue(element % 2 == 0);
            }
        }

        [TestMethod]
        public void RemoveUnexistentTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                set.Add(i);
            }

            var oldCount = set.Count;
            var isRemoved = set.Remove(10);

            Assert.IsTrue(set.Count == oldCount && !isRemoved);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void RemoveEmptyExceptionTest()
        {
            set.Remove(1);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void RemoveReadOnlyExceptionTest()
        {
            readOnlySet.Remove(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CopyToNullArrayExceptionTest()
        {
            int[] array = null;

            readOnlySet.CopyTo(array, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CopyToNegativeIndexExceptionTest()
        {
            var array = new int[] { 1, 2, 3 };

            readOnlySet.CopyTo(array, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CopyToTooBigIndexExceptionTest()
        {
            var array = new int[] { 1, 2, 3 };

            readOnlySet.CopyTo(array, 10);
        }

        [TestMethod]
        public void CopyToTest()
        {
            var array = new int[5];

            readOnlySet.CopyTo(array, 0);

            foreach (var element in readOnlySet)
            {
                if (!array.Contains(element))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void ExceptWithTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                set.Add(i);

                if (i % 2 == 0)
                {
                    list.Add(i);
                }
            }

            set.ExceptWith(list);

            foreach (var element in set)
            {
                Assert.IsTrue(element % 2 != 0);
            }
        }

        [TestMethod]
        public void ExceptWithEmptyTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                set.Add(i);
            }

            var setElements = new int[5];
            set.CopyTo(setElements, 0);

            set.ExceptWith(list);

            foreach (var element in setElements)
            {
                Assert.IsTrue(set.Contains(element));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptWithNullExceptionTest()
        {
            set.ExceptWith(null);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void ExceptReadOnlyWithExceptionTest()
        {
            list.Add(1);

            readOnlySet.ExceptWith(list);
        }

        [TestMethod]
        public void IntersectWithTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                set.Add(i);
            }

            list.Add(2);
            list.Add(3);

            set.IntersectWith(list);

            Assert.IsTrue(set.Count == 1 && set.Contains(2));
        }

        [TestMethod]
        public void IntersectWithAllDifferentElementsTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                set.Add(i);
            }

            list.Add(-10);
            list.Add(10);

            set.IntersectWith(list);

            Assert.AreEqual(0, set.Count);
        }

        [TestMethod]
        public void IntersectWithEmptyTest()
        {
            set.IntersectWith(list);

            Assert.AreEqual(0, set.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException))]
        public void IntersectReadOnlyWithExceptionTest()
        {
            readOnlySet.IntersectWith(list);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IntersectWithNullExceptionTest()
        {
            set.IntersectWith(null);
        }

        [TestMethod]
        public void IsProperSubsetOfTrueTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                list.Add(i);
                set.Add(i);
            }

            list.Add(10);

            Assert.IsTrue(set.IsProperSubsetOf(list));
        }

        [TestMethod]
        public void IsProperSubsetOfFalseNotProperTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                list.Add(i);
                set.Add(i);
            }

            Assert.IsFalse(set.IsProperSubsetOf(list));
        }

        [TestMethod]
        public void IsProperSubsetOfFalseNotSubsetTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                list.Add(i);
                set.Add(i);
            }

            set.Add(10);

            Assert.IsFalse(set.IsProperSubsetOf(list));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsProperSubsetOfNullExceptionTest()
        {
            set.IsProperSubsetOf(null);
        }

        [TestMethod]
        public void IsProperSupersetOfTrueTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                list.Add(i);
                set.Add(i);
            }

            set.Add(10);

            Assert.IsTrue(set.IsProperSupersetOf(list));
        }

        [TestMethod]
        public void IsProperSupersetOfFalseNotSupersetTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                list.Add(i);
                set.Add(i);
            }

            list.Add(10);

            Assert.IsFalse(set.IsProperSupersetOf(list));
        }

        [TestMethod]
        public void IsProperSupersetOfFalseNotProperTest()
        {
            for (var i = -2; i <= 2; ++i)
            {
                list.Add(i);
                set.Add(i);
            }

            Assert.IsFalse(set.IsProperSupersetOf(list));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsProperSupersetOfNullExceptionTest()
        {
            set.IsProperSupersetOf(null);
        }

        [TestMethod]
        public void IsSubsetOfTrueTest()
        {
            for (var i = -2; i <= -2; ++i)
            {
                set.Add(i);
                list.Add(i);
            }

            list.Add(10);

            Assert.IsTrue(set.IsSubsetOf(list));
        }

        [TestMethod]
        public void IsSubsetOfFalseTest()
        {
            for (var i = -2; i <= -2; ++i)
            {
                set.Add(i);
                list.Add(i);
            }

            set.Add(1);

            Assert.IsFalse(set.IsSubsetOf(list));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsSubsetOfNullExceptionTest()
        {
            set.IsSubsetOf(null);
        }

        [TestMethod]
        public void IsSupersetOfTrueTest()
        {
            for (var i = -2; i <= -2; ++i)
            {
                set.Add(i);
                list.Add(i);
            }

            set.Add(1);

            Assert.IsTrue(set.IsSupersetOf(list));
        }

        [TestMethod]
        public void IsSupersetOfFalseTest()
        {
            for (var i = -2; i <= -2; ++i)
            {
                set.Add(i);
                list.Add(i);
            }

            list.Add(10);

            Assert.IsTrue(set.IsSubsetOf(list));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsSupersetOfNullExceptionTest()
        {
            set.IsSupersetOf(null);
        }

        [TestMethod]
        public void OverlapsTrueTest()
        {
            for (var i = 0; i <= 2; ++i)
            {
                set.Add(i - 2);
                list.Add(i);
            }

            Assert.IsTrue(set.Overlaps(list));
        }

        [TestMethod]
        public void OverlapsFalseTest()
        {
            for (var i = 0; i <= 2; ++i)
            {
                set.Add(i - 10);
                list.Add(i + 10);
            }

            Assert.IsFalse(set.Overlaps(list));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void OverlapsNullExceptionTest()
        {
            set.Overlaps(null);
        }

        [TestMethod]
        public void SetEqualsTrueTest()
        {
            for (var i = -5; i <= 5; ++i)
            {
                set.Add(i);
                list.Add(i);
            }

            Assert.IsTrue(set.SetEquals(list));
        }

        [TestMethod]
        public void SetEqualsFalseTest()
        {
            for (var i = -5; i <= 5; ++i)
            {
                set.Add(i);
                list.Add(1 - i);
            }

            Assert.IsFalse(set.SetEquals(list));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetEqualsNullExceptionTest()
        {
            set.SetEquals(null);
        }

        [TestMethod]
        public void SymmetricExceptWithTest()
        {
            for (var i = -5; i <= 0; ++i)
            {
                set.Add(i);
                list.Add(-i);
            }

            set.SymmetricExceptWith(list);

            for (var i = -5; i <= 5; ++i)
            {
                Assert.IsTrue(set.Contains(i) || i == 0);
            }
        }

        [TestMethod]
        public void UnionWithTest()
        {
            for (var i = -5; i <= 0; ++i)
            {
                set.Add(i);
                list.Add(-i);
            }

            set.UnionWith(list);

            for (var i = -5; i <= 5; ++i)
            {
                Assert.IsTrue(set.Contains(i));
            }
        }
    }
}