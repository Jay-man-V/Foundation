//-----------------------------------------------------------------------
// <copyright file="BreadCrumbControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Foundation.Views.Controls.Basic
{
    /// <summary>
    /// Interaction logic for BreadCrumbControl.xaml
    /// </summary>
    public partial class BreadCrumbControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="BreadCrumbControl"/> class.
        /// </summary>
        public BreadCrumbControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The BackColour property
        /// </summary>
        public static readonly DependencyProperty BackColourProperty = DependencyProperty.Register
        (
            nameof(BackColour),
            typeof(Brush),
            typeof(UserControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the BackColour.
        /// </summary>
        /// <value>
        /// The BackColour.
        /// </value>
        [Bindable(true)]
        [Category("Appearance")]
        public Brush BackColour
        {
            get => (Brush)GetValue(BackColourProperty);
            set => SetValue(BackColourProperty, value);
        }

        /// <summary>
        /// The Text1 property
        /// </summary>
        public static readonly DependencyProperty Text1Property = DependencyProperty.Register
        (
            nameof(Text1),
            typeof(String),
            typeof(UserControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the Text1.
        /// </summary>
        /// <value>
        /// The Text1.
        /// </value>
        [Bindable(true)]
        [Category("Appearance")]
        public String Text1
        {
            get => (String)GetValue(Text1Property);
            set => SetValue(Text1Property, value);
        }
    }
}
