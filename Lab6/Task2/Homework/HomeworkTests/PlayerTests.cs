using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Tests
{
    [TestClass]
    public class PlayerTests
    {
        private string mapFileName = "TestEmptyField.txt";
        private string outOfScreenFileName = "TestOutOfScreen.txt";
        private Player testPlayer;
        private Map testMap;
        private Player testOutOfScreenPlayer;

        [TestInitialize]
        public void Initialize()
        {
            testMap = new Map(mapFileName);
            testPlayer = new Player(testMap.InitialPlayerCoordinates);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.HitWallException))]
        public void GoLeftHitWallExceptionTest()
        {
            while (true)
            {
                testPlayer.GoLeft(testMap);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.HitWallException))]
        public void GoRightHitWallExceptionTest()
        {
            while (true)
            {
                testPlayer.GoRight(testMap);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.HitWallException))]
        public void GoUpHitWallExceptionTest()
        {
            while (true)
            {
                testPlayer.GoUp(testMap);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.HitWallException))]
        public void GoDownHitWallExceptionTest()
        {
            while (true)
            {
                testPlayer.GoDown(testMap);
            }
        }
    }
}