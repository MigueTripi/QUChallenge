using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using QU.Challenge.Business;
using Assert = NUnit.Framework.Assert;

namespace WordMatching_TEST
{
    [TestClass]
    public class UnitTest
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

            var findRecursive = new FindRecursive();
            var result = findRecursive.Execute(matrix, words);

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

            var findRecursive = new FindRecursive();
            var result = findRecursive.Execute(matrix, words);

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

            var findRecursive = new FindRecursive();
            var result = findRecursive.Execute(matrix, words);

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

            var findRecursive = new FindRecursive();
            var result = findRecursive.Execute(matrix, words);

            Assert.That(result, Is.EqualTo(new List<string>() { }));
        }

    }
}
