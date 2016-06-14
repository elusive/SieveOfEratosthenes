using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SieveOfEratosthenes.Services.Tests
{
    [TestClass]
    public class PrimeNumberServiceTests
    {
        [TestMethod]
        public void TestIsPrimeMethodNumberMethodShouldReturnTrueForPrimeNumber()
        {
            // arrange
            const int knownPrime = 7;
            const bool expected = true;

            // act
            var serviceUnderTest = new PrimeNumberService();
            var actual = serviceUnderTest.IsPrimeNumber(knownPrime);

            // assert
            Assert.AreEqual(expected, actual, "The prime number should return true.");
        }

        [TestMethod]
        public void TestIsPrimeNumberMethodShouldReturnFalseForNonPrimeNumber()
        {
            // arrange
            const int knownNonPrime = 8;
            const bool expected = false;

            // act
            var serviceUnderTest = new PrimeNumberService();
            var actual = serviceUnderTest.IsPrimeNumber(knownNonPrime);

            // assert
            Assert.AreEqual(expected, actual, "The non prime number should return false.");
        }
    }
}