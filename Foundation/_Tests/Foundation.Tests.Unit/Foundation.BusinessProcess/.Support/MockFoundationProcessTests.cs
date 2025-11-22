//-----------------------------------------------------------------------
// <copyright file="MockFoundationProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.Drawing;

using NSubstitute;

using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;
using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.Support
{
    [TestFixture]
    public class MockFoundationProcessTests : CommonBusinessProcessTests<IMockFoundationModel, IMockFoundationModelProcess, IMockFoundationModelRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 17;
        protected override String ExpectedScreenTitle => String.Empty;
        protected override String ExpectedStatusBarText => "Number of rows:";

        protected override string ExpectedComboBoxDisplayMember => "Made up property name";

        protected override IMockFoundationModelProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IMockFoundationModelProcess retVal = new MockFoundationModelProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return retVal;
        }

        protected override IMockFoundationModelRepository CreateRepository()
        {
            IMockFoundationModelRepository retVal = Substitute.For<IMockFoundationModelRepository>();

            return retVal;
        }

        protected override IMockFoundationModel CreateBlankEntity(Int32 entityId)
        {
            IMockFoundationModel retVal = new MockFoundationModel();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IMockFoundationModel CreateEntity(IMockFoundationModelProcess process, Int32 entityId)
        {
            IMockFoundationModel retVal = CreateBlankEntity(entityId);

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.IsOpen = true;
            retVal.IsClosed = true;
            retVal.UnitPrice = 123.456m;
            retVal.Quantity = 456.789m;
            retVal.Count = 147;
            retVal.Name = $"Name{entityId:D2}";
            retVal.Code = "ABC";
            retVal.Description = Guid.NewGuid().ToString();
            retVal.ImagePicture = new Bitmap(10, 10);
            retVal.Duration = new TimeSpan(1, 2, 3, 4, 5);
            retVal.ExecutionTime = new DateTime(2025, 09, 17, 19, 46, 30);

            return retVal;
        }

        protected override void UpdateEntityProperties(IMockFoundationModel entity)
        {
            entity.IsOpen = !entity.IsOpen;
            entity.IsClosed = !entity.IsClosed;
            entity.UnitPrice += 123.456m;
            entity.Quantity += 456.789m;
            entity.Count += 147;
            entity.Name += "Updated";
            entity.Code += "DEF";
            entity.Description += "Updated";
            entity.ImagePicture = new Bitmap(5, 4);
            entity.Duration = new TimeSpan(5, 4, 3, 2, 1);
            entity.ExecutionTime = new DateTime(2025, 01, 02, 03, 04, 05);
        }

        protected override void CheckBlankEntry(IMockFoundationModel entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IMockFoundationModel entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IMockFoundationModel entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IMockFoundationModel entity1, IMockFoundationModel entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.IsOpen, Is.EqualTo(entity1.IsOpen));
            Assert.That(entity2.IsClosed, Is.EqualTo(entity1.IsClosed));
            Assert.That(entity2.UnitPrice, Is.EqualTo(entity1.UnitPrice));
            Assert.That(entity2.Quantity, Is.EqualTo(entity1.Quantity));
            Assert.That(entity2.Count, Is.EqualTo(entity1.Count));
            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
            Assert.That(entity2.Code, Is.EqualTo(entity1.Code));
            Assert.That(entity2.Description, Is.EqualTo(entity1.Description));
            Assert.That(entity2.ImagePicture, Is.EqualTo(entity1.ImagePicture));
            Assert.That(entity2.Duration, Is.EqualTo(entity1.Duration));
            Assert.That(entity2.ExecutionTime, Is.EqualTo(entity1.ExecutionTime));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Status,Created By,Created On,Updated By,Updated On,Profile Picture,Name,Code,Description,Duration,Count,Is Closed,Is Open,Quantity,Unit Price,Execution Time" + Environment.NewLine;
            retVal += "1,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name01,ABC,e9b66186-c540-47ed-b929-0497b57c0cd7,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "2,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name02,ABC,914f58e9-d556-47a3-8381-6609296760fc,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "3,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name03,ABC,3a752dae-dd7b-4343-9985-b445cdb45909,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "4,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name04,ABC,9d9a8ce1-c443-47a0-94af-092b7400a7a5,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "5,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name05,ABC,b55f2caa-061b-43d0-a475-652e94652ec3,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "6,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name06,ABC,5baf568d-6470-4e93-a2fc-96ab27e09b32,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "7,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name07,ABC,345cdced-5332-4864-8f1f-a56fd6e618de,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "8,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name08,ABC,04d642f4-8ca8-4da8-9ec6-49fd9246584d,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "9,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name09,ABC,d4777e64-3899-4b47-abb7-a6446d58e354,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "10,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name10,ABC,b4e9969c-a856-41a4-9a75-f7419b2da28e,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;

            return retVal;
        }

        [TestCase]
        public void Test_ValidateEntity()
        {
            IMockFoundationModel mockFoundationModel = CreateEntity(TheProcess!, 1);

            mockFoundationModel.Code = String.Empty;

            AggregateException actualException = Assert.Throws<AggregateException>(() =>
            {
                TheProcess!.ValidateEntity(mockFoundationModel);
            });

            Assert.That(actualException.InnerExceptions.Count, Is.EqualTo(1));
            Assert.That(actualException.InnerExceptions[0], Is.TypeOf<ValidationException>());

            ValidationException validationException = (ValidationException)actualException.InnerExceptions[0];
            Assert.That(validationException.Message, Is.EqualTo($"{nameof(IMockFoundationModel.Code)} must be provided"));
        }
    }
}