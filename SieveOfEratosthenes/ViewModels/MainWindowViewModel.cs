using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
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
        [InjectionConstructor]
        public MainWindowViewModel(IDispatchService dispatchService)
        {
            Numbers = new ObservableCollection<NumberViewModel>();

            // build number list
            Enumerable.Range(2, 100).Select(
                n => new NumberViewModel(
                    new NumberModel(n), dispatchService)).ForEach(Numbers.Add);

            ProcessNumberSieveCommand = new RelayCommand(ExecuteProcessNumberSieveCommand, () => true);
        }

        /// <summary>
        ///     Gets the process number sieve command.
        /// </summary>
        public ICommand ProcessNumberSieveCommand { get; private set; }

        /// <summary>
        ///     Gets or sets the prime number service.
        /// </summary>
        [Dependency]
        public IPrimeNumberService PrimeNumberService { get; set; }

        /// <summary>
        ///     Gets or sets the dispatch service.
        /// </summary>
        [Dependency]
        public IDispatchService DispatchService { get; set; }

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
        ///     Gets the column count for an even uniform grid of the numbers in the list.
        /// </summary>
        public int ColumnCount
        {
            get { return Convert.ToInt32(Math.Sqrt(Numbers.Count)); }
        }

        private void ExecuteProcessNumberSieveCommand()
        {
            DispatchService.Background(() =>
            {
                const int interval = 100;
                var max = _numbers.Count;

                for (var i = 2; i <= max; i++)
                {
                    // delay
                    System.Threading.Thread.Sleep(interval);

                    // adjust for collection starting at 2
                    var index = i - 2;
                    var number = i;

                    // See if i is prime.
                    if (!PrimeNumberService.IsPrimeNumber(number)) continue;

                    // mark as prime
                    _numbers[index].IsPrime = true;

                    // Knock out multiples of number
                    for (var j = number*2; j <= max; j += number)
                    {
                        _numbers[j - 2].IsPrime = false;
                        _numbers[j - 2].Model.UpdateDisplayColor(number);

                        // delay
                        System.Threading.Thread.Sleep(interval);
                    }
                }
            });
        }
    }
}