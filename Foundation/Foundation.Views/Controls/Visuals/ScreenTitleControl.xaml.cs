//-----------------------------------------------------------------------
// <copyright file="ScreenTitleControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;

using FEnums = Foundation.Interfaces;

namespace Foundation.Views
{
    /// <summary>
    /// Interaction logic for ScreenTitleControl.xaml
    /// </summary>
    public partial class ScreenTitleControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ScreenTitleControl"/> class.
        /// </summary>
        public ScreenTitleControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets a value indicating whether [message box image visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [message box image visible]; otherwise, <c>false</c>.
        /// </value>
        public Boolean MessageBoxImageVisible { get; private set; }

        /// <summary>
        /// The message box image property
        /// </summary>
        public static readonly DependencyProperty MessageBoxImageProperty = DependencyProperty.Register
        (
            nameof(MessageBoxImage),
            typeof(FEnums.MessageBoxImage),
            typeof(ScreenTitleControl),
            new UIPropertyMetadata(FEnums.MessageBoxImage.None, MessageBoxImageValueChanged)
        );

        /// <summary>
        /// Message box image value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void MessageBoxImageValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScreenTitleControl thisControl = (ScreenTitleControl)d;

            if (e.NewValue != null)
            {
                //thisControl.MessageBoxImageVisible = (thisControl.MessageBoxImage != FEnums.MessageBoxImage.None);
            }
        }

        /// <summary>
        /// Gets or sets the message box image.
        /// </summary>
        /// <value>
        /// The message box image.
        /// </value>
        public FEnums.MessageBoxImage MessageBoxImage
        {
            get => (FEnums.MessageBoxImage)GetValue(MessageBoxImageProperty);
            set => SetValue(MessageBoxImageProperty, value);
        }

        /// <summary>
        /// The screen name property
        /// </summary>
        public static readonly DependencyProperty ScreenNameProperty = DependencyProperty.Register
        (
            nameof(ScreenName),
            typeof(String),
            typeof(ScreenTitleControl),
            new PropertyMetadata(nameof(ScreenName), ScreenNameValueChanged)
        );

        /// <summary>
        /// The screen name value changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject"/>.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void ScreenNameValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScreenTitleControl thisControl = (ScreenTitleControl)d;

            thisControl.ScreenNameTextBox.Visibility = Visibility.Hidden;
            if (e.NewValue != null)
            {
                thisControl.ScreenNameTextBox.Text = e.NewValue.ToString();
                thisControl.ScreenNameTextBox.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Gets or sets the name of the screen.
        /// </summary>
        /// <value>
        /// The name of the screen.
        /// </value>
        public String ScreenName
        {
            get => (String)GetValue(ScreenNameProperty);
            set => SetValue(ScreenNameProperty, value);
        }

        /// <summary>
        /// The screen instructions property
        /// </summary>
        public static readonly DependencyProperty ScreenInstructionsProperty = DependencyProperty.Register
        (
            nameof(ScreenInstructions),
            typeof(String),
            typeof(ScreenTitleControl),
            new PropertyMetadata(nameof(ScreenInstructions), ScreenInstructionsValueChanged)
        );

        /// <summary>
        /// Screens the instructions value changed.
        /// </summary>
        /// <param name="d">The <see cref="DependencyObject"/>.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void ScreenInstructionsValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ScreenTitleControl thisControl = (ScreenTitleControl)d;

            thisControl.ScreenInstructionsTextBox.Visibility = Visibility.Hidden;
            if (e.NewValue != null)
            {
                thisControl.ScreenInstructionsTextBox.Text = e.NewValue.ToString();
                thisControl.ScreenInstructionsTextBox.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Gets or sets the screen instructions.
        /// </summary>
        /// <value>
        /// The screen instructions.
        /// </value>
        public String ScreenInstructions
        {
            get => (String)GetValue(ScreenInstructionsProperty);
            set => SetValue(ScreenInstructionsProperty, value);
        }
    }
}
