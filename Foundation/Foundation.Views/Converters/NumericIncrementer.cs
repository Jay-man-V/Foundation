//-----------------------------------------------------------------------
// <copyright file="NumericIncrementer.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;
using System.Windows.Data;

namespace Foundation.Views.Converters
{
    /// <summary>
    /// Converts a number to string of at least three characters
    /// </summary>
    /// <seealso cref="IValueConverter" />
    [ValueConversion(typeof(Int32), typeof(String))]
    public class NumericIncrementer : IValueConverter
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
        public Object? Convert(Object? value, Type targetType, Object? parameter, CultureInfo culture)
        {
            String retVal = String.Empty;
            if (value == null) return retVal;

            String stringValue = System.Convert.ToString(value) ?? "0";
            if (!String.IsNullOrWhiteSpace(stringValue))
            {
                if (Int32.TryParse(stringValue, out Int32 temp))
                {
                    temp += 1;
                    retVal = temp.ToString("000");
                }
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
        public Object? ConvertBack(Object? value, Type targetType, Object? parameter, CultureInfo culture)
        {
            Int32 retVal = 0;
            if (value == null) return retVal;

            retVal = System.Convert.ToInt32(value) - 1;
            
            return retVal;
        }
    }
}