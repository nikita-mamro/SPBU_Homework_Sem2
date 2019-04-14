using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;
using System.IO;
using System.Collections.Generic;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты класса Map
    /// </summary>
    [TestClass]
    public class MapTests
    {
        private string mapFileName = "TestEmptyField.txt";
        private Map testMap;

        [TestInitialize]
        public void Initialize()
        {
            testMap = new Map(mapFileName);
        }

        /// <summary>
        /// Тесты корректности работы метода генерации карты
        /// </summary>
        [TestMethod]
        public void WallGenerationTest()
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
                    Assert.IsTrue(' ' == testMap.Field[i][j] || 'X' == testMap.Field[i][j] || '@' == testMap.Field[i][j]);
                }
            }
        }

        /// <summary>
        /// Тесты корректности работы метода IsWall
        /// </summary>
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

        /// <summary>
        /// Проверка корректности получения координат спауна игрока и костей
        /// </summary>
        [TestMethod]
        public void GetPlayerAndDestionationCoordinatesTest()
        {
            (int, int) expectedPlayerCoordinates = (-1, -1);
            (int, int) expectedDestinationCoordinates = (-1, -1);

            using (StreamReader sr = new StreamReader(Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory())), mapFileName)))
            {
                string line;
                var y = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    var x = 0;

                    foreach (var symbol in line)
                    {
                        if (symbol == '@')
                        {
                            expectedPlayerCoordinates = (x, y);
                            ++x;
                            continue;
                        }

                        if (symbol == 'X')
                        {
                            expectedDestinationCoordinates = (x, y);
                        }

                        ++x;
                    }

                    ++y;
                }
            }

            Assert.IsTrue(expectedPlayerCoordinates == testMap.InitialPlayerCoordinates && expectedDestinationCoordinates == testMap.DestinationCoordinates);
        }
    }
}