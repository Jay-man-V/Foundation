//-----------------------------------------------------------------------
// <copyright file="ConfigurationScope.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Configuration Scope data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ConfigurationScope : EnumModel
    {
        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public static String EntityName => nameof(ConfigurationScope);

        /// <summary>
        /// Gets the usage sequence.
        /// </summary>
        /// <value>
        /// The usage sequence.
        /// </value>
        public static String UsageSequence => "UsageSequence";
    }
}
