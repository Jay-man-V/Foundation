//-----------------------------------------------------------------------
// <copyright file="ApplicationConfiguration.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.DataColumns
{
    /// <summary>
    /// Application Configuration data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ApplicationConfiguration : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The key
            /// </summary>
            public const Int32 Key = 250;

            /// <summary>
            /// The value
            /// </summary>
            public const Int32 Value = Int32.MaxValue;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(ApplicationConfiguration);

        /// <summary>
        /// Gets the application id.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String ApplicationId => "ApplicationId";

        /// <summary>
        /// Gets the configuration scope id.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String ConfigurationScopeId => "ConfigurationScopeId";

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public static String Key => "Key";

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public static String Value => "Value";
    }
}
