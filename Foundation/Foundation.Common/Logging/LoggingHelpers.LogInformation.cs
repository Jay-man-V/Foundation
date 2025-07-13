//-----------------------------------------------------------------------
// <copyright file="LoggingHelpers.LogInformation.cs" company="JDV Software Ltd">
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
        /// Logs the information message.
        /// </summary>
        /// <param name="messageToLog">The message to log.</param>
        public static void LogInformationMessage(String messageToLog)
        {
            if (LoggingBase.TraceSwitch.TraceInfo && InformationLogger != null)
            {
                ContextInformation contextInfo = new();
                InformationLogger.LogMessage(contextInfo, messageToLog);
            }
        }

        /// <summary>
        /// Logs the information message.
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        public static void LogInformationMessage(params Object[] parameterValues)
        {
            if (LoggingBase.TraceSwitch.TraceInfo && InformationLogger != null)
            {
                ContextInformation contextInfo = new();
                InformationLogger.LogMessage(contextInfo, parameterValues);
            }
        }

        /// <summary>
        /// Logs the information message.
        /// </summary>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="parameterValues">The parameter values.</param>
        public static void LogInformationMessage(String messageToLog, params Object[] parameterValues)
        {
            if (LoggingBase.TraceSwitch.TraceInfo && InformationLogger != null)
            {
                ContextInformation contextInfo = new();
                InformationLogger.LogMessage(contextInfo, messageToLog, parameterValues);
            }
        }

        /// <summary>
        /// Logs the information message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void LogInformationMessage(Exception exception)
        {
            if (LoggingBase.TraceSwitch.TraceInfo && InformationLogger != null)
            {
                ContextInformation contextInfo = new();
                InformationLogger.LogMessage(contextInfo, exception);
            }
        }

        /// <summary>
        /// Logs the information message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="messageValues">The message values.</param>
        public static void LogInformationMessage(Exception exception, String messageToLog, params Object[] messageValues)
        {
            if (LoggingBase.TraceSwitch.TraceInfo && InformationLogger != null)
            {
                ContextInformation contextInfo = new();
                InformationLogger.LogMessage(contextInfo, exception, messageToLog, messageValues);
            }
        }
    }
}
