using System;
using System.Collections.Generic;
using SieveOfEratosthenes.Core.Interfaces;

namespace SieveOfEratosthenes.Services
{
    /// <summary>
    ///     Implementation of the <see cref="IPrimeNumberService" /> interface.
    /// </summary>
    public class PrimeNumberService : IPrimeNumberService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PrimeNumberService" /> class.
        /// </summary>
        public PrimeNumberService()
        {
            PrimesFound = new List<int>();
        }

        /// <summary>
        ///     Determines whether [is prime number] [the specified number].
        /// </summary>
        /// <param name="number">The number to check for primeness.</param>
        /// <returns>
        ///     <c>True</c> if the number specified is a prime number,
        ///     otherwise <c>false</c>.
        /// </returns>
        public bool IsPrimeNumber(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            for (var i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i)
            {
                if (number%i == 0) return false;
            }

            PrimesFound.Add(number);
            return true;
        }

        /// <summary>
        ///     Gets or sets the primes found.
        /// </summary>
        /// <remarks>
        ///     Will store found prime numbers, from <see cref="IPrimeNumberService.IsPrimeNumber" /> method
        ///     until the <see cref="Reset" /> method is called.
        /// </remarks>
        public IList<int> PrimesFound { get; set; }

        /// <summary>
        ///     Resets the list of found prime numbers stored in the
        ///     <see cref="PrimesFound" /> property.
        /// </summary>
        public void Reset()
        {
            PrimesFound = new List<int>();
        }
    }
}