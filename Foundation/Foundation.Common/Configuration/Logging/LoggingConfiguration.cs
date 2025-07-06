//-----------------------------------------------------------------------
// <copyright file="LoggingConfiguration.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the behaviours for the LoggingConfiguration
    /// </summary>
    /// <seealso cref="ConfigurationSection" />
    public class LoggingConfiguration : ConfigurationSection
    {
        /// <summary>
        /// Gets the application.
        /// </summary>
        /// <value>
        /// The application.
        /// </value>
        [ConfigurationProperty(Constants.ApplicationName)]
        public String Application => this[Constants.ApplicationName] as String;

        /// <summary>
        /// Gets the log writers.
        /// </summary>
        /// <value>
        /// The log writers.
        /// </value>
        [ConfigurationProperty(Constants.Sections.LogWriters.Name, IsDefaultCollection = false)]
        [ConfigurationCollection(typeof(LogWriterCollection),
           AddItemName = "add",
           ClearItemsName = "clear",
           RemoveItemName = "remove")]
        public LogWriterCollection LogWriters => (LogWriterCollection)base[Constants.Sections.LogWriters.Name];

        /// <summary>
        /// Gets the tracing.
        /// </summary>
        /// <value>
        /// The tracing.
        /// </value>
        [ConfigurationProperty(Constants.Sections.Tracing.Name)]
        public TracingElement Tracing => this[Constants.Sections.Tracing.Name] as TracingElement;

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <value>
        /// The information.
        /// </value>
        [ConfigurationProperty(Constants.Sections.Information.Name)]
        public InformationElement Information => this[Constants.Sections.Information.Name] as InformationElement;

        /// <summary>
        /// Gets the error.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        [ConfigurationProperty(Constants.Sections.Error.Name)]
        public ErrorElement Error => this[Constants.Sections.Error.Name] as ErrorElement;

        /// <summary>
        /// Gets the warning.
        /// </summary>
        /// <value>
        /// The warning.
        /// </value>
        [ConfigurationProperty(Constants.Sections.Warning.Name)]
        public WarningElement Warning => this[Constants.Sections.Warning.Name] as WarningElement;

        /// <summary>
        /// Gets the audit.
        /// </summary>
        /// <value>
        /// The audit.
        /// </value>
        [ConfigurationProperty(Constants.Sections.Audit.Name)]
        public AuditElement Audit => this[Constants.Sections.Audit.Name] as AuditElement;
    }
}
