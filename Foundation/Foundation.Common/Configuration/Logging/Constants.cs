//-----------------------------------------------------------------------
// <copyright file="Constants.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common
{
    /// <summary>
    /// Constants for the Log Writers Configuration
    /// </summary>
    internal static class Constants
    {
        /// <summary>
        /// The application name
        /// </summary>
        internal const String ApplicationName = "application";

        /// <summary>
        /// Constants for the Sections
        /// </summary>
        internal static class Sections
        {
            /// <summary>
            /// 
            /// </summary>
            internal static class LogWriters
            {
                public const String Name = "LogWriters";
                public const String Key = "key";
                public const String Events = "events";
                public const String Assembly = "assembly";
                public const String LoggingType = "type";
            }

            /// <summary>
            /// Constants for Common Properties
            /// </summary>
            internal static class CommonProperties
            {
                /// <summary>
                /// The prefix
                /// </summary>
                public const String Prefix = "prefix";
            }

            /// <summary>
            /// Constants for Tracing
            /// </summary>
            internal static class Tracing
            {
                /// <summary>
                /// The name
                /// </summary>
                public const String Name = "Tracing";
            }

            /// <summary>
            /// Constants for Information
            /// </summary>
            internal static class Information
            {
                /// <summary>
                /// The name
                /// </summary>
                public const String Name = "Information";
            }

            /// <summary>
            /// Constants for Error
            /// </summary>
            internal static class Error
            {
                /// <summary>
                /// The name
                /// </summary>
                public const String Name = "Error";
            }

            /// <summary>
            /// Constants for Audit
            /// </summary>
            internal static class Audit
            {
                /// <summary>
                /// The name
                /// </summary>
                public const String Name = "Audit";
            }

            /// <summary>
            /// Constants for Warning
            /// </summary>
            internal static class Warning
            {
                /// <summary>
                /// The name
                /// </summary>
                public const String Name = "Warning";
            }
        }
    }
}
