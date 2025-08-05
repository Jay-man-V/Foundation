//-----------------------------------------------------------------------
// <copyright file="DatetimePickerControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace Foundation.Views
{
    /// <summary>
    /// Interaction logic for DatetimePickerControl.xaml
    /// </summary>
    public partial class DatetimePickerControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DatetimePickerControl"/> class.
        /// </summary>
        public DatetimePickerControl()
        {
            InitializeComponent();

            ShowCheckBox = true;
        }

        /// <summary>
        /// The show CheckBox property
        /// </summary>
        public static readonly DependencyProperty ShowCheckBoxProperty = DependencyProperty.RegisterAttached
        (
            nameof(ShowCheckBox),
            typeof(Boolean),
            typeof(DatetimePickerControl),
            new FrameworkPropertyMetadata(true, ShowCheckBoxChanged)
        );

        /// <summary>
        /// Shows the CheckBox changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void ShowCheckBoxChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DatetimePickerControl thisControl = d as DatetimePickerControl;
            ControlTemplate controlTemplate = thisControl.Template;

            //ExpanderControl thisExpander = thisControl.Content as ExpanderControl;
            //Grid thisGrid = thisExpander.Content as Grid;
            //StackPanel validityPeriod = thisGrid.Children.OfType<StackPanel>().ToList()[1];

            //if (validityPeriod != null)
            //{
            //    validityPeriod.Visibility = (Visibility)e.NewValue;
            //}
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show CheckBox].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show CheckBox]; otherwise, <c>false</c>.
        /// </value>
        public Boolean ShowCheckBox
        {
            get => (Boolean)GetValue(ShowCheckBoxProperty);
            set => SetValue(ShowCheckBoxProperty, value);
        }


        //public static readonly DependencyProperty CustomFormatProperty = DependencyProperty.RegisterAttached(
        //    nameof(CustomFormat),
        //    typeof(String),
        //    typeof(DatePicker),
        //    new FrameworkPropertyMetadata("dd-MMM-yyyy", FrameworkPropertyMetadataOptions.None)
        //);

        //public static void SetCustomFormatProperty(UIElement element, String value)
        //{
        //    element.SetValue(CustomFormatProperty, value);
        //}

        //public static String GetCustomFormatProperty(UIElement element)
        //{
        //    return (String)element.GetValue(CustomFormatProperty);
        //}
    }
}
