//-----------------------------------------------------------------------
// <copyright file="LoggingHelpers.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Configuration;
using System.Diagnostics;
using System.Text;

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Defines Logging Helper methods
    /// </summary>
    [DependencyInjectionSingleton]
    public partial class LoggingHelpers : IApplicationStartup
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LoggingHelpers"/> class.
        /// </summary>
        /// <exception cref="ConfigurationErrorsException">Raised if the Configuration file does not contain the correct setup</exception>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public LoggingHelpers
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService
        )
        {
            String tracingPrefix = LoggingConstants.TracingPrefix;
            String informationPrefix = LoggingConstants.InformationPrefix;
            String warningPrefix = LoggingConstants.WarningPrefix;
            String auditPrefix = LoggingConstants.AuditPrefix;
            String errorPrefix = LoggingConstants.ErrorPrefix;

            String applicationName = core.ApplicationName;

            //if (ApplicationSettings.LoggingConfiguration.Tracing != null)
            //{
            //    tracingPrefix = ApplicationSettings.LoggingConfiguration.Tracing.Prefix;
            //}

            //if (ApplicationSettings.LoggingConfiguration.Information != null)
            //{
            //    informationPrefix = ApplicationSettings.LoggingConfiguration.Information.Prefix;
            //}

            //if (ApplicationSettings.LoggingConfiguration.Warning != null)
            //{
            //    warningPrefix = ApplicationSettings.LoggingConfiguration.Warning.Prefix;
            //}

            //if (ApplicationSettings.LoggingConfiguration.Audit != null)
            //{
            //    auditPrefix = ApplicationSettings.LoggingConfiguration.Audit.Prefix;
            //}

            //if (ApplicationSettings.LoggingConfiguration.Error != null)
            //{
            //    errorPrefix = ApplicationSettings.LoggingConfiguration.Error.Prefix;
            //}

            /*
            TODO: This is where code needs to be added to use different Log Writers
            */

            TraceLogger = new TraceLogWriter(runTimeEnvironmentSettings, dateTimeService, TraceLevel.Verbose, tracingPrefix);

            InformationLogger = new EventLogWriter(runTimeEnvironmentSettings, dateTimeService, core.ApplicationName, TraceLevel.Info, informationPrefix, applicationName);
            ErrorLogger = new EventLogWriter(runTimeEnvironmentSettings, dateTimeService, core.ApplicationName, TraceLevel.Error, errorPrefix, applicationName);
            WarningLogger = new EventLogWriter(runTimeEnvironmentSettings, dateTimeService, core.ApplicationName, TraceLevel.Warning, warningPrefix, applicationName);
            AuditLogger = new EventLogWriter(runTimeEnvironmentSettings, dateTimeService, core.ApplicationName, TraceLevel.Info, auditPrefix, applicationName);
        }

        /// <summary>
        /// The error logger
        /// </summary>
        private static LoggingBase? ErrorLogger { get; set; }

        /// <summary>
        /// The warning logger
        /// </summary>
        private static LoggingBase? WarningLogger { get; set; }

        /// <summary>
        /// The audit logger
        /// </summary>
        private static LoggingBase? AuditLogger { get; set; }

        /// <summary>
        /// The information logger
        /// </summary>
        private static LoggingBase? InformationLogger { get; set; }

        /// <summary>
        /// The trace logger
        /// </summary>
        private static LoggingBase? TraceLogger { get; set; }

        /// <summary>
        /// Method to be called on entry to each 'significant' method. As a minimum ALL
        /// public methods on a class should call this.
        /// </summary>
        public static void TraceCallEnter()
        {
            // Can't simply call TraceCallEnter override as this would mess up the StackTrace.
            // ContextInformation assumes that there is only one call between it and the calling
            // function.
            if (LoggingBase.TraceSwitch.TraceVerbose)
            {
                ContextInformation contextInfo = new ContextInformation();
                TraceCallEnter(contextInfo);
            }
        }

        /// <summary>
        /// Method to be called on entry to each 'significant' method. As a minimum ALL
        /// public methods on a class should call this.
        /// </summary>
        /// <param name="parameterValue">Parameters passed to call to be output in trace</param>
        public static void TraceCallEnter(Object? parameterValue)
        {
            if (LoggingBase.TraceSwitch.TraceVerbose)
            {
                ContextInformation contextInfo = new ContextInformation(parameterValue);
                TraceCallEnter(contextInfo);
            }
        }

        /// <summary>
        /// Method to be called on entry to each 'significant' method. As a minimum ALL
        /// public methods on a class should call this.
        /// </summary>
        /// <param name="parameterValues">Parameters passed to call to be output in trace</param>
        public static void TraceCallEnter(params Object?[] parameterValues)
        {
            if (LoggingBase.TraceSwitch.TraceVerbose)
            {
                ContextInformation contextInfo = new ContextInformation(parameterValues);
                TraceCallEnter(contextInfo);
            }
        }

        /// <summary>
        /// Method to be called when a method exits. Must be matched to TraceCallEnter().
        /// Ensure call comes BEFORE the return statement.
        /// </summary>
        public static void TraceCallReturn()
        {
            // Can't simply call TraceCallEnter override as this would mess up the StackTrace.
            // ContextInformation assumes that there is only one call between it and the calling
            // function.
            if (LoggingBase.TraceSwitch.TraceVerbose)
            {
                ContextInformation contextInfo = new ContextInformation();
                TraceCallReturn(null, contextInfo);
            }
        }

        /// <summary>
        /// Traces the call return.
        /// </summary>
        /// <param name="returnValue">The return value.</param>
        public static void TraceCallReturn(Object? returnValue)
        {
            if (LoggingBase.TraceSwitch.TraceVerbose)
            {
                ContextInformation contextInfo = new ContextInformation();
                TraceCallReturn(returnValue, contextInfo);
            }
        }

        /// <summary>
        /// Traces the call enter.
        /// </summary>
        /// <param name="contextInfo">The context information.</param>
        private static void TraceCallEnter(ContextInformation contextInfo)
        {
            StringBuilder traceMessage = new StringBuilder();
            traceMessage.Append($"{nameof(TraceCallEnter)}: {contextInfo}");
            WriteLogMessage(traceMessage);
            Trace.Indent();
        }

        /// <summary>
        /// Traces the call return.
        /// </summary>
        /// <param name="returnValue">The return value.</param>
        /// <param name="contextInfo">The context information.</param>
        private static void TraceCallReturn(Object? returnValue, ContextInformation contextInfo)
        {
            Trace.Unindent();
            StringBuilder traceMessage = new StringBuilder();
            traceMessage.Append($"{nameof(TraceCallReturn)}: {contextInfo}");
            if (returnValue != null)
            {
                traceMessage.Append(returnValue.GetType().Name);
                traceMessage.Append('=');
                traceMessage.Append(MessageFormatter.RenderObjectValue(returnValue));
            }

            WriteLogMessage(traceMessage);
        }

        /// <summary>
        /// Writes the log message.
        /// </summary>
        /// <param name="logMessage">The log message.</param>
        private static void WriteLogMessage(StringBuilder logMessage)
        {
            if (TraceLogger != null)
            {
                TraceLogger.WriteMessage(logMessage.ToString());
            }
        }

        /// <inheritdoc cref="IApplicationStartup.ApplicationStarting()"/>
        public void ApplicationStarting()
        {
            // Does nothing
        }
    }
}
