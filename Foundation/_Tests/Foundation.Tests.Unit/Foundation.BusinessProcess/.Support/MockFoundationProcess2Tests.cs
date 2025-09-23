//-----------------------------------------------------------------------
// <copyright file="MockFoundationProcess2Tests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.Drawing;

using NSubstitute;

using Foundation.Interfaces;

using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.Support
{
    [TestFixture]
    public class MockFoundationProcess2Tests : CommonBusinessProcessTests<IMockFoundationModel, IMockFoundationModelProcess2, IMockFoundationModelRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 19;
        protected override String ExpectedScreenTitle => String.Empty;
        protected override String ExpectedStatusBarText => "Number of rows:";

        protected override String ExpectedComboBoxDisplayMember => String.Empty;

        protected override IMockFoundationModelProcess2 CreateBusinessProcess()
        {
            IMockFoundationModelProcess2 retVal = CreateBusinessProcess(DateTimeService);

            return retVal;
        }

        protected override IMockFoundationModelProcess2 CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();

            CopyProperties(applicationProcess, CoreInstance.IoC.Get<IApplicationProcess>());

            IMockFoundationModelProcess2 retVal = new MockFoundationModelProcess2(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return retVal;
        }

        protected override IMockFoundationModelRepository CreateRepository()
        {
            IMockFoundationModelRepository retVal = Substitute.For<IMockFoundationModelRepository>();

            return retVal;
        }

        protected override IMockFoundationModel CreateBlankEntity(IMockFoundationModelProcess2 process, Int32 entityId)
        {
            IMockFoundationModel retVal = CoreInstance.IoC.Get<IMockFoundationModel>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IMockFoundationModel CreateEntity(IMockFoundationModelProcess2 process, Int32 entityId)
        {
            IMockFoundationModel retVal = CreateBlankEntity(process, entityId);

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
            retVal += "Id,Status,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Profile Picture,Name,Code,Description,Duration,Count,Is Closed,Is Open,Quantity,Unit Price,Execution Time" + Environment.NewLine;
            retVal += "1,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Drawing.Bitmap,Name01,ABC,3ba35e54-a292-42d9-bd5e-07a7dd33a139,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "2,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Drawing.Bitmap,Name02,ABC,15e61c19-0457-4823-ab2d-d90c4f80bdf4,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "3,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Drawing.Bitmap,Name03,ABC,801d46f5-16e3-407e-8b97-c1c4e5427d3d,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "4,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Drawing.Bitmap,Name04,ABC,f1eba42d-f95a-48d7-a937-ff768edc6fad,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "5,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Drawing.Bitmap,Name05,ABC,6c7de580-e7f5-4b9f-91a7-388760d8475f,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "6,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Drawing.Bitmap,Name06,ABC,b4c9ca5a-4d13-4d7c-8d68-4b0344a12143,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "7,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Drawing.Bitmap,Name07,ABC,2f5bf570-a52a-467f-86b9-7e3d9671771d,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "8,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Drawing.Bitmap,Name08,ABC,13da0b76-a74f-4e11-8895-e6a8e334d26d,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "9,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Drawing.Bitmap,Name09,ABC,f417460f-dbcc-4aa6-8fb4-bec86b31bee9,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "10,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Drawing.Bitmap,Name10,ABC,bdcf3ad5-5d8f-4834-82eb-74451bd6cd22,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;

            return retVal;
        }

        [TestCase]
        public void Test_ValidateEntity()
        {
            IMockFoundationModelProcess2 process = CreateBusinessProcess();
            IMockFoundationModel mockFoundationModel = CreateEntity(process, 1);

            mockFoundationModel.Code = String.Empty;

            AggregateException actualException = Assert.Throws<AggregateException>(() =>
            {
                process.ValidateEntity(mockFoundationModel);
            });

            Assert.That(actualException.InnerExceptions.Count, Is.EqualTo(1));
            Assert.That(actualException.InnerExceptions[0], Is.TypeOf<ValidationException>());

            ValidationException validationException = (ValidationException)actualException.InnerExceptions[0];
            Assert.That(validationException.Message, Is.EqualTo($"{nameof(IMockFoundationModel.Code)} must be provided"));
        }
    }
}