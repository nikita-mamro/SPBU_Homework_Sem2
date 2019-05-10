using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Tests
{
    /// <summary>
    /// Недотесты множества SortedSet
    /// </summary>
    [TestClass]
    public class SortedSetTests
    {
        [TestMethod]
        public void GetSortedElementsTest()
        {
            var strings = new List<string>();

            strings.Add("One two three four five");
            strings.Add("One two three four");
            strings.Add("One two three");
            strings.Add("One two");
            strings.Add("One");

            var lists = new List<List<string>>();

            foreach (var str in strings)
            {
                lists.Add(StringSeparator.GetListOfWords(str));
            }

            var set = new SortedSet<string>(lists);

            var sortedStrings = set.GetSortedElements();

            var currentCount = -1;

            foreach (var sentence in sortedStrings)
            {
                if (sentence.Count < currentCount)
                {
                    Assert.Fail();
                }

                currentCount = sentence.Count;
            }
        }
    }
}