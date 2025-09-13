//-----------------------------------------------------------------------
// <copyright file="LoggedOnUsersControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Windows;

namespace Foundation.Views.Controls
{
    /// <summary>
    /// Interaction logic for LoggedOnUsersControl.xaml
    /// </summary>
    public partial class LoggedOnUsersControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LoggedOnUsersControl"/> class.
        /// </summary>
        public LoggedOnUsersControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The data source property
        /// </summary>
        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register
        (
            nameof(DataSource),
            typeof(IEnumerable),
            typeof(LoggedOnUsersControl),
            new PropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the data source.
        /// </summary>
        /// <value>
        /// The data source.
        /// </value>
        public IEnumerable DataSource
        {
            get => (IEnumerable)GetValue(DataSourceProperty);
            set => SetValue(DataSourceProperty, value);
        }
    }
}
