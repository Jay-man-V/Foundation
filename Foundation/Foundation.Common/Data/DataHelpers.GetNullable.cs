//-----------------------------------------------------------------------
// <copyright file="DataHelpers.GetNullable.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common
{
    /// <summary>
    /// Defines the DataHelpers
    /// </summary>
    public static partial class DataHelpers
    {
        /// <summary>
        /// Gets the nullable boolean value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Boolean? GetNullableBooleanValue(Object? value)
        {
            LoggingHelpers.TraceCallEnter(value);

            Boolean? retVal = null;

            if (value != null)
            {
                retVal = Convert.ToBoolean(value);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the nullable double value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Double? GetNullableDoubleValue(Object? value)
        {
            LoggingHelpers.TraceCallEnter(value);

            Double? retVal = null;

            if (value != null)
            {
                retVal = Convert.ToDouble(value);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the nullable decimal value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Decimal? GetNullableDecimalValue(Object? value)
        {
            LoggingHelpers.TraceCallEnter(value);

            Decimal? retVal = null;

            if (value != null)
            {
                retVal = Convert.ToDecimal(value);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the nullable int32 value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Int32? GetNullableInt32Value(Object? value)
        {
            LoggingHelpers.TraceCallEnter(value);

            Int32? retVal = null;

            if (value != null)
            {
                retVal = Convert.ToInt32(value);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the nullable date time value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="dateTimeKind">Kind of the date time.</param>
        /// <returns></returns>
        public static DateTime? GetNullableDateTimeValue(Object? value, DateTimeKind dateTimeKind = DateTimeKind.Utc)
        {
            LoggingHelpers.TraceCallEnter(value);

            DateTime? retVal = null;

            if (value != null)
            {
                retVal = DateTime.SpecifyKind(Convert.ToDateTime(value), dateTimeKind);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the nullable time span value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static TimeSpan? GetNullableTimeSpanValue(Object? value)
        {
            LoggingHelpers.TraceCallEnter(value);

            TimeSpan? retVal = null;

            if (value != null)
            {
                retVal = TimeSpan.Parse(value.ToString() ?? "00:00:00");
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the nullable guid value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static Guid? GetNullableGuidValue(Object? value)
        {
            LoggingHelpers.TraceCallEnter(value);

            Guid? retVal = null;

            if (value != null)
            {
                retVal = Guid.Parse(value.ToString() ?? Guid.Empty.ToString());
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
