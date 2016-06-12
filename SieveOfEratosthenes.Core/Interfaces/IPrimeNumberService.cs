using System.Collections.Generic;

namespace SieveOfEratosthenes.Core.Interfaces
{
    /// <summary>
    /// Service for finding and listing prime numbers.
    /// </summary>
    public interface IPrimeNumberService
    {
        /// <summary>
        /// Determines whether [is prime number] [the specified number].
        /// </summary>
        /// <param name="number">The number to check for primeness.</param>
        /// <returns><c>True</c> if the number specified is a prime number, 
        /// otherwise <c>false</c>.</returns>
        bool IsPrimeNumber(int number);

        /// <summary>
        /// Gets or sets the primes found.
        /// </summary>
        /// <remarks>Will store found prime numbers, from <see 
        /// cref="IPrimeNumberService.IsPrimeNumber"/> method
        /// until the <see cref="Reset"/> method is called.</remarks>
        IList<int> PrimesFound { get; set; }

        /// <summary>
        /// Resets the list of found prime numbers stored in the 
        /// <see cref="PrimesFound"/> property.
        /// </summary>
        void Reset();
    }
}
