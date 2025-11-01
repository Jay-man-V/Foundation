//-----------------------------------------------------------------------
// <copyright file="MockFoundationProcess2Tests.cs" company="JDV Software Ltd">
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
    public class MockFoundationProcess2Tests : CommonBusinessProcessTests<IMockFoundationModel, IMockFoundationModelProcess2, IMockFoundationModelRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 17;
        protected override String ExpectedScreenTitle => String.Empty;
        protected override String ExpectedStatusBarText => "Number of rows:";

        protected override String ExpectedComboBoxDisplayMember => String.Empty;

        protected override IMockFoundationModelProcess2 CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IMockFoundationModelProcess2 retVal = new MockFoundationModelProcess2(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

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

        protected override IMockFoundationModel CreateEntity(IMockFoundationModelProcess2 process, Int32 entityId)
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
            retVal += "1,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name01,ABC,c5386d83-9e29-4278-8d61-4fea3dfcc5a6,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "2,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name02,ABC,92099dd6-ec3c-4eff-acf6-473fcf3cc525,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "3,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name03,ABC,c13cb9bf-3c31-467a-9eef-aeaece480c5d,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "4,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name04,ABC,3a0c9db0-1793-42d6-b48a-fd698f7aa28f,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "5,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name05,ABC,b2e3b9c8-27db-4b06-9bfd-e2c2bbf26ea7,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "6,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name06,ABC,14db0da5-372b-4b25-bc27-9ab12a01a979,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "7,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name07,ABC,a9c982ef-a7cb-4525-bfd3-2f365a2fd715,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "8,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name08,ABC,8be7a79f-0cf2-4c0a-9048-56abcce36a9b,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "9,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name09,ABC,2b28ccc7-3bd6-4039-89e2-8ab303872428,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;
            retVal += "10,0,0,0001-01-01T00:00:00.000,0,0001-01-01T00:00:00.000,System.Drawing.Bitmap,Name10,ABC,c27c2a6f-6185-4bc9-b3b2-ee0fb77ec05a,1.02:03:04.0050000,147,True,True,456.789,123.456,2025-09-17T19:46:30.000" + Environment.NewLine;

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