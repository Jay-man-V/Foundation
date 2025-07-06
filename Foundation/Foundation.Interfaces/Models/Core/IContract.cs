//-----------------------------------------------------------------------
// <copyright file="IContract.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Contract model interface
    /// </summary>
    public interface IContract : IFoundationModel
    {
        /// <summary>Gets or sets the contract type identifier.</summary>
        /// <value>The contract type identifier.</value>
        EntityId ContractTypeId { get; set; }

        /// <summary>Gets or sets the contract reference.</summary>
        /// <value>The contract reference.</value>
        String ContractReference { get; set; }

        /// <summary>Gets or sets the short name.</summary>
        /// <value>The short name.</value>
        String ShortName { get; set; }

        /// <summary>Gets or sets the full name.</summary>
        /// <value>The full name.</value>
        String FullName { get; set; }

        /// <summary>Gets or sets the start date.</summary>
        /// <value>The start date.</value>
        DateTime StartDate { get; set; }

        /// <summary>Gets or sets the end date.</summary>
        /// <value>The end date.</value>
        DateTime EndDate { get; set; }
    }
}
