//-----------------------------------------------------------------------
// <copyright file="IContactDetail.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Contact model interface
    /// </summary>
    public interface IContactDetail : IFoundationModel
    {
        /// <summary>Gets or sets the parent contact identifier.</summary>
        /// <value>The parent contact identifier.</value>
        EntityId ParentContactId { get; set; }

        /// <summary>Gets or sets the contract identifier.</summary>
        /// <value>The contract identifier.</value>
        EntityId ContractId { get; set; }

        /// <summary>Gets or sets the contact type identifier.</summary>
        /// <value>The contact type identifier.</value>
        EntityId ContactTypeId { get; set; }

        /// <summary>Gets or sets the national region identifier.</summary>
        /// <value>The national region identifier.</value>
        EntityId NationalRegionId { get; set; }

        /// <summary>Gets or sets the country identifier.</summary>
        /// <value>The country identifier.</value>
        EntityId CountryId { get; set; }

        /// <summary>Gets or sets the short name.</summary>
        /// <value>The short name.</value>
        String ShortName { get; set; }

        /// <summary>Gets or sets the display name.</summary>
        /// <value>The display name.</value>
        String DisplayName { get; set; }

        /// <summary>Gets or sets the name of the legal.</summary>
        /// <value>The name of the legal.</value>
        String LegalName { get; set; }

        /// <summary>Gets or sets the name of the building.</summary>
        /// <value>The name of the building.</value>
        String BuildingName { get; set; }

        /// <summary>Gets or sets the street1.</summary>
        /// <value>The street1.</value>
        String Street1 { get; set; }

        /// <summary>Gets or sets the street2.</summary>
        /// <value>The street2.</value>
        String Street2 { get; set; }

        /// <summary>Gets or sets the town.</summary>
        /// <value>The town.</value>
        String Town { get; set; }

        /// <summary>Gets or sets the county.</summary>
        /// <value>The county.</value>
        String County { get; set; }

        /// <summary>Gets or sets the post code.</summary>
        /// <value>The post code.</value>
        String PostCode { get; set; }

        /// <summary>Gets or sets the telephone1.</summary>
        /// <value>The telephone1.</value>
        String Telephone1 { get; set; }

        /// <summary>Gets or sets the telephone2.</summary>
        /// <value>The telephone2.</value>
        String Telephone2 { get; set; }

        /// <summary>Gets or sets the email address.</summary>
        /// <value>The email address.</value>
        EmailAddress EmailAddress { get; set; }
    }
}
