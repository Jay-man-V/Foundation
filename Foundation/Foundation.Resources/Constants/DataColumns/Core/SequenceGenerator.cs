//-----------------------------------------------------------------------
// <copyright file="SequenceGenerator.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Sequence Generator data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class SequenceGenerator : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The sequence name
            /// </summary>
            public const Int32 SequenceName = 200;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(SequenceGenerator);

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
        /// Gets the sequence name.
        /// </summary>
        /// <value>
        /// The sequence name.
        /// </value>
        public static String SequenceName => "SequenceName";

        /// <summary>
        /// Gets the Last Sequence.
        /// </summary>
        /// <value>
        /// The Last Sequence.
        /// </value>
        public static String LastSequence => "LastSequence";

        /// <summary>
        /// Reset On New Date.
        /// </summary>
        /// <value>
        /// 
        /// </value>
        public static String ResetOnNewDate => "ResetOnNewDate";
    }
}
