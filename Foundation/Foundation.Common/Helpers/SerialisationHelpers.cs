//-----------------------------------------------------------------------
// <copyright file="SerialisationHelpers.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

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

            // By default, convert the value to a string first
            String retVal = Convert.ToString(value) ?? String.Empty;

            // TODO: Test for null value input

            if (value is null)
            {
                retVal = String.Empty;
            }
            else
            {
                if (value.IsNativeType())
                {
                    // Special formatting for the following types
                    if (value is DateTime)
                    {
                        DateTime localDateTime = Convert.ToDateTime(value);
                        retVal = localDateTime.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds);
                    }
                    else if (value is TimeSpan)
                    {
                        TimeSpan localTimeSpan = TimeSpan.Parse(value.ToString() ?? "00:00:00");
                        retVal = localTimeSpan.ToString();
                    }
                }
                else
                {
                    // All other types, the custom ones, use JSON to serialise it
                    JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings()
                    {
                        DateFormatHandling = DateFormatHandling.IsoDateFormat,
                        DateTimeZoneHandling = DateTimeZoneHandling.RoundtripKind,
                        Formatting = Formatting.Indented,
                    };

                    retVal = JsonConvert.SerializeObject(value, jsonSerializerSettings);
                }
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
        [return: NotNull]
        public static TObject Deserialise<TObject>(String? value)
        {
            LoggingHelpers.TraceCallEnter(value);

            TObject retVal = default!;

            if (value is not null)
            {
                if (retVal.IsNativeType() ||
                    typeof(TObject) == typeof(String))
                {
                    TypeConverter converter = TypeDescriptor.GetConverter(typeof(TObject));

                    if (converter.CanConvertFrom(typeof(String)))
                    {
                        TObject? temp = (TObject?)converter.ConvertFromInvariantString(value);

                        if (temp is null)
                        {
                            throw new ArgumentNullException(nameof(value));
                        }

                        retVal = temp;
                    }
                }
                else
                {
                    TObject? temp = JsonConvert.DeserializeObject<TObject>(value);

                    if (temp is null)
                    {
                        throw new ArgumentNullException(nameof(value));
                    }

                    retVal = temp;
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
