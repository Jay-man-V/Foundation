//-----------------------------------------------------------------------
// <copyright file="EventLogApplicationProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Log;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Log;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.LogTests
{
    /// <summary>
    /// Summary description for EventLogApplicationProcessTests
    /// </summary>
    [TestFixture]
    public class EventLogApplicationProcessTests : CommonBusinessProcessTests<IEventLogApplication, IEventLogApplicationProcess, IEventLogApplicationRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 10;
        protected override String ExpectedScreenTitle => "Event Log Applications";
        protected override String ExpectedStatusBarText => "Number of Event Log Applications:";

        protected override String ExpectedComboBoxDisplayMember => FDC.EventLogApplication.ShortName;

        protected override IEventLogApplicationRepository CreateRepository()
        {
            IEventLogApplicationRepository dataAccess = Substitute.For<IEventLogApplicationRepository>();

            return dataAccess;
        }

        protected override IEventLogApplicationProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            //IApplicationRepository applicationRepository = Substitute.For<IApplicationRepository>();
            //IApplicationProcess applicationProcess = new ApplicationProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, applicationRepository, StatusRepository!, UserProfileRepository!);
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();

            IEventLogApplicationProcess process = new EventLogApplicationProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, applicationProcess);

            return process;
        }

        protected override IEventLogApplication CreateBlankEntity(IEventLogApplicationProcess process, Int32 entityId)
        {
            IEventLogApplication retVal = new FModels.EventLogApplication();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IEventLogApplication CreateEntity(IEventLogApplicationProcess process, Int32 entityId)
        {
            IEventLogApplication retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.ProcessName = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IEventLogApplication entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(String.Empty));
            Assert.That(entity.ProcessName, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IEventLogApplication entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IEventLogApplication entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IEventLogApplication entity1, IEventLogApplication entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ShortName, Is.EqualTo(entity1.ShortName));
            Assert.That(entity2.ProcessName, Is.EqualTo(entity1.ProcessName));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Application,Short Name,Process Name" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,f2df2be3-1fde-4ff7-9133-b065910a5f99,0aee86a9-df33-4fc0-a925-d6b8a350cbc3" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,94e54a51-efba-4375-bd8f-79bd6cd54e05,217191e6-0d03-4f95-a2af-b37ea5004b83" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,c4ed2535-c78c-49dc-9223-a3cc146d3030,faadca60-ee0a-430a-acc1-d1602e53101f" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,71729a17-ccb2-4053-805b-b683c64d35c5,c3f32dcb-7ccf-477e-beec-001042d5a21f" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,638d9368-5dde-48a2-bcf3-cf863d1733cf,61b6db4c-b3f9-4605-b51c-8b5a3306bf8f" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,815df72b-d3cd-477c-9100-c17310430be4,b9fb997f-ad21-44cf-aa2b-53f9da71100d" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,ae1aece4-9c8a-4da9-84ab-25aa0a9ee289,9d926831-6f4f-4402-938a-77e5611d1342" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,26913183-d3a4-45da-9e44-d0a869fc7fc9,ae8be0a6-5b91-4964-aaf9-56f1cda40380" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,db5bd390-0a43-4dfb-b8f6-7f38d0955f5d,9f10bcda-3bc0-4985-aef5-f7c52d54337a" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,851198fa-946d-4798-a9e5-fcef1b717091,efa4fe4b-bf2a-4cf8-b29a-e30ed51089f1" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IEventLogApplication entity)
        {
            entity.ShortName += "Updated";
            entity.ProcessName += "Updated";
        }
    }
}
