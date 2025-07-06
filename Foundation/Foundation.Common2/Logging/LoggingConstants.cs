//-----------------------------------------------------------------------
// <copyright file="LoggingConstants.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common
{
    /// <summary>
    /// Constants for the LoggingHelpers
    /// </summary>
    internal static class LoggingConstants
    {
        /// <summary>
        /// The event logging section
        /// </summary>
        internal const String EventLoggingSection = "Foundation/Foundation.EventLogging";

        /// <summary>
        /// The tracing prefix
        /// </summary>
        internal const String TracingPrefix = "Trace Message";

        /// <summary>
        /// The information prefix
        /// </summary>
        internal const String InformationPrefix = "Information Message";

        /// <summary>
        /// The warning prefix
        /// </summary>
        internal const String WarningPrefix = "Warning Message";

        /// <summary>
        /// The audit prefix
        /// </summary>
        internal const String AuditPrefix = "Audit Message";

        /// <summary>
        /// The error prefix
        /// </summary>
        internal const String ErrorPrefix = "Error Message";
    }
}
