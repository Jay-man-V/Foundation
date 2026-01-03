//-----------------------------------------------------------------------
// <copyright file="LoggingHelpers.Trace.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common
{
    /// <summary>
    /// Defines Logging Helper methods
    /// </summary>
    public partial class LoggingHelpers
    {
        /// <summary>
        /// Traces the message.
        /// </summary>
        /// <param name="messageToLog">The message to log.</param>
        public static void TraceMessage(String messageToLog)
        {
            if (RunTimeEnvironmentSettings!.TraceSwitch.TraceVerbose && TraceLogger != null)
            {
                ContextInformation contextInfo = new ContextInformation(true);
                TraceLogger.LogMessage(contextInfo, messageToLog);
            }
        }

        /// <summary>
        /// Traces the message.
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        public static void TraceMessage(params Object[] parameterValues)
        {
            if (RunTimeEnvironmentSettings!.TraceSwitch.TraceVerbose && TraceLogger != null)
            {
                ContextInformation contextInfo = new ContextInformation(true);
                TraceLogger.LogMessage(contextInfo, parameterValues);
            }
        }

        /// <summary>
        /// Traces the message.
        /// </summary>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="parameterValues">The parameter values.</param>
        public static void TraceMessage(String messageToLog, params Object[] parameterValues)
        {
            if (RunTimeEnvironmentSettings!.TraceSwitch.TraceVerbose && TraceLogger != null)
            {
                ContextInformation contextInfo = new ContextInformation(true);
                TraceLogger.LogMessage(contextInfo, messageToLog, parameterValues);
            }
        }

        /// <summary>
        /// Traces the message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void TraceMessage(Exception exception)
        {
            if (RunTimeEnvironmentSettings!.TraceSwitch.TraceVerbose && TraceLogger != null)
            {
                ContextInformation contextInfo = new ContextInformation(true);
                TraceLogger.LogMessage(contextInfo, exception);
            }
        }

        /// <summary>
        /// Traces the message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="messageValues">The message values.</param>
        public static void TraceMessage(Exception exception, String messageToLog, params Object[] messageValues)
        {
            if (RunTimeEnvironmentSettings!.TraceSwitch.TraceVerbose && TraceLogger != null)
            {
                ContextInformation contextInfo = new ContextInformation(true);
                TraceLogger.LogMessage(contextInfo, exception, messageToLog, messageValues);
            }
        }
    }
}
