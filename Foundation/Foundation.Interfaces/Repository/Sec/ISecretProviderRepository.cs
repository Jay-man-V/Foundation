//-----------------------------------------------------------------------
// <copyright file="ISecretProviderService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces.Repository.Sec
{
    /// <summary>
    /// Defines the behaviour of the Secret Provider Repository
    /// </summary>
    public interface ISecretProviderRepository
    {
        /// <summary>
        /// Retrieves a secret by its name and application code
        /// </summary>
        /// <param name="applicationCode"></param>
        /// <param name="secretName"></param>
        /// <returns></returns>
        String GetSecret(String applicationCode, String secretName);
    }
}
