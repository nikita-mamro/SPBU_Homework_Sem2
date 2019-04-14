using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;

namespace Homework.Tests
{
    [TestClass]
    public class GameTests
    {
        private string mapFileName = "TestEmptyField.txt";
        private Game game;
        private event EventHandler<EventArgs> LeftTestHandler;
        private event EventHandler<EventArgs> RightTestHandler;
        private event EventHandler<EventArgs> UpTestHandler;
        private event EventHandler<EventArgs> DownTestHandler;

        [TestInitialize]
        public void Initialize()
        {
            game = new Game(mapFileName);
            LeftTestHandler += game.OnLeft;
            RightTestHandler += game.OnRight;
            UpTestHandler += game.OnUp;
            DownTestHandler += game.OnDown;
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.HitWallException))]
        public void OnLeftHitWallExceptionTest()
        {
            while (true)
            {
                LeftTestHandler(this, EventArgs.Empty);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.HitWallException))]
        public void OnRightHitWallExceptionTest()
        {
            while (true)
            {
                RightTestHandler(this, EventArgs.Empty);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.HitWallException))]
        public void OnUpHitWallExceptionTest()
        {
            while (true)
            {
                UpTestHandler(this, EventArgs.Empty);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.HitWallException))]
        public void OnDownHitWallExceptionTest()
        {
            while (true)
            {
                DownTestHandler(this, EventArgs.Empty);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.GotBonesException))]
        public void GotBonesGoingLeftExceptionTest()
        {
            UpTestHandler(this, EventArgs.Empty);

            for (var i = 0; i < 3; ++i)
            {
                LeftTestHandler(this, EventArgs.Empty);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.GotBonesException))]
        public void GotBonesGoingRightExceptionTest()
        {
            for (var i = 0; i < 4; ++i)
            {
                LeftTestHandler(this, EventArgs.Empty);
            }

            UpTestHandler(this, EventArgs.Empty);
            RightTestHandler(this, EventArgs.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.GotBonesException))]
        public void GotBonesGoingUpExceptionTest()
        {
            for (var i = 0; i < 3; ++i)
            {
                LeftTestHandler(this, EventArgs.Empty);
            }

            UpTestHandler(this, EventArgs.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(Exceptions.GotBonesException))]
        public void GotBonesGoingDownExceptionTest()
        {
            UpTestHandler(this, EventArgs.Empty);
            UpTestHandler(this, EventArgs.Empty);

            for (var i = 0; i < 3; ++i)
            {
                LeftTestHandler(this, EventArgs.Empty);
            }

            DownTestHandler(this, EventArgs.Empty);
        }
    }
}