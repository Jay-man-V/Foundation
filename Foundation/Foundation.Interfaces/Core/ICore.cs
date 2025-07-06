//-----------------------------------------------------------------------
// <copyright file="ICore.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICore
    {
        /// <summary>
        /// 
        /// </summary>
        AppId ApplicationId { get; }

        /// <summary>
        /// 
        /// </summary>
        Boolean Initialised { get; }

        /// <summary>
        /// 
        /// </summary>
        IIoC Container { get; }

        /// <summary>
        /// 
        /// </summary>
        ICore TheInstance { get; }

        /// <summary>
        /// 
        /// </summary>
        ICurrentLoggedOnUser CurrentLoggedOnUser { get; }

        // TODO - Future development for Cache and Crypto
        // ICache Cache { get; }

        // ICrypto Crypto { get; }
    }
}
