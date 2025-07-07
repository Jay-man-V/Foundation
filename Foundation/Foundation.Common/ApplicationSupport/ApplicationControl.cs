////-----------------------------------------------------------------------
//// <copyright file="ApplicationControl.cs" company="JDV Software Ltd">
////     Copyright (c) JDV Software Ltd. All rights reserved.
//// </copyright>
////-----------------------------------------------------------------------

//using System.Windows.Threading;

//namespace Foundation.Common
//{
//    /// <summary>
//    /// Application Control contains basic functionality that all applications need to call
//    /// </summary>
//    public abstract class ApplicationControl
//    {
//        /// <summary>
//        /// 
//        /// </summary>
//        private static Action<Exception>? DisplayHandler { get; set; }

//        /// <summary>
//        /// 
//        /// </summary>
//        public static void ApplicationStart(Action<Exception> displayHandler)
//        {
//            DisplayHandler = displayHandler;

//            // For catching Global uncaught exception
//            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionOccurred;
//            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="exception">The exception.</param>
//        public static void LogUnhandledExceptionMessage(Exception exception)
//        {
//            LoggingHelpers.LogErrorMessage(exception);

//            //Core.Core.Instance.Container.Reset();
//            //Core.Core.Instance.Container.Initialise();
//        }

//        /// <summary>
//        /// Handles the UnobservedTaskException event of the TaskScheduler control.
//        /// </summary>
//        /// <param name="sender">The source of the event.</param>
//        /// <param name="args">The <see cref="UnobservedTaskExceptionEventArgs" /> instance containing the event data.</param>
//        public static void TaskScheduler_UnobservedTaskException(Object? sender, UnobservedTaskExceptionEventArgs args)
//        {
//            Exception exception = args.Exception;

//            DisplayHandler?.Invoke(exception);
//        }

//        /// <summary>
//        /// Handles the UnhandledException event of the Dispatcher control.
//        /// </summary>
//        /// <param name="sender">The source of the event.</param>
//        /// <param name="args">The <see cref="DispatcherUnhandledExceptionEventArgs" /> instance containing the event data.</param>
//        public static void Dispatcher_UnhandledException(Object? sender, DispatcherUnhandledExceptionEventArgs args)
//        {
//            Exception exception = args.Exception;

//            DisplayHandler?.Invoke(exception);
//            args.Handled = true;
//        }

//        /// <summary>
//        /// Catches any unhandled exceptions.
//        /// </summary>
//        /// <param name="sender">The sender.</param>
//        /// <param name="args">The <see cref="UnhandledExceptionEventArgs" /> instance containing the event data.</param>
//        public static void UnhandledExceptionOccurred(Object sender, UnhandledExceptionEventArgs args)
//        {
//            Exception exception = (Exception)args.ExceptionObject;

//            DisplayHandler?.Invoke(exception);
//        }
//    }
//}
