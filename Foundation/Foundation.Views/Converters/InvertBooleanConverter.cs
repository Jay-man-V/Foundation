//-----------------------------------------------------------------------
// <copyright file="InvertBooleanConverter.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;
using System.Windows.Data;

namespace Foundation.Views
{
    /// <summary>
    /// Inverts the Boolean value. False -> True. True -> False
    /// </summary>
    /// <seealso cref="IValueConverter" />
    [ValueConversion(typeof(Boolean), typeof(Boolean))]
    public class InvertBooleanConverter : IValueConverter
    {
        /// <summary>
        /// Inverts <see cref="Boolean"/> value
        /// <para>
        /// true becomes false (default)
        /// </para>
        /// <para>
        /// false becomes true
        /// </para>
        /// </summary>
        /// <param name="value"><see cref="Boolean"/> value to convert</param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns><see cref="Boolean"/></returns>
        public Object Convert(Object value, Type targetType, Object parameter, CultureInfo culture)
        {
            Boolean retVal = false;

            if (value == null) return retVal;

            String stringValue = value.ToString();

            if (!Boolean.TryParse(stringValue, out Boolean booleanValue))
            {
                booleanValue = true;
            }

            retVal = !booleanValue;

            return retVal;
        }

        /// <summary>
        /// Inverts <see cref="Boolean"/> value
        /// <para>
        /// false becomes true
        /// </para>
        /// <para>
        /// true becomes false (default)
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

            if (!Boolean.TryParse(stringValue, out Boolean booleanValue))
            {
                booleanValue = true;
            }

            retVal = !booleanValue;

            return retVal;
        }
    }
}
