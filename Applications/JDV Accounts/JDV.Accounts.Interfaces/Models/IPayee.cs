//-----------------------------------------------------------------------
// <copyright file="IPayee.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace JDV.Accounts.Interfaces
{
    /// <summary>
    /// The Payee model interface
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IPayee : IAccountsModel
    {
        /// <summary>
        /// Gets or sets the short, machine-friendly code that uniquely identifies the category.
        /// </summary>
        /// <remarks>
        /// Intended as a concise identifier for lookups, serialization and business rules. Should be short,
        /// unique within its scope and use a stable format (e.g. alphanumeric with optional '-' or '_') — avoid long or user-facing text.
        /// </remarks>
        public String Code { get; set; }

        public String ShortName { get; set; }

        public String LegalName { get; set; }

        public String Description { get; set; }

        public EntityId CategoryTypeId { get; set; }

        public EntityId PayeeTypeId { get; set; }
    }
}
