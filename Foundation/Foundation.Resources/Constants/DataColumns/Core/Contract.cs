//-----------------------------------------------------------------------
// <copyright file="Contract.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Contract data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class Contract : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The contract reference
            /// </summary>
            public const Int32 ContractReference = 100;

            /// <summary>
            /// The short name
            /// </summary>
            public const Int32 ShortName = 50;

            /// <summary>
            /// The full name
            /// </summary>
            public const Int32 FullName = 250;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(Contract);

        /// <summary>
        /// Gets the contract type identifier.
        /// </summary>
        /// <value>
        /// The contract type identifier.
        /// </value>
        public static String ContractTypeId => "ContractTypeId";

        /// <summary>
        /// Gets the contract reference.
        /// </summary>
        /// <value>
        /// The contract reference.
        /// </value>
        public static String ContractReference => "ContractReference";

        /// <summary>
        /// Gets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        public static String ShortName => "ShortName";

        /// <summary>
        /// Gets the full name.
        /// </summary>
        /// <value>
        /// The full name.
        /// </value>
        public static String FullName => "FullName";

        /// <summary>
        /// Gets the start date.
        /// </summary>
        /// <value>
        /// The start date.
        /// </value>
        public static String StartDate => "StartDate";

        /// <summary>
        /// Gets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public static String EndDate => "EndDate";
    }
}
