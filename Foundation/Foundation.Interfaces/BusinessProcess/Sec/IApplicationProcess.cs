//-----------------------------------------------------------------------
// <copyright file="IApplicationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Application Process
    /// </summary>
    public interface IApplicationProcess : ICommonBusinessProcess<IApplication>
    {
        /// <inheritdoc cref="ICommonBusinessProcess.NullId"/>
        new AppId NullId { get; }

        /// <inheritdoc cref="ICommonBusinessProcess.AllId"/>
        new AppId AllId { get; }

        /// <inheritdoc cref="ICommonBusinessProcess.NoneId"/>
        new AppId NoneId { get; }

        /// <summary>
        /// Deletes the application from the data store
        /// </summary>
        /// <param name="applicationId">The id of the application to be deleted</param>
        void Delete(AppId applicationId);

        /// <summary>
        /// Loads the application from the data store
        /// </summary>
        /// <param name="applicationId">The Id of the application to be loaded</param>
        IApplication? Get(AppId applicationId);
    }
}
