using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using QU.Challenge.Business;
using Assert = NUnit.Framework.Assert;
using Xunit.Sdk;

namespace WordMatching_TEST
{
    [TestClass]
    public class UnitTestVector
    {
        [TestMethod]
        public void TestFindTwoWords()
        {
            var matrix = new string[]
            {
                "ARESCT"
            };

            var words = new string[]
            {
                "ARE",
                "ARES",
                "REC"
            };

            var findRecursive = new WordFinder(matrix);
            var result = findRecursive.Find(words);

            Assert.That(result, Is.EqualTo(new List<string>() { "ARE", "ARES" }));
        }
        [TestMethod]
        public void Test_FindOnlyOneWord()
        {
            var matrix = new string[]
            {
                "ARESTC"
            };

            var words = new string[]
            {
                "REST",
            };

            var findRecursive = new WordFinder(matrix);
            var result = findRecursive.Find(words);

            Assert.That(result, Is.EqualTo(new List<string>() { "REST" }));
        }

        [TestMethod]
        public void Test_FindStartingWord()
        {
            var matrix = new string[]
            {
                "BOAT"
            };

            var words = new string[]
            {
                "BOAT",
            };

            var findRecursive = new WordFinder(matrix);
            var result = findRecursive.Find(words);

            Assert.That(result, Is.EqualTo(new List<string>() { "BOAT" }));
        }

        [TestMethod]
        public void Test_DoesNotFindHigherWord()
        {
            var matrix = new string[]
            {
                "BOA"
            };

            var words = new string[]
            {
                "BOAT",
            };

            var findRecursive = new WordFinder(matrix);
            var result = findRecursive.Find(words);

            Assert.That(result, Is.EqualTo(new List<string>() { }));
        }

    }
}
