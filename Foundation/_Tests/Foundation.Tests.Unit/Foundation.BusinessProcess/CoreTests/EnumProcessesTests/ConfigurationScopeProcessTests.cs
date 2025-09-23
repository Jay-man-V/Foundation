//-----------------------------------------------------------------------
// <copyright file="ConfigurationScopeProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core.EnumProcesses;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ConfigurationScopeProcessTests
    /// </summary>
    [TestFixture]
    public class ConfigurationScopeProcessTests : CommonBusinessProcessTests<IConfigurationScope, IConfigurationScopeProcess, IConfigurationScopeRepository>
    {
        protected override int ColumnDefinitionsCount => 8;
        protected override string ExpectedScreenTitle => "Configuration Scopes";
        protected override string ExpectedStatusBarText => "Number of Configuration Scopes:";

        protected override string ExpectedComboBoxDisplayMember => FDC.ConfigurationScope.Name;

        protected override IConfigurationScopeRepository CreateRepository()
        {
            IConfigurationScopeRepository dataAccess = Substitute.For<IConfigurationScopeRepository>();

            return dataAccess;
        }

        protected override IConfigurationScopeProcess CreateBusinessProcess()
        {
            IConfigurationScopeProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IConfigurationScopeProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IConfigurationScopeProcess process = new ConfigurationScopeProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IConfigurationScope CreateBlankEntity(IConfigurationScopeProcess process, Int32 entityId)
        {
            IConfigurationScope retVal = CoreInstance.IoC.Get<IConfigurationScope>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IConfigurationScope CreateEntity(IConfigurationScopeProcess process, Int32 entityId)
        {
            IConfigurationScope retVal = CreateBlankEntity(process, entityId);

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IConfigurationScope entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IConfigurationScope entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IConfigurationScope entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IConfigurationScope entity1, IConfigurationScope entity2)
        {
            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
            Assert.That(entity2.Description, Is.EqualTo(entity1.Description));
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Name,Description,Usage Sequence" + Environment.NewLine;
            retVal += "1,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,ed4d29c6-8fcb-445f-98a9-9,807408b4-3ebb-4fc1-92e7-db805ab0e15a,0" + Environment.NewLine;
            retVal += "2,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,51ce016a-2b1b-4e89-8a03-e,a84ff591-985f-4ba9-bcd8-998bf3f4fe7c,0" + Environment.NewLine;
            retVal += "3,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,00b0e35f-f487-41c2-b053-c,135e4ee4-2582-4a45-8e1b-90ad6981212d,0" + Environment.NewLine;
            retVal += "4,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,4619926c-29f6-4bbe-9677-3,12ebb9e0-b4a7-4cba-8d96-76cafd5afcae,0" + Environment.NewLine;
            retVal += "5,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,e1f6ae5e-17ed-4971-bd55-1,c5b357e8-e13e-4a3a-a372-3b1f5d9dd443,0" + Environment.NewLine;
            retVal += "6,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,98f5e1d1-5ef9-435e-8640-d,27078857-36b0-40a9-86f9-9db1d26a842b,0" + Environment.NewLine;
            retVal += "7,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,15aba387-5af6-4f49-9098-9,958466ae-a758-465c-ad97-fa2871ed234e,0" + Environment.NewLine;
            retVal += "8,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,ca55b802-9048-4b42-8ceb-0,3af94315-e008-4aa6-ac07-1d14e5781298,0" + Environment.NewLine;
            retVal += "9,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,0d053963-4644-4179-b278-b,9d4dbdec-11d0-4123-b667-4666ffd119e9,0" + Environment.NewLine;
            retVal += "10,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,e5ef9f6f-2409-4860-9bce-0,bcb76fda-0241-4867-b793-9b146975abc7,0" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IConfigurationScope entity)
        {
            entity.Name += "Updated";
            entity.Description += "Updated";
        }
    }
}
