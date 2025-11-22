//-----------------------------------------------------------------------
// <copyright file="CountryProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Tests.Unit.Support;

using Foundation.BusinessProcess.Core;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Core;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.CoreTests
{
    /// <summary>
    /// Summary description for CountryProcessTests
    /// </summary>
    [TestFixture]
    [DeploymentItem(@".Support\SampleDocuments\United Kingdom.png", @".Support\SampleDocuments\")]
    public class CountryProcessTests : CommonBusinessProcessTests<ICountry, ICountryProcess, ICountryRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 18;
        protected override String ExpectedScreenTitle => "Countries";
        protected override String ExpectedStatusBarText => "Number of Countries:";

        protected override string ExpectedComboBoxDisplayMember => FDC.Country.AbbreviatedName;

        protected override ICountryRepository CreateRepository()
        {
            ICountryRepository retVal = Substitute.For<ICountryRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override ICountryProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            ICurrencyProcess currencyProcess = Substitute.For<ICurrencyProcess>();
            ILanguageProcess languageProcess = Substitute.For<ILanguageProcess>();
            ITimeZoneProcess timeZoneProcess = Substitute.For<ITimeZoneProcess>();
            IWorldRegionProcess worldRegionProcess = Substitute.For<IWorldRegionProcess>();

            SetProperties(currencyProcess);
            SetProperties(languageProcess);
            SetProperties(timeZoneProcess);
            SetProperties(worldRegionProcess);

            ICountryProcess process = new CountryProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!,  ReportGenerator!, currencyProcess, languageProcess, timeZoneProcess, worldRegionProcess);

            return process;
        }

        protected override ICountry CreateBlankEntity(Int32 entityId)
        {
            ICountry retVal = new FModels.Country();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ICountry CreateEntity(ICountryProcess process, Int32 entityId)
        {
            ICountry retVal = CreateBlankEntity(entityId);

            IFileApi fileApi = Substitute.For<IFileApi>();

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.IsoCode = $"IsoCode{entityId:D3}";
            retVal.AbbreviatedName = Guid.NewGuid().ToString();
            retVal.FullName = Guid.NewGuid().ToString();
            retVal.NativeName = Guid.NewGuid().ToString();
            retVal.DialingCode = $"Dialing{entityId:D3}";
            retVal.PostCodeFormat = Guid.NewGuid().ToString();
            retVal.CurrencyId = new EntityId(1);
            retVal.LanguageId = new EntityId(1);
            retVal.TimeZoneId = new EntityId(1);
            retVal.WorldRegionId = new EntityId(1);
            retVal.CountryFlag = fileApi.GetFileContentsAsByteArray(@".Support\SampleDocuments\United Kingdom.png");

            return retVal;
        }

        protected override void CheckBlankEntry(ICountry entity)
        {
            Assert.That(entity.AbbreviatedName, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(ICountry entity)
        {
            Assert.That(entity.AbbreviatedName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(ICountry entity)
        {
            Assert.That(entity.AbbreviatedName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(ICountry entity1, ICountry entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.IsoCode, Is.EqualTo(entity1.IsoCode));
            Assert.That(entity2.AbbreviatedName, Is.EqualTo(entity1.AbbreviatedName));
            Assert.That(entity2.FullName, Is.EqualTo(entity1.FullName));
            Assert.That(entity2.NativeName, Is.EqualTo(entity1.NativeName));
            Assert.That(entity2.DialingCode, Is.EqualTo(entity1.DialingCode));
            Assert.That(entity2.PostCodeFormat, Is.EqualTo(entity1.PostCodeFormat));
            Assert.That(entity2.CountryFlag, Is.EqualTo(entity1.CountryFlag));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Flag,ISO Code,Abbreviated Name,Full Name,Native Name,Dialing Code,Postal Code DotNetFormat,Currency,Language,Time Zone,World Region" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],IsoCode001,43ed9837-7f9d-48af-b5d7-d4de70f6e236,49ba89ee-8360-4162-b3d4-9ae6cb0568ae,aa2a9297-08de-47cc-a3c4-34b2725d48d3,Dialing001,67c41763-1af4-40a9-9317-2805ea4e82f9,1,1,1,1" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],IsoCode002,4d9b0d36-c2ea-4092-ae61-db5b26d91677,66a57e20-e561-4bde-a7d1-d807430963d1,4cfb8ef7-9655-4130-a026-fd09aa6ac3da,Dialing002,75daa3c5-7dbf-47d0-8939-42e6cc35acda,1,1,1,1" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],IsoCode003,9ca908ae-95d5-48c1-b260-9288597a9f79,26310835-55db-4e70-b2c9-809e6276b0ad,48c4342b-91a2-4676-b3ef-d58d8d4ff415,Dialing003,0a9c6c17-178f-4250-b38e-bbc32db401aa,1,1,1,1" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],IsoCode004,4a7664f1-48cd-46fd-9074-3cc14d7a48b2,20fd73e6-d858-4086-96bc-506245c6c057,4ffaddd0-ecdf-4616-a2fb-0124e09f1dec,Dialing004,d521ca98-a93d-4aef-b38e-c73d976416f9,1,1,1,1" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],IsoCode005,59e1015d-0067-4580-bfa1-b9db7cc56893,3733bdc4-5803-464b-9f9c-e96cccb111d5,4d757e68-a18b-49b1-b8c2-9071668a6803,Dialing005,24bb98cf-b536-445c-9c56-9b304bed27bc,1,1,1,1" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],IsoCode006,40c19679-8ddc-442b-8da3-29ee18cbc36a,2ee0f5cb-b5e4-4343-a7a0-88740a4ce4b3,1ec7ecbe-18fb-4db8-a652-b1199d7be7b3,Dialing006,1f2ad725-c221-4737-a5d2-7d07d2348adf,1,1,1,1" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],IsoCode007,f185a129-a748-4d5e-b1a3-e2f7ecfe8c0e,3d48ec12-5cbc-4d91-9e7d-ab2a9ef62e7a,268ab0fd-3c39-4dd1-acc1-4ea37eab427d,Dialing007,074bfb69-2b7a-4fef-be8a-e063e5b0ae1e,1,1,1,1" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],IsoCode008,757be121-6133-4f25-a16e-a4b695c8b5ab,89e831bc-a66f-4c35-be16-080a16581032,e18ed040-c9f5-45cf-85fd-6e60e8a601ad,Dialing008,7e4f21f0-fc6a-4886-a42f-e239b0815926,1,1,1,1" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],IsoCode009,60655a02-aaf0-4d8e-b958-5acd8359c6b2,e3af8925-29a2-4401-a380-36ba2d16fd48,f5ce7ce2-06c6-4b69-ab9a-923172610019,Dialing009,7864f705-a02d-4cbc-a1e9-ac7e55b7f392,1,1,1,1" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,System.Byte[],IsoCode010,4a766e19-8bcd-469d-8458-f5e05a8c019f,d483ed4d-21db-462d-9b27-3d8818d1ca60,2e7bf482-0509-49b5-8f2e-80d0cb7a0742,Dialing010,e06cfdae-bf3b-4a30-978e-efae8fe98ee6,1,1,1,1" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(ICountry entity)
        {
            entity.AbbreviatedName += "Updated";
            entity.FullName += "Updated";
        }
    }
}
