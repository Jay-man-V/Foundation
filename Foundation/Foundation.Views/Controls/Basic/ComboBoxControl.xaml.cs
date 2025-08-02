//-----------------------------------------------------------------------
// <copyright file="ComboBoxControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Input;

namespace Foundation.Views
{
    /// <summary>
    /// Interaction logic for ComboBoxControl.xaml
    /// </summary>
    public partial class ComboBoxControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ComboBoxControl"/> class.
        /// </summary>
        public ComboBoxControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The selected item changed command property
        /// </summary>
        public static readonly DependencyProperty SelectedItemChangedCommandProperty = DependencyProperty.Register
        (
            nameof(SelectedItemChangedCommand),
            typeof(ICommand),
            typeof(ComboBoxControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the selected item changed command.
        /// </summary>
        /// <value>
        /// The selected item changed command.
        /// </value>
        public ICommand SelectedItemChangedCommand
        {
            get => (ICommand)GetValue(SelectedItemChangedCommandProperty);
            set => SetValue(SelectedItemChangedCommandProperty, value);
        }
    }
}
