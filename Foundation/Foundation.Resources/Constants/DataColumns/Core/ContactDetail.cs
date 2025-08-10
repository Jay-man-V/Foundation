//-----------------------------------------------------------------------
// <copyright file="ContactDetails.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Contact Detail data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ContactDetail : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The short name
            /// </summary>
            public const Int32 ShortName = 50;

            /// <summary>
            /// The display name
            /// </summary>
            public const Int32 DisplayName = 450;

            /// <summary>
            /// The legal name
            /// </summary>
            public const Int32 LegalName = 450;

            /// <summary>
            /// The building name
            /// </summary>
            public const Int32 BuildingName = 250;

            /// <summary>
            /// The street1
            /// </summary>
            public const Int32 Street1 = 250;

            /// <summary>
            /// The street2
            /// </summary>
            public const Int32 Street2 = 250;

            /// <summary>
            /// The town
            /// </summary>
            public const Int32 Town = 250;

            /// <summary>
            /// The county
            /// </summary>
            public const Int32 County = 250;

            /// <summary>
            /// The post code
            /// </summary>
            public const Int32 PostCode = 25;

            /// <summary>
            /// The telephone1
            /// </summary>
            public const Int32 Telephone1 = 50;

            /// <summary>
            /// The telephone2
            /// </summary>
            public const Int32 Telephone2 = 50;

            /// <summary>
            /// The email address
            /// </summary>
            public const Int32 EmailAddress = 320;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(ContactDetail);

        /// <summary>
        /// Gets the parent contact identifier.
        /// </summary>
        /// <value>
        /// The parent contact identifier.
        /// </value>
        public static String ParentContactId => "ParentContactId";

        /// <summary>
        /// Gets the contract identifier.
        /// </summary>
        /// <value>
        /// The contract identifier.
        /// </value>
        public static String ContractId => "ContractId";

        /// <summary>
        /// Gets the contact type identifier.
        /// </summary>
        /// <value>
        /// The contact type identifier.
        /// </value>
        public static String ContactTypeId => "ContactTypeId";

        /// <summary>
        /// Gets the short name.
        /// </summary>
        /// <value>
        /// The short name.
        /// </value>
        public static String ShortName => "ShortName";

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        public static String DisplayName => "DisplayName";

        /// <summary>
        /// Gets the name of the legal.
        /// </summary>
        /// <value>
        /// The name of the legal.
        /// </value>
        public static String LegalName => "LegalName";

        /// <summary>
        /// Gets the name of the building.
        /// </summary>
        /// <value>
        /// The name of the building.
        /// </value>
        public static String BuildingName => "BuildingName";

        /// <summary>
        /// Gets the street1.
        /// </summary>
        /// <value>
        /// The street1.
        /// </value>
        public static String Street1 => "Street1";

        /// <summary>
        /// Gets the street2.
        /// </summary>
        /// <value>
        /// The street2.
        /// </value>
        public static String Street2 => "Street2";

        /// <summary>
        /// Gets the town.
        /// </summary>
        /// <value>
        /// The town.
        /// </value>
        public static String Town => "Town";

        /// <summary>
        /// Gets the county.
        /// </summary>
        /// <value>
        /// The county.
        /// </value>
        public static String County => "County";

        /// <summary>
        /// Gets the post code.
        /// </summary>
        /// <value>
        /// The post code.
        /// </value>
        public static String PostCode => "PostCode";

        /// <summary>
        /// Gets the national region identifier.
        /// </summary>
        /// <value>
        /// The national region identifier.
        /// </value>
        public static String NationalRegionId => "NationalRegionId";

        /// <summary>
        /// Gets the country identifier.
        /// </summary>
        /// <value>
        /// The country identifier.
        /// </value>
        public static String CountryId => "CountryId";

        /// <summary>
        /// Gets the telephone1.
        /// </summary>
        /// <value>
        /// The telephone1.
        /// </value>
        public static String Telephone1 => "Telephone1";

        /// <summary>
        /// Gets the telephone2.
        /// </summary>
        /// <value>
        /// The telephone2.
        /// </value>
        public static String Telephone2 => "Telephone2";

        /// <summary>
        /// Gets the email address.
        /// </summary>
        /// <value>
        /// The email address.
        /// </value>
        public static String EmailAddress => "EmailAddress";
    }
}
