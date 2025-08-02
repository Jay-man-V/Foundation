//-----------------------------------------------------------------------
// <copyright file="NumericIncrementer.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;
using System.Windows.Data;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Views
{
    /// <summary>
    /// Converts a <see cref="DateTime"/> array to a <see cref="String"/>
    /// </summary>
    /// <seealso cref="IMultiValueConverter" />
    [ValueConversion(typeof(DateTime), typeof(String))]
    public class DateTimeToStringMultiConverter : IMultiValueConverter
    {
        /// <summary>
        /// values[0] = DateTime value
        /// values[1] = The format to be applied
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public Object Convert(Object?[]? values, Type targetType, Object? parameter, CultureInfo culture)
        {
            Object retVal = "Select Date";

            if (values == null || values.Length != 2) return retVal;

            String stringValue = values[0].ToString();

            String dateFormat = Formats.DotNet.DateTimeSeconds;
            if (values[1] != null &&
                !String.IsNullOrEmpty(values[1].ToString()))
            {
                dateFormat = values[1].ToString();
            }

            if (!DateTime.TryParse(stringValue, out DateTime dateValue))
            {
                IDateTimeService dateTimeService = Core.Core.TheInstance.IoC.Get<IDateTimeService>();
                dateValue = dateTimeService.SystemDateTimeNow;
            }

            retVal = dateValue.ToString(dateFormat);

            return retVal;
        }

        /// <summary>
        /// Converts a binding target value to the source binding values.
        /// </summary>
        /// <param name="value">The value that the binding target produces.</param>
        /// <param name="targetTypes">The array of types to convert to. The array length indicates the number and types of values that are suggested for the method to return.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        /// <returns>
        /// An array of values that have been converted from the target value back to the source values.
        /// </returns>
        public Object[]? ConvertBack(Object value, Type[] targetTypes, Object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
