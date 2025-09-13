//-----------------------------------------------------------------------
// <copyright file="DateTimeToStringConverter.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Globalization;
using System.Windows.Data;

using Foundation.Interfaces;
using Foundation.Resources;

namespace Foundation.Views.Converters
{
    /// <summary>
    /// Converts a <see cref="DateTime"/> array to a <see cref="String"/>
    /// </summary>
    /// <seealso cref="IValueConverter" />
    [ValueConversion(typeof(DateTime), typeof(String))]
    public class DateTimeToStringConverter : IValueConverter
    {
        /// <summary>
        /// Converts supplied <see cref="DateTime"/> to a <see cref="String"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public Object Convert(Object? value, Type targetType, Object? parameter, CultureInfo culture)
        {
            Object retVal = "Select Date";

            if (value == null) return retVal;

            String dateFormat = Formats.DotNet.DateTimeSeconds;
            if (parameter != null)
            {
                dateFormat = parameter.ToString() ?? String.Empty;
            }

            String stringValue = value.ToString() ?? String.Empty;

            if (!DateTime.TryParse(stringValue, out DateTime dateValue))
            {
                IDateTimeService dateTimeService = Core.Core.TheInstance.IoC.Get<IDateTimeService>();
                dateValue = dateTimeService.SystemDateTimeNow;
            }

            retVal = dateValue.ToString(dateFormat);

            return retVal;
        }

        /// <summary>
        /// Converts supplied <see cref="String"/> to a <see cref="DateTime"/>
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public Object? ConvertBack(Object? value, Type targetType, Object? parameter, CultureInfo culture)
        {
            Object? retVal = null;

            if (value == null) return retVal;

            String? stringValue = value.ToString();

            if (DateTime.TryParse(stringValue, out DateTime dateValue))
            {
                retVal = dateValue;
            }

            return retVal;
        }
    }
}
