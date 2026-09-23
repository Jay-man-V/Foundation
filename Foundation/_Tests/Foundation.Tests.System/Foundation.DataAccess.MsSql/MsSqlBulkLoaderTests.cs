//-----------------------------------------------------------------------
// <copyright file="MsSqlBulkLoaderTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Diagnostics;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.System.BaseClasses;
using Foundation.Tests.Unit.Foundation.DataAccess.Database.Support;

namespace Foundation.Tests.System.Foundation.DataAccess.MsSql
{
    /// <summary>
    /// System Tests for BulkLoaderTests
    /// </summary>
    [TestFixture]
    public class MsSqlBulkLoaderTests : SystemTestBase
    {
        private String ClassName => LocationUtils.GetClassName();
        private IMsSqlBulkLoader? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = CoreInstance.IoC.Get<IMsSqlBulkLoader>();
        }

        public override void TestCleanup()
        {
            base.TestCleanup();
        }

        protected override List<IApplicationConfiguration> GetTestApplicationConfigurations()
        {
            List<IApplicationConfiguration> retVal = base.GetTestApplicationConfigurations();

            IApplicationConfiguration applicationConfiguration;

            applicationConfiguration = GetExistingOrCreateNewApplicationConfiguration($"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailSubject", EmailSubject);
            retVal.Add(applicationConfiguration);

            applicationConfiguration = GetExistingOrCreateNewApplicationConfiguration($"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailToAddresses", EmailToAddress);
            retVal.Add(applicationConfiguration);

            applicationConfiguration = GetExistingOrCreateNewApplicationConfiguration($"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailCcAddresses", EmailCcAddress);
            retVal.Add(applicationConfiguration);

            applicationConfiguration = GetExistingOrCreateNewApplicationConfiguration($"{ClassName}.{BatchName}.{ProcessName}.{TaskName}.EmailFromAddresses", EmailFromAddress);
            retVal.Add(applicationConfiguration);

            return retVal;
        }

        [TestCase]
        public void Test_BulkDataLoad()
        {
            // Setup
            String functionName = LocationUtils.GetFunctionName();

            Int32 requiredRowCount = 1_000_000;
            Int32 requiredColumnCount = 10;
            String dataFile = $@"D:\Data - {functionName}.txt";

            IComplexTestEntityRepository complexTestEntityRepository = CoreInstance.IoC.Get<IComplexTestEntityRepository>();
            CreateFileWithData(requiredRowCount, requiredColumnCount, dataFile);

            // Act
            ExecutionTimer executionTimer = new ExecutionTimer("Test_BulkDataLoad");
            complexTestEntityRepository.BulkLoadData(dataFile, requiredColumnCount);
            executionTimer.StopTimer();
            Debug.WriteLine($"Duration: {executionTimer.Duration}");
        }
    }
}
