//-----------------------------------------------------------------------
// <copyright file="MainWindowForm.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

using Foundation.Common;
using Foundation.Interfaces;

using FEnums = Foundation.Interfaces;

namespace Foundation.Views
{
    /// <summary>
    /// Interaction logic for MainWindowForm.xaml
    /// </summary>
    /// <remarks>
    /// Reference site: https://engy.us/blog/2020/01/01/implementing-a-custom-window-title-bar-in-wpf/
    /// </remarks>
    [DependencyInjectionTransient]
    public partial class MainWindowForm : Window, IMainWindowForm
    {
        public MainWindowForm
        (
            String caption
        ) :
            this()
        {
            this.Title = caption;
        }

        private void MainWindowForm_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshMaximizeRestoreButton();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindowForm()
        {
            LoggingHelpers.TraceCallEnter();

            InitializeComponent();

            this.StateChanged -= OnStateChanged;
            this.StateChanged += OnStateChanged;

            Closing += AppWindowBase_Closing;

            LoggingHelpers.TraceCallReturn();
        }

        private void AppWindowBase_Closing(Object? sender, CancelEventArgs e)
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
        private void TitleBar_MouseDown(Object? sender, MouseButtonEventArgs e)
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
        private void CloseButton_Click(Object? sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// MaximizedButton_Clicked
        /// </summary>
        private void MaximizeRestoreButton_Click(Object? sender, RoutedEventArgs e)
        {
            AdjustWindowSize();
        }

        /// <summary>
        /// Minimized Button_Clicked
        /// </summary>
        private void MinimizeButton_Click(Object? sender, RoutedEventArgs e)
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
                MaximizeButton.Content = this.FindResource("WindowMaximiseIcon");
            }
            else
            {
                WindowState = WindowState.Maximized;
                MaximizeButton.Content = this.FindResource("WindowRestoreIcon");
            }
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            ((HwndSource)PresentationSource.FromVisual(this)).AddHook(HookProc);
        }

        public static IntPtr HookProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_GETMINMAXINFO)
            {
                // We need to tell the system what our size should be when maximized. Otherwise, it will cover the whole screen,
                // including the task bar.
                MINMAXINFO mmi = (MINMAXINFO)(Marshal.PtrToStructure(lParam, typeof(MINMAXINFO)) ?? new MINMAXINFO());

                // Adjust the maximized size and position to fit the work area of the correct monitor
                IntPtr monitor = MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

                if (monitor != IntPtr.Zero)
                {
                    MONITORINFO monitorInfo = new MONITORINFO
                    {
                        cbSize = Marshal.SizeOf(typeof(MONITORINFO))
                    };
                    GetMonitorInfo(monitor, ref monitorInfo);
                    RECT rcWorkArea = monitorInfo.rcWork;
                    RECT rcMonitorArea = monitorInfo.rcMonitor;
                    mmi.ptMaxPosition.X = Math.Abs(rcWorkArea.Left - rcMonitorArea.Left);
                    mmi.ptMaxPosition.Y = Math.Abs(rcWorkArea.Top - rcMonitorArea.Top);
                    mmi.ptMaxSize.X = Math.Abs(rcWorkArea.Right - rcWorkArea.Left);
                    mmi.ptMaxSize.Y = Math.Abs(rcWorkArea.Bottom - rcWorkArea.Top);
                }

                Marshal.StructureToPtr(mmi, lParam, true);
            }

            return IntPtr.Zero;
        }

        private const int WM_GETMINMAXINFO = 0x0024;

        private const uint MONITOR_DEFAULTTONEAREST = 0x00000002;

        [DllImport("user32.dll")]
        private static extern IntPtr MonitorFromWindow(IntPtr handle, uint flags);

        [DllImport("user32.dll")]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                this.Left = left;
                this.Top = top;
                this.Right = right;
                this.Bottom = bottom;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MONITORINFO
        {
            public int cbSize;
            public RECT rcMonitor;
            public RECT rcWork;
            public uint dwFlags;
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MINMAXINFO
        {
            public POINT ptReserved;
            public POINT ptMaxSize;
            public POINT ptMaxPosition;
            public POINT ptMinTrackSize;
            public POINT ptMaxTrackSize;
        }

        private void OnStateChanged(object? sender, EventArgs e)
        {
            this.RefreshMaximizeRestoreButton();
        }

        private void OnMinimizeButtonClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void OnMaximizeRestoreButtonClick(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
            }
        }

        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown(0);
        }

        private void RefreshMaximizeRestoreButton()
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.MaximizeButton.Visibility = Visibility.Collapsed;
                this.RestoreButton.Visibility = Visibility.Visible;
            }
            else
            {
                this.MaximizeButton.Visibility = Visibility.Visible;
                this.RestoreButton.Visibility = Visibility.Collapsed;
            }
        }
    }
}
