using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using SieveOfEratosthenes.Core.Interfaces;

namespace SieveOfEratosthenes.Services
{
    /// <summary>
    ///     Implementation of <see cref="IDispatchService" />
    /// </summary>
    public class DispatchService : IDispatchService
    {
        private readonly TimeSpan _uiEternity = new TimeSpan(0, 0, 10);

        private Dispatcher _dispatcher;

        /// <summary>
        ///     Current application's Dispatcher
        /// </summary>
        private Dispatcher Dispatcher
        {
            get
            {
                if (_dispatcher == null && Application.Current != null)
                {
                    _dispatcher = Application.Current.Dispatcher;
                }

                return _dispatcher;
            }
        }

        /// <summary>
        ///     Invoke an action on a background thread - any thread but the dispatcher.
        /// </summary>
        /// <param name="action">the Method to execute</param>
        public void Background(Action action)
        {
            var wrappedAction = new Action(
                () =>
                {
                    try
                    {
                        action();
                    }
                    catch (Exception e)
                    {
                        throw new ApplicationException(e.Message);
                    }
                });

            if (CheckAccess())
            {
                Task.Run(wrappedAction);
            }
            else
            {
                wrappedAction();
            }
        }

        /// <summary>
        ///     Invoke a method on the Dispatcher asynchronously
        /// </summary>
        /// <param name="action">the Method to execute</param>
        public void BeginInvoke(Action action)
        {
            BeginInvoke(action, DispatcherPriority.Normal);
        }

        /// <summary>
        ///     Invoke a method on the Dispatcher asynchronously
        /// </summary>
        /// <param name="action">the Method to execute</param>
        /// <param name="priority">Invoke Priority</param>
        public void BeginInvoke(Action action, DispatcherPriority priority)
        {
            if (Dispatcher == null || Dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                Dispatcher.BeginInvoke(action, priority);
            }
        }

        /// <summary>
        ///     Determines if the calling thread is the dispatcher thread.
        /// </summary>
        /// <returns>True if the calling thread is the dispatcher</returns>
        public bool CheckAccess()
        {
            return (Dispatcher == null || Dispatcher.CheckAccess());
        }

        /// <summary>
        ///     Allows break in main thread for updates to main window display.
        /// </summary>
        public void DoEvents()
        {
            Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }

        /// <summary>
        ///     Invoke a method on the Dispatcher synchronously
        /// </summary>
        /// <param name="action">the Method to execute</param>
        public void Invoke(Action action)
        {
            Invoke(action, DispatcherPriority.Normal);
        }

        /// <summary>
        ///     Invoke a method on the Dispatcher synchronously
        /// </summary>
        /// <param name="action">the Method to execute</param>
        /// <param name="priority">Invoke Priority</param>
        public void Invoke(Action action, DispatcherPriority priority)
        {
            if (Dispatcher == null || Dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                Dispatcher.BeginInvoke(action, priority);
            }
        }
    }
}