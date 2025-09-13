//-----------------------------------------------------------------------
// <copyright file="TreeViewControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;

namespace Foundation.Views.Controls.Basic
{
    /// <summary>
    /// Interaction logic for TreeViewControl.xaml
    /// </summary>
    public partial class TreeViewControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="TreeViewControl"/> class.
        /// </summary>
        public TreeViewControl()
        {
            InitializeComponent();

            this.SelectedItemChanged += OnSelectedItemChanged;
        }

        /// <summary>
        /// Called when [selected item changed].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedPropertyChangedEventArgs{Object}"/> instance containing the event data.</param>
        void OnSelectedItemChanged(Object sender, RoutedPropertyChangedEventArgs<Object> e)
        {
            if (SelectedItem != null)
            {
                SetValue(SelectedItem_Property, SelectedItem);
            }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        public Object SelectedItem_
        {
            get => GetValue(SelectedItem_Property);
            set => SetValue(SelectedItem_Property, value);
        }

        /// <summary>
        /// The selected item property
        /// </summary>
        public static readonly DependencyProperty SelectedItem_Property = DependencyProperty.Register
        (
            nameof(SelectedItem_),
            typeof(Object),
            typeof(TreeViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// The left click command property
        /// </summary>
        public static readonly DependencyProperty LeftClickCommandProperty = DependencyProperty.Register
        (
            nameof(LeftClickCommand),
            typeof(Object),
            typeof(TreeViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the left click command.
        /// </summary>
        /// <value>
        /// The left click command.
        /// </value>
        public Object LeftClickCommand
        {
            get => GetValue(LeftClickCommandProperty);
            set => SetValue(LeftClickCommandProperty, value);
        }

        /// <summary>
        /// The left click command parameter property
        /// </summary>
        public static readonly DependencyProperty LeftClickCommandParameterProperty = DependencyProperty.Register
        (
            nameof(LeftClickCommandParameter),
            typeof(Object),
            typeof(TreeViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the left click command parameter.
        /// </summary>
        /// <value>
        /// The left click command parameter.
        /// </value>
        public Object LeftClickCommandParameter
        {
            get => GetValue(LeftClickCommandParameterProperty);
            set => SetValue(LeftClickCommandParameterProperty, value);
        }

        /// <summary>
        /// The right click command property
        /// </summary>
        public static readonly DependencyProperty RightClickCommandProperty = DependencyProperty.Register
        (
            nameof(RightClickCommand),
            typeof(Object),
            typeof(TreeViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the right click command.
        /// </summary>
        /// <value>
        /// The right click command.
        /// </value>
        public Object RightClickCommand
        {
            get => GetValue(RightClickCommandProperty);
            set => SetValue(RightClickCommandProperty, value);
        }

        /// <summary>
        /// The right click command parameter property
        /// </summary>
        public static readonly DependencyProperty RightClickCommandParameterProperty = DependencyProperty.Register
        (
            nameof(RightClickCommandParameter),
            typeof(Object),
            typeof(TreeViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the right click command parameter.
        /// </summary>
        /// <value>
        /// The right click command parameter.
        /// </value>
        public Object RightClickCommandParameter
        {
            get => (Object)GetValue(RightClickCommandParameterProperty);
            set => SetValue(RightClickCommandParameterProperty, value);
        }

        //public static readonly DependencyProperty TreeViewSelectedItemProperty = DependencyProperty.Register(nameof(TreeViewSelectedItem),
        //                                                                               typeof(Object),
        //                                                                               typeof(TreeViewControl),
        //                                                                               new PropertyMetadata("TreeViewSelectedItem", TreeViewSelectedItemValueChanged));

        //private static void TreeViewSelectedItemValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    //ScreenTitleControl thisControl = d as ScreenTitleControl;

        //    //if (e.NewValue != null)
        //    //{
        //    //    thisControl.TreeViewSelectedItemTextBox.Text = e.NewValue.ToString();
        //    //}
        //}

        //public Object TreeViewSelectedItem
        //{
        //    get { return (Object)GetValue(TreeViewSelectedItemProperty); }
        //    set { SetValue(TreeViewSelectedItemProperty, value); }
        //}


        //public static readonly DependencyProperty ExpandedCommandProperty = DependencyProperty.Register(nameof(ExpandedCommand), typeof(ICommand), typeof(TreeViewControl));

        //public ICommand ExpandedCommand
        //{
        //    get { return (ICommand)GetValue(ExpandedCommandProperty); }
        //    set { SetValue(ExpandedCommandProperty, value); }
        //}
    }
}
