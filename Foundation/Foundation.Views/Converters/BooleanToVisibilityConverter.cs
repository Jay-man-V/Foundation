//-----------------------------------------------------------------------
// <copyright file="BooleanToVisibilityConverter.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Foundation.Views
{
    /// <summary>
    /// Converts Boolean to Visible. False -> Collapsed. True -> Visible
    /// </summary>
    /// <seealso cref="IValueConverter" />
    [ValueConversion(typeof(Boolean), typeof(Boolean))]
    public class BooleanToVisibilityConverter : IValueConverter
    {
        /// <summary>
        /// Converts <see cref="Boolean"/> value to <see cref="Visibility"/>
        /// <para>
        /// true becomes Visible
        /// </para>
        /// <para>
        /// false becomes Collapsed (default)
        /// </para>
        /// </summary>
        /// <param name="value"><see cref="Boolean"/> value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns><see cref="Boolean"/></returns>
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            Visibility retVal = Visibility.Collapsed;

            if (value == null) return retVal;

            String stringValue = value.ToString();

            if (!Boolean.TryParse(stringValue, out Boolean booleanValue))
            {
                booleanValue = false;
            }

            retVal = booleanValue ? Visibility.Visible : Visibility.Collapsed;

            return retVal;
        }

        /// <summary>
        /// Converts <see cref="Visibility"/> value to <see cref="Boolean"/>
        /// <para>
        /// Visible becomes true
        /// </para>
        /// <para>
        /// Collapsed becomes false (default)
        /// </para>
        /// </summary>
        /// <param name="value"><see cref="Boolean"/> value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns><see cref="Boolean"/></returns>
        public Object ConvertBack(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            Boolean retVal = false;

            if (value == null) return retVal;

            String stringValue = value.ToString();

            if (!Visibility.TryParse(stringValue, out Visibility visibilityValue))
            {
                visibilityValue = Visibility.Collapsed;
            }

            retVal = (visibilityValue == Visibility.Visible);

            return retVal;
        }
    }
}
