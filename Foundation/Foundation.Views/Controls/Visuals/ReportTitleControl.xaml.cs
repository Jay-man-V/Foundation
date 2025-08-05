//-----------------------------------------------------------------------
// <copyright file="ReportTitleControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;

namespace Foundation.Views
{
    /// <summary>
    /// Interaction logic for ReportTitleControl.xaml
    /// </summary>
    public partial class ReportTitleControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ReportTitleControl"/> class.
        /// </summary>
        public ReportTitleControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The Title property
        /// </summary>
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register
        (
            nameof(Title),
            typeof(String),
            typeof(ReportTitleControl),
            new UIPropertyMetadata(String.Empty)//,
            //new FrameworkPropertyMetadata(nameof(Title), FrameworkPropertyMetadataOptions.AffectsRender)
        );

        /// <summary>
        /// Gets or sets the Title.
        /// </summary>
        /// <value>
        /// The Title.
        /// </value>
        public String Title
        {
            get => (String)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        /// <summary>
        /// The Sub Title property
        /// </summary>
        public static readonly DependencyProperty SubTitleProperty = DependencyProperty.Register
        (
            nameof(SubTitle),
            typeof(String),
            typeof(ReportTitleControl),
            new UIPropertyMetadata(String.Empty)//,
            //new FrameworkPropertyMetadata(nameof(SubTitle), FrameworkPropertyMetadataOptions.AffectsRender)
        );

        /// <summary>
        /// Gets or sets the Sub Title.
        /// </summary>
        /// <value>
        /// The Sub Title.
        /// </value>
        public String SubTitle
        {
            get => (String)GetValue(SubTitleProperty);
            set => SetValue(SubTitleProperty, value);
        }
    }
}
