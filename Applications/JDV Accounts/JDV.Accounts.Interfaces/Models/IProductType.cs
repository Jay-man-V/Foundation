//-----------------------------------------------------------------------
// <copyright file="IProductType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace JDV.Accounts.Interfaces
{
    /// <summary>
    /// The Product Type model interface
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IProductType : IAccountsModel, IEnumModel
    {
    }
}
