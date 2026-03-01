//-----------------------------------------------------------------------
// <copyright file="ICategoryType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace JDV.Accounts.Interfaces
{
    /// <summary>
    /// The Category Type model interface
    /// </summary>
    [DependencyInjectionIgnore]
    public interface ICategoryType : IAccountsModel, IEnumModel
    {
    }
}
