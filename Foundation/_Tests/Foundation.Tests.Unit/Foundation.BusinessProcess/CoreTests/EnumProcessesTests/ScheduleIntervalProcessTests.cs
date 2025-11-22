//-----------------------------------------------------------------------
// <copyright file="ScheduleIntervalProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core.EnumProcesses;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core.EnumModels;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ScheduleIntervalProcessTests
    /// </summary>
    [TestFixture]
    public class ScheduleIntervalProcessTests : CommonBusinessProcessTests<IScheduleInterval, IScheduleIntervalProcess, IScheduleIntervalRepository>
    {
        protected override int ColumnDefinitionsCount => 9;
        protected override string ExpectedScreenTitle => "Scheduled Intervals";
        protected override string ExpectedStatusBarText => "Number of Schedule Intervals:";

        protected override string ExpectedComboBoxDisplayMember => FDC.ScheduleInterval.Name;

        protected override IScheduleIntervalRepository CreateRepository()
        {
            IScheduleIntervalRepository retVal = Substitute.For<IScheduleIntervalRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IScheduleIntervalProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IScheduleIntervalProcess process = new ScheduleIntervalProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override IScheduleInterval CreateBlankEntity(Int32 entityId)
        {
            IScheduleInterval retVal = new FModels.ScheduleInterval();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IScheduleInterval CreateEntity(IScheduleIntervalProcess process, Int32 entityId)
        {
            IScheduleInterval retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IScheduleInterval entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IScheduleInterval entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IScheduleInterval entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IScheduleInterval entity1, IScheduleInterval entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
            Assert.That(entity2.Description, Is.EqualTo(entity1.Description));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Name,Description" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,41d1fa53-e4c8-406b-9b22-a,10a57549-ffd7-42a6-b773-9752f33d905a" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2c79425e-ada2-42c9-a23e-b,624c08fb-23bc-42b0-8b7d-dc9eac5e1677" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,008e2930-703d-4570-a19f-a,0ba360b3-6324-428b-ba39-6d61995905e2" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1940c758-1abc-40b5-8184-b,3ef60fa4-9e24-4745-8c0e-1838be607f12" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,83c70566-5d38-45f7-a1c8-a,3f1e06a4-1962-4994-92af-a4a59179428a" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,4c7fdcd2-612f-41da-97c7-3,9fde1ad5-3474-4f56-902f-0658637e4862" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,44d2ca46-dff1-450a-860a-d,5f85cd48-6df2-405f-a4f0-b94e6ddc3250" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,50bb776e-8302-44b2-9c72-e,6fc2d057-1780-4185-9f30-1ff222109d89" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,0d83f072-e267-4b90-9303-1,a3cbe34b-7263-4b9a-a05e-6e8094038176" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,77e549e6-ec56-47ba-9367-1,bf6ec893-7357-4d64-b705-3080526ffe56" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IScheduleInterval entity)
        {
            entity.Name = "Updated";
            entity.Description += "Updated";
        }
    }
}
