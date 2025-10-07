//-----------------------------------------------------------------------
// <copyright file="TimeZoneProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for TimeZoneProcessTests
    /// </summary>
    [TestFixture]
    public class TimeZoneProcessTests : CommonBusinessProcessTests<ITimeZone, ITimeZoneProcess, ITimeZoneRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 11;
        protected override String ExpectedScreenTitle => "Time Zones";
        protected override String ExpectedStatusBarText => "Number of Time Zones:";

        protected override String ExpectedComboBoxDisplayMember => FDC.TimeZone.Code;

        protected override ITimeZoneRepository CreateRepository()
        {
            ITimeZoneRepository dataAccess = Substitute.For<ITimeZoneRepository>();

            return dataAccess;
        }

        protected override ITimeZoneProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            ITimeZoneProcess process = new TimeZoneProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override ITimeZone CreateBlankEntity(ITimeZoneProcess process, Int32 entityId)
        {
            ITimeZone retVal = new FModels.TimeZone();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ITimeZone CreateEntity(ITimeZoneProcess process, Int32 entityId)
        {
            ITimeZone retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Code = $"Code{entityId:D2}";
            retVal.Description = Guid.NewGuid().ToString();
            retVal.Offset = 12;
            retVal.HasDaylightSavings = true;

            return retVal;
        }

        protected override void CheckBlankEntry(ITimeZone entity)
        {
            Assert.That(entity.Code, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(ITimeZone entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(ITimeZone entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(ITimeZone entity1, ITimeZone entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Code, Is.EqualTo(entity1.Code));
            Assert.That(entity2.Description, Is.EqualTo(entity1.Description));
            Assert.That(entity2.Offset, Is.EqualTo(entity1.Offset));
            Assert.That(entity2.HasDaylightSavings, Is.EqualTo(entity1.HasDaylightSavings));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Code,Description,Time Offset,Has Daylight Savings" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code01,5c3571d7-af01-4881-9ba2-49b14c65a9e6,12,True" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code02,2c1eb5df-f2e1-4a1c-ba11-f5f2f4c99146,12,True" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code03,1e53239f-dcb9-4ecb-b1cf-05a2f5a6d53e,12,True" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code04,d91f4992-60d7-461b-a944-c6d9982bd0c6,12,True" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code05,70b15e4b-273a-4ed0-a7b1-ddc68be4a251,12,True" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code06,10a123aa-02cd-408c-8209-8db7fad5e7f8,12,True" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code07,fccba7f4-c6e7-4605-80e5-386aea0feedb,12,True" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code08,f058372f-c99c-4aea-a2e5-824c653dff20,12,True" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code09,05a962ce-894f-46c5-8f7c-c18e406a3a34,12,True" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code10,de0227b2-528f-44d1-9ed5-53fb6ed80581,12,True" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(ITimeZone entity)
        {
            entity.Code = "Updated";
            entity.Description += "Updated";
            entity.Offset += 10;
            entity.HasDaylightSavings = false;
        }
    }
}
