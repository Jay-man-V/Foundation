//-----------------------------------------------------------------------
// <copyright file="OfficeProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for OfficeProcessTests
    /// </summary>
    [TestFixture]
    public class OfficeProcessTests : CommonBusinessProcessTests<IOffice, IOfficeProcess, IOfficeRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 11;
        protected override String ExpectedScreenTitle => "Offices";
        protected override String ExpectedStatusBarText => "Number of Offices:";

        protected override String ExpectedComboBoxDisplayMember => FDC.Office.ShortName;

        protected override IOfficeRepository CreateRepository()
        {
            IOfficeRepository dataAccess = Substitute.For<IOfficeRepository>();

            return dataAccess;
        }

        protected override IOfficeProcess CreateBusinessProcess()
        {
            IOfficeProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IOfficeProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IOfficeProcess process = new OfficeProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IOffice CreateBlankEntity(IOfficeProcess process, Int32 entityId)
        {
            IOffice retVal = CoreInstance.IoC.Get<IOffice>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IOffice CreateEntity(IOfficeProcess process, Int32 entityId)
        {
            IOffice retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Code = $"Code{entityId:D6}";
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.ContactDetailId = new EntityId(1);
            retVal.OfficeWeekCalendarId = new EntityId(1);

            return retVal;
        }

        protected override void CheckBlankEntry(IOffice entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IOffice entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IOffice entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IOffice entity1, IOffice entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Code, Is.EqualTo(entity1.Code));
            Assert.That(entity2.ShortName, Is.EqualTo(entity1.ShortName));
            Assert.That(entity2.ContactDetailId, Is.EqualTo(entity1.ContactDetailId));
            Assert.That(entity2.OfficeWeekCalendarId, Is.EqualTo(entity1.OfficeWeekCalendarId));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Code,Short name,Contact detail Id,Office Week Calendar Id" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000001,2555e62a-2090-4ed2-ba51-3a071fb3aaef,1,1" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000002,57b2df0f-bdea-4f8a-8715-eb856521147d,1,1" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000003,ff422a54-8e23-49be-8e80-0cf764d89dd9,1,1" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000004,5e3cad88-733f-4482-8b8a-9579b5e93915,1,1" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000005,c6bdbbdb-9960-4859-ba20-4f2858de5d17,1,1" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000006,6f94187d-6590-404e-ab52-05639cf41808,1,1" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000007,61c13b4d-72b7-4d87-b22f-d69613c2a80e,1,1" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000008,504c3ee0-cbd2-4ac6-ae1e-2e2f93160491,1,1" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000009,36cdcff6-ec3b-46ea-84e8-079bf3e0c767,1,1" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,Code000010,f100bce9-31a9-4d77-b23b-3b52996eb9ba,1,1" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IOffice entity)
        {
            entity.Code = "Updated";
            entity.ShortName += "Updated";
        }
    }
}
