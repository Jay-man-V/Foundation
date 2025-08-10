//-----------------------------------------------------------------------
// <copyright file="EntityDetailsControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;

namespace Foundation.Views
{
    /// <summary>
    /// Interaction logic for EntityDetailsControl.xaml
    /// </summary>
    public partial class EntityDetailsControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EntityDetailsControl"/> class.
        /// </summary>
        public EntityDetailsControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The caption property
        /// </summary>
        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register
        (
            nameof(Caption),
            typeof(String),
            typeof(EntityDetailsControl),
            new PropertyMetadata(String.Empty, CaptionValueChanged)
        );

        /// <summary>
        /// The show validity period property
        /// </summary>
        public static readonly DependencyProperty ShowValidityPeriodProperty = DependencyProperty.Register
        (
            nameof(ShowValidityPeriod),
            typeof(Boolean),
            typeof(EntityDetailsControl),
            new PropertyMetadata(true, ShowValidityPeriodValueChanged)
        );

        /// <summary>
        /// Captions the value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void CaptionValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EntityDetailsControl thisControl)
            {
                thisControl.Header = e.NewValue;
            }
        }

        /// <summary>
        /// Shows the validity period value changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void ShowValidityPeriodValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is EntityDetailsControl thisControl)
            {
                Boolean newPropertyValue = (Boolean)e.NewValue;
                Visibility visibility = (newPropertyValue) ? Visibility.Visible : Visibility.Collapsed;
                thisControl.ValidityDetailsStackPanel.Visibility = visibility;
            }
        }

        /// <summary>
        /// Gets or sets the caption.
        /// </summary>
        /// <value>
        /// The caption.
        /// </value>
        public String Caption
        {
            get => (String)GetValue(CaptionProperty);
            set => SetValue(CaptionProperty, value);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show validity period].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show validity period]; otherwise, <c>false</c>.
        /// </value>
        public Boolean ShowValidityPeriod
        {
            get => (Boolean)GetValue(ShowValidityPeriodProperty);
            set => SetValue(ShowValidityPeriodProperty, value);
        }

        //public static readonly DependencyProperty StatusItemsSourceProperty = DependencyProperty.Register(nameof(StatusItemsSource),
        //                                                                               typeof(IEnumerable),
        //                                                                               typeof(EntityDetailsControl),
        //                                                                               new PropertyMetadata(null, StatusItemsSourceValueChanged));

        //private static void StatusItemsSourceValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    EntityDetailsControl thisControl = d as EntityDetailsControl;

        //    thisControl.StatusComboBox.ItemsSource = e.NewValue as IEnumerable;
        //}

        //public IEnumerable StatusItemsSource
        //{
        //    get { return (IEnumerable)GetValue(StatusItemsSourceProperty); }
        //    set { SetValue(StatusItemsSourceProperty, value); }
        //}
    }
}
