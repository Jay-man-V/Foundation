//-----------------------------------------------------------------------
// <copyright file="IFoundationBulkLoader.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the IFoundationBulkLoader behaviours
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IFoundationBulkLoader
    {
        /// <summary>
        /// Executes a bulk data load operation based on the provided settings.
        /// </summary>
        /// <param name="bulkDataLoadSettings"></param>
        void BulkDataLoad(IBulkDataLoadSettings bulkDataLoadSettings);
    }
}
