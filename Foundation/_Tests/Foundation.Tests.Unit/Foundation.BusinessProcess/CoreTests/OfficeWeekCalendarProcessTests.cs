//-----------------------------------------------------------------------
// <copyright file="OfficeWeekCalendarProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for OfficeWeekCalendarProcessTests
    /// </summary>
    [TestFixture]
    public class OfficeWeekCalendarProcessTests : CommonBusinessProcessTests<IOfficeWeekCalendar, IOfficeWeekCalendarProcess, IOfficeWeekCalendarRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 16;
        protected override String ExpectedScreenTitle => "Office Week Calendars";
        protected override String ExpectedStatusBarText => "Number of Office Week Calendars:";

        protected override String ExpectedComboBoxDisplayMember => FDC.OfficeWeekCalendar.ShortName;

        protected override IOfficeWeekCalendarRepository CreateRepository()
        {
            IOfficeWeekCalendarRepository retVal = Substitute.For<IOfficeWeekCalendarRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IOfficeWeekCalendarProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IOfficeWeekCalendarProcess process = new OfficeWeekCalendarProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IOfficeWeekCalendar CreateBlankEntity(Int32 entityId)
        {
            IOfficeWeekCalendar retVal = new FModels.OfficeWeekCalendar();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IOfficeWeekCalendar CreateEntity(IOfficeWeekCalendarProcess process, Int32 entityId)
        {
            IOfficeWeekCalendar retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Code = $"Code{entityId:D6}";
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.Mon = true;
            retVal.Tue = true;
            retVal.Wed = true;
            retVal.Thu = true;
            retVal.Fri = true;
            retVal.Sat = true;
            retVal.Sun = true;

            return retVal;
        }

        protected override void CheckBlankEntry(IOfficeWeekCalendar entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IOfficeWeekCalendar entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IOfficeWeekCalendar entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IOfficeWeekCalendar entity1, IOfficeWeekCalendar entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Code, Is.EqualTo(entity1.Code));
            Assert.That(entity2.ShortName, Is.EqualTo(entity1.ShortName));
            Assert.That(entity2.Mon, Is.EqualTo(entity1.Mon));
            Assert.That(entity2.Tue, Is.EqualTo(entity1.Tue));
            Assert.That(entity2.Wed, Is.EqualTo(entity1.Wed));
            Assert.That(entity2.Thu, Is.EqualTo(entity1.Thu));
            Assert.That(entity2.Fri, Is.EqualTo(entity1.Fri));
            Assert.That(entity2.Sat, Is.EqualTo(entity1.Sat));
            Assert.That(entity2.Sun, Is.EqualTo(entity1.Sun));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Code,Short name,Mon,Tue,Wed,Thu,Fri,Sat,Sun" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000001,09b03bbe-70e4-4233-84d3-425b40d978d8,True,True,True,True,True,True,True" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000002,c5b253ec-ac2c-4060-80db-6fb435a4019a,True,True,True,True,True,True,True" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000003,be5f095b-d155-4f58-8b9e-bf992c2462cc,True,True,True,True,True,True,True" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000004,308bc8e7-b6a2-4055-ba8b-871161cd5225,True,True,True,True,True,True,True" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000005,41e9cccc-2519-43e9-836e-856d4a600217,True,True,True,True,True,True,True" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000006,f922c8f0-b7f9-42ac-a160-e8909021513b,True,True,True,True,True,True,True" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000007,e36381fb-b0f2-4486-ad24-f39097fc6b17,True,True,True,True,True,True,True" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000008,63572f68-0423-4b52-a3c2-8bd5dd51310c,True,True,True,True,True,True,True" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000009,69d16f2b-874a-44de-9390-b9246b761b33,True,True,True,True,True,True,True" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000010,c4f9f0a6-64fd-449e-b6ea-fb6442d3ca8a,True,True,True,True,True,True,True" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IOfficeWeekCalendar entity)
        {
            entity.Code += "Updated";
            entity.ShortName += "Updated";
            entity.Mon = true;
            entity.Tue = false;
            entity.Wed = true;
            entity.Thu = false;
            entity.Fri = true;
            entity.Sat = false;
            entity.Sun = true;
        }
    }
}
