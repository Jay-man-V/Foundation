//-----------------------------------------------------------------------
// <copyright file="LoggingBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Text;

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the basic behaviours for all Log Writers
    /// </summary>
    internal abstract class LoggingBase
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LoggingBase"/> class.
        /// </summary>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date/time service.</param>
        /// <param name="requestedLogLevel">The requested log level.</param>
        /// <param name="messagePrefix">The message prefix.</param>
        internal LoggingBase(IRunTimeEnvironmentSettings runTimeEnvironmentSettings, IDateTimeService dateTimeService, TraceLevel requestedLogLevel, String messagePrefix)
        {
            RunTimeEnvironmentSettings = runTimeEnvironmentSettings;
            DateTimeService = dateTimeService;

            if (TraceSwitch.IsNull())
            {
                TraceSwitch = new("TraceLevelSwitch", String.Empty);
            }

            RequestedLogLevel = requestedLogLevel;
            MessagePrefix = messagePrefix;
        }

        /// <summary>
        /// Gets the requested Trace Level.
        /// Off     0   None
        /// Error   1   Only error messages
        /// Warning 2   Warning messages and error messages
        /// Info    3   Informational messages, warning messages, and error messages
        /// Verbose 4   Verbose messages, informational messages, warning messages, and error messages
        /// </summary>
        /// <example>
        /// This is an example of the appSettings required in either the App.Config or Web.Config
        /// <code>
        /// <system.diagnostics>
        ///     <switches>
        ///         <add name="TraceLevelSwitch" value="3" />
        /// <!--
        /// Off     0   None
        /// Error   1   Only error messages
        /// Warning 2   Warning messages and error messages
        /// Info    3   Informational messages, warning messages, and error messages
        /// Verbose 4   Verbose messages, informational messages, warning messages, and error messages
        /// -->
        ///     </switches>
        /// </system.diagnostics>
        /// </code>
        /// </example>
        public static TraceSwitch TraceSwitch { get; private set; } = new ("TraceLevelSwitch", String.Empty);

        /// <summary>
        /// Gets the requested log level.
        /// </summary>
        /// <value>
        /// The requested log level.
        /// </value>
        public TraceLevel RequestedLogLevel { get; }

        /// <summary>
        /// Gets the message prefix.
        /// </summary>
        /// <value>
        /// The message prefix.
        /// </value>
        public String MessagePrefix { get; }

        /// <summary>
        /// Gets the run time environment settings
        /// </summary>
        /// <value>
        /// The run time environment settings.
        /// </value>
        protected IRunTimeEnvironmentSettings RunTimeEnvironmentSettings { get; }

        /// <summary>
        /// The Date/time service
        /// </summary>
        protected IDateTimeService DateTimeService { get; }

        /// <summary>
        /// Writes the given message to the log
        /// </summary>
        /// <param name="contextInfo">The context information.</param>
        /// <param name="exception">The exception.</param>
        public void LogMessage(ContextInformation contextInfo, Exception exception)
        {
            if (TraceSwitch.Level >= RequestedLogLevel)
            {
                StringBuilder traceMessage = new();
                traceMessage.AppendLine($"{MessagePrefix}: {contextInfo} ");
                ExceptionOutput exceptionOutput = MessageFormatter.FormatMessage(RunTimeEnvironmentSettings, DateTimeService, exception);
                String exceptionMessage = exceptionOutput.ToString();
                traceMessage.AppendLine(exceptionMessage);

                WriteMessage(traceMessage.ToString());
            }
        }

        /// <summary>
        /// Writes the given message to the log
        /// </summary>
        /// <param name="contextInfo">The context information.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="args">The arguments.</param>
        public void LogMessage(ContextInformation contextInfo, Exception exception, String messageToLog, params Object[] args)
        {
            if (TraceSwitch.Level >= RequestedLogLevel)
            {
                StringBuilder traceMessage = new();
                traceMessage.AppendLine($"{MessagePrefix}: {contextInfo} ");
                ExceptionOutput exceptionOutput = MessageFormatter.FormatMessage(RunTimeEnvironmentSettings, DateTimeService, exception, messageToLog, args);
                String exceptionMessage = exceptionOutput.ToString();
                traceMessage.AppendLine(exceptionMessage);

                WriteMessage(traceMessage.ToString());
            }
        }

        /// <summary>
        /// Writes the given message to the log
        /// </summary>
        /// <param name="contextInfo">The context information.</param>
        /// <param name="messageToLog">The message to log.</param>
        /// <param name="args">The arguments.</param>
        public void LogMessage(ContextInformation contextInfo, String messageToLog, params Object[] args)
        {
            if (TraceSwitch.Level >= RequestedLogLevel)
            {
                StringBuilder traceMessage = new();
                traceMessage.AppendLine($"{MessagePrefix}: {contextInfo} ");
                if (args.IsNotNull() && args.Length > 0)
                {
                    traceMessage.AppendFormat(messageToLog, args);
                }
                else
                {
                    traceMessage.Append(messageToLog);
                }

                WriteMessage(traceMessage.ToString());
            }
        }

        /// <summary>
        /// Writes the given message to the log
        /// </summary>
        /// <param name="contextInfo">The context information.</param>
        /// <param name="args">The arguments.</param>
        public void LogMessage(ContextInformation contextInfo, params Object[] args)
        {
            if (TraceSwitch.Level >= RequestedLogLevel)
            {
                StringBuilder traceMessage = new();
                traceMessage.AppendLine($"{MessagePrefix}: {contextInfo} ");
                traceMessage.Append(MessageFormatter.RenderObjectValue(args));

                WriteMessage(traceMessage.ToString());
            }
        }

        /// <summary>
        /// Writes the given message to the log
        /// </summary>
        /// <param name="logMessage">The message to be logged</param>
        public abstract void WriteMessage(String logMessage);
    }
}
