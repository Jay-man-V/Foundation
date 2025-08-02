//-----------------------------------------------------------------------
// <copyright file="IdService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="IIdService" />
    [DependencyInjectionTransient]
    public class IdService : IIdService
    {
        /// <inheritdoc cref="IIdService.NewGuid()"/>
        public Guid NewGuid()
        {
            LoggingHelpers.TraceCallEnter();

            Guid retVal = Guid.NewGuid();

            LoggingHelpers.TraceCallEnter(retVal);

            return retVal;
        }
    }
}
