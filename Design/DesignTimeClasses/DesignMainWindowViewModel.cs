using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SieveOfEratosthenes.Core.Models;

namespace DesignTimeClasses
{
    /// <summary>
    /// Design time view model for main window.
    /// </summary>
    public class DesignMainWindowViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DesignMainWindowViewModel"/> class.
        /// </summary>
        public DesignMainWindowViewModel()
        {
            Numbers = new ObservableCollection<DesignNumberViewModel>();
            Enumerable.Range(2, 100).Select(
                n => new DesignNumberViewModel(
                    new NumberModel(n))).ToList()
                    .ForEach(Numbers.Add);
        }

        public ObservableCollection<DesignNumberViewModel> Numbers { get; set; }
        
        /// <summary>
        /// Gets the column count for an even uniform grid of the numbers in the list.
        /// </summary>
        public int ColumnCount
        {
            get { return Convert.ToInt32(Math.Sqrt(Numbers.Count)); }
        }
    }
}
