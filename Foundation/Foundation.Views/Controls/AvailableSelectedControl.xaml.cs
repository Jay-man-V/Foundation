//-----------------------------------------------------------------------
// <copyright file="AvailableSelectedControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Windows;

namespace Foundation.Views.Controls
{
    /// <summary>
    /// Interaction logic for AvailableSelectedControl.xaml
    /// </summary>
    public partial class AvailableSelectedControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AvailableSelectedControl"/> class.
        /// </summary>
        public AvailableSelectedControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The available list items property
        /// </summary>
        public static readonly DependencyProperty AvailableListItemsProperty = DependencyProperty.Register
        (
            nameof(AvailableListItems),
            typeof(IEnumerable),
            typeof(AvailableSelectedControl),
            new PropertyMetadata(null, AvailableListItemsValueChanged)
        );

        /// <summary>
        /// The selected list items property
        /// </summary>
        public static readonly DependencyProperty SelectedListItemsProperty = DependencyProperty.Register
        (
            nameof(SelectedListItems),
            typeof(IEnumerable),
            typeof(AvailableSelectedControl),
            new PropertyMetadata(null, SelectedListItemsValueChanged)
        );

        /// <summary>
        /// Available list items value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void AvailableListItemsValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AvailableSelectedControl thisControl)
            {
                thisControl.AvailableItemsListbox.ItemsSource = e.NewValue as IEnumerable;
            }
        }

        /// <summary>
        /// Selected list items value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void SelectedListItemsValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AvailableSelectedControl thisControl)
            {
                thisControl.SelectedItemsListbox.ItemsSource = e.NewValue as IEnumerable;
            }
        }

        /// <summary>
        /// Gets or sets the available list items.
        /// </summary>
        /// <value>
        /// The available list items.
        /// </value>
        public IEnumerable AvailableListItems
        {
            get => (IEnumerable)GetValue(AvailableListItemsProperty);
            set => SetValue(AvailableListItemsProperty, value);
        }

        /// <summary>
        /// Gets or sets the selected list items.
        /// </summary>
        /// <value>
        /// The selected list items.
        /// </value>
        public IEnumerable SelectedListItems
        {
            get => (IEnumerable)GetValue(SelectedListItemsProperty);
            set => SetValue(SelectedListItemsProperty, value);
        }
    }
}
