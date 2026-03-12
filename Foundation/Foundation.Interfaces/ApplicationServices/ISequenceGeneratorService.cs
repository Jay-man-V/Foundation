//-----------------------------------------------------------------------
// <copyright file="ISequenceGeneratorService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Id Generator Service
    /// </summary>
    public interface ISequenceGeneratorService
    {
        /// <summary>
        /// Gets the next value for a id
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="sequenceName">Name of the sequence.</param>
        /// <returns></returns>
        Int32 GetNextId(AppId applicationId, IUserProfile userProfile, String sequenceName);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        String NewUniqueIdentifier();
    }
}
