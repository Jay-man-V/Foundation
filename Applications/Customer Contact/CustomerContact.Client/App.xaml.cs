//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;

using Foundation.Views;

namespace CustomerContact.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 
        /// </summary>
        private MainWindow? TheMainWindow { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            TheMainWindow = new();

            this.MainWindow = TheMainWindow;
            this.MainWindow.Show();
        }
    }
}
