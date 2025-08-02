//-----------------------------------------------------------------------
// <copyright file="TraceLogWriter.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// The Trace Log Writer
    /// </summary>
    internal class TraceLogWriter : LoggingBase
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="TraceLogWriter"/> class.
        /// </summary>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date/time service.</param>
        /// <param name="requestedLogLevel">The requested log level.</param>
        /// <param name="messagePrefix">The message prefix.</param>
        internal TraceLogWriter
        (
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            TraceLevel requestedLogLevel,
            String messagePrefix
        )
            : base
            (
                runTimeEnvironmentSettings,
                dateTimeService,
                requestedLogLevel,
                messagePrefix
            )
        {
            // Does nothing
        }

        /// <summary>
        /// Writes the given message to the log
        /// </summary>
        /// <param name="logMessage">The message to be logged</param>
        public override void WriteMessage(String logMessage)
        {
            InternalLogMessage(logMessage);
        }

        /// <summary>
        /// Internals the log message.
        /// </summary>
        /// <param name="logMessage">The message to be logged</param>
        private void InternalLogMessage(String logMessage)
        {
            Trace.WriteLine(logMessage);
        }
    }
}
