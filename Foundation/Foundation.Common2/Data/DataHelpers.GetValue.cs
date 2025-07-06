//-----------------------------------------------------------------------
// <copyright file="DataHelpers.GetValue.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Drawing;
using System.IO;

using Foundation.Interfaces;

using FEnums = Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the DataHelpers
    /// </summary>
    public partial class DataHelpers
    {
        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">if set to <c>true</c> [default value].</param>
        /// <returns></returns>
        public static Boolean GetValue(Object value, Boolean defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            Boolean retVal = defaultValue;

            if (value.IsNotNull())
            {
                if (Boolean.TryParse(value.ToString(), out var tempValue))
                {
                    retVal = tempValue;
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static Double GetValue(Object value, Double defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            Double retVal = defaultValue;

            if (value.IsNotNull())
            {
                if (Double.TryParse(value.ToString(), out var tempValue))
                {
                    retVal = tempValue;
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static Decimal GetValue(Object value, Decimal defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            Decimal retVal = defaultValue;

            if (value.IsNotNull())
            {
                if (Decimal.TryParse(value.ToString(), out var tempValue))
                {
                    retVal = tempValue;
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static Int32 GetValue(Object value, Int32 defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            Int32 retVal = defaultValue;

            if (value.IsNotNull())
            {
                if (Int32.TryParse(value.ToString(), out var tempValue))
                {
                    retVal = tempValue;
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <param name="dateTimeKind">Kind of the date time.</param>
        /// <returns></returns>
        public static DateTime GetValue(Object value, DateTime defaultValue, DateTimeKind dateTimeKind = DateTimeKind.Utc)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            DateTime retVal = defaultValue;

            if (value.IsNotNull())
            {
                if (DateTime.TryParse(value.ToString(), out var tempValue))
                {
                    // This is being done a second time to preserve the Millisecond portion of the DateTime object
                    retVal = (DateTime)value;
                }
            }

            retVal = DateTime.SpecifyKind(retVal, dateTimeKind);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static TimeSpan GetValue(Object value, TimeSpan defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            TimeSpan retVal = defaultValue;

            if (value.IsNotNull())
            {
                if (TimeSpan.TryParse(value.ToString(), out var tempValue))
                {
                    retVal = tempValue;
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static String GetValue(Object value, String defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            String retVal = defaultValue;

            if (value.IsNotNull())
            {
                String tempValue = value.ToString();

                if (!String.IsNullOrEmpty(tempValue))
                {
                    retVal = tempValue;
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static Byte[] GetValue(Object value, Byte[] defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            Byte[] retVal = defaultValue;

            if (value.IsNotNull())
            {
                retVal = (Byte[])value;
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static Image GetValue(Object value, Image defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            Image retVal = defaultValue;

            if (value.IsNotNull())
            {
                if (value is Bitmap bitmap)
                {
                    retVal = bitmap;
                }
                else if (value.GetType() == typeof(Byte[]))
                {
                    Byte[] byteArray = (Byte[])value;
                    MemoryStream ms = new MemoryStream(byteArray);
                    retVal = Image.FromStream(ms);
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static Guid GetValue(Object value, Guid defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            Guid retVal = defaultValue;

            if (value.IsNotNull())
            {
                if (Guid.TryParse(value.ToString(), out var tempValue))
                {
                    retVal = tempValue;
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static EntityStatus GetValue(Object value, EntityStatus defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            EntityStatus retVal = defaultValue;

            if (value.IsNotNull())
            {
                Enum.TryParse(value.ToString(), out retVal);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static FEnums.TaskStatus GetValue(Object value, FEnums.TaskStatus defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            FEnums.TaskStatus retVal = defaultValue;

            if (value.IsNotNull())
            {
                Enum.TryParse(value.ToString(), out retVal);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static ScheduleInterval GetValue(Object value, ScheduleInterval defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            ScheduleInterval retVal = defaultValue;

            if (value.IsNotNull())
            {
                Enum.TryParse(value.ToString(), out retVal);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static LogSeverity GetValue(Object value, LogSeverity defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            LogSeverity retVal = defaultValue;

            if (value.IsNotNull())
            {
                Enum.TryParse(value.ToString(), out retVal);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static MessageType GetValue(Object value, MessageType defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            MessageType retVal = defaultValue;

            if (value.IsNotNull())
            {
                Enum.TryParse(value.ToString(), out retVal);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static EntityId GetValue(Object value, EntityId defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            EntityId retVal = defaultValue;

            if (value.IsNotNull())
            {
                Int32.TryParse(value.ToString(), out Int32 temp);
                retVal = new EntityId(temp);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static AppId GetValue(Object value, AppId defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            AppId retVal = defaultValue;

            if (value.IsNotNull())
            {
                Int32.TryParse(value.ToString(), out Int32 temp);
                retVal = new AppId(temp);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static LogId GetValue(Object value, LogId defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            LogId retVal = defaultValue;

            if (value.IsNotNull())
            {
                Int32.TryParse(value.ToString(), out Int32 temp);
                retVal = new LogId(temp);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static EmailAddress GetValue(Object value, EmailAddress defaultValue)
        {
            LoggingHelpers.TraceCallEnter(value, defaultValue);

            EmailAddress retVal = defaultValue;

            if (value.IsNotNull())
            {
                retVal = new EmailAddress(value.ToString());
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
