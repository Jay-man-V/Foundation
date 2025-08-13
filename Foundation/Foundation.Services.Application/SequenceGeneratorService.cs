//-----------------------------------------------------------------------
// <copyright file="SequenceGeneratorService.cs" company="JDV Software Ltd">
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
    /// <seealso cref="ISequenceGeneratorService"/>
    [DependencyInjectionTransient]
    public class SequenceGeneratorService : ServiceBase, ISequenceGeneratorService
    {
        /// <summary>
        /// 
        /// </summary>
        public SequenceGeneratorService
        (
            ISequenceGeneratorRepository repository
        ) : 
            base
            (
            )
        {
            LoggingHelpers.TraceCallEnter(repository);

            Repository = repository;

            LoggingHelpers.TraceCallReturn();
        }

        private ISequenceGeneratorRepository Repository { get; }

        /// <inheritdoc cref="ISequenceGeneratorService.GetNextSequence(AppId, IUserProfile, String)" />
        public Int32 GetNextSequence(AppId applicationId, IUserProfile userProfile, String sequenceName)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, sequenceName);

            Int32 retVal = Repository.GetNextSequence(applicationId, userProfile, sequenceName);

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
