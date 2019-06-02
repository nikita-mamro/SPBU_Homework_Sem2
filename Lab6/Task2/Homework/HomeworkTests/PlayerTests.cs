using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;
using Exceptions;

namespace Homework.Tests
{
    /// <summary>
    /// Тесты класса, реализующего игрока как персонажа
    /// </summary>
    [TestClass]
    public class PlayerTests
    {
        private string mapFileName = "TestEmptyField.txt";
        private string outOfScreenFileName = "TestOutOfScreen.txt";
        private Player testPlayer;
        private Map testMap;
        private Player testOutOfScreenPlayer;
        private Map testOutOfScreenMap;

        [TestInitialize]
        public void Initialize()
        {
            testMap = new Map(mapFileName);
            testPlayer = new Player(testMap.InitialPlayerCoordinates);
            testOutOfScreenMap = new Map(outOfScreenFileName);
            testOutOfScreenPlayer = new Player(testOutOfScreenMap.InitialPlayerCoordinates);
        }

        /// <summary>
        /// Тесты корректности срабатывания исключения, когда игрок врезается в стену с разных сторон
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(HitWallException))]
        public void GoLeftHitWallExceptionTest()
        {
            while (true)
            {
                testPlayer.GoLeft(testMap);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(HitWallException))]
        public void GoRightHitWallExceptionTest()
        {
            while (true)
            {
                testPlayer.GoRight(testMap);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(HitWallException))]
        public void GoUpHitWallExceptionTest()
        {
            while (true)
            {
                testPlayer.GoUp(testMap);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(HitWallException))]
        public void GoDownHitWallExceptionTest()
        {
            while (true)
            {
                testPlayer.GoDown(testMap);
            }
        }

        /// <summary>
        /// Тесты корректности срабатывания исключения, когда игрок забирает косточки с разных сторон
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(GotBonesException))]
        public void GotBonesGoingLeftExceptionTest()
        {
            testPlayer.GoUp(testMap);

            for (var i = 0; i < 3; ++i)
            {
                testPlayer.GoLeft(testMap);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(GotBonesException))]
        public void GotBonesGoingRightExceptionTest()
        {
            for (var i = 0; i < 4; ++i)
            {
                testPlayer.GoLeft(testMap);
            }

            testPlayer.GoUp(testMap);
            testPlayer.GoRight(testMap);
        }

        [TestMethod]
        [ExpectedException(typeof(GotBonesException))]
        public void GotBonesGoingUpExceptionTest()
        {
            for (var i = 0; i < 3; ++i)
            {
                testPlayer.GoLeft(testMap);
            }

            testPlayer.GoUp(testMap);
        }

        [TestMethod]
        [ExpectedException(typeof(GotBonesException))]
        public void GotBonesGoingDownExceptionTest()
        {
            testPlayer.GoUp(testMap);
            testPlayer.GoUp(testMap);

            for (var i = 0; i < 3; ++i)
            {
                testPlayer.GoLeft(testMap);
            }

            testPlayer.GoDown(testMap);
        }

        /// <summary>
        /// Тесты корректности срабатывания исключения, когда игрок выходит за пределы экрана сверху/слева
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(GoingOutOfScreenException))]
        public void OutOfScreenGoingUpExceptionTest()
        {
            testOutOfScreenPlayer.GoUp(testOutOfScreenMap);
        }

        [TestMethod]
        [ExpectedException(typeof(GoingOutOfScreenException))]
        public void OutOfScreenGoingLeftExceptionTest()
        {
            testOutOfScreenPlayer.GoLeft(testOutOfScreenMap);
        }
    }
}