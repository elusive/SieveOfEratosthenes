using System.Windows.Media;

namespace SieveOfEratosthenes.Core.Models
{
    /// <summary>
    ///     Model class for Number items.
    /// </summary>
    public class NumberModel : ModelBase
    {
        private Color _displayColor = Constants.DefaultColor;
        private bool _isPrime;
        private int _number;

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
            set { SetProperty(ref _isPrime, value); }
        }

        /// <summary>
        ///     Gets or sets the display color.
        /// </summary>
        public Color DisplayColor
        {
            get { return _displayColor; }
            set { SetProperty(ref _displayColor, value); }
        }
    }
}