//-----------------------------------------------------------------------
// <copyright file="MockFoundationModelRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Repository;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Mocks
{
    public interface IMockFoundationModelRepository : IFoundationModelRepository<IMockFoundationModel>
    {
        /// <summary>
        /// 
        /// </summary>
        IFoundationDataAccess FoundationDataAccess { get; }
    }

    [DependencyInjectionTransient]
    public class MockFoundationModelRepository : FoundationModelRepository<IMockFoundationModel>, IMockFoundationModelRepository
    {
        public MockFoundationModelRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            IFoundationDataAccess foundationDataAccess,
            IUnitTestingDataProvider dataProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                foundationDataAccess,
                dataProvider,
                dateTimeService
            )
        {

        }

        protected override String EntityName => nameof(MockFoundationModel);
        protected override String TableName => nameof(MockFoundationModel);

        /// <inheritdoc cref="IMockFoundationModelRepository.FoundationDataAccess"/>
        public new IFoundationDataAccess FoundationDataAccess => base.FoundationDataAccess;
    }
}
