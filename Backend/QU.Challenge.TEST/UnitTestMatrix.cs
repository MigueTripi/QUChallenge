using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using QU.Challenge.Business;
using Assert = NUnit.Framework.Assert;
using Xunit.Sdk;

namespace WordMatching_TEST
{
    [TestClass]
    public class UnitTestMatrix
    {
        [TestMethod]
        public void TestFindTwoHorizontalWords_OnePerRow()
        {
            var matrix = new string[]
            {
                "ARESCT",
                "PUTRYZ"
            };

            var words = new string[]
            {
                "ARE",
                "PUT",
                "ESD"
            };

            var findRecursive = new WordFinder(matrix);
            var result = findRecursive.Find(words);

            Assert.That(result, Is.EqualTo(new List<string>() { "ARE", "PUT" }));
        }
        [TestMethod]
        public void TestFindTwoHorizontalWordsAtTheEnd_OnePerRow()
        {
            var matrix = new string[]
            {
                "HELLOEND",
                "BYEETNET"
            };

            var words = new string[]
            {
                "END",
                "NET"
            };

            var findRecursive = new WordFinder(matrix);
            var result = findRecursive.Find(words);

            Assert.That(result, Is.EqualTo(new List<string>() { "END", "NET" }));
        }

    }
}
