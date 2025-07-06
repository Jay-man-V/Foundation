//-----------------------------------------------------------------------
// <copyright file="Currency.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Currency data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class Currency : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The symbol
            /// </summary>
            public const Int32 Symbol = 5;

            /// <summary>
            /// The iso code
            /// </summary>
            public const Int32 IsoCode = 10;

            /// <summary>
            /// The iso number
            /// </summary>
            public const Int32 IsoNumber = 10;

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
        public static String EntityName => nameof(Currency);

        /// <summary>
        /// Gets the prefix symbol.
        /// </summary>
        /// <value>
        /// The prefix symbol.
        /// </value>
        public static String PrefixSymbol => "PrefixSymbol";

        /// <summary>
        /// Gets the symbol.
        /// </summary>
        /// <value>
        /// The symbol.
        /// </value>
        public static String Symbol => "Symbol";

        /// <summary>
        /// Gets the iso code.
        /// </summary>
        /// <value>
        /// The iso code.
        /// </value>
        public static String IsoCode => "IsoCode";

        /// <summary>
        /// Gets the iso number.
        /// </summary>
        /// <value>
        /// The iso number.
        /// </value>
        public static String IsoNumber => "IsoNumber";

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String Name => "Name";

        /// <summary>
        /// Gets the number to basic.
        /// </summary>
        /// <value>
        /// The number to basic.
        /// </value>
        public static String NumberToBasic => "NumberToBasic";
    }
}
