using System.Windows;
using Microsoft.Practices.Unity;
using SieveOfEratosthenes.ViewModels;

namespace SieveOfEratosthenes.Views
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Sets the view model.
        /// </summary>
        [Dependency]
        public MainWindowViewModel ViewModel
        {
            set { DataContext = value; }
        }
    }
}