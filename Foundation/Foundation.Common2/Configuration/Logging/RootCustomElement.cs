//-----------------------------------------------------------------------
// <copyright file="RootCustomElement.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Configuration;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the behaviours for the RootCustomElement
    /// </summary>
    /// <seealso cref="ConfigurationElement" />
    public class RootCustomElement : ConfigurationElement
    {
        /// <summary>
        /// Gets the prefix.
        /// </summary>
        /// <value>
        /// The prefix.
        /// </value>
        [ConfigurationProperty(Constants.Sections.CommonProperties.Prefix)]
        public String Prefix => this[Constants.Sections.CommonProperties.Prefix] as String;
    }
}
