//-----------------------------------------------------------------------
// <copyright file="GridControl.xaml.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using Foundation.Interfaces;

using MenuItem = System.Windows.Controls.MenuItem;

namespace Foundation.Views.Controls.Basic
{
    /// <summary>
    /// Interaction logic for GridViewControl.xaml
    /// </summary>
    public partial class GridViewControl
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="GridViewControl"/> class.
        /// </summary>
        public GridViewControl()
        {
            InitializeComponent();
        }

        //void SortHandler(Object sender, DataGridSortingEventArgs e)
        //{
        //    DataGrid thisDataGrid = sender as DataGrid;
        //    DataGridColumn column = e.Column;

        //    IComparer comparer;

        //    //i do some custom checking based on column to get the right comparer
        //    //i have different comparers for different columns. I also handle the sort direction
        //    //in my comparer

        //    // prevent the built-in sort from sorting

        //    ListSortDirection direction = column.SortDirection != ListSortDirection.Ascending ? ListSortDirection.Ascending : ListSortDirection.Descending;

        //    if (direction == ListSortDirection.Ascending)
        //    {
        //        comparer = new EntityId.SortAscending();
        //    }
        //    else
        //    {
        //        comparer = new EntityId.SortDescending();
        //    }

        //    if (comparer != null)
        //    {
        //        e.Handled = true;
        //    }

        //    //set the sort order on the column
        //    column.SortDirection = direction;

        //    //use a ListCollectionView to do the sort.
        //    ListCollectionView lcv = (ListCollectionView)CollectionViewSource.GetDefaultView(thisDataGrid.ItemsSource);

        //    //this is my custom sorter it just derives from IComparer and has a few properties
        //    //you could just apply the comparer but i needed to do a few extra bits and pieces
        //    //comparer = new ResultSort(direction);

        //    //apply the sort
        //    lcv.CustomSort = comparer;
        //}

        /// <summary>
        /// The show row number property
        /// </summary>
        public static readonly DependencyProperty ShowRowNumberProperty = DependencyProperty.Register
        (
            nameof(ShowRowNumber),
            typeof(Boolean),
            typeof(GridViewControl),
            new PropertyMetadata(true)
        );

        /// <summary>
        /// Gets or sets a value indicating whether [show row number].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show row number]; otherwise, <c>false</c>.
        /// </value>
        public Boolean ShowRowNumber
        {
            get => (Boolean)GetValue(ShowRowNumberProperty);
            set => SetValue(ShowRowNumberProperty, value);
        }

        //private static void OnShowRowNumberChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        //{
        //}

        /// <summary>
        /// The display target property
        /// </summary>
        public static readonly DependencyProperty DisplayTargetProperty = DependencyProperty.Register
        (
            nameof(DisplayTarget),
            typeof(DisplayTarget),
            typeof(GridViewControl),
            new PropertyMetadata(DisplayTarget.User)
        );

        /// <summary>
        /// Gets or sets the display target.
        /// </summary>
        /// <value>
        /// The display target.
        /// </value>
        public DisplayTarget DisplayTarget
        {
            get => (DisplayTarget)GetValue(DisplayTargetProperty);
            set => SetValue(DisplayTargetProperty, value);
        }

        /// <summary>
        /// The status bar text property
        /// </summary>
        public static readonly DependencyProperty StatusBarTextProperty = DependencyProperty.Register
        (
            nameof(StatusBarText),
            typeof(String),
            typeof(GridViewControl),
            new UIPropertyMetadata("Number of records:")
        );

        /// <summary>
        /// Gets or sets the status bar text.
        /// </summary>
        /// <value>
        /// The status bar text.
        /// </value>
        public Object StatusBarText
        {
            get => GetValue(StatusBarTextProperty);
            set => SetValue(StatusBarTextProperty, value);
        }

        /// <summary>
        /// The grid columns property
        /// </summary>
        public static readonly DependencyProperty GridColumnsProperty = DependencyProperty.Register
        (
            nameof(GridColumns),
            typeof(IEnumerable),
            typeof(GridViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the grid columns.
        /// </summary>
        /// <value>
        /// The grid columns.
        /// </value>
        public Object GridColumns
        {
            get => GetValue(GridColumnsProperty);
            set => SetValue(GridColumnsProperty, value);
        }

        /// <summary>
        /// The selected item property
        /// </summary>
        public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.Register
        (
            nameof(SelectedItem),
            typeof(Object),
            typeof(GridViewControl),
            new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault)
        );

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        public Object SelectedItem
        {
            get => GetValue(SelectedItemProperty);
            set => SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// The selected item changed command property
        /// </summary>
        public static readonly DependencyProperty SelectedItemChangedCommandProperty = DependencyProperty.Register
        (
            nameof(SelectedItemChangedCommand),
            typeof(ICommand),
            typeof(GridViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the selected item changed command.
        /// </summary>
        /// <value>
        /// The selected item changed command.
        /// </value>
        public ICommand SelectedItemChangedCommand
        {
            get => (ICommand)GetValue(SelectedItemChangedCommandProperty);
            set => SetValue(SelectedItemChangedCommandProperty, value);
        }

        //// ToolBar
        //public Boolean ToolbarVisible { get { return (ToolBar != null); } }

        //public static readonly DependencyProperty ToolBarProperty = DependencyProperty.Register(nameof(ToolBar),
        //                                                                                        typeof(Object),
        //                                                                                        typeof(GridViewControl),
        //                                                                                        new UIPropertyMetadata(null));

        //public Object ToolBar
        //{
        //    get { return (Object)GetValue(ToolBarProperty); }
        //    set { SetValue(ToolBarProperty, value); }
        //}

        /// <summary>
        /// The filter property
        /// </summary>
        public static readonly DependencyProperty FilterProperty = DependencyProperty.Register
        (
            nameof(Filter),
            typeof(Object),
            typeof(GridViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        /// <value>
        /// The filter.
        /// </value>
        public Object? Filter
        {
            get => GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }

        /// <summary>
        /// Gets a value indicating whether [filter visible].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [filter visible]; otherwise, <c>false</c>.
        /// </value>
        public Boolean FilterVisible => Filter != null;

        /// <summary>
        /// The custom toolbar property
        /// </summary>
        public static readonly DependencyProperty CustomToolbarProperty = DependencyProperty.Register
        (
            nameof(CustomToolbar),
            typeof(Object),
            typeof(GridViewControl),
            new UIPropertyMetadata(null, OnCustomToolbarChanged)
        );

        /// <summary>
        /// Gets or sets the custom toolbar.
        /// </summary>
        /// <value>
        /// The custom toolbar.
        /// </value>
        public Object CustomToolbar
        {
            get => GetValue(CustomToolbarProperty);
            set => SetValue(CustomToolbarProperty, value);
        }

        /// <summary>
        /// Called when [custom toolbar changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="ArgumentException">
        /// Attached property 'CustomToolbar' must be a ToolBar
        /// or
        /// Parent DependencyObject must be a 'GridViewControl'
        /// </exception>
        private static void OnCustomToolbarChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // check if object is an ItemsControl or ToolBarTray (is a must for menu hosts)
            if (e.NewValue is not ToolBar customToolbar)
            {
                throw new ArgumentException("Attached property 'CustomToolbar' must be a ToolBar");
            }

            if (d is not GridViewControl thisGridViewControl)
            {
                throw new ArgumentException("Parent DependencyObject must be a 'GridViewControl'");
            }

            thisGridViewControl.StandardToolBarTray.ToolBars.Add(customToolbar);
        }

        /// <summary>
        /// The refresh command property
        /// </summary>
        public static readonly DependencyProperty RefreshCommandProperty = DependencyProperty.Register
        (
            nameof(RefreshCommand),
            typeof(ICommand), 
            typeof(GridViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the refresh command.
        /// </summary>
        /// <value>
        /// The refresh command.
        /// </value>
        public ICommand RefreshCommand
        {
            get => (ICommand)GetValue(RefreshCommandProperty);
            set => SetValue(RefreshCommandProperty, value);
        }

        /// <summary>
        /// The view command property
        /// </summary>
        public static readonly DependencyProperty ViewCommandProperty = DependencyProperty.Register
        (
            nameof(ViewCommand),
            typeof(ICommand),
            typeof(GridViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the view command.
        /// </summary>
        /// <value>
        /// The view command.
        /// </value>
        public ICommand ViewCommand
        {
            get => (ICommand)GetValue(ViewCommandProperty);
            set => SetValue(ViewCommandProperty, value);
        }

        /// <summary>
        /// The add command property
        /// </summary>
        public static readonly DependencyProperty AddCommandProperty = DependencyProperty.Register
        (
            nameof(AddCommand),
            typeof(ICommand),
            typeof(GridViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the add command.
        /// </summary>
        /// <value>
        /// The add command.
        /// </value>
        public ICommand AddCommand
        {
            get => (ICommand)GetValue(AddCommandProperty);
            set => SetValue(AddCommandProperty, value);
        }

        /// <summary>
        /// The edit command property
        /// </summary>
        public static readonly DependencyProperty EditCommandProperty = DependencyProperty.Register
        (
            nameof(EditCommand),
            typeof(ICommand),
            typeof(GridViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the edit command.
        /// </summary>
        /// <value>
        /// The edit command.
        /// </value>
        public ICommand EditCommand
        {
            get => (ICommand)GetValue(EditCommandProperty);
            set => SetValue(EditCommandProperty, value);
        }

        /// <summary>
        /// The delete command property
        /// </summary>
        public static readonly DependencyProperty DeleteCommandProperty = DependencyProperty.Register
        (
            nameof(DeleteCommand),
            typeof(ICommand),
            typeof(GridViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the delete command.
        /// </summary>
        /// <value>
        /// The delete command.
        /// </value>
        public ICommand DeleteCommand
        {
            get => (ICommand)GetValue(DeleteCommandProperty);
            set => SetValue(DeleteCommandProperty, value);
        }

        /// <summary>
        /// The data source property
        /// </summary>
        public static readonly DependencyProperty DataSourceProperty = DependencyProperty.Register
        (
            nameof(DataSource),
            typeof(IEnumerable),
            typeof(GridViewControl),
            new UIPropertyMetadata(null)
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

        /// <summary>
        /// The refresh button enabled property
        /// </summary>
        public static readonly DependencyProperty RefreshButtonEnabledProperty = DependencyProperty.Register
        (
            nameof(RefreshButtonEnabled),
            typeof(Boolean),
            typeof(GridViewControl),
            new UIPropertyMetadata(true)
        );

        /// <summary>
        /// Gets or sets a value indicating whether [refresh button enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [refresh button enabled]; otherwise, <c>false</c>.
        /// </value>
        public Boolean RefreshButtonEnabled
        {
            get => (Boolean)GetValue(RefreshButtonEnabledProperty);
            set => SetValue(RefreshButtonEnabledProperty, value);
        }

        /// <summary>
        /// The refresh button visibility property
        /// </summary>
        public static readonly DependencyProperty RefreshButtonVisibilityProperty = DependencyProperty.Register
        (
            nameof(RefreshButtonVisibility),
            typeof(Visibility),
            typeof(GridViewControl),
            new UIPropertyMetadata(Visibility.Visible)
        );

        /// <summary>
        /// Gets or sets the refresh button visibility.
        /// </summary>
        /// <value>
        /// The refresh button visibility.
        /// </value>
        public Visibility RefreshButtonVisibility
        {
            get => (Visibility)GetValue(RefreshButtonVisibilityProperty);
            set => SetValue(RefreshButtonVisibilityProperty, value);
        }

        /// <summary>
        /// Gets the refresh separator visibility.
        /// </summary>
        /// <value>
        /// The refresh separator visibility.
        /// </value>
        public Visibility RefreshSeparatorVisibility => RefreshButtonVisibility;

        /// <summary>
        /// The view button enabled property
        /// </summary>
        public static readonly DependencyProperty ViewButtonEnabledProperty = DependencyProperty.Register
        (
            nameof(ViewButtonEnabled),
            typeof(Boolean),
            typeof(GridViewControl),
            new UIPropertyMetadata(false)
        );

        /// <summary>
        /// Gets or sets a value indicating whether [view button enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [view button enabled]; otherwise, <c>false</c>.
        /// </value>
        public Boolean ViewButtonEnabled
        {
            get => (Boolean)GetValue(ViewButtonEnabledProperty);
            set => SetValue(ViewButtonEnabledProperty, value);
        }

        /// <summary>
        /// The view button visibility property
        /// </summary>
        public static readonly DependencyProperty ViewButtonVisibilityProperty = DependencyProperty.Register
        (
            nameof(ViewButtonVisibility),
            typeof(Visibility),
            typeof(GridViewControl),
            new UIPropertyMetadata(Visibility.Collapsed)
        );

        /// <summary>
        /// Gets or sets the view button visibility.
        /// </summary>
        /// <value>
        /// The view button visibility.
        /// </value>
        public Visibility ViewButtonVisibility
        {
            get => (Visibility)GetValue(ViewButtonVisibilityProperty);
            set => SetValue(ViewButtonVisibilityProperty, value);
        }

        /// <summary>
        /// The add button enabled property
        /// </summary>
        public static readonly DependencyProperty AddButtonEnabledProperty = DependencyProperty.Register
        (
            nameof(AddButtonEnabled),
            typeof(Boolean),
            typeof(GridViewControl),
            new UIPropertyMetadata(false)
        );

        /// <summary>
        /// Gets or sets a value indicating whether [add button enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [add button enabled]; otherwise, <c>false</c>.
        /// </value>
        public Boolean AddButtonEnabled
        {
            get => (Boolean)GetValue(AddButtonEnabledProperty);
            set => SetValue(AddButtonEnabledProperty, value);
        }

        /// <summary>
        /// The add button visibility property
        /// </summary>
        public static readonly DependencyProperty AddButtonVisibilityProperty = DependencyProperty.Register
        (
            nameof(AddButtonVisibility),
            typeof(Visibility),
            typeof(GridViewControl),
            new UIPropertyMetadata(Visibility.Collapsed)
        );

        /// <summary>
        /// Gets or sets the add button visibility.
        /// </summary>
        /// <value>
        /// The add button visibility.
        /// </value>
        public Visibility AddButtonVisibility
        {
            get => (Visibility)GetValue(AddButtonVisibilityProperty);
            set => SetValue(AddButtonVisibilityProperty, value);
        }

        /// <summary>
        /// The edit button enabled property
        /// </summary>
        public static readonly DependencyProperty EditButtonEnabledProperty = DependencyProperty.Register
        (
            nameof(EditButtonEnabled),
            typeof(Boolean),
            typeof(GridViewControl),
            new UIPropertyMetadata(false)
        );

        /// <summary>
        /// Gets or sets a value indicating whether [edit button enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [edit button enabled]; otherwise, <c>false</c>.
        /// </value>
        public Boolean EditButtonEnabled
        {
            get => (Boolean)GetValue(EditButtonEnabledProperty);
            set => SetValue(EditButtonEnabledProperty, value);
        }

        /// <summary>
        /// The edit button visibility property
        /// </summary>
        public static readonly DependencyProperty EditButtonVisibilityProperty = DependencyProperty.Register
        (
            nameof(EditButtonVisibility),
            typeof(Visibility),
            typeof(GridViewControl),
            new UIPropertyMetadata(Visibility.Collapsed)
        );

        /// <summary>
        /// Gets or sets the edit button visibility.
        /// </summary>
        /// <value>
        /// The edit button visibility.
        /// </value>
        public Visibility EditButtonVisibility
        {
            get => (Visibility)GetValue(EditButtonVisibilityProperty);
            set => SetValue(EditButtonVisibilityProperty, value);
        }

        /// <summary>
        /// The delete button enabled property
        /// </summary>
        public static readonly DependencyProperty DeleteButtonEnabledProperty = DependencyProperty.Register
        (
            nameof(DeleteButtonEnabled),
            typeof(Boolean),
            typeof(GridViewControl),
            new UIPropertyMetadata(false)
        );

        /// <summary>
        /// Gets or sets a value indicating whether [delete button enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [delete button enabled]; otherwise, <c>false</c>.
        /// </value>
        public Boolean DeleteButtonEnabled
        {
            get => (Boolean)GetValue(DeleteButtonEnabledProperty);
            set => SetValue(DeleteButtonEnabledProperty, value);
        }

        /// <summary>
        /// The delete button visibility property
        /// </summary>
        public static readonly DependencyProperty DeleteButtonVisibilityProperty = DependencyProperty.Register
        (
            nameof(DeleteButtonVisibility),
            typeof(Visibility),
            typeof(GridViewControl),
            new UIPropertyMetadata(Visibility.Collapsed)
        );

        /// <summary>
        /// Gets or sets the delete button visibility.
        /// </summary>
        /// <value>
        /// The delete button visibility.
        /// </value>
        public Visibility DeleteButtonVisibility
        {
            get => (Visibility)GetValue(DeleteButtonVisibilityProperty);
            set => SetValue(DeleteButtonVisibilityProperty, value);
        }

        /// <summary>
        /// The export grid to excel command property
        /// </summary>
        public static readonly DependencyProperty ExportGridToExcelCommandProperty = DependencyProperty.Register
        (
            nameof(ExportGridToExcelCommand),
            typeof(ICommand),
            typeof(GridViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the export grid to excel command.
        /// </summary>
        /// <value>
        /// The export grid to excel command.
        /// </value>
        public ICommand ExportGridToExcelCommand
        {
            get => (ICommand)GetValue(ExportGridToExcelCommandProperty);
            set => SetValue(ExportGridToExcelCommandProperty, value);
        }

        /// <summary>
        /// The export grid to excel button enabled property
        /// </summary>
        public static readonly DependencyProperty ExportGridToExcelButtonEnabledProperty = DependencyProperty.Register
        (
            nameof(ExportGridToExcelButtonEnabled),
            typeof(Boolean),
            typeof(GridViewControl),
            new UIPropertyMetadata(true)
        );

        /// <summary>
        /// Gets or sets a value indicating whether [export grid to excel button enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [export grid to excel button enabled]; otherwise, <c>false</c>.
        /// </value>
        public Boolean ExportGridToExcelButtonEnabled
        {
            get => (Boolean)GetValue(ExportGridToExcelButtonEnabledProperty);
            set => SetValue(ExportGridToExcelButtonEnabledProperty, value);
        }

        /// <summary>
        /// The export grid to excel button visibility property
        /// </summary>
        public static readonly DependencyProperty ExportGridToExcelButtonVisibilityProperty = DependencyProperty.Register
        (
            nameof(ExportGridToExcelButtonVisibility),
            typeof(Visibility),
            typeof(GridViewControl),
            new UIPropertyMetadata(Visibility.Visible)
        );

        /// <summary>
        /// Gets or sets the export grid to excel button visibility.
        /// </summary>
        /// <value>
        /// The export grid to excel button visibility.
        /// </value>
        public Visibility ExportGridToExcelButtonVisibility
        {
            get => (Visibility)GetValue(ExportGridToExcelButtonVisibilityProperty);
            set => SetValue(ExportGridToExcelButtonVisibilityProperty, value);
        }

        /// <summary>
        /// The export grid to CSV command property
        /// </summary>
        public static readonly DependencyProperty ExportGridToCsvCommandProperty = DependencyProperty.Register
        (
            nameof(ExportGridToCsvCommand),
            typeof(ICommand),
            typeof(GridViewControl),
            new UIPropertyMetadata(null)
        );

        /// <summary>
        /// Gets or sets the export grid to CSV command.
        /// </summary>
        /// <value>
        /// The export grid to CSV command.
        /// </value>
        public ICommand ExportGridToCsvCommand
        {
            get => (ICommand)GetValue(ExportGridToCsvCommandProperty);
            set => SetValue(ExportGridToCsvCommandProperty, value);
        }

        /// <summary>
        /// The export grid to CSV button enabled property
        /// </summary>
        public static readonly DependencyProperty ExportGridToCsvButtonEnabledProperty = DependencyProperty.Register
        (
            nameof(ExportGridToCsvButtonEnabled),
            typeof(Boolean),
            typeof(GridViewControl),
            new UIPropertyMetadata(true)
        );

        /// <summary>
        /// Gets or sets a value indicating whether [export grid to CSV button enabled].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [export grid to CSV button enabled]; otherwise, <c>false</c>.
        /// </value>
        public Boolean ExportGridToCsvButtonEnabled
        {
            get => (Boolean)GetValue(ExportGridToCsvButtonEnabledProperty);
            set => SetValue(ExportGridToCsvButtonEnabledProperty, value);
        }

        /// <summary>
        /// The export grid to CSV button visibility property
        /// </summary>
        public static readonly DependencyProperty ExportGridToCsvButtonVisibilityProperty = DependencyProperty.Register
        (
            nameof(ExportGridToCsvButtonVisibility),
            typeof(Visibility),
            typeof(GridViewControl),
            new UIPropertyMetadata(Visibility.Visible)
        );

        /// <summary>
        /// Gets or sets the export grid to CSV button visibility.
        /// </summary>
        /// <value>
        /// The export grid to CSV button visibility.
        /// </value>
        public Visibility ExportGridToCsvButtonVisibility
        {
            get => (Visibility)GetValue(ExportGridToCsvButtonVisibilityProperty);
            set => SetValue(ExportGridToCsvButtonVisibilityProperty, value);
        }

        /// <summary>
        /// Gets the record edit buttons visibility.
        /// </summary>
        /// <value>
        /// The record edit buttons visibility.
        /// </value>
        public Visibility RecordEditButtonsVisibility
        {
            get
            {
                Visibility retVal = Visibility.Collapsed;
                if (AddButtonVisibility != Visibility.Collapsed &&
                    EditButtonVisibility != Visibility.Collapsed &&
                    ViewButtonVisibility != Visibility.Collapsed &&
                    DeleteButtonVisibility != Visibility.Collapsed)
                {
                    retVal = Visibility.Visible;
                }

                return retVal;
            }
        }

        /// <summary>
        /// Gets the export buttons visibility.
        /// </summary>
        /// <value>
        /// The export buttons visibility.
        /// </value>
        public Visibility ExportButtonsVisibility
        {
            get
            {
                Visibility retVal = Visibility.Collapsed;
                if (ExportGridToExcelButtonVisibility != Visibility.Collapsed &&
                    ExportGridToCsvButtonVisibility != Visibility.Collapsed)
                {
                    retVal = Visibility.Visible;
                }

                return retVal;
            }
        }

        private void MenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            DataGrid thisDataGrid = DataGrid;

            if (thisDataGrid != null &&
                thisDataGrid.SelectedCells.Count > 0)
            {
                DataGridCellInfo dataGridCellInfo = thisDataGrid.CurrentCell;
                DataGridColumn columnInfo = dataGridCellInfo.Column;
                FrameworkElement frameworkElement = columnInfo.GetCellContent(dataGridCellInfo.Item);
                if (frameworkElement != null)
                {
                    Object cellValue = frameworkElement.GetValue(TextBlock.TextProperty);
                    if (cellValue == null ||
                        String.IsNullOrEmpty(cellValue.ToString()))
                    {
                        cellValue = frameworkElement.GetValue(ComboBox.TextProperty);
                    }

                    if (cellValue != null)
                    {
                        var selectedTextValue = cellValue.ToString();

                        MenuItem thisMenuItem = (MenuItem)sender;
                        if (thisMenuItem.Command.CanExecute(selectedTextValue))
                        {
                            thisMenuItem.Command.Execute(selectedTextValue);
                        }
                    }
                }
            }
        }
    }
}
