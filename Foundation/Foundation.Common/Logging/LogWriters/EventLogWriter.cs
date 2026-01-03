//-----------------------------------------------------------------------
// <copyright file="EventLogWriter.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Security;
using System.Security.Principal;

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the behaviours for the EventLogWriter
    /// </summary>
    internal class EventLogWriter : LoggingBase
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventLogWriter"/> class.
        /// </summary>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date/time service.</param>
        /// <param name="targetEventLog">The target event log.</param>
        /// <param name="requestedLogLevel">The requested log level.</param>
        /// <param name="messagePrefix">The message prefix.</param>
        /// <param name="eventSource">The event source.</param>
        internal EventLogWriter
        (
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            String targetEventLog,
            TraceLevel requestedLogLevel,
            String messagePrefix,
            String eventSource
        )
            : base
            (
                runTimeEnvironmentSettings,
                dateTimeService,
                requestedLogLevel,
                messagePrefix
            )
        {
            TargetEventLog = targetEventLog;
            EventSource = eventSource;

            EventLogEntryType = requestedLogLevel switch
            {
                TraceLevel.Error => EventLogEntryType.Error,
                TraceLevel.Warning => EventLogEntryType.Warning,
                TraceLevel.Info => EventLogEntryType.Information,
                TraceLevel.Verbose => EventLogEntryType.Information,
                _ => EventLogEntryType.Information
            };

            CreateEventSource();
        }

        /// <summary>
        /// The target event log
        /// </summary>
        public String TargetEventLog { get; set; }

        /// <summary>
        /// The local machine name
        /// </summary>
        public static String LocalMachineName => Environment.MachineName;

        /// <summary>
        /// The event source
        /// </summary>
        public  String EventSource { get;}

        /// <summary>
        /// The event log entry type
        /// </summary>
        public EventLogEntryType EventLogEntryType { get;}

        /// <summary>
        /// Writes the given message to the log
        /// </summary>
        /// <param name="logMessage">The message to be logged</param>
        public override void WriteMessage(String logMessage)
        {
            InternalLogMessage(EventLogEntryType, logMessage);
        }

        /// <summary>
        /// Writes the given message to the log
        /// </summary>
        /// <param name="eventLogEntryType">The event log entry type</param>
        /// <param name="logMessage">The message to be logged</param>
        public void WriteMessage(EventLogEntryType eventLogEntryType, String logMessage)
        {
            InternalLogMessage(eventLogEntryType, logMessage);
        }

        /// <summary>
        /// Internals the log message.
        /// </summary>
        /// <param name="eventLogEntryType">The event log entry type</param>
        /// <param name="logMessage">The message to be logged</param>
        private void InternalLogMessage(EventLogEntryType eventLogEntryType, String logMessage)
        {
            Debug.WriteLine($"{eventLogEntryType} - {logMessage}");

            EventLog logger = new EventLog(TargetEventLog, LocalMachineName, EventSource);
            logger.WriteEntry(logMessage, eventLogEntryType);
        }

        /// <summary>
        /// Creates the event source.
        /// </summary>
        /// <exception cref="SecurityException">Security exception encountered while creating the Event Source</exception>
        private void CreateEventSource()
        {
            try
            {
                String targetEventSource = EventSource;
                //Int32 maxLength = (EventSource.Length > 8) ? 8 : EventSource.Length;
                //targetEventSource = EventSource.Substring(0, maxLength);
                Boolean eventSourceExists = EventLog.SourceExists(targetEventSource, LocalMachineName);

                if (!eventSourceExists)
                {
                    EventLog.CreateEventSource(targetEventSource, TargetEventLog);
                }
            }
            catch (Exception exception)
            {
                WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
                String executingAccount = windowsIdentity.Name;

                String errorMessage = $"Error Creating Event Source '{EventSource}({EventSource.Substring(0, 8)})'. Check Permissions of execution account. Current Executing Account is: '{executingAccount}'";
                throw new SecurityException(errorMessage, exception);
            }
        }
    }
}
