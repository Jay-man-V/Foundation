//-----------------------------------------------------------------------
// <copyright file="Formats.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources
{
    /// <summary>
    /// Common Formats definition
    /// </summary>
    public static class Formats
    {
        /// <summary>
        /// Formats for use within dotNet languages
        /// </summary>
        public static class DotNet
        {
            /// <summary>
            /// The Date Month Year Hours format - dd-MMM-yyyy
            /// </summary>
            public static String FromDate => DateOnly;

            /// <summary>
            /// The Date Month Year Hours format - dd-MMM-yyyy
            /// </summary>
            public static String ToDate => DateOnly;

            /// <summary>
            /// The Date Month Year Hours Minutes format - dd-MMM-yyyy HH:mm
            /// </summary>
            public static String FromDateTime => DateOnly + " " + TimeOnly;

            /// <summary>
            /// The Date Month Year Hours Minutes format - dd-MMM-yyyy HH:mm
            /// </summary>
            public static String ToDateTime => DateOnly + " " + TimeOnly;

            /// <summary>
            /// The Date Month Year Hours Minutes format - dd-MMM-yyyy HH:mm
            /// </summary>
            public static String CreatedDateTime => DateOnly + " " + TimeOnly;

            /// <summary>
            /// The Date Month Year Hours Minutes format - dd-MMM-yyyy HH:mm
            /// </summary>
            public static String UpdatedDateTime => DateOnly + " " + TimeOnly;

            /// <summary>
            /// The Time in 24hour format - HH:mm
            /// </summary>
            public static String TimeOnly => "HH:mm";

            /// <summary>
            /// The Time in 24hour format - HH:mm:ss
            /// </summary>
            public static String TimeWithSeconds => TimeOnly + ":ss";

            /// <summary>
            /// The Time in 24hour format - HH:mm:ss.fff
            /// </summary>
            public static String TimeWithMilliseconds => TimeWithSeconds + ".fff";

            /// <summary>
            /// The Month Year format - MMM-yyyy
            /// </summary>
            public static String MonthYear => "MMM-yyyy";

            /// <summary>
            /// The Date Month Year format - dd-MMM-yyyy
            /// </summary>
            public static String DateOnly => "dd-" + MonthYear;

            /// <summary>
            /// The Date Month Year format - ddd dd-MMM-yyyy
            /// </summary>
            public static String DateOnlyWithDoW => "ddd, " + DateOnly;

            /// <summary>
            /// The Date Month Year Hours Minutes format - dd-MMM-yyyy HH:mm
            /// </summary>
            public static String DateTime => DateOnly + " " + TimeOnly;

            /// <summary>
            /// The date/time only format - dd-MMM-yyyy HH:mm:ss
            /// </summary>
            public static String DateTimeSeconds => DateOnly + " " + TimeWithSeconds;

            /// <summary>
            /// The date/time only format - dd-MMM-yyyy HH:mm:ss.fff
            /// </summary>
            public static String DateTimeMilliseconds => DateOnly + " " + TimeWithMilliseconds;

            /// <summary>
            /// The ISO 8601 format - yyyy-MM-dd
            /// </summary>
            public static String Iso8601Date => "yyyy-MM-dd";

            /// <summary>
            /// The ISO 8601 format - yyyy-MM-ddTHH:mm:ss
            /// </summary>
            public static String Iso8601DateTime => "yyyy-MM-ddTHH:mm:ss";

            /// <summary>
            /// The date/time only format - yyyy-MMM-ddTHH:mm:ss.fff
            /// </summary>
            public static String Iso8601DateTimeMilliseconds => "yyyy-MM-ddTHH:mm:ss.fff";

            /// <summary>
            /// The percentage format - P2 - 0.05123456 -> 5.12%
            /// </summary>
            public static String Percentage2dp => "P2";

            /// <summary>
            /// The percentage format - P5 - 0.05123456 -> 5.12346%
            /// </summary>
            public static String Percentage5dp => "P5";

            /// <summary>
            /// The integer format - N0 - #,###
            /// </summary>
            public static String Integer => "N0";

            /// <summary>
            /// The integer format - D3 - 000###
            /// </summary>
            public static String IntegerPad3 => "D3";

            /// <summary>
            /// The decimal format - N2 - #,##0.00
            /// </summary>
            public static String Decimal2dp => "N2";

            /// <summary>
            /// The decimal format - N5 - #,##0.00000
            /// </summary>
            public static String Decimal5dp => "N5";
        }

        /// <summary>
        /// Formats for use with Microsoft Excel
        /// </summary>
        public class Excel
        {
            /// <summary>
            /// The Date Month Year Hours format - dd-MMM-yyyy
            /// </summary>
            public static String FromDate => DateOnly;

            /// <summary>
            /// The Date Month Year Hours format - dd-MMM-yyyy
            /// </summary>
            public static String ToDate => DateOnly;

            /// <summary>
            /// The Date Month Year Hours Minutes format - dd-MMM-yyyy HH:mm
            /// </summary>
            public static String FromDateTime => DateOnly + " " + TimeOnly;

            /// <summary>
            /// The Date Month Year Hours Minutes format - dd-MMM-yyyy HH:mm
            /// </summary>
            public static String ToDateTime => DateOnly + " " + TimeOnly;

            /// <summary>
            /// The Date Month Year Hours Minutes format - dd-MMM-yyyy HH:mm
            /// </summary>
            public static String CreatedDateTime => DateOnly + " " + TimeOnly;

            /// <summary>
            /// The Date Month Year Hours Minutes format - dd-MMM-yyyy HH:mm
            /// </summary>
            public static String UpdatedDateTime => DateOnly + " " + TimeOnly;

            /// <summary>
            /// The Time in 24hour format - HH:mm
            /// </summary>
            public static String TimeOnly => "HH:mm";

            /// <summary>
            /// The Time in 24hour format - HH:mm:ss
            /// </summary>
            public static String TimeWithSeconds => TimeOnly + ":ss";

            /// <summary>
            /// The Time in 24hour format - HH:mm:ss.000
            /// </summary>
            public static String TimeWithMilliseconds => TimeWithSeconds + ".000";

            /// <summary>
            /// The Month Year format - MMM-yyyy
            /// </summary>
            public static String MonthYear => "MMM-yyyy";

            /// <summary>
            /// The Date Month Year format - dd-MMM-yyyy
            /// </summary>
            public static String DateOnly => "dd-" + MonthYear;

            /// <summary>
            /// The Date Month Year format - ddd dd-MMM-yyyy
            /// </summary>
            public static String DateOnlyWithDoW => "ddd, " + DateOnly;

            /// <summary>
            /// The Date Month Year Hours Minutes format - dd-MMM-yyyy HH:mm
            /// </summary>
            public static String DateTime => DateOnly + " " + TimeOnly;

            /// <summary>
            /// The date/time only format - dd-MMM-yyyy HH:mm:ss
            /// </summary>
            public static String DateTimeSeconds => DateOnly + " " + TimeWithSeconds;

            /// <summary>
            /// The date/time only format - dd-MMM-yyyy HH:mm:ss.000
            /// </summary>
            public static String DateTimeMilliseconds => DateOnly + " " + TimeWithMilliseconds;

            /// <summary>
            /// The ISO 8601 format - yyyy-MM-dd
            /// </summary>
            public static String Iso8601Date => "yyyy-MM-dd";

            /// <summary>
            /// The ISO 8601 format - yyyy-MM-ddTHH:mm:ss
            /// </summary>
            public static String Iso8601DateTime => "yyyy-MM-ddTHH:mm:ss";

            /// <summary>
            /// The date/time only format - yyyy-MMM-ddTHH:mm:ss.000
            /// </summary>
            public static String Iso8601DateTimeMilliseconds => "yyyy-MM-ddTHH:mm:ss.000";

            /// <summary>
            /// The percentage format 0.05123456 -> 5.12%
            /// </summary>
            public static String Percentage2dp => "0.00%";

            /// <summary>
            /// The percentage format 0.05123456 -> 5.12346%
            /// </summary>
            public static String Percentage5dp => "0.00000%";

            /// <summary>
            /// The integer format - #,###
            /// </summary>
            public static String Integer => "#,##0";

            /// <summary>
            /// The integer format - #,000
            /// </summary>
            public static String IntegerPad3 => "#,000";

            /// <summary>
            /// The decimal format - #,##0.00
            /// </summary>
            public static String Decimal2dp => "#,##0.00";

            /// <summary>
            /// The decimal format - #,##0.00000
            /// </summary>
            public static String Decimal5dp => "#,##0.00000";
        }
    }
}
