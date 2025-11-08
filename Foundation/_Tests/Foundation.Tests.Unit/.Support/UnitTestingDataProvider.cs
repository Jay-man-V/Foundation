//-----------------------------------------------------------------------
// <copyright file="UnitTestingDataProvider.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.DataAccess.Database;
using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Support
{
    public interface IUnitTestingDataProvider : IDataProvider
    {

    }

    [DependencyInjectionTransient]
    public class UnitTestingDataProvider : FoundationDataAccess, IUnitTestingDataProvider
    {
        public UnitTestingDataProvider
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService
        ) :
            this
            (
                core,
                systemConfigurationService,
                "UnitTesting"
            )
        {
        }

        public UnitTestingDataProvider
        (
            ICore core,
            ISystemConfigurationService systemConfigurationService,
            String connectionName
        ) :
            base
            (
                core,
                systemConfigurationService,
                connectionName
            )
        {
            ConnectionName = connectionName;
        }

        public String ConnectionName { get; }
    }
}
