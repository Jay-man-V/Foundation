//-----------------------------------------------------------------------
// <copyright file="CustomTabControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Views
{
    /// <summary>
    /// Interaction logic for CustomTabControl.xaml
    /// </summary>
    public partial class CustomTabControl
    {
        //public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initialises a new instance of the <see cref="CustomTabControl"/> class.
        /// </summary>
        public CustomTabControl()
        {
            InitializeComponent();
        }

        //public static readonly DependencyProperty TreeViewSelectedItemProperty = DependencyProperty.RegisterAttached(
        //    nameof(TreeViewSelectedItem),
        //    typeof(Object),
        //    typeof(CustomTabControl),
        //    new FrameworkPropertyMetadata(null)
        //);

        //protected override void OnSelectedItemChanged(RoutedPropertyChangedEventArgs<object> e)
        //{
        //    SetTreeViewSelectedItem(this, e.NewValue);
        //    //OnPropertyChanged("TreeViewSelectedItem");
        //}

        //public static void SetTreeViewSelectedItem(UIElement element, Object value)
        //{
        //    element.SetValue(TreeViewSelectedItemProperty, value);
        //}

        //public static Object GetTreeViewSelectedItem(UIElement element)
        //{
        //    return (Object)element.GetValue(TreeViewSelectedItemProperty);
        //}

        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
