//-----------------------------------------------------------------------
// <copyright file="CompanyDetails.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Drawing;

namespace Foundation.Resources
{
    /// <summary>
    /// Defines the Company Details as static members to allow them to be accessed
    /// from all places
    /// </summary>
    public partial class CompanyDetails
    {
        /// <summary>
        /// Gets the name - JDV Software Ltd
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String Name => "JDV Software Ltd";

        /// <summary>
        /// Gets the registered number.
        /// </summary>
        /// <value>
        /// The registered number.
        /// </value>
        public static String RegisteredNumber => String.Empty;

        /// <summary>
        /// Gets the Vat Number.
        /// </summary>
        /// <value>
        /// The vat number.
        /// </value>
        public static String VatNumber => String.Empty;

        /// <summary>
        /// Gets the website address.
        /// </summary>
        /// <value>
        /// The website.
        /// </value>
        public static String WebSite => "http://www.jdvsoftware.co.uk";

        /// <summary>
        /// Gets the company logo.
        /// </summary>
        /// <value>
        /// The company logo.
        /// </value>
        public static Image CompanyLogo
        {
            get
            {
                Image retVal = ResourceLoader.GetResourceImage(ResourceNames.Logos.CompanyLogo);

                return retVal;
            }
        }
    }
}
