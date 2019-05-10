using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Tests
{
    [TestClass]
    public class StringSeparatorTests
    {
        [TestMethod]
        public void GetListOfWordsTest()
        {
            var sentence0 = "";
            var sentence1 = "hello";
            var sentence2 = "hello hey";

            var words0 = StringSeparator.GetListOfWords(sentence0);
            var words1 = StringSeparator.GetListOfWords(sentence1);
            var words2 = StringSeparator.GetListOfWords(sentence2);

            if (words0.Count != 0 || words1.Count != 1 || words2.Count != 2)
            {
                Assert.Fail();
            }
        }
    }
}