//-----------------------------------------------------------------------
// <copyright file="ICore.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICore
    {
        /// <summary>
        /// Gets the Application Name.
        /// </summary>
        /// <value>
        /// The Application Name.
        /// </value>
        String ApplicationName { get; }

        /// <summary>
        /// Gets the Application Id Number.
        /// </summary>
        /// <value>
        /// The Application Id Number.
        /// </value>
        AppId ApplicationId { get; }

        /// <summary>
        /// Gets the Trace Level.
        /// </summary>
        /// <value>
        /// The Trace Level.
        /// </value>
        TraceLevel TraceLevel { get; }

        /// <summary>
        /// 
        /// </summary>
        IIoC IoC { get; }

        /// <summary>
        /// The .Net configuration manager
        /// </summary>
        IConfigurationWrapper ConfigurationManager { get; }

        /// <summary>
        /// 
        /// </summary>
        ICore Instance { get; }

        /// <summary>
        /// 
        /// </summary>
        ICurrentUser CurrentLoggedOnUser { get; }

        /// <summary>
        /// 
        /// </summary>
        ISharedVariables SharedVariables { get; }

        /// <summary>
        /// 
        /// </summary>
        ICache Cache { get; }

        /// <summary>
        /// 
        /// </summary>
        ICrypto Crypto { get; }
    }
}
