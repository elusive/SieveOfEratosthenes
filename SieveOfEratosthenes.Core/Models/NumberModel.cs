using System.Windows.Media;

namespace SieveOfEratosthenes.Core.Models
{
    /// <summary>
    ///     Model class for Number items.
    /// </summary>
    public class NumberModel : ModelBase
    {
        private Color _displayColor = Constants.DefaultColor;
        private bool _isPrime = false;
        private int _number = 0;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NumberModel" /> class.
        /// </summary>
        /// <param name="number">The number.</param>
        public NumberModel(int number)
        {
            Number = number;
        }

        /// <summary>
        ///     Gets or sets the number.
        /// </summary>
        public int Number
        {
            get { return _number; }
            set { SetProperty(ref _number, value); }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is prime.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is prime; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrime
        {
            get { return _isPrime; }
            set
            {
                SetProperty(ref _isPrime, value);
                DisplayColor = Constants.PrimeColor;
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is marked,
        ///     meaning it has been handled by the sieve process.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is marked; otherwise, <c>false</c>.
        /// </value>
        public bool IsMarked
        {
            get { return DisplayColor == Constants.DefaultColor; }
        }

        /// <summary>
        ///     Gets or sets the display color.
        /// </summary>
        public Color DisplayColor
        {
            get { return _displayColor; }
            set { SetProperty(ref _displayColor, value); }
        }

        /// <summary>
        ///     Updates the display color from outside the model class.
        /// </summary>
        public void UpdateDisplayColor(int factor)
        {
            DisplayColor = DetermineColor(factor);
        }

        private Color DetermineColor(int factor)
        {
            // colored by multiple for non-primes
            if (factor == 2) return Constants.MultipleOfTwoColor;
            if (factor == 3) return Constants.MultipleOfThreeColor;
            if (factor == 5) return Constants.MultipleOfFiveColor;
            if (factor == 7) return Constants.MultipleOfSevenColor;
            if (factor == 11) return Constants.MultipleOfElevenColor;
            if (factor == 13) return Constants.MultipleOfThirteenColor;
            if (factor == 17) return Constants.MultipleOfSeventeenColor;

            return DisplayColor;
        }
    }
}