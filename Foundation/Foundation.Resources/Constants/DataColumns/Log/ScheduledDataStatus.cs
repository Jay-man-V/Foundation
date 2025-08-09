//-----------------------------------------------------------------------
// <copyright file="ScheduledDataStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.DataColumns
{
    /// <summary>
    /// Scheduled Task data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ScheduledDataStatus : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The name
            /// </summary>
            public const Int32 Name = 150;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(ScheduledDataStatus);

        /// <summary>
        /// Gets the data date.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String DataDate => "DataDate";

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String Name => "Name";

        /// <summary>
        /// Gets the data status identifier.
        /// </summary>
        /// <value>
        /// The data status identifier.
        /// </value>
        public static String DataStatusId => "DataStatusId";
    }
}
