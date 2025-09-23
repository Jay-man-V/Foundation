//-----------------------------------------------------------------------
// <copyright file="ScheduledDataStatusProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Log;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.LogTests
{
    /// <summary>
    /// Summary description for ScheduledDataStatusProcessTests
    /// </summary>
    [TestFixture]
    public class ScheduledDataStatusProcessTests : CommonBusinessProcessTests<IScheduledDataStatus, IScheduledDataStatusProcess, IScheduledDataStatusRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 10;
        protected override String ExpectedScreenTitle => "Scheduled Data Statuses";
        protected override String ExpectedStatusBarText => "Number of Scheduled Data Statuses:";

        protected override String ExpectedComboBoxDisplayMember => FDC.ScheduledDataStatus.Name;

        protected override IScheduledDataStatusRepository CreateRepository()
        {
            IScheduledDataStatusRepository dataAccess = Substitute.For<IScheduledDataStatusRepository>();

            return dataAccess;
        }

        protected override IScheduledDataStatusProcess CreateBusinessProcess()
        {
            IScheduledDataStatusProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IScheduledDataStatusProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IDataStatusProcess dataStatusProcess = Substitute.For<IDataStatusProcess>();

            IScheduledDataStatusProcess process = new ScheduledDataStatusProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, dataStatusProcess);

            return process;
        }

        protected override IScheduledDataStatus CreateBlankEntity(IScheduledDataStatusProcess process, Int32 entityId)
        {
            IScheduledDataStatus retVal = CoreInstance.IoC.Get<IScheduledDataStatus>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IScheduledDataStatus CreateEntity(IScheduledDataStatusProcess process, Int32 entityId)
        {
            IScheduledDataStatus retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.DataDate = DateTimeService.SystemDateTimeNow;
            retVal.Name = Guid.NewGuid().ToString();
            retVal.DataStatusId = new EntityId(1);

            return retVal;
        }

        protected override void CheckBlankEntry(IScheduledDataStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IScheduledDataStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IScheduledDataStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IScheduledDataStatus entity1, IScheduledDataStatus entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Data date,Name,Data Status" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2022-11-28T13:11:54.300,69b062c9-fb85-4b9b-80e6-be9c94aa7450,1" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2022-11-28T13:11:54.300,a32b5bba-4dac-423f-94a4-0c15d324538d,1" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2022-11-28T13:11:54.300,2c9a75c7-3b4a-4a09-a6cb-afae858dbde9,1" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2022-11-28T13:11:54.300,83393974-13c2-44bc-9915-0e060f0656f0,1" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2022-11-28T13:11:54.300,be2b78ac-c732-43ec-a685-3b141035e6e6,1" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2022-11-28T13:11:54.300,d9ef0120-7233-4b03-8b95-2b157a97aaf1,1" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2022-11-28T13:11:54.300,d82db5b6-6316-4705-a1b9-c2b3ac6b0236,1" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2022-11-28T13:11:54.300,7019cd58-8e63-42bf-ae5f-69319d122613,1" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2022-11-28T13:11:54.300,33b29c88-0d10-4ab7-aaf0-acb9d4d52cc4,1" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2022-11-28T13:11:54.300,8c157126-a1e9-4e15-8da4-537ae76f1377,1" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IScheduledDataStatus entity)
        {
            entity.Name = "Updated";
        }
    }
}
