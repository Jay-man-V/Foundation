//-----------------------------------------------------------------------
// <copyright file="LoggingHelpers.LogWarningWriters.cs" company="JDV Software Ltd">
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
        /// Logs the warning message.
        /// </summary>
        /// <param name="messageToLog">The message to log.</param>
        public void LogWarningMessage(String messageToLog)
        {
            if (LoggingBase.TraceSwitch.TraceWarning && WarningLogger != null)
            {
                ContextInformation contextInfo = new(true);
                WarningLogger.LogMessage(contextInfo, messageToLog);
            }
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        public static void LogWarningMessage(params Object[] parameterValues)
        {
            if (LoggingBase.TraceSwitch.TraceWarning && WarningLogger != null)
            {
                ContextInformation contextInfo = new(true);
                WarningLogger.LogMessage(contextInfo, parameterValues);
            }
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="parameterValues">The parameter values.</param>
        public static void LogWarningMessage(String messageToLog, params Object[] parameterValues)
        {
            if (LoggingBase.TraceSwitch.TraceWarning && WarningLogger != null)
            {
                ContextInformation contextInfo = new(true);
                WarningLogger.LogMessage(contextInfo, messageToLog, parameterValues);
            }
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void LogWarningMessage(Exception exception)
        {
            if (LoggingBase.TraceSwitch.TraceWarning && WarningLogger != null)
            {
                ContextInformation contextInfo = new(true);
                WarningLogger.LogMessage(contextInfo, exception);
            }
        }

        /// <summary>
        /// Logs the warning message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="messageValues">The message values.</param>
        public static void LogWarningMessage(Exception exception, String messageToLog, params Object[] messageValues)
        {
            if (LoggingBase.TraceSwitch.TraceWarning && WarningLogger != null)
            {
                ContextInformation contextInfo = new(true);
                WarningLogger.LogMessage(contextInfo, exception, messageToLog, messageValues);
            }
        }
    }
}
