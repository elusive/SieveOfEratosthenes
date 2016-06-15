using System.Windows.Media;

namespace SieveOfEratosthenes.Core.Interfaces
{
    /// <summary>
    ///     Service providing a color for use in displaying backgrounds of a coordinating color.
    /// </summary>
    public interface IColorService
    {
        /// <summary>
        /// Gets the default color.
        /// </summary>
        Color DefaultColor { get; }

        /// <summary>
        /// Gets the color of the prime.
        /// </summary>
        Color PrimeColor { get; }

        /// <summary>
        /// Gets the next color from the list of available display colors
        /// </summary>
        /// <returns>
        /// Media color instance used for brush color.
        /// </returns>
        Color GetNextColor();
    }
}