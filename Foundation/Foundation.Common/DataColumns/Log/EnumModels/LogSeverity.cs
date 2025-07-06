//-----------------------------------------------------------------------
// <copyright file{ get { return "LogSeverity.cs" company{ get { return "JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Log Severity data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public class LogSeverity : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public class Lengths
        {
            /// <summary>
            /// The code
            /// </summary>
            public const Int32 Code = 10;

            /// <summary>
            /// The description
            /// </summary>
            public const Int32 Description = 250;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "LogSeverity";

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public static String Code => "Code";

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public static String Description => "Description";
    }
}
