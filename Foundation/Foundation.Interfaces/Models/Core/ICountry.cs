//-----------------------------------------------------------------------
// <copyright file="ICountry.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Country model interface
    /// </summary>
    public interface ICountry : IFoundationModel
    {
        /// <summary>Gets or sets the iso code.</summary>
        /// <value>The iso code.</value>
        String IsoCode { get; set; }

        /// <summary>Gets or sets the name of the abbreviated.</summary>
        /// <value>The name of the abbreviated.</value>
        String AbbreviatedName { get; set; }

        /// <summary>Gets or sets the full name.</summary>
        /// <value>The full name.</value>
        String FullName { get; set; }

        /// <summary>Gets or sets the name of the native.</summary>
        /// <value>The name of the native.</value>
        String NativeName { get; set; }

        /// <summary>Gets or sets the dialing code.</summary>
        /// <value>The dialing code.</value>
        String DialingCode { get; set; }

        /// <summary>Gets or sets the post code format.</summary>
        /// <value>The post code format.</value>
        String PostCodeFormat { get; set; }

        /// <summary>Gets or sets the currency identifier.</summary>
        /// <value>The currency identifier.</value>
        EntityId CurrencyId { get; set; }

        /// <summary>Gets or sets the language identifier.</summary>
        /// <value>The language identifier.</value>
        EntityId LanguageId { get; set; }

        /// <summary>Gets or sets the time zone identifier.</summary>
        /// <value>The time zone identifier.</value>
        EntityId TimeZoneId { get; set; }

        /// <summary>Gets or sets the world region identifier.</summary>
        /// <value>The world region identifier.</value>
        EntityId WorldRegionId { get; set; }

        /// <summary>Gets or sets the country flag.</summary>
        /// <value>The country flag.</value>
        Byte[]? CountryFlag { get; set; }
    }
}
