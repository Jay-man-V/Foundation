//-----------------------------------------------------------------------
// <copyright file="NonWorkingDayViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Core;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for NonWorkingDayViewModelTests
    /// </summary>
    [TestFixture]
    public class NonWorkingDayViewModelTests : GenericDataGridViewModelTestBaseClass<INonWorkingDay, INonWorkingDayViewModel, INonWorkingDayProcess>
    {
        protected override String ExpectedScreenTitle => "Non-Working Days";
        protected override String ExpectedStatusBarText => "Number of Non-Working Days:";

        protected override Boolean ExpectedHasOptionalAction1 => true;
        protected override String ExpectedAction1Name => "Refresh from Government source";

        protected override Boolean ExpectedHasOptionalDropDownParameter1 => true;
        protected override String ExpectedFilter1Name => "Country:";
        protected override String ExpectedFilter1DisplayMemberPath => FDC.Country.AbbreviatedName;

        protected override Boolean ExpectedHasOptionalDropDownParameter2 => true;
        protected override String ExpectedFilter2Name => "Year:";
        protected override String ExpectedFilter2DisplayMemberPath => ".";
        protected override String ExpectedFilter2SelectedValuePath => ".";

        protected override Boolean ExpectedHasOptionalDropDownParameter3 => true;
        protected override String ExpectedFilter3Name => "Description:";
        protected override String ExpectedFilter3DisplayMemberPath => ".";
        protected override String ExpectedFilter3SelectedValuePath => ".";

        protected override INonWorkingDayViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ICountryProcess countryProcess = Substitute.For<ICountryProcess>();

            INonWorkingDayViewModel viewModel = new NonWorkingDayViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess, countryProcess);

            return viewModel;
        }

        protected override INonWorkingDayProcess CreateBusinessProcess()
        {
            INonWorkingDayProcess process = Substitute.For<INonWorkingDayProcess>();

            return process;
        }

        protected override INonWorkingDay CreateModel()
        {
            INonWorkingDay retVal = base.CreateModel();

            retVal.Date = DateTimeService.SystemUtcDateTimeNow.Date;
            retVal.CountryId = new EntityId(1);
            retVal.Description = Guid.NewGuid().ToString();
            retVal.Notes = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override void SetupForRefreshData()
        {
            base.SetupForRefreshData();

            List<ICountry> countries = new List<ICountry>
            {
                CoreInstance.IoC.Get<ICountry>(),
            };
            BusinessProcess.GetListOfNonWorkingDayCountries(Arg.Any<List<INonWorkingDay>>()).Returns(countries);

            List<String> years = new List<String>
            {
                "2024",
            };
            BusinessProcess.GetListOfNonWorkingDayYears(Arg.Any<List<INonWorkingDay>>()).Returns(years);

            List<String> descriptions = new List<String>
            {
                "A Description",
            };
            BusinessProcess.GetListOfNonWorkingDayDescriptions(Arg.Any<List<INonWorkingDay>>()).Returns(descriptions);

            List<INonWorkingDay> nonWorkingDays = new List<INonWorkingDay>();
            BusinessProcess.ApplyFilter(Arg.Any<List<INonWorkingDay>>(), Arg.Any<ICountry>(), Arg.Any<String>(), Arg.Any<String>()).Returns(nonWorkingDays);
        }

        protected override object SetupForAction1Command(INonWorkingDayViewModel viewModel)
        {
            ICountry retVal = CoreInstance.IoC.Get<ICountry>();

            viewModel.Filter1SelectedItem = retVal;

            IEnumerable<ICountry> countries = MakeListOfCountries();
            BusinessProcess.GetListOfNonWorkingDayCountries(Arg.Any<IEnumerable<INonWorkingDay>>()).Returns(countries);

            List<String> years = new List<String> { "2021", "2022", "2023", "2024", "2025" };
            BusinessProcess.GetListOfNonWorkingDayYears(Arg.Any<List<INonWorkingDay>>()).Returns(years);

            List<String> descriptions = new List<String> { "Desc 1", "Desc 2", "Desc 3", "Desc 4", "Desc 5" };
            BusinessProcess.GetListOfNonWorkingDayDescriptions(Arg.Any<List<INonWorkingDay>>()).Returns(descriptions);

            return retVal;
        }

        protected override Object CreateModelForDropDown1()
        {
            return CoreInstance.IoC.Get<INonWorkingDay>();
        }

        protected override Object CreateModelForDropDown2()
        {
            return Guid.NewGuid().ToString();
        }

        protected override Object CreateModelForDropDown3()
        {
            return CoreInstance.IoC.Get<INonWorkingDay>();
        }

        private List<ICountry> MakeListOfCountries()
        {
            List<ICountry> retVal = new List<ICountry>
            {
                CoreInstance.IoC.Get<ICountry>(),
                CoreInstance.IoC.Get<ICountry>(),
                CoreInstance.IoC.Get<ICountry>(),
                CoreInstance.IoC.Get<ICountry>(),
            };
            retVal[0].Id = new EntityId(1);
            retVal[1].Id = new EntityId(2);
            retVal[2].Id = new EntityId(3);
            retVal[0].Id = new EntityId(1);


            return retVal;
        }
    }
}
