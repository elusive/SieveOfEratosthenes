using System.Windows.Media;

namespace SieveOfEratosthenes.Core.Models
{
    /// <summary>
    ///     Model class for Number items.
    /// </summary>
    public class NumberModel : ModelBase
    {
        private Color _displayColor = Colors.CadetBlue;
        private bool _isPrime = false;
        private int _number = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="NumberModel"/> class.
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
                OnPropertyChanged(() => DisplayColor);
            }
        }

        /// <summary>
        ///     Gets or sets the display color.
        /// </summary>
        public Color DisplayColor
        {
            get
            {
                _displayColor = DetermineColor();
                return _displayColor;
            }
        }

        private Color DetermineColor()
        {
            // prime?
            if (_isPrime) return Constants.PrimeColor;

            // colored by multiple for non-primes
            if (_number%2 == 0) return Constants.MultipleOfTwoColor;
            if (_number%3 == 0) return Constants.MultipleOfThreeColor;
            if (_number%5 == 0) return Constants.MultipleOfFiveColor;
            if (_number%7 == 0) return Constants.MultipleOfSevenColor;

            return Constants.DefaultColor;
        }
    }
}