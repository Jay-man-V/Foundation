//-----------------------------------------------------------------------
// <copyright file="NotificationWindow.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Drawing;
using System.Windows;
using System.Windows.Input;

using Foundation.Interfaces;

namespace Foundation.Views
{
    /// <summary>
    /// Interaction logic for NotificationWindow.xaml
    /// </summary>
    public partial class NotificationWindow : IWindow
    {
        private static Int32 _notificationCounter = 0;

        /// <summary>
        /// Static Constructor
        /// </summary>
        static NotificationWindow()
        {
            DisplayedMessages = new List<NotificationWindow>();
        }

        /// <summary>
        /// The Message Type property
        /// </summary>
        public static readonly DependencyProperty MessageTypeProperty = DependencyProperty.Register
        (
            nameof(MessageType),
            typeof(MessageType),
            typeof(NotificationWindow),
            new PropertyMetadata(MessageType.NotSet)
        );

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="messageType"></param>
        /// <param name="messageHeader"></param>
        /// <param name="message"></param>
        public NotificationWindow(MessageType messageType, String messageHeader, String message)
        {
            this.InitializeComponent();

            this.Closed += this.NotificationWindowClosed;
            MessageType = messageType;
            WindowId = Guid.NewGuid().ToString();
            _notificationCounter++;

            NotificationHeaderTextBlock.Text = messageHeader;
            NotificationMessageTextBlock.Text = message;
        }

        private static List<NotificationWindow> DisplayedMessages { get; }
        private String WindowId { get; }

        /// <summary>
        /// The Message Type
        /// </summary>
        public MessageType MessageType
        {
            get => (MessageType)GetValue(MessageTypeProperty);
            set => SetValue(MessageTypeProperty, value);
        }

        /// <summary>
        /// Displays the form on the screen
        /// </summary>
        public new void Show()
        {
            Topmost = true;
            base.Show();

            Owner = Application.Current.MainWindow;
            Closed += this.NotificationWindowClosed;

            DisplayedMessages.Add(this);

            UpdateDisplayedMessageLocations();
        }

        private void ImageMouseUp(Object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void DoubleAnimationCompleted(Object sender, EventArgs e)
        {
            if (!this.IsMouseOver)
            {
                this.Close();
            }
        }

        private void NotificationWindowClosed(Object sender, EventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                NotificationWindow thisWindow = DisplayedMessages.FirstOrDefault(nw => nw.WindowId == WindowId);

                if (thisWindow != null)
                {
                    DisplayedMessages.Remove(thisWindow);
                }

                UpdateDisplayedMessageLocations();

                String windowName = window.GetType().Name;

                if (windowName.Equals(this.Title) && window != this)
                {
                    // Adjust any windows that were above this one to drop down
                    if (window.Top < this.Top)
                    {
                        window.Top += this.ActualHeight;
                    }
                }
            }
        }

        private void UpdateDisplayedMessageLocations()
        {
            Int32 distanceBetweenNotifications = 40;

            // Only show notifications in the applications window area
            Rectangle workingArea = new Rectangle((Int32)Owner.Left - 20, (Int32)Owner.Top, (Int32)Owner.Width, (Int32)Owner.Height);

            // Show notifications on the desktop area
            //Rectangle workingArea = new Rectangle(0, 0, (Int32)SystemParameters.PrimaryScreenWidth, (Int32)SystemParameters.PrimaryScreenHeight);

            for (Int32 counter = DisplayedMessages.Count - 1; counter >= 0; counter--)
            {
                // Don't want to multiply by 0
                Int32 multiplier = counter + 1;

                Left = workingArea.Right - ActualWidth;
                Double top = workingArea.Bottom - (ActualHeight * multiplier) - distanceBetweenNotifications;

                foreach (Window window in Application.Current.Windows)
                {
                    String windowName = window.GetType().Name;

                    if (windowName.Equals(Title) &&
                        window != this)
                    {
                        window.Topmost = true;
                        top = window.Top - window.ActualHeight;
                    }
                }

                Top = top;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
