//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Foundation.Common;
using Foundation.Core;
using Foundation.Interfaces;
using Foundation.ViewModels.Main;
using Foundation.Views;

namespace JDV.Accounts.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// 
        /// </summary>
        private ICore? CoreInstance { get; set; }

        /// <summary>
        /// Gets or sets this application.
        /// </summary>
        /// <value>The application.</value>
        private static IMainWindowForm? ThisApplication { get; set; }

        /// <summary>
        /// Gets or sets the view model.
        /// </summary>
        /// <value>The view model.</value>
        private static IMainWindowViewModel? ViewModel { get; set; }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Application.Startup">Startup</see> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs">StartupEventArgs</see> that contains the event data.</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            CoreInstance = Core.Initialise();
            Foundation.ViewModels.ViewModel.InitialiseStaticMembers();

            LoggingHelpers.TraceCallEnter(e);

            ApplicationControl.ApplicationStart(DisplayUnhandledExceptionMessage);
            Dispatcher.UnhandledException += ApplicationControl.Dispatcher_UnhandledException;

            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Window), new FrameworkPropertyMetadata
            {
                DefaultValue = FindResource(typeof(Window))
            });

            FrameworkElement.StyleProperty.OverrideMetadata(typeof(UserControl), new FrameworkPropertyMetadata
            {
                DefaultValue = FindResource(typeof(UserControl))
            });

            FrameworkElement.StyleProperty.OverrideMetadata(typeof(Control), new FrameworkPropertyMetadata
            {
                DefaultValue = FindResource(typeof(Control))
            });

            LoggingHelpers.TraceMessage("Initialising");

            // Initialize the splash screen and set it as the application main window
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings = CoreInstance.IoC.Get<IRunTimeEnvironmentSettings>();
            IDateTimeService dateTimeService = CoreInstance.IoC.Get<IDateTimeService>();
            IWpfApplicationObjects wpfApplicationObjects = CoreInstance.IoC.Get<IWpfApplicationObjects>();

            AboutSplashScreenForm splashScreen = new AboutSplashScreenForm();
            this.MainWindow = splashScreen;
            const Boolean isSplashScreen = true;
            AboutSplashScreenFormViewModel splashScreenViewModel = new AboutSplashScreenFormViewModel(CoreInstance, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, isSplashScreen);
            ////IAboutSplashScreenFormViewModel splashScreenViewModel = Core.Core.Instance.Container.Get<AboutSplashScreenFormViewModel>(isSplashScreen);

            splashScreen.DataContext = splashScreenViewModel;
            splashScreen.Show();

            // In order to ensure the UI stays responsive, we need to do the work on a different thread
            Task.Run(() =>
            {
                // Simulate some work being done
                Thread.Sleep(500);

                // Since we're not on the UI thread once we're done we need to use the Dispatcher
                // to create and show the main window
                this.Dispatcher.Invoke(() =>
                {
                    LoggingHelpers.TraceMessage("Starting App");

                    IApplicationProcess applicationProcess = CoreInstance.IoC.Get<IApplicationProcess>();
                    IApplication? application = applicationProcess.Get(CoreInstance.ApplicationId);

                    if (application == null)
                    {
                        String message = $"Unable to load application details with Id '{CoreInstance.ApplicationId}'";
                        throw new InvalidOperationException(message);
                    }

                    ThisApplication = CoreInstance.IoC.Get<IMainWindowForm>();
                    MainWindow = (Window)ThisApplication;

                    ViewModel = CoreInstance.IoC.Get<IMainWindowViewModel>();
                    ViewModel.Initialise(ThisApplication, null, application.Name);

                    ThisApplication.DataContext = ViewModel;

                    splashScreen.BringIntoView();
                    Thread.Sleep(750);
                    splashScreen.Close();

                    ThisApplication.Show();

                    Mouse.OverrideCursor = null;
                });
            });

            LoggingHelpers.TraceCallReturn();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            e.ApplicationExitCode = 0;
        }

        /// <summary>
        /// Displays the unhandled exception message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        private static void DisplayUnhandledExceptionMessage(Exception exception)
        {
            if (ViewModel != null)
            {
                ViewModel.LastException = exception;

                ViewModel.DisplayUnhandledExceptionMessage(exception);
            }

            ApplicationControl.LogExceptionMessage(exception);
        }
    }
}
