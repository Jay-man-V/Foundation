//-----------------------------------------------------------------------
// <copyright file="ApplicationControl.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows.Threading;

namespace Foundation.Common
{
    /// <summary>
    /// Application Control contains basic functionality that all applications need to call
    /// </summary>
    public abstract class ApplicationControl
    {
        /// <summary>
        /// 
        /// </summary>
        private static Action<Exception>? AdditionalExceptionHandler { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public static void ApplicationStart(Action<Exception>? additionalExceptionHandler)
        {
            AdditionalExceptionHandler = additionalExceptionHandler;

            ApplicationClose(additionalExceptionHandler);

            // For catching Global uncaught exception
            AppDomain.CurrentDomain.UnhandledException += AppDomain_UnhandledException;

            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
        }

        /// <summary>
        /// 
        /// </summary>
        public static void ApplicationClose(Action<Exception>? additionalExceptionHandler)
        {
            AdditionalExceptionHandler = additionalExceptionHandler;

            // For catching Global uncaught exception
            AppDomain.CurrentDomain.UnhandledException -= AppDomain_UnhandledException;

            TaskScheduler.UnobservedTaskException -= TaskScheduler_UnobservedTaskException;
        }

        /// <summary>
        /// Handles the UnhandledException event of the Dispatcher control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="DispatcherUnhandledExceptionEventArgs" /> instance containing the event data.</param>
        public static void Dispatcher_UnhandledException(Object? sender, DispatcherUnhandledExceptionEventArgs args)
        {
            Exception exception = args.Exception;

            AdditionalExceptionHandler?.Invoke(exception);

            args.Handled = true;
        }

        /// <summary>
        /// Catches any unhandled exceptions.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="UnhandledExceptionEventArgs" /> instance containing the event data.</param>
        private static void AppDomain_UnhandledException(Object sender, UnhandledExceptionEventArgs args)
        {
            Exception exception = (Exception)args.ExceptionObject;

            AdditionalExceptionHandler?.Invoke(exception);
        }

        /// <summary>
        /// Handles the UnobservedTaskException event of the TaskScheduler control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="UnobservedTaskExceptionEventArgs" /> instance containing the event data.</param>
        private static void TaskScheduler_UnobservedTaskException(Object? sender, UnobservedTaskExceptionEventArgs args)
        {
            Exception exception = args.Exception;

            LogExceptionMessage(exception);

            AdditionalExceptionHandler?.Invoke(exception);

            args.SetObserved();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void LogExceptionMessage(Exception exception)
        {
            LoggingHelpers.LogErrorMessage(exception);

            // TODO
            //Core.Core.Instance.Container.Reset();
            //Core.Core.Instance.Container.Initialise();
        }
    }
}
