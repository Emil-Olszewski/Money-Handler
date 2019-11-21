using Money_App.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Money_App.Model.Tests
{
    [TestClass()]
    public class SorterTests
    {
        [TestMethod()]
        public void SortAlphabeticallyTest()
        {
            var list = new List<string>()
            {
                "abc", "cab", "bac", "acb", "cba", "bca"
            };

            Sorter.SortAlphabetically(list);

            Assert.IsTrue(list[0] == "abc");
            Assert.IsTrue(list[1] == "acb");
            Assert.IsTrue(list[2] == "bac");
            Assert.IsTrue(list[3] == "bca");
            Assert.IsTrue(list[4] == "cab");
            Assert.IsTrue(list[5] == "cba");
        }

        [TestMethod()]
        public void IsAlphabeticallyFirstTest()
        {
            string[] strings =
            {
                "ab", "ba", "abcde", "abced",
                "04yui", "02rrr", "00kak", "00kaka"
            };

            Assert.IsTrue(Sorter.IsAlphabeticallyFirst(strings[0], strings[1]));
            Assert.IsTrue(Sorter.IsAlphabeticallyFirst(strings[2], strings[3]));
            Assert.IsTrue(Sorter.IsAlphabeticallyFirst(strings[5], strings[4]));
            Assert.IsTrue(Sorter.IsAlphabeticallyFirst(strings[6], strings[7]));
        }
    }
}