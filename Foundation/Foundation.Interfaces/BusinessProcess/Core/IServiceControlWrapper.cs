//-----------------------------------------------------------------------
// <copyright file="IServiceControlWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ServiceProcess;

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IServiceControlWrapper : IDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceName">The name that identifies the service to the system. This can also be the display name for the service.</param>
        /// <param name="serverName">The computer on which the service resides.</param>
        IServiceControlWrapper SetupController(String serviceName, String serverName);

        /// <summary>
        /// 
        /// </summary>
        ServiceControllerStatus Status { get; }
    }
}
