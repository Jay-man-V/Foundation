//-----------------------------------------------------------------------
// <copyright file="SerialisationHelpers.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel;

using Newtonsoft.Json;

using Foundation.Resources;

namespace Foundation.Common
{
    /// <summary>
    /// The Serialisation Helpers class definition
    /// </summary>
    public class SerialisationHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static String Serialise<TObject>(TObject value)
        {
            LoggingHelpers.TraceCallEnter(value);

            String retVal = Convert.ToString(value);

            if (value.IsNativeType())
            {
                if (value is DateTime)
                {
                    DateTime localDateTime = Convert.ToDateTime(value);
                    retVal = localDateTime.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds);
                }
                else if (value is TimeSpan)
                {
                    TimeSpan localTimeSpan = TimeSpan.Parse(value.ToString());
                    retVal = localTimeSpan.ToString();
                }
            }
            else
            {
                JsonSerializerSettings jsonSerializerSettings = new()
                {
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                    Formatting = Formatting.Indented,
                };

                retVal = JsonConvert.SerializeObject(value, jsonSerializerSettings);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TObject Deserialise<TObject>(Object value)
        {
            LoggingHelpers.TraceCallEnter(value);

            TObject retVal = default;

            if (retVal.IsNativeType() ||
                typeof(TObject) == typeof(String))
            {
                TypeConverter converter = TypeDescriptor.GetConverter(typeof(TObject));

                if (converter.CanConvertFrom(typeof(String)))
                {
                    retVal = (TObject)converter.ConvertFromInvariantString(value.ToString());
                }
            }
            else
            {
                retVal = JsonConvert.DeserializeObject<TObject>(value.ToString());
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
