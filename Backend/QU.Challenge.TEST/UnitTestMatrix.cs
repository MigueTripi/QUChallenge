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

        [TestMethod]
        public void TestProvidedExample()
        {
            var matrix = new string[]
            {
                "ABCDC",
                "FGWIO",
                "CHILL",
                "PQNSD",
                "UVDXY"
            };

            var words = new string[]
            {
                "COLD",
                "WIND",
                "SNOW",
                "CHILL"
            };

            var findRecursive = new WordFinder(matrix);
            var result = findRecursive.Find(words);

            Assert.That(result, Is.EqualTo(new List<string>() { "CHILL", "COLD", "WIND" }));
        }

        [TestMethod]
        public void TestFindElevenWords_ReturnTen()
        {
            var matrix = new string[]
            {
                "BIRDCRY",
                "IGWIOUT",
                "RHILLOL",
                "DONSDUE",
                "BIDXYOU"
            };

            //YOU whould be expluded due to alphabetic order
            var words = new string[]
            {
                "COLD",
                "SNOW",
                "BIRD",
                "CRY",
                "IO",
                "OUT",
                "LOL",
                "DON",
                "DUE",
                "YOU",
                "BID",
                "ILL"
            };

            var findRecursive = new WordFinder(matrix);
            var result = findRecursive.Find(words);
            
            Assert.That(result, Is.EqualTo(
                new List<string>() { "BIRD", "BID", "COLD", "CRY", "DON", "DUE", "ILL", "IO", "LOL", "OUT" }));
        }


        [TestMethod]
        public void TestFindFourWords_BiggestMatrix()
        {
            var matrix = new string[]
            {
                "BIRDCRYCOLDDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYOBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYLBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYDBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCOLDBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCOLD",
                "BIRDCRYSBIRDOBIRBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDOLYS",
                "BIRDCRYSBIRDLBIRBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDLRYS",
                "BIRDCRYSBIRDDBIRBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDDRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCOLDBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDOBIRBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDLBIRBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDDBIRBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCSNOWIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCNYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "BIRDCOYSBIODCRYSBIRDCRYSBIRDCRYSOUTDCRYSBIRDCRYSBIRDCRYSBIRDCRYS",
                "SNOWCWYSBIRDCRYSBIRDCRYSBIRDCRYSBIROUTYSBIRDCRYSBIRDCRYSBIRDCRYS"
            };

            var words = new string[]
            {
                "COLD",
                "SNOW",
                "IO",
                "OUT",
                "LOL",
                "DON",
                "DUE",
                "ILL"
            };

            var findRecursive = new WordFinder(matrix);
            var result = findRecursive.Find(words);

            Assert.That(result, Is.EqualTo(
                new List<string>() { "COLD", "SNOW", "OUT", "IO" }));
        }
    }
}
