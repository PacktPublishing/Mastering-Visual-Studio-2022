using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using kata;

namespace kata.Tests
{
    [TestClass]
    [PexClass(typeof(FizzBuzz))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class FizzBuzzTest
    {

        [PexMethod]
        public string[] GenerateOutput(int maxNumber)
        {
            string[] result = FizzBuzz.GenerateOutput(maxNumber);
            return result;
            // TODO: add assertions to method FizzBuzzTest.GenerateOutput(Int32)
        }

        [PexMethod]
        public FizzBuzz Constructor()
        {
            FizzBuzz target = new FizzBuzz();
            return target;
            // TODO: add assertions to method FizzBuzzTest.Constructor()
        }
    }
}
