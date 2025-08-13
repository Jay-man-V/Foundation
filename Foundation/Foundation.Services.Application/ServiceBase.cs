//-----------------------------------------------------------------------
// <copyright file="ServiceBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

namespace Foundation.Services.Application
{
    /// <summary>
    /// Base class for all Services
    /// </summary>
    public abstract class ServiceBase
    {
        /// <summary>
        /// 
        /// </summary>
        protected ServiceBase
        (
        )
        {
            LoggingHelpers.TraceCallEnter();

            LoggingHelpers.TraceCallReturn();
        }
    }
}
