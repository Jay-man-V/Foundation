//-----------------------------------------------------------------------
// <copyright file="IdGeneratorService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IIdGeneratorService"/>
    [DependencyInjectionTransient]
    public class IdGeneratorService : ServiceBase, IIdGeneratorService
    {
        /// <summary>
        /// 
        /// </summary>
        public IdGeneratorService
        (
            IIdGeneratorRepository repository
        ) : 
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter(repository);

            Repository = repository;

            LoggingHelpers.TraceCallReturn();
        }

        private IIdGeneratorRepository Repository { get; }

        /// <inheritdoc cref="IIdGeneratorService.GetNextId(AppId, IUserProfile, String)" />
        public Int32 GetNextId(AppId applicationId, IUserProfile userProfile, String idName)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, idName);

            Int32 retVal = Repository.GetNextId(applicationId, userProfile, idName);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IIdGeneratorService.NewUniqueIdentifier"/>
        public String NewUniqueIdentifier()
        {
            LoggingHelpers.TraceCallEnter();

            String retVal = Guid.NewGuid().ToString();

            LoggingHelpers.TraceCallEnter(retVal);

            return retVal;
        }
    }
}
