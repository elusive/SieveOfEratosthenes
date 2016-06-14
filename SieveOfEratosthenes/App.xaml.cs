using System.Windows;
using Microsoft.Practices.Unity;
using SieveOfEratosthenes.Core.Interfaces;
using SieveOfEratosthenes.Services;
using SieveOfEratosthenes.ViewModels;
using SieveOfEratosthenes.Views;

namespace SieveOfEratosthenes
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        ///     Raises the <see cref="E:System.Windows.Application.Startup" /> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer container = new UnityContainer();

            container.RegisterType<IPrimeNumberService, PrimeNumberService>();
            container.RegisterType<IDispatchService, DispatchService>();
            container.RegisterType<MainWindow>();
            container.RegisterType<MainWindowViewModel>();

            var window = container.Resolve<MainWindow>();
            window.Show();
        }
    }
}