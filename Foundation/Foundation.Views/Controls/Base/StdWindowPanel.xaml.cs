//-----------------------------------------------------------------------
// <copyright file="StdWindowPanel.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Controls;

using Foundation.Common;

using FEnums = Foundation.Interfaces;

namespace Foundation.Views
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
                Source = new Uri("/Foundation.Views;component/Controls/Base/StdWindowPanel.xaml", UriKind.Relative),
            };
            this.Resources.MergedDictionaries.Add(resourceDictionary);
        }

        /// <summary>
        /// Gets a value indicating whether [toolbar visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [toolbar visible]; otherwise, <c>false</c>.
        /// </value>
        public Boolean ToolbarVisible => (ToolBar != null);

        /// <summary>
        /// Gets a value indicating whether [filter visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [filter visible]; otherwise, <c>false</c>.
        /// </value>
        public Boolean FilterVisible => (Filter != null);

        /// <summary>
        /// Gets a value indicating whether [screen title control visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [screen title control visible]; otherwise, <c>false</c>.
        /// </value>
        public Boolean ScreenTitleControlVisible => (!String.IsNullOrEmpty(Title) || !String.IsNullOrEmpty(Instructions));

        /// <summary>
        /// Gets a value indicating whether [status bar visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [status bar visible]; otherwise, <c>false</c>.
        /// </value>
        public Boolean StatusBarVisible => StatusBar != null;

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
            typeof(String),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(String.Empty)
        );

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public String Title
        {
            get => (String)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// The instructions property
        /// </summary>
        public static readonly DependencyProperty InstructionsProperty = DependencyProperty.Register
        (
            nameof(Instructions),
            typeof(String),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(String.Empty)
        );

        /// <summary>
        /// Gets or sets the instructions.
        /// </summary>
        /// <value>
        /// The instructions.
        /// </value>
        public String Instructions
        {
            get => (String)GetValue(InstructionsProperty);
            set => SetValue(InstructionsProperty, value);
        }

        /// <summary>
        /// The tool bar property
        /// </summary>
        public static readonly DependencyProperty ToolBarProperty = DependencyProperty.Register
        (
            nameof(ToolBar),
            typeof(Object),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the tool bar.
        /// </summary>
        /// <value>
        /// The tool bar.
        /// </value>
        public Object ToolBar
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
            typeof(Object),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public Object Filter
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
            typeof(Object),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the workspace.
        /// </summary>
        /// <value>
        /// The workspace.
        /// </value>
        public Object Workspace
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
            typeof(Object),
            typeof(StdWindowPanel),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the status bar.
        /// </summary>
        /// <value>
        /// The status bar.
        /// </value>
        public Object StatusBar
        {
            get => GetValue(StatusBarProperty);
            set => SetValue(StatusBarProperty, value);
        }
    }
}
