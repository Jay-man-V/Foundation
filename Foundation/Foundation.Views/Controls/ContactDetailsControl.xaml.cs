//-----------------------------------------------------------------------
// <copyright file="ContactDetailsControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Views
{
    /// <summary>
    /// Interaction logic for ContactDetailsControl.xaml
    /// </summary>
    public partial class ContactDetailsControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ContactDetailsControl"/> class.
        /// </summary>
        public ContactDetailsControl()
        {
            InitializeComponent();
        }

        //public static readonly DependencyProperty AvailableListItemsProperty = DependencyProperty.Register(nameof(AvailableListItems),
        //                                                                               typeof(IEnumerable),
        //                                                                               typeof(AvailableSelectedControl),
        //                                                                               new PropertyMetadata(null, AvailableListItemsValueChanged));


        //public static readonly DependencyProperty SelectedListItemsProperty = DependencyProperty.Register(nameof(SelectedListItems),
        //                                                                               typeof(IEnumerable),
        //                                                                               typeof(AvailableSelectedControl),
        //                                                                               new PropertyMetadata(null, SelectedListItemsValueChanged));

        //private static void AvailableListItemsValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    AvailableSelectedControl thisControl = d as AvailableSelectedControl;

        //    thisControl.AvailableItemsListbox.ItemsSource = e.NewValue as IEnumerable;
        //}

        //private static void SelectedListItemsValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    AvailableSelectedControl thisControl = d as AvailableSelectedControl;

        //    thisControl.SelectedItemsListbox.ItemsSource = e.NewValue as IEnumerable;
        //}

        //public IEnumerable AvailableListItems
        //{
        //    get { return (IEnumerable)GetValue(AvailableListItemsProperty); }
        //    set { SetValue(AvailableListItemsProperty, value); }
        //}

        //public IEnumerable SelectedListItems
        //{
        //    get { return (IEnumerable)GetValue(SelectedListItemsProperty); }
        //    set { SetValue(SelectedListItemsProperty, value); }
        //}
    }
}
