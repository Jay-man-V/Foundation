//-----------------------------------------------------------------------
// <copyright file="NationalRegionProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for NationalRegionProcessTests
    /// </summary>
    [TestFixture]
    public class NationalRegionProcessTests : CommonBusinessProcessTests<INationalRegion, INationalRegionProcess, INationalRegionRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 11;
        protected override String ExpectedScreenTitle => "National Regions";
        protected override String ExpectedStatusBarText => "Number of National Regions:";

        protected override String ExpectedComboBoxDisplayMember => FDC.NationalRegion.ShortName;

        protected override INationalRegionRepository CreateRepository()
        {
            INationalRegionRepository retVal = Substitute.For<INationalRegionRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override INationalRegionProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            ICountryProcess countryProcess = Substitute.For<ICountryProcess>();

            SetProperties(countryProcess);

            INationalRegionProcess process = new NationalRegionProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!, countryProcess);

            return process;
        }

        protected override INationalRegion CreateBlankEntity(Int32 entityId)
        {
            INationalRegion retVal = new FModels.NationalRegion();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override INationalRegion CreateEntity(INationalRegionProcess process, Int32 entityId)
        {
            INationalRegion retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.CountryId = new EntityId(1);
            retVal.Abbreviation = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.FullName = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(INationalRegion entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(INationalRegion entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(INationalRegion entity)
        {
            Assert.That(entity.ShortName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(INationalRegion entity1, INationalRegion entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.CountryId, Is.EqualTo(entity1.CountryId));
            Assert.That(entity2.Abbreviation, Is.EqualTo(entity1.Abbreviation));
            Assert.That(entity2.ShortName, Is.EqualTo(entity1.ShortName));
            Assert.That(entity2.FullName, Is.EqualTo(entity1.FullName));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Country,Abbreviation,Short Name,Full Name" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,f2455319-82a4-4b2d-a51d-ebc4f3e14cc4,b4188198-7638-4653-9d4f-b7ef506c80db,a14aeba1-180e-4739-8d20-75f678942b4e" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,c325052f-3f57-4576-a8d6-35db494b321f,10046382-7fb6-494b-9713-ac3449838254,a69a69d1-ec95-40b6-a8bb-80717c0bab17" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,7efafa74-dcd4-4d83-8a1d-88368e856e20,19c44408-5351-49e4-954e-c8af8625d002,469348f5-e4ee-47f6-9230-555fdb5df850" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,947a9c9b-a9f0-44b4-a909-3133e36eb156,7e9269ce-a429-408a-b954-b692ce3ad8c3,64d45208-8014-4936-b071-956d71f6866c" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,b72d800e-3fda-4edf-84e6-9e3e5256fd9d,eb7faa2b-4de5-4840-a120-337a497edaea,01f921d0-6096-45de-a7a8-10bccbc99096" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,c1a0eb20-332a-4711-bf66-87a04376594f,bc7e1f82-91ba-479d-a5c9-29bc1fbeea16,e0c4a80e-137d-4976-9ea6-f0b06f7b89ca" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,b9ded9f7-4410-4d24-8ee3-ac2af6c3a609,b58aa57b-7010-4ced-b278-ef8c9a544dee,fd373950-2b5c-4ced-92bc-b618e43092b9" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,057f68e5-9104-45b5-a1f2-a98301edd926,7ea2878f-a896-48b7-8e9f-e926f27bb778,6de7470e-5a7d-44e2-88fb-619de5ec9a82" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,0c149ec4-31e4-45e1-80f1-ce8477ca8920,4c4f3d98-20d3-41a3-8a53-5b383df3efc3,e4e8ccff-0d6e-45ef-a573-e042518d1a9b" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,67ab4bc0-0d05-4e67-b0a0-f1a70a1d199a,cfc1a8f8-8ee1-4190-ad3e-f08b8edb2c41,35dc13af-59c7-4a9e-a280-b195979798b8" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(INationalRegion entity)
        {
            entity.Abbreviation += "Updated";
            entity.ShortName += "Updated";
            entity.FullName += "Updated";
        }
    }
}
