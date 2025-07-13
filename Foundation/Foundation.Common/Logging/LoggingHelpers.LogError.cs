//-----------------------------------------------------------------------
// <copyright file="LoggingHelpers.LogError.cs" company="JDV Software Ltd">
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
        /// Logs the error message.
        /// </summary>
        /// <param name="messageToLog">The message to log.</param>
        public static void LogErrorMessage(String messageToLog)
        {
            if (LoggingBase.TraceSwitch.TraceError && ErrorLogger != null)
            {
                ContextInformation contextInfo = new(true);
                ErrorLogger.LogMessage(contextInfo, messageToLog);
            }
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        public static void LogErrorMessage(params Object[] parameterValues)
        {
            if (LoggingBase.TraceSwitch.TraceError && ErrorLogger != null)
            {
                ContextInformation contextInfo = new(true);
                ErrorLogger.LogMessage(contextInfo, parameterValues);
            }
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="parameterValues">The parameter values.</param>
        public static void LogErrorMessage(String messageToLog, params Object[] parameterValues)
        {
            if (LoggingBase.TraceSwitch.TraceError && ErrorLogger != null)
            {
                ContextInformation contextInfo = new(true);
                ErrorLogger.LogMessage(contextInfo, messageToLog, parameterValues);
            }
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void LogErrorMessage(Exception exception)
        {
            if (LoggingBase.TraceSwitch.TraceError && ErrorLogger != null)
            {
                ContextInformation contextInfo = new(true);
                ErrorLogger.LogMessage(contextInfo, exception);
            }
        }

        /// <summary>
        /// Logs the error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="messageValues">The message values.</param>
        public static void LogErrorMessage(Exception exception, String messageToLog, params Object[] messageValues)
        {
            if (LoggingBase.TraceSwitch.TraceError && ErrorLogger != null)
            {
                ContextInformation contextInfo = new(true);
                ErrorLogger.LogMessage(contextInfo, exception, messageToLog, messageValues);
            }
        }
    }
}
