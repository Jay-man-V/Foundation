//-----------------------------------------------------------------------
// <copyright file="Department.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Department data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class Department : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The code
            /// </summary>
            public const Int32 Code = 10;

            /// <summary>
            /// The short name
            /// </summary>
            public const Int32 ShortName = 50;

            /// <summary>
            /// The Description
            /// </summary>
            public const Int32 Description = 150;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(Department);

        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public static String Code => "Code";

        /// <summary>
        /// Gets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        public static String ShortName => "ShortName";

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public static String Description => "Description";
    }
}
