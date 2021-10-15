using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using QU.Challenge.Business;
using Assert = NUnit.Framework.Assert;
using Xunit.Sdk;
using QU.Challenge.API.Validators;

namespace WordMatching_TEST
{
    [TestClass]
    public class UnitTestValidator
    {
        [TestMethod]
        public void TestFindWordsValidator_NullRequest()
        {
            var validatorResult = WordFinderValidator.ValidateRequest(null);
            Assert.IsTrue(!validatorResult.IsOk && validatorResult.Code == 400);
        }

        [TestMethod]
        public void TestFindWordsValidator_EmptyRequest()
        {
            var validatorResult = WordFinderValidator.ValidateRequest(new QU.Challenge.API.Controllers.FindWordRequest());
            Assert.IsTrue(!validatorResult.IsOk && validatorResult.Code == 400);
        }

        [TestMethod]
        public void TestFindWordsValidator_NullMatrix()
        {
            var words = new string[]
            {
                "ASD"
            };

            var validatorResult = WordFinderValidator.ValidateRequest(new QU.Challenge.API.Controllers.FindWordRequest()
            {
                Words = words
            });

            Assert.IsTrue(!validatorResult.IsOk && validatorResult.Code == 400);
        }

        [TestMethod]
        public void TestFindWordsValidator_NullWords()
        {
            var matrix = new string[]
            {
                "BOADLKFHGDJFKBN",
                "BOADLKFHGDJFKBN"
            };

            var validatorResult = WordFinderValidator.ValidateRequest(new QU.Challenge.API.Controllers.FindWordRequest()
            {
                Matrix = matrix
            });

            Assert.IsTrue(!validatorResult.IsOk && validatorResult.Code == 400);
        }

        [TestMethod]
        public void TestFindWordsValidator_TooManyRows()
        {
            var matrix = new string[]
            {
                "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW" ,"ROW",
                "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW" ,"ROW",
                "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW" ,"ROW",
                "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW" ,"ROW",
                "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW" ,"ROW",
                "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW" ,"ROW",
                "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW", "ROW" ,"ROW"
            };

            var words = new string[]
            {
                "ASD"
            };

            var validatorResult = WordFinderValidator.ValidateRequest(new QU.Challenge.API.Controllers.FindWordRequest()
            {
                Matrix = matrix,
                Words = words
            });

            Assert.IsTrue(!validatorResult.IsOk && validatorResult.Code == 400);
        }

        [TestMethod]
        public void TestFindWordsValidator_OK()
        {
            var matrix = new string[]
            {
                "BOADLKFHGDJFKBN",
                "BOADLKFHGDJFKBN"
            };

            var words = new string[]
            {
                "ASD"
            };

            var validatorResult = WordFinderValidator.ValidateRequest(new QU.Challenge.API.Controllers.FindWordRequest()
            {
                Matrix = matrix,
                Words = words
            });

            Assert.IsTrue(validatorResult.IsOk && validatorResult.Code == 200);
        }

        [TestMethod]
        public void TestFindWordsValidator_TooLongColumns()
        {
            var matrix = new string[]
            {
                "BOADLKFHGDJFKBN,DFNGKNFKLDFMGLKDFMGKLDFMGKLMFDLKGMDFLKGMDFLKMGDKFLMDLLFDMGLKDFMGLKDFMGKLFDMGKLFDMGLKDFMGLKFDMGL",
                "BOADLKFHGDJFKBN,DFNGKNFKLDFMGLKDFMGKLDFMGKLMFDLKGMDFLKGMDFLKMGDKFLMDLLFDMGLKDFMGLKDFMGKLFDMGKLFDMGLKDFMGLKFDMGL"
            };

            var words = new string[]
            {
                "ASD"
            };

            var validatorResult = WordFinderValidator.ValidateRequest(new QU.Challenge.API.Controllers.FindWordRequest() 
            {
                Matrix = matrix,
                Words = words
            });

            Assert.IsTrue(!validatorResult.IsOk && validatorResult.Code == 400);
        }
        
        [TestMethod]
        public void TestFindWordsValidator_DifferentColumnLenght()
        {
            var matrix = new string[]
            {
                "BOADLKFHGDJFKBNFFF",
                "BOADLKFHGDJFKBN"
            };

            var words = new string[]
            {
                "ASD"
            };

            var validatorResult = WordFinderValidator.ValidateRequest(new QU.Challenge.API.Controllers.FindWordRequest()
            {
                Matrix = matrix,
                Words = words
            });

            Assert.IsTrue(!validatorResult.IsOk && validatorResult.Code == 400);
        }
    }
}
