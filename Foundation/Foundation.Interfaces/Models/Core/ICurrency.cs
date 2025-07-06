//-----------------------------------------------------------------------
// <copyright file="ICurrency.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Currency model interface
    /// Refer to https://en.wikipedia.org/wiki/ISO_4217
    /// </summary>
    public interface ICurrency : IFoundationModel
    {
        /// <summary>Gets or sets a value indicating whether [prefix symbol].</summary>
        /// <value>
        ///   <c>true</c> if [prefix symbol]; otherwise, <c>false</c>.</value>
        Boolean PrefixSymbol { get; set; }

        /// <summary>Gets or sets the symbol.</summary>
        /// <value>The symbol.</value>
        String Symbol { get; set; }

        /// <summary>Gets or sets the iso code.</summary>
        /// <value>The iso code.</value>
        String IsoCode { get; set; }

        /// <summary>Gets or sets the iso number.</summary>
        /// <value>The iso number.</value>
        String IsoNumber { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        String Name { get; set; }

        /// <summary>Gets or sets the number to basic.</summary>
        /// <value>The number to basic.</value>
        Int32 NumberToBasic { get; set; }
    }
}
