//-----------------------------------------------------------------------
// <copyright file="IApplicationShutDown.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The IApplicationShutDown interface is for special cases only.
    /// Classes that implement it will be created as normal.
    /// The implementation should be reserved for Singleton classes that need to be run as soon as possible when the application shuts down
    /// The calling or shutdown sequence cannot be set, it will be random
    /// </summary>
    public interface IApplicationShutDown
    {
        /// <summary>
        /// Method will be called once on application shutdown
        /// </summary>
        void ApplicationShuttingDown();
    }
}
