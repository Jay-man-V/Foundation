//-----------------------------------------------------------------------
// <copyright file="ToggleButtonControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;

namespace Foundation.Views.Controls.Basic
{
    /// <summary>
    /// Interaction logic for ToggleButtonControl.xaml
    /// </summary>
    public partial class ToggleButtonControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ToggleButtonControl"/> class.
        /// </summary>
        public ToggleButtonControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The is selected property
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register
        (
            nameof(IsSelected),
            typeof(Boolean),
            typeof(ToggleButtonControl),
            new PropertyMetadata(false)
        );

        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        public Boolean IsSelected
        {
            get => (Boolean)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
        }
    }
}
