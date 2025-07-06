//-----------------------------------------------------------------------
// <copyright file="LoggingHelpers.LogAudit.cs" company="JDV Software Ltd">
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
        /// Logs the audit message.
        /// </summary>
        /// <param name="messageToLog">The message to log.</param>
        public static void LogAuditMessage(String messageToLog)
        {
            if (LoggingBase.TraceSwitch.TraceInfo && AuditLogger.IsNotNull())
            {
                ContextInformation contextInfo = new(true);
                AuditLogger.LogMessage(contextInfo, messageToLog);
            }
        }

        /// <summary>
        /// Logs the audit message.
        /// </summary>
        /// <param name="parameterValues">The parameter values.</param>
        public static void LogAuditMessage(params Object[] parameterValues)
        {
            if (LoggingBase.TraceSwitch.TraceInfo && AuditLogger.IsNotNull())
            {
                ContextInformation contextInfo = new(true);
                AuditLogger.LogMessage(contextInfo, parameterValues);
            }
        }

        /// <summary>
        /// Logs the audit message.
        /// </summary>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="parameterValues">The parameter values.</param>
        public static void LogAuditMessage(String messageToLog, params Object[] parameterValues)
        {
            if (LoggingBase.TraceSwitch.TraceInfo && AuditLogger.IsNotNull())
            {
                ContextInformation contextInfo = new(true);
                AuditLogger.LogMessage(contextInfo, messageToLog, parameterValues);
            }
        }

        /// <summary>
        /// Logs the audit message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        public static void LogAuditMessage(Exception exception)
        {
            if (LoggingBase.TraceSwitch.TraceInfo && AuditLogger.IsNotNull())
            {
                ContextInformation contextInfo = new(true);
                AuditLogger.LogMessage(contextInfo, exception);
            }
        }

        /// <summary>
        /// Logs the audit message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="messageValues">The message values.</param>
        public static void LogAuditMessage(Exception exception, String messageToLog, params Object[] messageValues)
        {
            if (LoggingBase.TraceSwitch.TraceInfo && AuditLogger.IsNotNull())
            {
                ContextInformation contextInfo = new(true);
                AuditLogger.LogMessage(contextInfo, exception, messageToLog, messageValues);
            }
        }
    }
}
