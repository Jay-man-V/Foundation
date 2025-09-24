//-----------------------------------------------------------------------
// <copyright file="ServiceControlWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ServiceProcess;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Mail.Services
{
    [DependencyInjectionTransient]
    internal class ServiceControlWrapper : IServiceControlWrapper
    {
        /// <summary>
        /// 
        /// </summary>
        public ServiceControlWrapper()
        {
            LoggingHelpers.TraceCallEnter();

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceName">The name that identifies the service to the system. This can also be the display name for the service.</param>
        /// <param name="serverName">The computer on which the service resides.</param>
        private ServiceControlWrapper
        (
            String serviceName,
            String serverName
        )
        {
            LoggingHelpers.TraceCallEnter();

            ServiceController = new ServiceController(serviceName, serverName);

            LoggingHelpers.TraceCallReturn();
        }

        private ServiceController? ServiceController { get; set; }

        public void Dispose()
        {
            ServiceController?.Dispose();
            ServiceController = null;
        }

        /// <inheritdoc cref="IServiceControlWrapper.SetupController(String, String)"/>
        public IServiceControlWrapper SetupController(String serviceName, String serverName)
        {
            IServiceControlWrapper retVal = new ServiceControlWrapper(serviceName, serverName);

            return retVal;
        }

        /// <inheritdoc cref="IServiceControlWrapper.Status"/>
        public ServiceControllerStatus Status
        {
            get
            {
                if (ServiceController == null)
                {
                    String errorMessage = $"{nameof(ServiceController)} has not been initialised yet. Please call the routine: '{nameof(SetupController)}'.";
                    throw new ArgumentNullException(errorMessage, nameof(ServiceController));
                }

                return ServiceController.Status;
            }
        }
    }
}
