//-----------------------------------------------------------------------
// <copyright file="ImportExportControl.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Import Export Control data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public class ImportExportControl : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public class Lengths
        {
            /// <summary>
            /// The short name
            /// </summary>
            public const Int32 Name = 150;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => "ImportExportControl";

        /// <summary>
        /// Gets the processed on.
        /// </summary>
        /// <value>
        /// The processed on.
        /// </value>
        public static String ProcessedOn => "ProcessedOn";

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String Name => "Name";

        /// <summary>
        /// Gets the in progress.
        /// </summary>
        /// <value>
        /// The in progress.
        /// </value>
        public static String InProgress => "InProgress";
    }
}
