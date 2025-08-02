//-----------------------------------------------------------------------
// <copyright file="MainWindowForm.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

using Foundation.Common;
using Foundation.Interfaces;

using FEnums = Foundation.Interfaces;

namespace Foundation.Views
{
    /// <summary>
    /// Interaction logic for MainWindowForm.xaml
    /// </summary>
    public partial class MainWindowForm : IWindow
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowForm()
        {
            LoggingHelpers.TraceCallEnter();

            InitializeComponent();

            Closing += AppWindowBase_Closing;

            LoggingHelpers.TraceCallReturn();
        }

        private void AppWindowBase_Closing(Object sender, CancelEventArgs e)
        {
            LoggingHelpers.TraceCallEnter();

            if (DataContext is IEntityViewModel viewModel &&
                viewModel.HasChanges)
            {
                DialogResult dialogResult = viewModel.PromptSaveBeforeExit();
                if (dialogResult == FEnums.DialogResult.Yes)
                {
                    viewModel.SaveChanges();
                }
                else if (dialogResult == FEnums.DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                // If the user clicks No, then no need to save, exit as is
            }

            LoggingHelpers.TraceCallReturn(e.Cancel);
        }

        /// <summary>
        /// TitleBar_MouseDown - Drag if single-click, resize if double-click
        /// </summary>
        private void TitleBar_MouseDown(Object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                if (e.ClickCount == 2)
                {
                    AdjustWindowSize();
                }
                else
                {
                    if (Application.Current != null &&
                        Application.Current.MainWindow != null)
                    {
                        Application.Current.MainWindow.DragMove();
                    }
                }
            }
        }

        /// <summary>
        /// CloseButton_Clicked
        /// </summary>
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// MaximizedButton_Clicked
        /// </summary>
        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            AdjustWindowSize();
        }

        /// <summary>
        /// Minimized Button_Clicked
        /// </summary>
        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Adjusts the WindowSize to correct parameters when Maximize button is clicked
        /// </summary>
        private void AdjustWindowSize()
        {
            if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
                MaxButton.Content = this.FindResource("WindowMaximiseIcon");
            }
            else
            {
                WindowState = WindowState.Maximized;
                MaxButton.Content = this.FindResource("WindowRestoreIcon");
            }

        }
    }
}
