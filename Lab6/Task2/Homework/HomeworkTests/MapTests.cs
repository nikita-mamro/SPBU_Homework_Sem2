using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;

namespace Homework.Tests
{
    [TestClass()]
    public class MapTests
    {
        private Map testMap;

        [TestInitialize]
        public void Initialize()
        {
            testMap = new Map("TestEmptyField.txt");
        }

        [TestMethod]
        public void MapGenerationTest()
        {
            for (var i = 0; i < testMap.Field.Count; ++i)
            {
                for (var j = 0; j < testMap.Field[i].Count; ++j)
                {
                    if (i == 0 || i == testMap.Field.Count - 1)
                    {
                        Assert.AreEqual('#', testMap.Field[i][j]);
                        continue;
                    }
                    if (j == 0 || j == testMap.Field[i].Count - 1)
                    {
                        Assert.AreEqual('#', testMap.Field[i][j]);
                        continue;
                    }
                    Assert.AreEqual(' ', testMap.Field[i][j]);
                }
            }
        }

        [TestMethod()]
        public void IsWallTest()
        {
            for (var i = 0; i < testMap.Field.Count; ++i)
            {
                for (var j = 0; j < testMap.Field[i].Count; ++j)
                {
                    if (i == 0 || i == testMap.Field.Count - 1)
                    {
                        Assert.IsTrue(testMap.IsWall((j, i)));
                        continue;
                    }
                    if (j == 0 || j == testMap.Field[i].Count - 1)
                    {
                        Assert.IsTrue(testMap.IsWall((j, i)));
                        continue;
                    }
                    Assert.IsFalse(testMap.IsWall((j, i)));
                }
            }
        }
    }
}