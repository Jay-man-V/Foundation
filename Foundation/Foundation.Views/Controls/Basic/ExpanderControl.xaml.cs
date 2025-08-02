//-----------------------------------------------------------------------
// <copyright file="Expander.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Input;

namespace Foundation.Views
{
    /// <summary>
    /// Interaction logic for ExpanderControl.xaml
    /// </summary>
    public partial class ExpanderControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ExpanderControl"/> class.
        /// </summary>
        public ExpanderControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The expanded command property
        /// </summary>
        public static readonly DependencyProperty ExpandedCommandProperty = DependencyProperty.Register
        (
            nameof(ExpandedCommand),
            typeof(ICommand), 
            typeof(ExpanderControl)
        );

        /// <summary>
        /// The collapsed command property
        /// </summary>
        public static readonly DependencyProperty CollapsedCommandProperty = DependencyProperty.Register
        (
            nameof(CollapsedCommand), 
            typeof(ICommand), 
            typeof(ExpanderControl)
        );

        /// <summary>
        /// Gets or sets the expanded command.
        /// </summary>
        /// <value>
        /// The expanded command.
        /// </value>
        public ICommand ExpandedCommand
        {
            get => (ICommand)GetValue(ExpandedCommandProperty);
            set => SetValue(ExpandedCommandProperty, value);
        }

        /// <summary>
        /// Gets or sets the collapsed command.
        /// </summary>
        /// <value>
        /// The collapsed command.
        /// </value>
        public ICommand CollapsedCommand
        {
            get => (ICommand)GetValue(CollapsedCommandProperty);
            set => SetValue(CollapsedCommandProperty, value);
        }
    }
}
