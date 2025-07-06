//-----------------------------------------------------------------------
// <copyright file="ApplicationSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;
using System.Diagnostics;

//using Foundation.Common.Properties;
using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the behaviours for the Application Settings
    /// </summary>
    [Serializable]
    public class ApplicationSettings
    {
        /// <summary>
        /// Initialises the <see cref="ApplicationSettings"/> class.
        /// </summary>
        static ApplicationSettings()
        {
            ApplicationName = "MyApp"; // TODO:
            ApplicationId = new(1); // TODO:

            TraceLevel = new TraceSwitch("TraceLevelSwitch", "Default Trace Level").Level;

            Initialise();
        }

        /// <summary>
        /// The default Valid To date/time that is used throughout the application
        /// <para>
        /// This is normally the '2199-Dec-31 23:59:59'
        /// </para>
        /// </summary>
        public static DateTime DefaultValidToDateTime => new(2199, 12, 31, 23, 59, 59, DateTimeKind.Utc);

        /// <summary>
        /// Gets the Application Name.
        /// </summary>
        /// <value>
        /// The Application Name.
        /// </value>
        public static String ApplicationName { get; internal set; }

        /// <summary>
        /// Gets the Application Id Number.
        /// </summary>
        /// <value>
        /// The Application Id Number.
        /// </value>
        public static AppId ApplicationId { get; internal set; }

        /// <summary>
        /// Gets the Trace Level.
        /// </summary>
        /// <value>
        /// The Trace Level.
        /// </value>
        public static TraceLevel TraceLevel { get; }

        /// <summary>
        /// Gets the Logging Configuration.
        /// </summary>
        /// <value>
        /// The Logging Configuration.
        /// </value>
        public static LoggingConfiguration LoggingConfiguration { get; set; }

        /// <summary>
        /// Initialises:
        /// <see cref="LoggingConfiguration"/>
        /// </summary>
        public static void Initialise()
        {
            LoggingConfiguration = ConfigurationManager.GetSection(LoggingConstants.EventLoggingSection) as LoggingConfiguration;

            if (LoggingConfiguration.IsNull())
            {
                String errorMessage = $"Application configuration not found. Missing section '{LoggingConstants.EventLoggingSection}'";

                ConfigurationErrorsException configurationErrorsException = new(errorMessage);

                throw configurationErrorsException;
            }
        }
    }
}
