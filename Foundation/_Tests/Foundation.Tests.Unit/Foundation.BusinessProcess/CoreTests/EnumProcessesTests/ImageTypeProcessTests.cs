//-----------------------------------------------------------------------
// <copyright file="ImageTypeProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ImageTypeProcessTests
    /// </summary>
    [TestFixture]
    public class ImageTypeProcessTests : CommonBusinessProcessTests<IImageType, IImageTypeProcess, IImageTypeRepository>
    {
        protected override int ColumnDefinitionsCount => 9;
        protected override string ExpectedScreenTitle => "Image Types";
        protected override string ExpectedStatusBarText => "Number of Image Types:";

        protected override string ExpectedComboBoxDisplayMember => FDC.ImageType.Name;

        protected override IImageTypeRepository CreateRepository()
        {
            IImageTypeRepository dataAccess = Substitute.For<IImageTypeRepository>();

            return dataAccess;
        }

        protected override IImageTypeProcess CreateBusinessProcess()
        {
            IImageTypeProcess process = CreateBusinessProcess(DateTimeService);

            return process;
        }

        protected override IImageTypeProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IImageTypeProcess process = new ImageTypeProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!);

            return process;
        }

        protected override IImageType CreateBlankEntity(IImageTypeProcess process, Int32 entityId)
        {
            IImageType retVal = CoreInstance.IoC.Get<IImageType>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IImageType CreateEntity(IImageTypeProcess process, Int32 entityId)
        {
            IImageType retVal = CreateBlankEntity(process, entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.FileExtension = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IImageType entity)
        {
            Assert.That(entity.Name, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IImageType entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IImageType entity)
        {
            Assert.That(entity.Name, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IImageType entity1, IImageType entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Name, Is.EqualTo(entity1.Name));
            Assert.That(entity2.FileExtension, Is.EqualTo(entity1.FileExtension));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Name,File Extensions" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,99b94ca0-f880-43a6-9d9a-c347f03d9c94,56956be4-e216-4bfd-824d-2111d26ae5b5" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,22a15057-04fb-422c-b397-1ee374fd2c18,40e733ce-0bf3-4b8e-9aa5-6ae00202d85e" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,3dcfb238-defe-4812-8772-9c4df6532871,61c15017-ab66-4bb4-9c1f-88df36b76003" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,ab7ef33b-52a7-4f34-88d9-009ce1e5568d,3dbf80ff-92a5-4a46-ad2f-df1025a6bfd8" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,c1ca1a6f-0d60-45a3-a839-120caf38b0b4,13547d47-095d-4e69-bdbc-0551982411f" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,f3749304-c54a-49d6-af7c-fdffd4c7f4e4,ca6d885f-7194-4b27-a129-d8182d659430" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1a0350cf-b94f-455a-9596-c2b5ff1d0e97,9b07cf43-894f-445c-9c7b-e2b4146af92c" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,d274bcdc-7cf8-4007-b3d0-b9383f87855c,fc81c3a7-d542-46d0-9663-6db6862c6fba" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,5a0353b8-46ec-48bf-96e4-746120c2a80e,b8645084-3f78-41e0-8c33-a63f6eab1d22" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,654495a4-df8b-426c-a0a5-1a0edf186c6b,e76f7eee-955c-429c-826a-1acb139dd4ba" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IImageType entity)
        {
            entity.Name += "Updated";
            entity.FileExtension += "Updated";
        }
    }
}
