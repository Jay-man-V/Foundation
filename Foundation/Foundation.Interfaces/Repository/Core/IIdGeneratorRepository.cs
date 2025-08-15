//-----------------------------------------------------------------------
// <copyright file="IIdGeneratorRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Id Generator Repository interface
    /// </summary>
    public interface IIdGeneratorRepository : IFoundationModelRepository<IIdGenerator>
    {
        /// <summary>
        /// Gets the next value for a id
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="idName">Name of the id.</param>
        /// <returns></returns>
        Int32 GetNextId(AppId applicationId, IUserProfile userProfile, String idName);
    }
}
