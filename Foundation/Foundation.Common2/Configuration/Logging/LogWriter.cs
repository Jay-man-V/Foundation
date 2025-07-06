//-----------------------------------------------------------------------
// <copyright file="LogWriter.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the behaviours for the LogWriter
    /// </summary>
    /// <seealso cref="ConfigurationElement" />
    public class LogWriterElement : ConfigurationElement
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        [ConfigurationProperty(Constants.Sections.LogWriters.Key)]
        public String Key => this[Constants.Sections.LogWriters.Key] as String;

        /// <summary>
        /// Gets the events.
        /// </summary>
        /// <value>
        /// The events.
        /// </value>
        [ConfigurationProperty(Constants.Sections.LogWriters.Events)]
        public String Events => this[Constants.Sections.LogWriters.Events] as String;

        /// <summary>
        /// Gets the assembly.
        /// </summary>
        /// <value>
        /// The assembly.
        /// </value>
        [ConfigurationProperty(Constants.Sections.LogWriters.Assembly)]
        public String Assembly => this[Constants.Sections.LogWriters.Assembly] as String;

        /// <summary>
        /// Gets the type of the logging.
        /// </summary>
        /// <value>
        /// The type of the logging.
        /// </value>
        [ConfigurationProperty(Constants.Sections.LogWriters.LoggingType)]
        public String LoggingType => this[Constants.Sections.LogWriters.LoggingType] as String;
    }
}
