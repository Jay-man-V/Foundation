//-----------------------------------------------------------------------
// <copyright file="NonWorkingDayProcessTests.cs" company="JDV Software Ltd">
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
    /// Summary description for NonWorkingDayProcessTests
    /// </summary>
    [TestFixture]
    public class NonWorkingDayProcessTests : CommonBusinessProcessTests<INonWorkingDay, INonWorkingDayProcess, INonWorkingDayRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 11;
        protected override String ExpectedScreenTitle => "Non-Working Days";
        protected override String ExpectedStatusBarText => "Number of Non-Working Days:";

        protected override Boolean ExpectedHasOptionalAction1 => true;
        protected override string ExpectedAction1Name => "Refresh from Government source";

        protected override Boolean ExpectedHasOptionalDropDownParameter1 => true;
        protected override String ExpectedFilter1Name => "Country:";
        protected override String ExpectedFilter1DisplayMemberPath => FDC.Country.AbbreviatedName;

        protected override Boolean ExpectedHasOptionalDropDownParameter2 => true;
        protected override String ExpectedFilter2Name => "Year:";
        protected override String ExpectedFilter2DisplayMemberPath => ".";
        protected override string ExpectedFilter2ValueMemberPath => ".";


        protected override Boolean ExpectedHasOptionalDropDownParameter3 => true;
        protected override String ExpectedFilter3Name => "Description:";
        protected override String ExpectedFilter3DisplayMemberPath => ".";
        protected override string ExpectedFilter3ValueMemberPath => ".";


        protected override String ExpectedComboBoxDisplayMember => FDC.NonWorkingDay.Description;

        protected override INonWorkingDayRepository CreateRepository()
        {
            INonWorkingDayRepository retVal = Substitute.For<INonWorkingDayRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override INonWorkingDayProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApplicationConfigurationService applicationConfigurationService = Substitute.For<IApplicationConfigurationService>();
            ICountryProcess countryProcess = Substitute.For<ICountryProcess>();
            IHttpApi httpWebApi = Substitute.For<IHttpApi>();

            SetComboBoxProperties(countryProcess);

            INonWorkingDayProcess process = new NonWorkingDayProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, applicationConfigurationService, countryProcess, httpWebApi);

            return process;
        }

        protected override INonWorkingDay CreateBlankEntity(Int32 entityId)
        {
            INonWorkingDay retVal = new FModels.NonWorkingDay();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override INonWorkingDay CreateEntity(INonWorkingDayProcess process, Int32 entityId)
        {
            INonWorkingDay retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;
            retVal.LastUpdatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.Date = new DateTime(2022, 12, 11);
            retVal.CountryId = new EntityId(1);
            retVal.Description = Guid.NewGuid().ToString();
            retVal.Notes = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void CheckBlankEntry(INonWorkingDay entity)
        {
            Assert.That(entity.Description, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(INonWorkingDay entity)
        {
            Assert.That(entity.Description, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(INonWorkingDay entity)
        {
            Assert.That(entity.Description, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(INonWorkingDay entity1, INonWorkingDay entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.Date, Is.EqualTo(entity1.Date));
            Assert.That(entity2.CountryId, Is.EqualTo(entity1.CountryId));
            Assert.That(entity2.Description, Is.EqualTo(entity1.Description));
            Assert.That(entity2.Notes, Is.EqualTo(entity1.Notes));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Country,Date,Description,Notes" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,2022-12-11T00:00:00.000,ad47eb5d-2915-41c0-a661-2fef157b93d3,ca76e190-bfb9-42e4-812a-8a22facf7e3a" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,2022-12-11T00:00:00.000,0c168ad3-2f30-4bcd-b4b0-06c9fe2ea19c,3d28a6a4-ff2d-4083-b101-b101818969e9" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,2022-12-11T00:00:00.000,fbdbadb8-25bd-4670-be89-9fb7961fda32,f8ff9e5e-65be-4af7-b999-505a6806d37b" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,2022-12-11T00:00:00.000,731968cf-a097-4144-8151-4245a1b34b9e,6c36293f-8947-4ac6-9fa6-0b2a8721c7cb" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,2022-12-11T00:00:00.000,30497180-3048-4c67-9234-c075d0916f76,5764fa10-68c5-45b8-b9c8-bbb2e6f4a8b5" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,2022-12-11T00:00:00.000,c6ca3a60-57d9-4067-8483-1b340d36d906,129de9c7-a540-4b42-a7a1-ad6229b6db84" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,2022-12-11T00:00:00.000,7b78c728-4b23-4f07-9193-e4b045b816ba,d88a69c5-e534-4e4e-b719-bd18e339ff9d" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,2022-12-11T00:00:00.000,3303604b-f884-493b-8fa1-d67ffa993378,f35d3ac0-ad1f-407c-b3d7-108ae7187c86" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,2022-12-11T00:00:00.000,0379fd7b-9847-49e6-bf24-27b1429c9e78,e60e4db2-d3bc-4345-a55d-6a844cf0a5cd" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,2022-12-11T00:00:00.000,d3f9efdc-c718-4079-9e39-8bdf5e33b8fa,12417cd1-f1fc-4f95-abf3-25fda333dbe1" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(INonWorkingDay entity)
        {
            entity.Date = DateTime.Now;
            entity.Description += "Updated";
            entity.Notes += "Updated";
        }

        [TestCase]
        public void Test_ApplyFilter_Country()
        {
            List<INonWorkingDay> nonWorkingDays = CreateListOfNonWorkingDays();
            ICountry country = CoreInstance.IoC.Get<ICountry>();
            country.Id = new EntityId(1);
            String year = String.Empty;
            String description = String.Empty;

            List<INonWorkingDay> filteredNonWorkingDays = TheProcess!.ApplyFilter(nonWorkingDays, country, year, description);

            Assert.That(filteredNonWorkingDays.Count, Is.EqualTo(8));

            Assert.That(filteredNonWorkingDays[0].Date, Is.EqualTo(new DateTime(2020, 1, 1)));
            Assert.That(filteredNonWorkingDays[1].Date, Is.EqualTo(new DateTime(2020, 1, 2)));
            Assert.That(filteredNonWorkingDays[2].Date, Is.EqualTo(new DateTime(2021, 1, 1)));
            Assert.That(filteredNonWorkingDays[3].Date, Is.EqualTo(new DateTime(2021, 1, 2)));
            Assert.That(filteredNonWorkingDays[4].Date, Is.EqualTo(new DateTime(2022, 1, 1)));
            Assert.That(filteredNonWorkingDays[5].Date, Is.EqualTo(new DateTime(2022, 1, 2)));
            Assert.That(filteredNonWorkingDays[6].Date, Is.EqualTo(new DateTime(2023, 1, 1)));
            Assert.That(filteredNonWorkingDays[7].Date, Is.EqualTo(new DateTime(2023, 1, 2)));

            Assert.That(filteredNonWorkingDays[0].Description, Is.EqualTo("C1. Y2020. New Years Day"));
            Assert.That(filteredNonWorkingDays[1].Description, Is.EqualTo("C1. Y2020. Second New Years Day1"));
            Assert.That(filteredNonWorkingDays[2].Description, Is.EqualTo("C1. Y2021. New Years Day"));
            Assert.That(filteredNonWorkingDays[3].Description, Is.EqualTo("C1. Y2021. Second New Years Day2"));
            Assert.That(filteredNonWorkingDays[4].Description, Is.EqualTo("C1. Y2022. New Years Day"));
            Assert.That(filteredNonWorkingDays[5].Description, Is.EqualTo("C1. Y2022. Second New Years Day3"));
            Assert.That(filteredNonWorkingDays[6].Description, Is.EqualTo("C1. Y2023. New Years Day"));
            Assert.That(filteredNonWorkingDays[7].Description, Is.EqualTo("C1. Y2023. Second New Years Day4"));
        }

        [TestCase]
        public void Test_ApplyFilter_Year()
        {
            List<INonWorkingDay> nonWorkingDays = CreateListOfNonWorkingDays();
            const ICountry? country = null;
            String year = "2022";
            String description = String.Empty;

            List<INonWorkingDay> filteredNonWorkingDays = TheProcess!.ApplyFilter(nonWorkingDays, country, year, description);

            Assert.That(filteredNonWorkingDays.Count, Is.EqualTo(6));

            Assert.That(filteredNonWorkingDays[0].Date, Is.EqualTo(new DateTime(2022, 1, 1)));
            Assert.That(filteredNonWorkingDays[1].Date, Is.EqualTo(new DateTime(2022, 1, 1)));
            Assert.That(filteredNonWorkingDays[2].Date, Is.EqualTo(new DateTime(2022, 1, 1)));
            Assert.That(filteredNonWorkingDays[3].Date, Is.EqualTo(new DateTime(2022, 1, 2)));
            Assert.That(filteredNonWorkingDays[4].Date, Is.EqualTo(new DateTime(2022, 1, 2)));
            Assert.That(filteredNonWorkingDays[5].Date, Is.EqualTo(new DateTime(2022, 1, 2)));

            Assert.That(filteredNonWorkingDays[0].Description, Is.EqualTo("C1. Y2022. New Years Day"));
            Assert.That(filteredNonWorkingDays[1].Description, Is.EqualTo("C2. Y2022. New Years Day"));
            Assert.That(filteredNonWorkingDays[2].Description, Is.EqualTo("C3. Y2022. New Years Day"));
            Assert.That(filteredNonWorkingDays[3].Description, Is.EqualTo("C1. Y2022. Second New Years Day3"));
            Assert.That(filteredNonWorkingDays[4].Description, Is.EqualTo("C2. Y2022. Second New Years Day3"));
            Assert.That(filteredNonWorkingDays[5].Description, Is.EqualTo("C3. Y2022. Second New Years Day3"));
        }

        [TestCase]
        public void Test_ApplyFilter_Description()
        {
            List<INonWorkingDay> nonWorkingDays = CreateListOfNonWorkingDays();
            const ICountry? country = null;
            String year = String.Empty;
            const String description = "C1. Y2022. New Years Day";

            List<INonWorkingDay> filteredNonWorkingDays = TheProcess!.ApplyFilter(nonWorkingDays, country, year, description);

            Assert.That(filteredNonWorkingDays.Count, Is.EqualTo(1));

            Assert.That(filteredNonWorkingDays[0].Date, Is.EqualTo(new DateTime(2022, 1, 1)));
            Assert.That(filteredNonWorkingDays[0].Description, Is.EqualTo("C1. Y2022. New Years Day"));
        }

        private INonWorkingDay CreateEntity(EntityId countryId, DateTime holidayDate, String description)
        {
            INonWorkingDay retVal = new FModels.NonWorkingDay();

            retVal.CountryId = countryId;
            retVal.Date = holidayDate;
            retVal.Description = description;

            return retVal;
        }

        private List<INonWorkingDay> CreateListOfNonWorkingDays()
        {
            List<INonWorkingDay> retVal =
            [
                CreateEntity(new EntityId(1), new DateTime(2020, 1, 1), "C1. Y2020. New Years Day"),
                CreateEntity(new EntityId(1), new DateTime(2021, 1, 1), "C1. Y2021. New Years Day"),
                CreateEntity(new EntityId(1), new DateTime(2022, 1, 1), "C1. Y2022. New Years Day"),
                CreateEntity(new EntityId(1), new DateTime(2023, 1, 1), "C1. Y2023. New Years Day"),

                CreateEntity(new EntityId(1), new DateTime(2020, 1, 2), "C1. Y2020. Second New Years Day1"),
                CreateEntity(new EntityId(1), new DateTime(2021, 1, 2), "C1. Y2021. Second New Years Day2"),
                CreateEntity(new EntityId(1), new DateTime(2022, 1, 2), "C1. Y2022. Second New Years Day3"),
                CreateEntity(new EntityId(1), new DateTime(2023, 1, 2), "C1. Y2023. Second New Years Day4"),

                CreateEntity(new EntityId(2), new DateTime(2020, 1, 1), "C2. Y2020. New Years Day"),
                CreateEntity(new EntityId(2), new DateTime(2021, 1, 1), "C2. Y2021. New Years Day"),
                CreateEntity(new EntityId(2), new DateTime(2022, 1, 1), "C2. Y2022. New Years Day"),
                CreateEntity(new EntityId(2), new DateTime(2023, 1, 1), "C2. Y2023. New Years Day"),

                CreateEntity(new EntityId(2), new DateTime(2020, 1, 2), "C2. Y2020. Second New Years Day1"),
                CreateEntity(new EntityId(2), new DateTime(2021, 1, 2), "C2. Y2021. Second New Years Day2"),
                CreateEntity(new EntityId(2), new DateTime(2022, 1, 2), "C2. Y2022. Second New Years Day3"),
                CreateEntity(new EntityId(2), new DateTime(2023, 1, 2), "C2. Y2023. Second New Years Day4"),

                CreateEntity(new EntityId(3), new DateTime(2020, 1, 1), "C3. Y2020. New Years Day"),
                CreateEntity(new EntityId(3), new DateTime(2021, 1, 1), "C3. Y2021. New Years Day"),
                CreateEntity(new EntityId(3), new DateTime(2022, 1, 1), "C3. Y2022. New Years Day"),
                CreateEntity(new EntityId(3), new DateTime(2023, 1, 1), "C3. Y2022. New Years Day"),

                CreateEntity(new EntityId(3), new DateTime(2020, 1, 2), "C3. Y2020. Second New Years Day1"),
                CreateEntity(new EntityId(3), new DateTime(2021, 1, 2), "C3. Y2021. Second New Years Day2"),
                CreateEntity(new EntityId(3), new DateTime(2022, 1, 2), "C3. Y2022. Second New Years Day3"),
                CreateEntity(new EntityId(3), new DateTime(2023, 1, 2), "C3. Y2023. Second New Years Day4"),
            ];

            return retVal;
        }

        [TestCase]
        public void Test_GetListOfNonWorkingDayCountries()
        {
            IApplicationConfigurationService applicationConfigurationService = Substitute.For<IApplicationConfigurationService>();
            ICountryProcess countryProcess = Substitute.For<ICountryProcess>();
            IHttpApi httpWebApi = Substitute.For<IHttpApi>();

            INonWorkingDayProcess process = new NonWorkingDayProcess(CoreInstance, RunTimeEnvironmentSettings, DateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, applicationConfigurationService, countryProcess, httpWebApi);

            List<ICountry> countriesToReturn =
            [
                CoreInstance.IoC.Get<ICountry>(),
                CoreInstance.IoC.Get<ICountry>(),
                CoreInstance.IoC.Get<ICountry>(),
                CoreInstance.IoC.Get<ICountry>(),
            ];
            countriesToReturn[0].Id = new EntityId(1);
            countriesToReturn[1].Id = new EntityId(2);
            countriesToReturn[2].Id = new EntityId(3);
            countriesToReturn[0].Id = new EntityId(1);

            countryProcess.Get(Arg.Any<List<EntityId>>()).Returns(countriesToReturn);

            List<INonWorkingDay> nonWorkingDays = CreateListOfNonWorkingDays();
            List<ICountry> countries = process.GetListOfNonWorkingDayCountries(nonWorkingDays);

            Assert.That(countries.Count, Is.EqualTo(countriesToReturn.Count));
            Assert.That(countries[0].Id, Is.EqualTo(new EntityId(1)));
            Assert.That(countries[1].Id, Is.EqualTo(new EntityId(2)));
            Assert.That(countries[2].Id, Is.EqualTo(new EntityId(3)));
        }

        [TestCase]
        public void Test_GetListOfNonWorkingDayYears()
        {
            List<INonWorkingDay> nonWorkingDays = CreateListOfNonWorkingDays();
            List<String> years = TheProcess!.GetListOfNonWorkingDayYears(nonWorkingDays);

            Assert.That(years.Count, Is.EqualTo(5));
            Assert.That(years[0], Is.EqualTo(TheProcess!.AllText));
            Assert.That(years[1], Is.EqualTo("2023"));
            Assert.That(years[2], Is.EqualTo("2022"));
            Assert.That(years[3], Is.EqualTo("2021"));
            Assert.That(years[4], Is.EqualTo("2020"));
        }

        [TestCase]
        public void Test_GetListOfNonWorkingDayDescriptions()
        {
            List<INonWorkingDay> nonWorkingDays = CreateListOfNonWorkingDays();
            List<String> years = TheProcess!.GetListOfNonWorkingDayDescriptions(nonWorkingDays);

            Assert.That(years.Count, Is.EqualTo(25));
            Assert.That(years[0], Is.EqualTo(TheProcess!.AllText));
            Assert.That(years[1], Is.EqualTo(TheProcess!.NoneText));
            Assert.That(years[2], Is.EqualTo("C1. Y2020. New Years Day"));
            Assert.That(years[3], Is.EqualTo("C1. Y2020. Second New Years Day1"));
            Assert.That(years[4], Is.EqualTo("C1. Y2021. New Years Day"));
            Assert.That(years[5], Is.EqualTo("C1. Y2021. Second New Years Day2"));
            Assert.That(years[6], Is.EqualTo("C1. Y2022. New Years Day"));
            Assert.That(years[7], Is.EqualTo("C1. Y2022. Second New Years Day3"));
            Assert.That(years[8], Is.EqualTo("C1. Y2023. New Years Day"));
            Assert.That(years[9], Is.EqualTo("C1. Y2023. Second New Years Day4"));
            Assert.That(years[10], Is.EqualTo("C2. Y2020. New Years Day"));
            Assert.That(years[11], Is.EqualTo("C2. Y2020. Second New Years Day1"));
            Assert.That(years[12], Is.EqualTo("C2. Y2021. New Years Day"));
            Assert.That(years[13], Is.EqualTo("C2. Y2021. Second New Years Day2"));
            Assert.That(years[14], Is.EqualTo("C2. Y2022. New Years Day"));
            Assert.That(years[15], Is.EqualTo("C2. Y2022. Second New Years Day3"));
            Assert.That(years[16], Is.EqualTo("C2. Y2023. New Years Day"));
            Assert.That(years[17], Is.EqualTo("C2. Y2023. Second New Years Day4"));
            Assert.That(years[18], Is.EqualTo("C3. Y2020. New Years Day"));
            Assert.That(years[19], Is.EqualTo("C3. Y2020. Second New Years Day1"));
            Assert.That(years[20], Is.EqualTo("C3. Y2021. New Years Day"));
            Assert.That(years[21], Is.EqualTo("C3. Y2021. Second New Years Day2"));
            Assert.That(years[22], Is.EqualTo("C3. Y2022. New Years Day"));
            Assert.That(years[23], Is.EqualTo("C3. Y2022. Second New Years Day3"));
            Assert.That(years[24], Is.EqualTo("C3. Y2023. Second New Years Day4"));
        }

        [TestCase]
        public void Test_UpdateBankHolidayCalendarFromGovernmentSource()
        {
            IApplicationConfigurationService applicationConfigurationService = Substitute.For<IApplicationConfigurationService>();
            ICountryProcess countryProcess = Substitute.For<ICountryProcess>();
            IHttpApi httpWebApi = Substitute.For<IHttpApi>();

            String inputJsonData = @"{
    ""england-and-wales"": {
        ""division"": ""england-and-wales"",
        ""events"": [
            {
                ""title"": """",
                ""date"": ""2020-01-01"",
                ""notes"": ""Some notes"",
                ""bunting"": false
            }
        ]
    }
}";

            ICountry country = CoreInstance.IoC.Get<ICountry>();

            const INonWorkingDay? nonWorkingDay = null;
            TheRepository!.Get(Arg.Any<EntityId>(), Arg.Any<DateTime>()).Returns(nonWorkingDay);

            applicationConfigurationService.Get<String>(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), Arg.Any<String>()).Returns("Configuration Value");
            httpWebApi.DownloadString(Arg.Any<IFileTransferSettings>()).Returns(inputJsonData);

            INonWorkingDayProcess process = new NonWorkingDayProcess(CoreInstance, RunTimeEnvironmentSettings, DateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, applicationConfigurationService, countryProcess, httpWebApi);

            process.UpdateBankHolidayCalendarFromGovernmentSource(country);

            TheRepository!.Get(Arg.Any<EntityId>(), Arg.Any<DateTime>()).Received(1);
            TheRepository!.Save(Arg.Any<INonWorkingDay>()).Received(1);
        }
    }
}
