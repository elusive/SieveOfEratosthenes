using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SieveOfEratosthenes.Services.Tests
{
    /// <summary>
    /// Test fixture for <see cref="PrimeNumberService"/>.
    /// </summary>
    [TestClass]
    public class PrimeNumberServiceTests
    {
        /// <summary>
        /// Tests the is prime method number method should return true for prime number.
        /// </summary>
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

        /// <summary>
        /// Tests the is prime number method should return false for non prime number.
        /// </summary>
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

        /// <summary>
        /// Tests the primes found returns numbers found to be prime.
        /// </summary>
        [TestMethod]
        public void TestPrimesFoundReturnsNumbersFoundToBePrime()
        {
            // arrange
            const int knownPrime = 7;

            // act
            var serviceUnderTest = new PrimeNumberService();
            serviceUnderTest.IsPrimeNumber(knownPrime);
            
            // assert
            Assert.IsTrue(serviceUnderTest.PrimesFound.Contains(knownPrime));
        }

        /// <summary>
        /// Tests the reset empties primes found list.
        /// </summary>
        [TestMethod]
        public void TestResetEmptiesPrimesFoundList()
        {
            // arrange
            const int knownPrime = 7;

            // act
            var serviceUnderTest = new PrimeNumberService();
            serviceUnderTest.IsPrimeNumber(knownPrime);
            serviceUnderTest.Reset();

            // assert
            Assert.IsFalse(serviceUnderTest.PrimesFound.Any());
        }
    }
}