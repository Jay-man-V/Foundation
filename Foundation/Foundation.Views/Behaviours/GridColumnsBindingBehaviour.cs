//-----------------------------------------------------------------------
// <copyright file="GridColumnsBindingBehaviour.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Microsoft.Xaml.Behaviors;

using Foundation.Interfaces;
using Foundation.Resources;
using Foundation.Views.Converters;
using FEnums = Foundation.Interfaces;

namespace Foundation.Views.Behaviours
{
    /// <summary>
    /// Behaviour class for Grid Column Binding
    /// </summary>
    public class GridColumnsBindingBehaviour : Behavior<DataGrid>
    {
        /// <summary>
        /// Columns property
        /// </summary>
        public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register
        (
            nameof(Columns),
            typeof(IEnumerable),
            typeof(GridColumnsBindingBehaviour),
            new PropertyMetadata(OnDataGridColumnsPropertyChanged)
        );

        /// <summary>
        /// Columns
        /// </summary>
        public IEnumerable Columns
        {
            get => (IEnumerable)GetValue(ColumnsProperty);
            set => SetValue(ColumnsProperty, value);
        }

        private ObservableCollection<DataGridColumn> _dataGridColumns = [];

        /// <summary>
        /// OnAttached handler
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            _dataGridColumns = AssociatedObject.Columns;
        }

        private static void OnDataGridColumnsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            if (source is GridColumnsBindingBehaviour context)
            {
                if (e.OldValue is ObservableCollection<Object> oldItems)
                {
                    foreach (DataGridColumn dataGridColumn in oldItems)
                    {
                        context._dataGridColumns.Remove(dataGridColumn);
                    }

                    oldItems.CollectionChanged -= context.CollectionChanged;
                }

                if (e.NewValue is ObservableCollection<IGridColumnDefinition> newItems)
                {
                    foreach (IGridColumnDefinition gridColumnDefinition in newItems)
                    {
                        //DataGridColumn dataGridColumn = CreateDataGridColumn(gridColumnDefinition, context.AssociatedObject);
                        DataGridColumn dataGridColumn = CreateDataGridColumn(gridColumnDefinition);
                        context._dataGridColumns.Add(dataGridColumn);
                    }

                    newItems.CollectionChanged += context.CollectionChanged;
                }
            }
        }

        private void CollectionChanged(Object? sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    if (e.NewItems != null)
                    {
                        foreach (DataGridColumn one in e.NewItems)
                        {
                            _dataGridColumns.Add(one);
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Remove:
                    if (e.OldItems != null)
                    {
                        foreach (DataGridColumn one in e.OldItems)
                        {
                            _dataGridColumns.Remove(one);
                        }
                    }
                    break;

                case NotifyCollectionChangedAction.Move:
                    _dataGridColumns.Move(e.OldStartingIndex, e.NewStartingIndex);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    _dataGridColumns.Clear();
                    if (e.NewItems != null)
                    {
                        foreach (DataGridColumn one in e.NewItems)
                        {
                            _dataGridColumns.Add(one);
                        }
                    }
                    break;
            }
        }

        private static DataGridColumn? CreateDataGridColumn(IGridColumnDefinition gridColumnDefinition, DependencyObject container)
        {
            DataGridColumn? retVal = null;

            ColumnTemplateSelector columnTemplateSelector = new ColumnTemplateSelector();

            DataTemplate dataTemplate = columnTemplateSelector.SelectTemplate(gridColumnDefinition, container);

            DependencyObject dependencyObject = dataTemplate.LoadContent();

            if (dependencyObject is ContentControl contentControl)
            {
                retVal = contentControl.Content as DataGridColumn;
            }

            return retVal;
        }

        private static DataGridColumn CreateDataGridColumn(IGridColumnDefinition gridColumnDefinition)
        {
            DataGridColumn retVal;

            if (gridColumnDefinition.TemplateName == GridColumnTemplateNames.DropDownBoxColumnTemplate)
            {
                DataGridComboBoxColumn dataGridColumn = new DataGridComboBoxColumn();
                retVal = dataGridColumn;
                dataGridColumn.ItemsSource = gridColumnDefinition.DataSource as IEnumerable;
                dataGridColumn.IsReadOnly = gridColumnDefinition.ReadOnly;
                dataGridColumn.DisplayMemberPath = gridColumnDefinition.DisplayMember;
                dataGridColumn.SelectedValuePath = gridColumnDefinition.ValueMember;
                dataGridColumn.SelectedValueBinding = new Binding(gridColumnDefinition.DataMemberName) { Mode = BindingMode.OneWay };
                dataGridColumn.ElementStyle = new Style(typeof(ComboBox));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(ComboBox.HorizontalAlignmentProperty, HorizontalAlignment.Center));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(ComboBox.VerticalAlignmentProperty, VerticalAlignment.Center));
            }
            else if (gridColumnDefinition.TemplateName == GridColumnTemplateNames.ImageDropDownBoxColumnTemplate)
            {
                gridColumnDefinition.Width += 30;

                DataGridTemplateColumn dataGridColumn = new DataGridTemplateColumn();
                retVal = dataGridColumn;
                retVal.IsReadOnly = gridColumnDefinition.ReadOnly;

                FrameworkElementFactory comboBoxElement = new FrameworkElementFactory(typeof(ComboBox));
                comboBoxElement.SetValue(ComboBox.ItemsSourceProperty, gridColumnDefinition.DataSource as IEnumerable);
                comboBoxElement.SetValue(ComboBox.IsReadOnlyProperty, gridColumnDefinition.ReadOnly);
                comboBoxElement.SetValue(ComboBox.DisplayMemberPathProperty, gridColumnDefinition.DisplayMember);
                comboBoxElement.SetValue(ComboBox.SelectedValuePathProperty, gridColumnDefinition.ValueMember);
                comboBoxElement.SetValue(ComboBox.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                comboBoxElement.SetValue(ComboBox.VerticalAlignmentProperty, VerticalAlignment.Center);
                comboBoxElement.SetValue(ComboBox.WidthProperty, (Double)(gridColumnDefinition.Width));

                Binding b1 = new Binding(gridColumnDefinition.DataMemberName) { Mode = BindingMode.OneWay };
                comboBoxElement.SetValue(ComboBox.SelectedValueProperty, b1);

                DataTemplate stackDataTemplate = new DataTemplate();
                FrameworkElementFactory stackPanel = new FrameworkElementFactory(typeof(StackPanel));
                FrameworkElementFactory imageElement = new FrameworkElementFactory(typeof(Image));

                Binding b2 = new Binding(gridColumnDefinition.DisplayMember)
                {
                    Mode = BindingMode.OneWay,
                    Converter = new ByteArrayToMediaImageConverter(),
                };

                imageElement.SetValue(Image.SourceProperty, b2);
                imageElement.SetValue(Image.StretchProperty, System.Windows.Media.Stretch.None);
                imageElement.SetValue(Image.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                imageElement.SetValue(Image.VerticalAlignmentProperty, VerticalAlignment.Center);
                imageElement.SetValue(Image.WidthProperty, (Double)gridColumnDefinition.Width);

                stackPanel.AppendChild(imageElement);
                stackDataTemplate.VisualTree = stackPanel;
                comboBoxElement.SetValue(ComboBox.ItemTemplateProperty, stackDataTemplate);

                DataTemplate cellTemplate1 = new DataTemplate { VisualTree = comboBoxElement, };

                dataGridColumn.CellTemplate = cellTemplate1;
            }
            else if (gridColumnDefinition.TemplateName == GridColumnTemplateNames.NumericColumnTemplate)
            {
                DataGridTextColumn dataGridColumn = new DataGridTextColumn();
                retVal = dataGridColumn;
                dataGridColumn.Binding = new Binding(gridColumnDefinition.DataMemberName) { Mode = BindingMode.OneWay, StringFormat = gridColumnDefinition.DotNetFormat };
                dataGridColumn.ElementStyle = new Style(typeof(TextBlock));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Stretch));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, System.Windows.TextAlignment.Right));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center));
            }
            else if (gridColumnDefinition.DataType == typeof(DateTime))
            {
                DataGridTextColumn dataGridColumn = new DataGridTextColumn();
                retVal = dataGridColumn;
                dataGridColumn.Binding = new Binding(gridColumnDefinition.DataMemberName) { Mode = BindingMode.OneWay, StringFormat = gridColumnDefinition.DotNetFormat };
                dataGridColumn.ElementStyle = new Style(typeof(TextBlock));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Stretch));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, System.Windows.TextAlignment.Right));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center));
            }
            else if (gridColumnDefinition.TemplateName == GridColumnTemplateNames.ImageColumnTemplate)
            {
                DataGridTemplateColumn dataGridColumn = new DataGridTemplateColumn();
                retVal = dataGridColumn;

                FrameworkElementFactory imageElement = new FrameworkElementFactory(typeof(Image));
                Binding b1 = new Binding(gridColumnDefinition.DataMemberName)
                {
                    Mode = BindingMode.OneWay,
                    Converter = new ByteArrayToMediaImageConverter(),
                };

                imageElement.SetValue(Image.SourceProperty, b1);
                imageElement.SetValue(Image.StretchProperty, System.Windows.Media.Stretch.None);
                imageElement.SetValue(Image.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                imageElement.SetValue(Image.VerticalAlignmentProperty, VerticalAlignment.Center);

                DataTemplate cellTemplate1 = new DataTemplate { VisualTree = imageElement };

                dataGridColumn.CellTemplate = cellTemplate1;
            }
            else if (gridColumnDefinition.TemplateName == GridColumnTemplateNames.YesNoColumnTemplate)
            {
                DataGridComboBoxColumn dataGridColumn = new DataGridComboBoxColumn();
                retVal = dataGridColumn;

                List<KeyValuePair<Boolean, String>> dropdown =
                [
                    new (true, gridColumnDefinition.TrueValue),
                    new (false, gridColumnDefinition.FalseValue)
                ];

                dataGridColumn.ItemsSource = dropdown;

                dataGridColumn.IsReadOnly = gridColumnDefinition.ReadOnly;
                dataGridColumn.DisplayMemberPath = nameof(KeyValuePair<Boolean, String>.Value);
                dataGridColumn.SelectedValuePath = nameof(KeyValuePair<Boolean, String>.Key);
                dataGridColumn.SelectedValueBinding = new Binding(gridColumnDefinition.DataMemberName) { Mode = BindingMode.OneWay };
                dataGridColumn.ElementStyle = new Style(typeof(ComboBox));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(ComboBox.HorizontalAlignmentProperty, HorizontalAlignment.Center));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(ComboBox.VerticalAlignmentProperty, VerticalAlignment.Center));
            }
            else
            {
                // Assume it is a String field by default
                DataGridTextColumn dataGridColumn = new DataGridTextColumn
                {
                    Binding = new Binding(gridColumnDefinition.DataMemberName) { Mode = BindingMode.OneWay },
                    ElementStyle = new Style(typeof(TextBlock))
                };
                dataGridColumn.ElementStyle.Setters.Add(new Setter(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Stretch));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(TextBlock.TextAlignmentProperty, GetTextAlignment(gridColumnDefinition.TextAlignment)));
                dataGridColumn.ElementStyle.Setters.Add(new Setter(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center));
                retVal = dataGridColumn;
            }

            // Common properties
            retVal.Header = gridColumnDefinition.ColumnHeaderName;
            retVal.Width = new DataGridLength(gridColumnDefinition.Width, DataGridLengthUnitType.Pixel);

            return retVal;
        }

        private static System.Windows.TextAlignment GetTextAlignment(FEnums.TextAlignment textAlignment)
        {
            System.Windows.TextAlignment retVal = System.Windows.TextAlignment.Left;

            switch (textAlignment)
            {
                case FEnums.TextAlignment.Right: retVal = System.Windows.TextAlignment.Right; break;
                case FEnums.TextAlignment.Centre: retVal = System.Windows.TextAlignment.Center; break;
            }

            return retVal;
        }
    }
}
