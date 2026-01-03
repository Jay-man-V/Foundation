//-----------------------------------------------------------------------
// <copyright file="IRunTimeEnvironmentSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Run Time Environment Settings
    /// </summary>
    public interface IRunTimeEnvironmentSettings
    {
        /// <summary>
        /// The command line arguments provided to start the application
        /// </summary>
        String[] Arguments { get; }

        /// <summary>
        /// Gets the standard country code - GB
        /// </summary>
        /// <value>
        /// The standard country code.
        /// </value>
        String StandardCountryCode { get; }

        /// <summary>
        /// Gets the Username of the person who is associated with the current thread.
        /// </summary>
        /// <returns></returns>
        String UserName { get; }

        /// <summary>
        /// Gets the network domain name associated with the current user.
        /// </summary>
        String UserDomainName { get; }

        /// <summary>
        /// Gets the users full logon name.
        /// <para>
        /// UserDomainName\Username
        /// </para>
        /// </summary>
        /// <returns></returns>
        String UserFullLogonName { get; }

        /// <summary>
        /// Gets the NetBIOS name of this local computer.
        /// </summary>
        String MachineName { get; }

        /// <summary>
        /// Gets the trace switch for controlling logging output
        /// </summary>
        TraceSwitch TraceSwitch { get; }
    }
}
