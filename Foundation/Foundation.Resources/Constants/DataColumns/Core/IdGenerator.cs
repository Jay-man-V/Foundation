//-----------------------------------------------------------------------
// <copyright file="IdGenerator.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Id Generator data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class IdGenerator : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The id name
            /// </summary>
            public const Int32 IdName = 200;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(IdGenerator);

        /// <summary>
        /// Gets the Application Id.
        /// </summary>
        /// <value>
        /// The Application Id.
        /// </value>
        public static String ApplicationId => "ApplicationId";

        /// <summary>
        /// Gets the Configuration Scope Id.
        /// </summary>
        /// <value>
        /// The Configuration Scope Id.
        /// </value>
        public static String ConfigurationScopeId => "ConfigurationScopeId";

        /// <summary>
        /// Gets the id name.
        /// </summary>
        /// <value>
        /// The id name.
        /// </value>
        public static String IdName => "IdName";

        /// <summary>
        /// Gets the Last Id.
        /// </summary>
        /// <value>
        /// The Last Id.
        /// </value>
        public static String LastId => "LastId";

        /// <summary>
        /// Reset On New Date.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        public static String ResetOnNewDate => "ResetOnNewDate";
    }
}
