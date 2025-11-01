//-----------------------------------------------------------------------
// <copyright file="LogSeverityProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Log.EnumProcesses;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Log.EnumModels;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.LogTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for LogSeverityProcessTests
    /// </summary>
    [TestFixture]
    public class LogSeverityProcessTests : CommonBusinessProcessTests<ILogSeverity, ILogSeverityProcess, ILogSeverityRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 9;
        protected override String ExpectedScreenTitle => "Log Severities";
        protected override String ExpectedStatusBarText => "Number of Log Severities:";

        protected override String ExpectedComboBoxDisplayMember => FDC.LogSeverity.Code;

        protected override ILogSeverityRepository CreateRepository()
        {
            ILogSeverityRepository retVal = Substitute.For<ILogSeverityRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override ILogSeverityProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            ILogSeverityProcess process = new LogSeverityProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override ILogSeverity CreateBlankEntity(Int32 entityId)
        {
            ILogSeverity retVal = new FModels.LogSeverity();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ILogSeverity CreateEntity(ILogSeverityProcess process, Int32 entityId)
        {
            ILogSeverity retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Code = entityId.ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(ILogSeverity entity)
        {
            Assert.That(entity.Code, Is.EqualTo(String.Empty));
            Assert.That(entity.Description, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(ILogSeverity entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(ILogSeverity entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(ILogSeverity entity1, ILogSeverity entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Code, Is.EqualTo(entity1.Code));
            Assert.That(entity2.Description, Is.EqualTo(entity1.Description));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Code,Description" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,d44be6f7-d84b-4a4a-8153-32de45d690ea" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2,60b07eea-6719-4c8a-94d6-c61e49b07215" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,3,a311fe16-135b-4191-a582-bbd0b9c55a4a" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,4,8b6e9196-d69d-470e-99de-0f219b973c10" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,5,09cc916f-306c-4dde-b70f-51e9aa3533b0" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,6,61b0c810-f6b0-421e-a7d2-386d9f360cf6" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,7,4eca1c2e-e5f5-4e22-b5ab-48f7b3020de4" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,8,87708108-cb93-4cb7-801c-09065cf37781" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,9,6e138540-399d-41cf-a6cc-7eeb91835b8d" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,10,0459729c-7204-4578-a08c-e553f30aea8c" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(ILogSeverity entity)
        {
            entity.Code += "Updated";
            entity.Description += "Updated";
        }
    }
}
