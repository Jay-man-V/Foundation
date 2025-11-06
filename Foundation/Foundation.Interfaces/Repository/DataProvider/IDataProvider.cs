//-----------------------------------------------------------------------
// <copyright file="IDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the IDataProvider behaviours.
    /// Defines requirements
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IDataProvider
    {
        /// <summary>
        /// The name of the connection to be used
        /// </summary>
        String ConnectionName { get; }
    }
}
