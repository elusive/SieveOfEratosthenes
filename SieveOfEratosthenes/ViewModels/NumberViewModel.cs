using System.ComponentModel;
using System.Windows.Media;
using SieveOfEratosthenes.Core;
using SieveOfEratosthenes.Core.Models;

namespace SieveOfEratosthenes.ViewModels
{
    /// <summary>
    ///     Interaction logic for number view models.
    /// </summary>
    public class NumberViewModel : ModelBase
    {
        protected NumberModel Model;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NumberViewModel" /> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public NumberViewModel(NumberModel model)
        {
            Model = model;
            Model.PropertyChanged += ModelOnPropertyChanged;
        }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public int Number
        {
            get { return Model.Number; }
            set { Model.Number = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is prime.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is prime; otherwise, <c>false</c>.
        /// </value>
        public bool IsPrime
        {
            get { return Model.IsPrime; }
            set { Model.IsPrime = value; }
        }

        /// <summary>
        /// Gets or sets the display color.
        /// </summary>
        public Color DisplayColor
        {
            get { return Model.DisplayColor; }
            set { Model.DisplayColor = value; }
        }

        private void ModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            OnPropertyChanged(propertyChangedEventArgs.PropertyName);
        }
    }
}