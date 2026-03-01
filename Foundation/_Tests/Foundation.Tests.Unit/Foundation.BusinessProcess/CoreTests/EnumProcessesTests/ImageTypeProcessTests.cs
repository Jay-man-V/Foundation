//-----------------------------------------------------------------------
// <copyright file="ImageTypeProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Core.EnumProcesses;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core.EnumModels;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ImageTypeProcessTests
    /// </summary>
    [TestFixture]
    public class ImageTypeProcessTests : CommonBusinessProcessTests<IImageType, IImageTypeProcess, IImageTypeRepository>
    {
        protected override int ColumnDefinitionsCount => 11;
        protected override string ExpectedScreenTitle => "Image Types";
        protected override string ExpectedStatusBarText => "Number of Image Types:";

        protected override string ExpectedComboBoxDisplayMember => FDC.ImageType.Code;

        protected override IImageTypeRepository CreateRepository()
        {
            IImageTypeRepository retVal = Substitute.For<IImageTypeRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override IImageTypeProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IImageTypeProcess process = new ImageTypeProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!);

            return process;
        }

        protected override IImageType CreateBlankEntity(Int32 entityId)
        {
            IImageType retVal = new FModels.ImageType();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IImageType CreateEntity(IImageTypeProcess process, Int32 entityId)
        {
            IImageType retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortDescription = Guid.NewGuid().ToString();
            retVal.LongDescription = Guid.NewGuid().ToString();
            retVal.FileExtension = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(IImageType entity)
        {
            Assert.That(entity.Code, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(IImageType entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(IImageType entity)
        {
            Assert.That(entity.Code, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(IImageType entity1, IImageType entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Code, Is.EqualTo(entity1.Code));
            Assert.That(entity2.ShortDescription, Is.EqualTo(entity1.ShortDescription));
            Assert.That(entity2.LongDescription, Is.EqualTo(entity1.LongDescription));
            Assert.That(entity2.FileExtension, Is.EqualTo(entity1.FileExtension));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Code,Short Description,Long Description,File Extensions" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,99b94ca0-f,56956be4-e216-4bfd-824d-2111d26ae5b5,56956be4-e216-4bfd-824d-2111d26ae5b5,56956be4-e216-4bfd-824d-2111d26ae5b5" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,22a15057-0,40e733ce-0bf3-4b8e-9aa5-6ae00202d85e,40e733ce-0bf3-4b8e-9aa5-6ae00202d85e,40e733ce-0bf3-4b8e-9aa5-6ae00202d85e" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,3dcfb238-d,61c15017-ab66-4bb4-9c1f-88df36b76003,61c15017-ab66-4bb4-9c1f-88df36b76003,61c15017-ab66-4bb4-9c1f-88df36b76003" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,ab7ef33b-5,3dbf80ff-92a5-4a46-ad2f-df1025a6bfd8,3dbf80ff-92a5-4a46-ad2f-df1025a6bfd8,3dbf80ff-92a5-4a46-ad2f-df1025a6bfd8" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,c1ca1a6f-0,13547d47-095d-4e69-bdbc-0551982411f,13547d47-095d-4e69-bdbc-0551982411f,13547d47-095d-4e69-bdbc-0551982411f" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,f3749304-c,ca6d885f-7194-4b27-a129-d8182d659430,ca6d885f-7194-4b27-a129-d8182d659430,ca6d885f-7194-4b27-a129-d8182d659430" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1a0350cf-b,9b07cf43-894f-445c-9c7b-e2b4146af92c,9b07cf43-894f-445c-9c7b-e2b4146af92c,9b07cf43-894f-445c-9c7b-e2b4146af92c" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,d274bcdc-7,fc81c3a7-d542-46d0-9663-6db6862c6fba,fc81c3a7-d542-46d0-9663-6db6862c6fba,fc81c3a7-d542-46d0-9663-6db6862c6fba" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,5a0353b8-4,b8645084-3f78-41e0-8c33-a63f6eab1d22,b8645084-3f78-41e0-8c33-a63f6eab1d22,b8645084-3f78-41e0-8c33-a63f6eab1d22" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,654495a4-d,e76f7eee-955c-429c-826a-1acb139dd4ba,e76f7eee-955c-429c-826a-1acb139dd4ba,e76f7eee-955c-429c-826a-1acb139dd4ba" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(IImageType entity)
        {
            entity.Code += "Code Updated";
            entity.ShortDescription += "Short Updated";
            entity.LongDescription += "Long Updated";
            entity.FileExtension += "File Extension Updated";
        }
    }
}
