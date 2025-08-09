//-----------------------------------------------------------------------
// <copyright file="IdService.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.Services.Application
{
    /// <ineritdoc cref="ISequenceGeneratorService" />
    [DependencyInjectionTransient]
    public class SequenceGeneratorService : ISequenceGeneratorService
    {
        /// <summary>
        /// 
        /// </summary>
        public SequenceGeneratorService
        (
            ISequenceGeneratorRepository repository
        )
        {
            LoggingHelpers.TraceCallEnter(repository);

            Repository = repository;

            LoggingHelpers.TraceCallReturn();
        }

        private ISequenceGeneratorRepository Repository { get; }


        /// <inheritdoc cref="ISequenceGeneratorService.GetNextSequence(AppId, IUserProfile, ConfigurationScope, String)" />
        public Int32 GetNextSequence(AppId applicationId, IUserProfile userProfile, ConfigurationScope configurationScope, String sequenceName)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, configurationScope, sequenceName);

            Int32 retVal = Repository.GetNextSequence(applicationId, userProfile, configurationScope, sequenceName);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ISequenceGeneratorService.NewGuid()"/>
        public Guid NewGuid()
        {
            LoggingHelpers.TraceCallEnter();

            Guid retVal = Guid.NewGuid();

            LoggingHelpers.TraceCallEnter(retVal);

            return retVal;
        }
    }
}
