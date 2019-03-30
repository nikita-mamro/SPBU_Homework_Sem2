using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;
using System.Collections.Generic;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты функций Map, Filter и Fold 
    /// </summary>
    [TestClass()]
    public class FunctionsTests
    {
        /// <summary>
        /// Тесты Map() для некоторых типов
        /// </summary>
        [TestMethod()]
        public void MapIntToIntTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var res = Functions.Map(list, x => x * 3);

            for (int i = 0; i < list.Count; ++i)
            {
                if (res[i] != list[i] * 3)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void MapIntToCharTest()
        {
            var list = new List<int>() {1, 2, 3, 4, 5};
            var res = Functions.Map(list, x => (char)x);

            for (int i = 0; i < res.Count; ++i)
            {
                if (res[i] != (char)list[i])
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void MapCharToIntTest()
        {
            var list = new List<char>() { '1', '2', '3', '4', '5' };
            var res = Functions.Map(list, x => (int)x);

            for (int i = 0; i < res.Count; ++i)
            {
                if (res[i] != (int)list[i])
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void MapCharToCharTest()
        {
            var list = new List<char>() { '1', '2', '3', '4', '5' };
            var res = Functions.Map(list, x => x + 2);

            for (int i = 0; i < res.Count; ++i)
            {
                if (res[i] != list[i] + 2)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void MapIntToDoubleTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var res = Functions.Map(list, x => (double)(x / 3));

            for (int i = 0; i < res.Count; ++i)
            {
                if (res[i] != (double)(list[i] / 3))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void MapDoubleToIntTest()
        {
            var list = new List<double>() { 1.21, 2.115, 3.124, 4.5125, 5.99 };
            var res = Functions.Map(list, x => (int)x);

            for (int i = 0; i < res.Count; ++i)
            {
                if (res[i] != (int)list[i])
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void MapDoubleToDoubleTest()
        {
            var list = new List<double>() { 1.21, 2.115, 3.124, 4.5125, 5.99 };
            var res = Functions.Map(list, x => x * 1.234);
            
            for (int i = 0; i < res.Count; ++i)
            {
                if (res[i] != list[i] * 1.234)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void MapCharToStringTest()
        {
            var list = new List<char>() { '1', '2', '3', '4', '5' };
            var res = Functions.Map(list, x => (string)(x.ToString() + "string"));

            for (int i = 0; i < res.Count; ++i)
            {
                if (res[i] != list[i].ToString() + "string")
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void MapSrtingToCharTest()
        {
            var list = new List<string>() { "one", "two", "three", "four", "five" };
            var res = Functions.Map(list, x => (char)(x[0]));

            for (int i = 0; i < res.Count; ++i)
            {
                if (res[i] != (char)(list[i][0]))
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void MapStringToStringTest()
        {
            var list = new List<string>() { "one", "two", "three", "four", "five" };
            var res = Functions.Map(list, x => (string)(x.ToString() + "string"));

            for (int i = 0; i < res.Count; ++i)
            {
                if (res[i] != list[i] + "string")
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// Тесты Fold() для некоторых типов
        /// </summary>
        [TestMethod()]
        public void FilterIntTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var res = Functions.Filter(list, x => x > 3);

            foreach (var element in res)
            {
                if (element <= 3)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void FilterBigListIntTest()
        {
            var list = new List<int>();

            for (int i = -100; i < 100; ++i)
            {
                list.Add(i);
            }

            var res = Functions.Filter(list, x => x < -31);

            foreach (var element in res)
            {
                if (element >= -31)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void FilterDoubleTest()
        {
            var list = new List<double>() { 1.21, 2.115, 3.124, 4.5125, 5.99 };
            var res = Functions.Filter(list, x => x > 2.4);

            foreach (var element in res)
            {
                if (element <= 2.4)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void FilterBigListDoubleTest()
        {
            var list = new List<double>();

            for (int i = -100; i < 100; ++i)
            {
                list.Add((double)i + 0.123);
            }

            var res = Functions.Filter(list, x => x < -10.23);

            foreach (var element in res)
            {
                if (element >= -10.23)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void FilterCharTest()
        {
            var list = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'c' };
            var res = Functions.Filter(list, x => x == 'c' || x == 'd');

            foreach (var element in res)
            {
                if (element != 'c' && element != 'd')
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void FilterBigListCharTest()
        {
            var list = new List<char>();

            for (int i = 0; i < 200; ++i)
            {
                list.Add((char)i);
            }

            var res = Functions.Filter(list, x => x >= 'q');

            foreach (var element in res)
            {
                if (element < 'q')
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod()]
        public void FilterStringTest()
        {
            var list = new List<string>() { "one", "two", "three", "four", "five" };
            var res = Functions.Filter(list, x => x == "three");

            foreach (var element in res)
            {
                if (element != "three")
                {
                    Assert.Fail();
                }
            }
        }

        /// <summary>
        /// Тесты Fold() для некоторых типов
        /// </summary>
        [TestMethod()]
        public void FoldIntToIntTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var res = Functions.Fold(list, 2, (acc, elem) => acc + elem);
            Assert.AreEqual(17, res);
        }

        [TestMethod()]
        public void FoldIntToDoubleTest()
        {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            var res = Functions.Fold(list, 4.5, (acc, elem) => acc * elem);
            Assert.IsTrue(res == 540);
        }

        [TestMethod()]
        public void FoldDoubleTest()
        {
            var list = new List<double>() { 1.23, 2.34, 3.45, 4.56, 5.67 };
            var res = Functions.Fold(list, 10.234, (acc, elem) => acc + elem);
            Assert.AreEqual(27.484, res);
        }

        [TestMethod()]
        public void FoldStringTest()
        {
            var list = new List<string>() { "w", "o", "r", "l", "d" };
            var res = Functions.Fold(list, "hello", (acc, elem) => acc + elem);
            Assert.AreEqual("helloworld", res);
        }
    }
}