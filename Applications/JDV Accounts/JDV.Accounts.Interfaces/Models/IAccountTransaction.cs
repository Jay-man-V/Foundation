//-----------------------------------------------------------------------
// <copyright file="IAccountTransaction.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace JDV.Accounts.Interfaces
{
    /// <summary>
    /// The Account Transaction model interface
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IAccountTransaction : IAccountsModel
    {
        public DateTime TransactionDate { get; set; }

        public String Reference { get; set; }

        public EntityId CategoryId { get; set; }

        public EntityId SubCategory1Id { get; set; }

        public EntityId SubCategory2Id { get; set; }

        public EntityId FromPayeeId { get; set; }

        public EntityId ToPayeeId { get; set; }

        public String Description { get; set; }

        public Decimal Amount { get; set; }

        public EntityId VatRateId { get; set; }

        public Boolean Reconciled { get; set; }

        public Decimal RunningTotal { get; set; }
    }
}
