using System.ComponentModel.Composition;
using System.Windows;

namespace SieveOfEratosthenes.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [ImportingConstructor]
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
