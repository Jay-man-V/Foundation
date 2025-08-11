//-----------------------------------------------------------------------
// <copyright file="ISequenceGeneratorRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Sequence Generator Data Access interface
    /// </summary>
    public interface ISequenceGeneratorRepository : IFoundationModelRepository<ISequenceGenerator>
    {
        /// <summary>
        /// Gets the next value for a sequence
        /// </summary>
        /// <param name="applicationId">The application id.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="sequenceName">Name of the sequence.</param>
        /// <returns></returns>
        Int32 GetNextSequence(AppId applicationId, IUserProfile userProfile, String sequenceName);
    }
}
