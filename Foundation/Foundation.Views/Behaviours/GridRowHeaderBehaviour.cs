//-----------------------------------------------------------------------
// <copyright file="GridRowHeaderBehaviour.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

using Microsoft.Xaml.Behaviors;

using Foundation.Resources;

namespace Foundation.Views.Behaviours
{
    /// <summary>
    /// Behaviour class for Grid Row Header
    /// </summary>
    public class GridRowHeaderBehaviour : Behavior<DataGrid>
    {
        /// <summary>
        /// ShowRowNumber property
        /// </summary>
        public static readonly DependencyProperty ShowRowNumberProperty = DependencyProperty.Register
        (
            nameof(ShowRowNumber),
            typeof(Boolean),
            typeof(GridRowHeaderBehaviour),
            new PropertyMetadata(OnShowRowNumberChanged)
        );

        /// <summary>
        /// Show Row Number
        /// </summary>
        public Boolean ShowRowNumber
        {
            get => (Boolean)GetValue(ShowRowNumberProperty);
            set => SetValue(ShowRowNumberProperty, value);
        }

        private DataGrid? _dataGrid;

        /// <summary>
        /// On Attached property handler
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            this._dataGrid = AssociatedObject;
        }

        private static void OnShowRowNumberChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            if (source is GridRowHeaderBehaviour context)
            {
                DataGrid? dataGrid = context._dataGrid;

                if (dataGrid == null) return;

                if ((Boolean)e.NewValue)
                {
                    void LoadedRowHandler(Object? sender, DataGridRowEventArgs ea)
                    {
                        if (context.ShowRowNumber == false)
                        {
                            dataGrid.LoadingRow -= LoadedRowHandler;
                            return;
                        }

                        Int32 rowNumber = ea.Row.GetIndex() + 1;
                        ea.Row.Header = rowNumber.ToString(Formats.DotNet.IntegerPad3);
                    }

                    dataGrid.LoadingRow += LoadedRowHandler;

                    void ItemsChangedHandler(Object sender, ItemsChangedEventArgs ea)
                    {
                        if (context.ShowRowNumber == false)
                        {
                            dataGrid.ItemContainerGenerator.ItemsChanged -= ItemsChangedHandler;
                            return;
                        }

                        GetVisualChildCollection<DataGridRow>(dataGrid).ForEach(d => d.Header = d.GetIndex());
                    }

                    dataGrid.ItemContainerGenerator.ItemsChanged += ItemsChangedHandler;
                }
            }
        }

        private static List<TElement> GetVisualChildCollection<TElement>(object parent) where TElement : Visual
        {
            List<TElement> visualCollection = [];
            GetVisualChildCollection((DependencyObject)parent, visualCollection);
            return visualCollection;
        }

        private static void GetVisualChildCollection<TElement>(DependencyObject parent, List<TElement> visualCollection) where TElement : Visual
        {
            Int32 totalChildren = VisualTreeHelper.GetChildrenCount(parent);
            for (Int32 counter = 0; counter < totalChildren; counter++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, counter);
                if (child is TElement visual)
                {
                    visualCollection.Add(visual);
                }
                //if (child != null)
                //{
                    GetVisualChildCollection(child, visualCollection);
                //}
            }
        }
    }
}
