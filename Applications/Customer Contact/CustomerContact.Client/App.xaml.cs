//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;

using Foundation.Core;
using Foundation.Interfaces;

namespace CustomerContact.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ICore coreInstance = Core.Initialise(0);

            IApplication? application = coreInstance.IoC.Get<IApplication>();

            IMainWindow theMainWindow = coreInstance.IoC.Get<IMainWindow>();

            IMainWindowViewModel viewModel = coreInstance.IoC.Get<IMainWindowViewModel>();
            viewModel.Initialise(theMainWindow, null, "This shit");

            theMainWindow.DataContext = viewModel;

            this.MainWindow = (Window)theMainWindow;
            this.MainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            e.ApplicationExitCode = 0;
        }
    }
}
