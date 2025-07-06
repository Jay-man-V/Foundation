//-----------------------------------------------------------------------
// <copyright file="ILanguage.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Language model interface
    /// </summary>
    public interface ILanguage : IFoundationModel
    {
        /// <summary>Gets or sets the name of the english.</summary>
        /// <value>The name of the english.</value>
        String EnglishName { get; set; }

        /// <summary>Gets or sets the name of the native.</summary>
        /// <value>The name of the native.</value>
        String NativeName { get; set; }

        /// <summary>Gets or sets the culture code.</summary>
        /// <value>The culture code.</value>
        String CultureCode { get; set; }

        /// <summary>Gets or sets the UI culture code.</summary>
        /// <value>The UI culture code.</value>
        String UiCultureCode { get; set; }
    }
}
