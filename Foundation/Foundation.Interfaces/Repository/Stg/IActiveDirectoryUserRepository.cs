//-----------------------------------------------------------------------
// <copyright file="IActiveDirectoryUserRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Generic;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Active Directory User Data Access interface
    /// </summary>
    public interface IActiveDirectoryUserRepository : IFoundationModelRepository<IActiveDirectoryUser>
    {
        /// <summary>
        /// Gets all active directory users.
        /// </summary>
        /// <returns>
        /// </returns>
        List<IActiveDirectoryUser> GetAllActiveDirectoryUsers();
    }
}
