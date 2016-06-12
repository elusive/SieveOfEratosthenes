using System;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;
using SieveOfEratosthenes.Core;
using SieveOfEratosthenes.Core.Interfaces;
using SieveOfEratosthenes.Core.Models;
using SieveOfEratosthenes.Views;

namespace SieveOfEratosthenes.ViewModels
{
    /// <summary>
    ///     Interaction logic for the <see cref="MainWindow" /> view.
    /// </summary>
    public class MainWindowViewModel : ModelBase
    {
        private ObservableCollection<NumberViewModel> _numbers;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindowViewModel" /> class.
        /// </summary>
        public MainWindowViewModel()
        {
            Numbers = new ObservableCollection<NumberViewModel>();

            // build number list
            Enumerable.Range(2, 100).Select(
                n => new NumberViewModel(
                    new NumberModel(n))).ForEach(Numbers.Add);
        }

        /// <summary>
        ///     Gets or sets the prime number service.
        /// </summary>
        [Dependency]
        public IPrimeNumberService PrimeNumberService { get; set; }

        /// <summary>
        ///     Gets or sets the numbers collection for databinding.
        /// </summary>
        public ObservableCollection<NumberViewModel> Numbers
        {
            get { return _numbers; }
            set
            {
                SetProperty(ref _numbers, value);
                OnPropertyChanged(() => ColumnCount);
            }
        }

        /// <summary>
        /// Gets the column count for an even uniform grid of the numbers in the list.
        /// </summary>
        public int ColumnCount
        {
            get { return Convert.ToInt32(Math.Sqrt(Numbers.Count)); }
        }
    }
}