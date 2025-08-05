//-----------------------------------------------------------------------
// <copyright file="ConfigurationScope.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Configuration Scope data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ConfigurationScope : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The name
            /// </summary>
            public const Int32 Name = 25;

            /// <summary>
            /// The description
            /// </summary>
            public const Int32 Description = 150;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(ConfigurationScope);

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String Name => "Name";

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public static String Description => "Description";

        /// <summary>
        /// Gets the usage sequence.
        /// </summary>
        /// <value>
        /// The usage sequence.
        /// </value>
        public static String UsageSequence => "UsageSequence";
    }
}
