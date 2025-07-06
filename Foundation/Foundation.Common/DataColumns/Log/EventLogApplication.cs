//-----------------------------------------------------------------------
// <copyright file{ get { return "EventLogApplication.cs" company{ get { return "JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Event Log Application data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public class EventLogApplication : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public class Lengths
        {
            /// <summary>
            /// The short name
            /// </summary>
            public const Int32 ShortName = 250;

            /// <summary>
            /// The process name
            /// </summary>
            public const Int32 ProcessName = 250;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "EventLogApplication";

        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public static String ApplicationId => "ApplicationId";

        /// <summary>
        /// Gets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        public static String ShortName => "ShortName";

        /// <summary>
        /// Gets the name of the process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public static String ProcessName => "ProcessName";
    }
}
