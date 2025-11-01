//-----------------------------------------------------------------------
// <copyright file="EventLogAttachmentProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for EventLogAttachmentProcessTests
    /// </summary>
    [TestFixture]
    public class EventLogAttachmentProcessTests : CommonBusinessProcessTests<IEventLogAttachment, IEventLogAttachmentProcess, IEventLogAttachmentRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 7;
        protected override String ExpectedScreenTitle => "Event Log Attachments";
        protected override String ExpectedStatusBarText => "Number of Event Log Attachments:";

        protected override String ExpectedComboBoxDisplayMember => FDC.EventLogAttachment.AttachmentFileName;

        protected override IEventLogAttachmentRepository CreateRepository()
        {
            IEventLogAttachmentRepository retVal = Substitute.For<IEventLogAttachmentRepository>();

            retVal.HasValidityPeriodColumns.Returns(false);

            return retVal;
        }

        protected override IEventLogAttachmentProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IEventLogAttachmentProcess process = new EventLogAttachmentProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override IEventLogAttachment CreateBlankEntity(Int32 entityId)
        {
            IEventLogAttachment retVal = new FModels.EventLogAttachment();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IEventLogAttachment CreateEntity(IEventLogAttachmentProcess process, Int32 entityId)
        {
            IEventLogAttachment retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.EventLogId = new LogId(1);
            retVal.AttachmentFileName = Guid.NewGuid().ToString();
            retVal.Attachment = Guid.NewGuid().ToByteArray();

            return retVal;
        }

        protected override void CheckBlankEntry(IEventLogAttachment entity)
        {
            Assert.That(entity.AttachmentFileName, Is.EqualTo(String.Empty));
            Assert.That(entity.Attachment, Is.EqualTo(null));
        }

        protected override void CheckAllEntry(IEventLogAttachment entity)
        {
            Assert.That(entity.AttachmentFileName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IEventLogAttachment entity)
        {
            Assert.That(entity.AttachmentFileName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IEventLogAttachment entity1, IEventLogAttachment entity2)
        {
            Assert.That(entity2.EventLogId, Is.EqualTo(entity1.EventLogId));
            Assert.That(entity2.AttachmentFileName, Is.EqualTo(entity1.AttachmentFileName));
            Assert.That(entity2.Attachment, Is.EqualTo(entity1.Attachment));

            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Event Log Id,File Name" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,c2c797eb-e5da-4c33-86e8-7644373b399a" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,62ad8a62-7da5-4b6c-9e16-d5c5013ef261" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,6eb036f1-96cd-42a9-bd98-f0b360ac96cb" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,fc422f1a-393a-43e8-8f73-2d2f283a792e" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,223e0795-483c-42a6-8ddf-da098319ee7d" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,ddfb2b90-f17d-4f34-8964-b661ab1a99ac" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,0b35cbf7-c80a-4469-9101-9fb8d26d9a90" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,b2236814-b73b-450e-98d8-3e4179a55736" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,0562703c-b8e6-45ed-ba09-d769c6843d39" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,1,d72ba80f-a00c-4d9b-bb14-430eb241cd65" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IEventLogAttachment entity)
        {
            entity.EventLogId = new LogId(456);
            entity.AttachmentFileName += "Updated";
            entity.Attachment = Guid.NewGuid().ToByteArray();
        }

        [TestCase]
        public override void Test_Delete_Entity_Id()
        {
            TheRepository!
                .When(da => da.Delete(Arg.Any<EntityId>()))
                .Do(_ => throw new NotImplementedException("Event Log Entries cannot be deleted"));

            NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
            {
                TheProcess!.Delete(new EntityId(1));
            });

            Assert.That(actualException, Is.Not.Null);
        }

        [TestCase]
        public override void Test_Delete_Entity_Object()
        {
            TheRepository!
                .When(da => da.Delete(Arg.Any<IEventLogAttachment>()))
                .Do(_ => throw new NotImplementedException("Event Log Entries cannot be deleted"));

            NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
            {
                IEventLogAttachment entity = Substitute.For<IEventLogAttachment>();
                TheProcess!.Delete(entity);
            });

            Assert.That(actualException, Is.Not.Null);
        }

        [TestCase]
        public override void Test_Delete_MultipleEntities()
        {
            List<IEventLogAttachment> eventLogAttachments = 
            [
                Substitute.For<IEventLogAttachment>(),
                Substitute.For<IEventLogAttachment>(),
            ];

            TheRepository!
                .When(da => da.Delete(Arg.Any<List<IEventLogAttachment>>()))
                .Do(_ => throw new NotImplementedException("Event Log Entries cannot be deleted"));

            NotImplementedException actualException = Assert.Throws<NotImplementedException>(() =>
            {
                TheProcess!.Delete(eventLogAttachments);
            });

            Assert.That(actualException, Is.Not.Null);
        }
    }
}
