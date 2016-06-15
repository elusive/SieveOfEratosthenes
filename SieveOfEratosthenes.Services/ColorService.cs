using System.Windows.Media;
using SieveOfEratosthenes.Core;
using SieveOfEratosthenes.Core.Interfaces;

namespace SieveOfEratosthenes.Services
{
    /// <summary>
    ///     Implementation of the <see cref="IColorService" /> interface.
    /// </summary>
    public class ColorService : IColorService
    {
        private readonly Color[] _colors =
        {
            Constants.MultipleOfTwoColor,
            Constants.MultipleOfThreeColor,
            Constants.MultipleOfFiveColor,
            Constants.MultipleOfSevenColor,
            Constants.MultipleOfElevenColor
        };

        private int _currentColorIndex = 0;

        /// <summary>
        ///     Gets the next color from the list of available display colors
        /// </summary>
        /// <returns>
        ///     Media color instance used for brush color.
        /// </returns>
        public Color GetNextColor()
        {
            var color = _colors[_currentColorIndex];
            if (_currentColorIndex == _colors.Length - 1)
            {
                _currentColorIndex = 0;
            }
            else
            {
                _currentColorIndex++;
            }

            return color;
        }

        /// <summary>
        ///     Gets the default color.
        /// </summary>
        public Color DefaultColor
        {
            get { return Constants.DefaultColor; }
        }

        /// <summary>
        ///     Gets the color of the prime.
        /// </summary>
        public Color PrimeColor
        {
            get { return Constants.PrimeColor; }
        }
    }
}