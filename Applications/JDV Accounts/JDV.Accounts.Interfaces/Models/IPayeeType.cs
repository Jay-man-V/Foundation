//-----------------------------------------------------------------------
// <copyright file="IPayeeType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace JDV.Accounts.Interfaces
{
    /// <summary>
    /// The Payee Type model interface
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IPayeeType : IAccountsModel, IEnumModel
    {
    }
}
