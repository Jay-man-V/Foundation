//-----------------------------------------------------------------------
// <copyright file="ComboBoxWidthFromItemsBehaviour.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Foundation.Views
{
    /// <summary>
    /// Behaviour class for ComboBoxWidthFromItems
    /// </summary>
    public static class ComboBoxWidthFromItemsBehaviour
    {
        /// <summary>
        /// ComboBoxWidthFromItems property
        /// </summary>
        public static readonly DependencyProperty ComboBoxWidthFromItemsProperty = DependencyProperty.RegisterAttached
        (
            "ComboBoxWidthFromItems",
            typeof(Boolean),
            typeof(ComboBoxWidthFromItemsBehaviour),
            new UIPropertyMetadata(false, OnComboBoxWidthFromItemsPropertyChanged)
        );

        /// <summary>
        /// Get GetComboBoxWidthFromItems
        /// </summary>
        /// <param name="dependencyObject"></param>
        /// <returns></returns>
        public static Boolean GetComboBoxWidthFromItems(DependencyObject dependencyObject)
        {
            return (Boolean)dependencyObject.GetValue(ComboBoxWidthFromItemsProperty);
        }

        /// <summary>
        /// Set GetComboBoxWidthFromItems
        /// </summary>
        /// <param name="dependencyObject"></param>
        /// <param name="value"></param>
        public static void SetComboBoxWidthFromItems(DependencyObject dependencyObject, Boolean value)
        {
            dependencyObject.SetValue(ComboBoxWidthFromItemsProperty, value);
        }

        private static void OnComboBoxWidthFromItemsPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            if (dependencyObject is ComboBox comboBox)
            {
                comboBox.Loaded -= OnComboBoxLoaded;
                if ((Boolean)e.NewValue)
                {
                    comboBox.Loaded += OnComboBoxLoaded;
                }
            }
        }

        private static void OnComboBoxLoaded(object sender, RoutedEventArgs e)
        {
            if (sender is ComboBox comboBox)
            {
                comboBox.Dispatcher.BeginInvoke(new Action(comboBox.SetWidthFromItems), DispatcherPriority.ContextIdle);
            }
        }
    }
}
