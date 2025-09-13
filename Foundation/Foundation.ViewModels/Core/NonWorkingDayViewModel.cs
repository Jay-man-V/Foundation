//-----------------------------------------------------------------------
// <copyright file="NonWorkingDayViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core
{
    /// <summary>
    /// The User Interface interaction logic for NonWorkingDay maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{INonWorkingDay}" />
    [DependencyInjectionTransient]
    public class NonWorkingDayViewModel : GenericDataGridViewModelBase<INonWorkingDay>, INonWorkingDayViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="NonWorkingDayViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="nonWorkingDayProcess">The nonworking day process.</param>
        /// <param name="countryProcess">The country process.</param>
        public NonWorkingDayViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            INonWorkingDayProcess nonWorkingDayProcess,
            ICountryProcess countryProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                nonWorkingDayProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, nonWorkingDayProcess, countryProcess);

            CountryProcess = countryProcess;
            NonWorkingDayProcess = nonWorkingDayProcess;

            AllNonWorkingDays = [];

            // Enable Refresh from Government source only for System Support
            Action1CommandEnabled = CanUpdateNonWorkingDays();

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets or sets the country process.
        /// </summary>
        /// <value>
        /// The country process.
        /// </value>
        private ICountryProcess CountryProcess { get; }

        /// <summary>
        /// Gets the non-working day process.
        /// </summary>
        /// <value>
        /// The non-working day process.
        /// </value>
        private INonWorkingDayProcess NonWorkingDayProcess { get; }

        /// <summary>
        /// Gets or sets all non-working days.
        /// </summary>
        /// <value>
        /// All non-working days.
        /// </value>
        private List<INonWorkingDay> AllNonWorkingDays { get; set; }

        /// <inheritdoc cref="RefreshData()"/>
        protected override List<INonWorkingDay> RefreshData()
        {
            LoggingHelpers.TraceCallEnter();

            AllNonWorkingDays = base.RefreshData();

            List<ICountry> countries = NonWorkingDayProcess.GetListOfNonWorkingDayCountries(AllNonWorkingDays);
            Filter1DataSource = countries;
            Filter1SelectedItem = countries[0];

            List<String> years = NonWorkingDayProcess.GetListOfNonWorkingDayYears(AllNonWorkingDays);
            Filter2DataSource = years;
            Filter2SelectedItem = years[0];

            List<String> descriptions = NonWorkingDayProcess.GetListOfNonWorkingDayDescriptions(AllNonWorkingDays);
            Filter3DataSource = descriptions;
            Filter3SelectedItem = descriptions[0];

            ApplyFilter1(Filter1SelectedItem);

            LoggingHelpers.TraceCallReturn(AllNonWorkingDays);

            return AllNonWorkingDays;
        }

        /// <inheritdoc cref="ApplyFilter1"/>
        protected override void ApplyFilter1(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            if (selectedFilter is ICountry country &&
                Filter2SelectedItem is String year &&
                Filter3SelectedItem is String descriptions)
            {
                Action1CommandEnabled = CanUpdateNonWorkingDays();

                List<INonWorkingDay> filteredData = ApplyFilter(country, year, descriptions);

                GridDataSource = filteredData;
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ApplyFilter2"/>
        protected override void ApplyFilter2(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            if (Filter1SelectedItem is ICountry country &&
                selectedFilter is String year &&
                Filter3SelectedItem is String descriptions)
            {
                List<INonWorkingDay> filteredData = ApplyFilter(country, year, descriptions);

                GridDataSource = filteredData;
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ApplyFilter3"/>
        protected override void ApplyFilter3(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            if (Filter1SelectedItem is ICountry country &&
                Filter2SelectedItem is String year &&
                selectedFilter is String descriptions)
            {
                List<INonWorkingDay> filteredData = ApplyFilter(country, year, descriptions);

                GridDataSource = filteredData;
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Applies the filter.
        /// </summary>
        /// <param name="country">The country.</param>
        /// <param name="year">The year.</param>
        /// <param name="description">The description.</param>
        /// <returns></returns>
        private List<INonWorkingDay> ApplyFilter(ICountry country, String year, string description)
        {
            LoggingHelpers.TraceCallEnter(country, year, description);

            List<INonWorkingDay> retVal = NonWorkingDayProcess.ApplyFilter(AllNonWorkingDays, country, year, description);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ExecuteAction1"/>
        protected override void ExecuteAction1()
        {
            LoggingHelpers.TraceCallEnter();

            if (Filter1SelectedItem is ICountry country)
            {
                NonWorkingDayProcess.UpdateBankHolidayCalendarFromGovernmentSource(country);

                RefreshData();
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Determines whether this instance [can update non-working days].
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can update non-working days]; otherwise, <c>false</c>.
        /// </returns>
        private Boolean CanUpdateNonWorkingDays()
        {
            LoggingHelpers.TraceCallEnter();

            Boolean isSystemSupport = false;
            Boolean isCountrySelected = false;
            if (Filter1SelectedItem is ICountry country)
            {
                isSystemSupport = Core.CurrentLoggedOnUser.IsSystemSupport;
                isCountrySelected = country.Id != CountryProcess.AllId;
            }

            LoggingHelpers.TraceCallReturn();

            return isCountrySelected && isSystemSupport;
        }
    }
}
