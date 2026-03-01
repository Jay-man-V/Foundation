//-----------------------------------------------------------------------
// <copyright file="IInvoice.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace JDV.Accounts.Interfaces
{
    /// <summary>
    /// The Invoice model interface
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IInvoice : IAccountsModel
    {
        public DateTime InvoiceDate { get; set; }

        public String Reference { get; set; }

        public EntityId InvoiceStatusId { get; set; }

        public EntityId OrganisationId { get; set; }

        public Boolean Reconciled { get; set; }
    }
}
