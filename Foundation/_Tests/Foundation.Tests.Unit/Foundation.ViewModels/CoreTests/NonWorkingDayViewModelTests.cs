//-----------------------------------------------------------------------
// <copyright file="NonWorkingDayViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Core;
using Foundation.ViewModels.Core;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for NonWorkingDayViewModelTests
    /// </summary>
    [TestFixture]
    public class NonWorkingDayViewModelTests : GenericDataGridViewModelTests<INonWorkingDay, INonWorkingDayViewModel, INonWorkingDayProcess>
    {
        protected override INonWorkingDayProcess CreateBusinessProcess()
        {
            INonWorkingDayProcess process = Substitute.For<INonWorkingDayProcess>();

            return process;
        }

        protected override INonWorkingDay CreateBlankModel(Int32 entityId)
        {
            INonWorkingDay retVal = new NonWorkingDay();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override INonWorkingDay CreateModel(Int32 entityId)
        {
            INonWorkingDay retVal = base.CreateModel(entityId);

            retVal.Date = DateTimeService.SystemUtcDateTimeNow.Date;
            retVal.CountryId = new EntityId(1);
            retVal.Description = Guid.NewGuid().ToString();
            retVal.Notes = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override INonWorkingDayViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ICountryProcess countryProcess = Substitute.For<ICountryProcess>();

            INonWorkingDayViewModel viewModel = new NonWorkingDayViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess, countryProcess);

            return viewModel;
        }

        protected override void SetupForRefreshData()
        {
            base.SetupForRefreshData();

            List<ICountry> countries =
            [
                Substitute.For<ICountry>(),
            ];
            BusinessProcess.GetListOfNonWorkingDayCountries(Arg.Any<List<INonWorkingDay>>()).Returns(countries);

            List<String> years =
            [
                "2024",
            ];
            BusinessProcess.GetListOfNonWorkingDayYears(Arg.Any<List<INonWorkingDay>>()).Returns(years);

            List<String> descriptions =
            [
                "A Description",
            ];
            BusinessProcess.GetListOfNonWorkingDayDescriptions(Arg.Any<List<INonWorkingDay>>()).Returns(descriptions);

            List<INonWorkingDay> nonWorkingDays = new List<INonWorkingDay>();
            BusinessProcess.ApplyFilter(Arg.Any<List<INonWorkingDay>>(), Arg.Any<ICountry>(), Arg.Any<String>(), Arg.Any<String>()).Returns(nonWorkingDays);
        }

        protected override object SetupForAction1Command()
        {
            ICountry retVal = Substitute.For<ICountry>();

            TheViewModel!.Filter1SelectedItem = retVal;

;           IEnumerable<ICountry> countries = MakeListOfCountries();
            BusinessProcess.GetListOfNonWorkingDayCountries(Arg.Any<IEnumerable<INonWorkingDay>>()).Returns(countries);

            List<String> years = ["2021", "2022", "2023", "2024", "2025"];
            BusinessProcess.GetListOfNonWorkingDayYears(Arg.Any<List<INonWorkingDay>>()).Returns(years);

            List<String> descriptions = ["Desc 1", "Desc 2", "Desc 3", "Desc 4", "Desc 5"];
            BusinessProcess.GetListOfNonWorkingDayDescriptions(Arg.Any<List<INonWorkingDay>>()).Returns(descriptions);

            return retVal;
        }

        protected override Object CreateModelForDropDown1()
        {
            return Substitute.For<INonWorkingDay>();
        }

        protected override Object CreateModelForDropDown2()
        {
            return Guid.NewGuid().ToString();
        }

        protected override Object CreateModelForDropDown3()
        {
            return Substitute.For<INonWorkingDay>();
        }

        private List<ICountry> MakeListOfCountries()
        {
            List<ICountry> retVal =
            [
                Substitute.For<ICountry>(),
                Substitute.For<ICountry>(),
                Substitute.For<ICountry>(),
                Substitute.For<ICountry>(),
            ];
            retVal[0].Id = new EntityId(1);
            retVal[1].Id = new EntityId(2);
            retVal[2].Id = new EntityId(3);
            retVal[0].Id = new EntityId(1);


            return retVal;
        }
    }
}
