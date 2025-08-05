//-----------------------------------------------------------------------
// <copyright file="NullStringVisibilityConverter.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Foundation.Views
{
    /// <summary>
    /// if a null string is supplied, returns Collapsed, otherwise Visible
    /// </summary>
    /// <seealso cref="IValueConverter" />
    [ValueConversion(typeof(String), typeof(Visibility))]
    public class NullStringVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns <see langword="null" />, the valid null value is used.
        /// </returns>
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            Visibility retVal = Visibility.Collapsed;

            if (value == null) return retVal;

            String stringValue = value.ToString();

            if (!String.IsNullOrWhiteSpace(stringValue))
            {
                retVal = Visibility.Visible;
            }

            return retVal;
        }

        /// <summary>
        /// Converts a value.
        /// </summary>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// A converted value. If the method returns <see langword="null" />, the valid null value is used.
        /// </returns>
        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
