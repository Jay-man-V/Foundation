//-----------------------------------------------------------------------
// <copyright file="StdWindowPanel.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

using FEnums = Foundation.Interfaces;

namespace Foundation.Views.Controls
{
    /// <summary>
    /// Interaction logic for StdWindowPanel.xaml
    /// </summary>
    /// <seealso cref="UserControl" />
    public class StdWindowPanel : UserControl
    {
        /// <summary>
        /// Raises the <see cref="E:System.Windows.FrameworkElement.Initialized" /> event. This method is invoked whenever <see cref="P:System.Windows.FrameworkElement.IsInitialized" /> is set to <see langword="true " />internally.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.RoutedEventArgs" /> that contains the event data.</param>
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            ResourceDictionary resourceDictionary = new ResourceDictionary
            {
                Source = new Uri("/Foundation.Views;component/Controls/StdWindowPanel.xaml", UriKind.Relative),
            };
            Resources.MergedDictionaries.Add(resourceDictionary);
        }

        /// <summary>
        /// Gets a value indicating whether [toolbar visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [toolbar visible]; otherwise, <c>false</c>.
        /// </value>
        public bool ToolbarVisible => ToolBar != null;

        /// <summary>
        /// Gets a value indicating whether [filter visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [filter visible]; otherwise, <c>false</c>.
        /// </value>
        public bool FilterVisible => Filter != null;

        /// <summary>
        /// Gets a value indicating whether [screen title control visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [screen title control visible]; otherwise, <c>false</c>.
        /// </value>
        public bool ScreenTitleControlVisible => !string.IsNullOrEmpty(Title) || !string.IsNullOrEmpty(Instructions);

        /// <summary>
        /// Gets a value indicating whether [status bar visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [status bar visible]; otherwise, <c>false</c>.
        /// </value>
        public bool StatusBarVisible => StatusBar != null;

        /// <summary>
        /// The message box image property
        /// </summary>
        public static readonly DependencyProperty MessageBoxImageProperty = DependencyProperty.Register
        (
            nameof(MessageBoxImage),
            typeof(FEnums.MessageBoxImage),
            typeof(StdWindowPanel),
            new PropertyMetadata(FEnums.MessageBoxImage.None, MessageBoxImageValueChanged)
        );

        /// <summary>
        /// Messages the box image value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void MessageBoxImageValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is StdWindowPanel thisControl)
            {
                if (e.NewValue != null)
                {
                    //thisControl.ScreenNameTextBox.Text = e.NewValue.ToString();
                }
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
        /// The title property
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register
        (
            nameof(Title),
            typeof(string),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(string.Empty)
        );

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// The instructions property
        /// </summary>
        public static readonly DependencyProperty InstructionsProperty = DependencyProperty.Register
        (
            nameof(Instructions),
            typeof(string),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(string.Empty)
        );

        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>
        /// The instructions.
        /// </value>
        public string Instructions
        {
            get => (string)GetValue(InstructionsProperty);
            set => SetValue(InstructionsProperty, value);
        }

        /// <summary>
        /// The tool bar property
        /// </summary>
        public static readonly DependencyProperty ToolBarProperty = DependencyProperty.Register
        (
            nameof(ToolBar),
            typeof(object),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the tool bar.
        /// </summary>
        /// <value>
        /// The tool bar.
        /// </value>
        public object ToolBar
        {
            get => GetValue(ToolBarProperty);
            set => SetValue(ToolBarProperty, value);
        }

        /// <summary>
        /// The filter property
        /// </summary>
        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register
        (
            nameof(Filter),
            typeof(object),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public object Filter
        {
            get => GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }

        /// <summary>
        /// The workspace property
        /// </summary>
        public static readonly DependencyProperty WorkspaceProperty = DependencyProperty.Register
        (
            nameof(Workspace),
            typeof(object),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the workspace.
        /// </summary>
        /// <value>
        /// The workspace.
        /// </value>
        public object Workspace
        {
            get => GetValue(WorkspaceProperty);
            set => SetValue(WorkspaceProperty, value);
        }

        /// <summary>
        /// The status bar property
        /// </summary>
        public static readonly DependencyProperty StatusBarProperty = DependencyProperty.Register
        (
            nameof(StatusBar),
            typeof(object),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the status bar.
        /// </summary>
        /// <value>
        /// The status bar.
        /// </value>
        public object StatusBar
        {
            get => GetValue(StatusBarProperty);
            set => SetValue(StatusBarProperty, value);
        }
    }
}
