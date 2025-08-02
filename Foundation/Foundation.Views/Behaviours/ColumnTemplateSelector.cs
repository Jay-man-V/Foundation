//-----------------------------------------------------------------------
// <copyright file="ColumnTemplateSelector.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Controls;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Views
{
    /// <summary>
    /// The Column Template Selector
    /// </summary>
    public class ColumnTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Selects a template for the Grid
        /// </summary>
        /// <param name="item"></param>
        /// <param name="container"></param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(Object item, DependencyObject container)
        {
            DataTemplate retVal = (DataTemplate)((Control)container).FindResource("DefaultColumnTemplate");
            IGridColumnDefinition gridColumnDefinition = item as IGridColumnDefinition;
            if (gridColumnDefinition != null)
            {
                String columnTemplateName = gridColumnDefinition.TemplateName;

                try
                {
                    retVal = (DataTemplate)((Control)container).FindResource(columnTemplateName);
                }
                catch
                {
                    // Swallow the exception
                }
            }

            return retVal;
        }
    }
}
