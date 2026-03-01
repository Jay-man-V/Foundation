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
        protected override int ColumnDefinitionsCount => 10;
        protected override string ExpectedScreenTitle => "Scheduled Intervals";
        protected override string ExpectedStatusBarText => "Number of Schedule Intervals:";

        protected override string ExpectedComboBoxDisplayMember => FDC.ScheduleInterval.Code;

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

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortDescription = Guid.NewGuid().ToString();
            retVal.LongDescription = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IScheduleInterval entity)
        {
            Assert.That(entity.Code, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IScheduleInterval entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IScheduleInterval entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IScheduleInterval entity1, IScheduleInterval entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Code, Is.EqualTo(entity1.Code));
            Assert.That(entity2.ShortDescription, Is.EqualTo(entity1.ShortDescription));
            Assert.That(entity2.LongDescription, Is.EqualTo(entity1.LongDescription));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Code,Short Description,Long Description" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,41d1fa53-e,10a57549-ffd7-42a6-b773-9752f33d905a,10a57549-ffd7-42a6-b773-9752f33d905a" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,2c79425e-a,624c08fb-23bc-42b0-8b7d-dc9eac5e1677,624c08fb-23bc-42b0-8b7d-dc9eac5e1677" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,008e2930-7,0ba360b3-6324-428b-ba39-6d61995905e2,0ba360b3-6324-428b-ba39-6d61995905e2" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1940c758-1,3ef60fa4-9e24-4745-8c0e-1838be607f12,3ef60fa4-9e24-4745-8c0e-1838be607f12" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,83c70566-5,3f1e06a4-1962-4994-92af-a4a59179428a,3f1e06a4-1962-4994-92af-a4a59179428a" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,4c7fdcd2-6,9fde1ad5-3474-4f56-902f-0658637e4862,9fde1ad5-3474-4f56-902f-0658637e4862" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,44d2ca46-d,5f85cd48-6df2-405f-a4f0-b94e6ddc3250,5f85cd48-6df2-405f-a4f0-b94e6ddc3250" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,50bb776e-8,6fc2d057-1780-4185-9f30-1ff222109d89,6fc2d057-1780-4185-9f30-1ff222109d89" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,0d83f072-e,a3cbe34b-7263-4b9a-a05e-6e8094038176,a3cbe34b-7263-4b9a-a05e-6e8094038176" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,77e549e6-e,bf6ec893-7357-4d64-b705-3080526ffe56,bf6ec893-7357-4d64-b705-3080526ffe56" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IScheduleInterval entity)
        {
            entity.Code = "Code Updated";
            entity.ShortDescription += "Short Updated";
            entity.LongDescription += "Long Updated";
        }
    }
}
