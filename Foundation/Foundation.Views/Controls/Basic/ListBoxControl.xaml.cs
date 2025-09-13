//-----------------------------------------------------------------------
// <copyright file="ListBoxControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Foundation.Views.Controls.Basic
{
    /// <summary>
    /// Interaction logic for ListBoxControl.xaml
    /// </summary>
    public partial class ListBoxControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ListBoxControl"/> class.
        /// </summary>
        public ListBoxControl()
        {
            InitializeComponent();

            this.SelectionChanged += OnSelectedItemChanged;
        }

        /// <summary>
        /// Called when [selected item changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Object}"/> instance containing the event data.</param>
        void OnSelectedItemChanged(Object sender, SelectionChangedEventArgs e)
        {
            if (SelectedItem != null)
            {
                SetValue(SelectedItem_Property, SelectedItem);
            }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        public Object SelectedItem_
        {
            get => GetValue(SelectedItem_Property);
            set => SetValue(SelectedItem_Property, value);
        }

        /// <summary>
        /// The selected item property
        /// </summary>
        public static readonly DependencyProperty SelectedItem_Property = DependencyProperty.Register
        (
            nameof(SelectedItem_),
            typeof(Object),
            typeof(TreeViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// The left click command property
        /// </summary>
        public static readonly DependencyProperty LeftClickCommandProperty = DependencyProperty.Register
        (
            nameof(LeftClickCommand),
            typeof(Object),
            typeof(ListBoxControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the left click command.
        /// </summary>
        /// <value>
        /// The left click command.
        /// </value>
        public Object LeftClickCommand
        {
            get => GetValue(LeftClickCommandProperty);
            set => SetValue(LeftClickCommandProperty, value);
        }

        /// <summary>
        /// The left click command parameter property
        /// </summary>
        public static readonly DependencyProperty LeftClickCommandParameterProperty = DependencyProperty.Register
        (
            nameof(LeftClickCommandParameter),
            typeof(Object),
            typeof(ListBoxControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the left click command parameter.
        /// </summary>
        /// <value>
        /// The left click command parameter.
        /// </value>
        public Object LeftClickCommandParameter
        {
            get => GetValue(LeftClickCommandParameterProperty);
            set => SetValue(LeftClickCommandParameterProperty, value);
        }

        /// <summary>
        /// The right click command property
        /// </summary>
        public static readonly DependencyProperty RightClickCommandProperty = DependencyProperty.Register
        (
            nameof(RightClickCommand),
            typeof(Object),
            typeof(ListBoxControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the right click command.
        /// </summary>
        /// <value>
        /// The right click command.
        /// </value>
        public Object RightClickCommand
        {
            get => GetValue(RightClickCommandProperty);
            set => SetValue(RightClickCommandProperty, value);
        }

        /// <summary>
        /// The right click command parameter property
        /// </summary>
        public static readonly DependencyProperty RightClickCommandParameterProperty = DependencyProperty.Register
        (
            nameof(RightClickCommandParameter),
            typeof(Object),
            typeof(ListBoxControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the right click command parameter.
        /// </summary>
        /// <value>
        /// The right click command parameter.
        /// </value>
        public Object RightClickCommandParameter
        {
            get => (Object)GetValue(RightClickCommandParameterProperty);
            set => SetValue(RightClickCommandParameterProperty, value);
        }
    }
}
