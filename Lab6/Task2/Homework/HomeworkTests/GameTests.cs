using Microsoft.VisualStudio.TestTools.UnitTesting;
using Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework.Tests
{
    [TestClass()]
    public class GameTests
    {
        private Map testMap;

        [TestInitialize]
        public void Initialize()
        {
            testMap = new Map("TestEmptyField.txt");
        }

        [TestMethod]
        public void OnLeftTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void OnRightTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void OnUpTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void OnDownTest()
        {
            Assert.Fail();
        }
    }
}