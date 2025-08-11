//-----------------------------------------------------------------------
// <copyright file="ServiceBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="ISequenceGeneratorService" />
    [DependencyInjectionTransient]
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
