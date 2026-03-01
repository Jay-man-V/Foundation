//-----------------------------------------------------------------------
// <copyright file="IInvoiceStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;

using Foundation.Interfaces;

namespace JDV.Accounts.Interfaces
{
    /// <summary>
    /// The Invoice Status model interface
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IInvoiceStatus : IAccountsModel, IEnumModel
    {
    }
}
