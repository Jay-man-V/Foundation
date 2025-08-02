//-----------------------------------------------------------------------
// <copyright file="CompanyDetails.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

namespace Foundation.Resources
{
    /// <summary>
    /// Defines the Company Details as static members to allow them to be accessed
    /// from all places
    /// </summary>
    public partial class CompanyDetails
    {
        /// <summary>
        /// Head Office details
        /// </summary>
        public class HeadOffice
        {
            /// <summary>
            /// Gets the contact telephone.
            /// </summary>
            /// <value>
            /// The contact telephone.
            /// </value>
            public static String ContactTelephone => "+44 (0) 7466 489 027";

            /// <summary>
            /// Gets the Postal/Legal/Registered address.
            /// </summary>
            /// <value>
            /// The address.
            /// </value>
            public static String Address
            {
                get
                {
                    StringBuilder retVal = new();

                    retVal.AppendLine("56 Buckingham Road");
                    retVal.AppendLine("Edgware");
                    retVal.AppendLine("Middlesex");
                    retVal.AppendLine("HA8 6LZ");

                    return retVal.ToString();
                }
            }

            /// <summary>
            /// Same as <see cref="Address"/> but with the addition of the Country
            /// </summary>
            /// <value>
            /// The address with country.
            /// </value>
            public static String AddressWithCountry
            {
                get
                {
                    StringBuilder retVal = new(Address);

                    retVal.AppendLine("England");

                    return retVal.ToString();
                }
            }

            /// <summary>
            /// 
            /// </summary>


            /// <summary>
            /// Gets the What3Words location of the office.
            /// https://what3words.com/
            /// </summary>
            /// <value>
            /// The what three words.
            /// </value>
            public static String WhatThreeWords => "tones.civic.vine";

            /// <summary>
            /// Gets the Latitude/Longitude location of the office.
            /// </summary>
            /// <value>
            /// The Latitude/Longitude coordinates.
            /// </value>
            public static String LatitudeLongitudeCoordinates => "51.60774,-0.28391";
        }
    }
}
