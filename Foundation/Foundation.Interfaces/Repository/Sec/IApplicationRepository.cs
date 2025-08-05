//-----------------------------------------------------------------------
// <copyright file="IApplicationRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Application Data Access interface
    /// </summary>
    public interface IApplicationRepository : IFoundationModelRepository<IApplication>
    {
        /// <summary>
        /// Deletes the entity with the <paramref name="applicationId"/>
        /// </summary>
        /// <param name="applicationId">The entity id.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="applicationId"/> is null</exception>
        void Delete(AppId applicationId);

        /// <summary>
        /// Gets the specified application.
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <returns>Loaded application</returns>
        IApplication Get(AppId applicationId);
    }
}
