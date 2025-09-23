//-----------------------------------------------------------------------
// <copyright file="StatusProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for StatusProcessTests
    /// </summary>
    [TestFixture]
    public class StatusProcessTests : CommonBusinessProcessTests<IStatus, IStatusProcess, IStatusRepository>
    {
        protected override int ColumnDefinitionsCount => 9;
        protected override string ExpectedScreenTitle => "Statuses";
        protected override string ExpectedStatusBarText => "Number of Statuses:";

        protected override string ExpectedComboBoxDisplayMember => FDC.Status.Name;

        protected override IStatusRepository CreateRepository()
        {
            IStatusRepository dataAccess = Substitute.For<IStatusRepository>();

            return dataAccess;
        }

        protected override IStatusProcess CreateBusinessProcess()
        {
            IStatusProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IStatusProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IStatusProcess process = new StatusProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IStatus CreateBlankEntity(IStatusProcess process, Int32 entityId)
        {
            IStatus retVal = CoreInstance.IoC.Get<IStatus>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IStatus CreateEntity(IStatusProcess process, Int32 entityId)
        {
            IStatus retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IStatus entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IStatus entity1, IStatus entity2)
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
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,6a2be7f9-b465-42e8-b68b-d,61ce9018-ed22-4e33-af52-18d410ee2395" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,82eadc44-9d8d-4384-b9d2-4,1cec1d23-3746-426d-9f7c-29a75d17756c" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,13052b75-d123-45d5-95f0-5,6cf66cf4-169f-4b47-a47d-afb3b42c746f" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,84bcbf32-f26e-4e81-b9ea-d,1fa832b0-14f3-48de-81e6-bdf0a8b4da4a" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,b32bf9a4-b3a5-4417-a20a-5,87144fbc-17b2-4bd3-b3ba-db859805637b" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,8b67de6e-757d-4912-a1f4-e,efb2cf01-542e-4547-8d2b-2d92fa633689" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,5b88ad19-c05f-4828-a9f8-d,1728a73c-5265-4e40-9984-391c3c49d171" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,6c30b150-fb1a-48fc-a839-6,2704521e-d8d6-4ff4-8bb0-8ba1289de2d4" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,cd7331fb-c62f-4dc7-95d4-8,45c3cb39-618b-40a0-bfad-f37dc1ac3a34" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,79f2f0d2-4829-4281-ad2f-0,2565a5d6-ba80-4179-ba1b-f10f13438ab8" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IStatus entity)
        {
            entity.Name = "Updated";
            entity.Description += "Updated";
        }
    }
}
