using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SieveOfEratosthenes.Core;

namespace SieveOfEratosthenes.Services.Tests
{
    /// <summary>
    /// Test fixture for <see cref="ColorService"/>.
    /// </summary>
    [TestClass]
    public class ColorServiceTests
    {
        /// <summary>
        /// Tests the get next color returns different colors on subsequent calls.
        /// </summary>
        [TestMethod]
        public void TestGetNextColorReturnsDifferentColorsOnSubsequentCalls()
        {
            // arrange
            var serviceUnderTest = new ColorService();

            // act
            var color1 = serviceUnderTest.GetNextColor();
            var color2 = serviceUnderTest.GetNextColor();

            // assert
            Assert.AreNotEqual(color1, color2);
        }

        /// <summary>
        /// Tests the default color returns expected value.
        /// </summary>
        [TestMethod]
        public void TestDefaultColorReturnsExpectedValue()
        {
            // arrange
            var expected = Constants.DefaultColor;
            var serviceUnderTest = new ColorService();

            // act
            var actual = serviceUnderTest.DefaultColor;

            // assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the prime color returns expected value.
        /// </summary>
        [TestMethod]
        public void TestPrimeColorReturnsExpectedValue()
        {
            // arrange
            var expected = Constants.PrimeColor;
            var serviceUnderTest = new ColorService();

            // act
            var actual = serviceUnderTest.PrimeColor;

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
