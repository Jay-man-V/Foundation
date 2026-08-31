//-----------------------------------------------------------------------
// <copyright file="SecretProviderServer.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Repository.Sec;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="ISecretProviderService" />
    [DependencyInjectionTransient]
    public class SecretProviderService : ServiceBase, ISecretProviderService
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="SecretProviderService"/> class.
        /// </summary>
        /// <param name="core"></param>
        /// <param name="secretProviderRepository"></param>
        public SecretProviderService
        (
            ICore core,
            ISecretProviderRepository secretProviderRepository
        ) :
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter(core);

            Core = core;
            SecretProviderRepository = secretProviderRepository;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
        private ISecretProviderRepository SecretProviderRepository { get; }

        /// <inheritdoc cref="ISecretProviderService.GetSecret(String, String)"/>
        public String GetSecret(String applicationCode, String secretName)
        {
            LoggingHelpers.TraceCallEnter(applicationCode, secretName);

            String retVal = SecretProviderRepository.GetSecret(applicationCode, secretName);

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }
    }
}
