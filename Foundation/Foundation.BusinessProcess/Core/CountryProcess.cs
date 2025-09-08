//-----------------------------------------------------------------------
// <copyright file="CountryProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Drawing;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Models.Specialised;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// The Country Business Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class CountryProcess : CommonBusinessProcess<ICountry, ICountryRepository>, ICountryProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CountryProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        /// <param name="currencyProcess">The currency process.</param>
        /// <param name="languageProcess">The language process.</param>
        /// <param name="timeZoneProcess">The time zone process.</param>
        /// <param name="worldRegionProcess">The world region process.</param>
        public CountryProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ICountryRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            ICurrencyProcess currencyProcess,
            ILanguageProcess languageProcess,
            ITimeZoneProcess timeZoneProcess,
            IWorldRegionProcess worldRegionProcess

        ) 
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                repository,
                statusRepository,
                userProfileRepository
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, userProfileRepository, currencyProcess, languageProcess, timeZoneProcess, worldRegionProcess);

            CurrencyProcess = currencyProcess;
            LanguageProcess = languageProcess;
            TimeZoneProcess = timeZoneProcess;
            WorldRegionProcess = worldRegionProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the currency process.
        /// </summary>
        /// <value>
        /// The currency process.
        /// </value>
        private ICurrencyProcess CurrencyProcess { get; }

        /// <summary>
        /// Gets the language process.
        /// </summary>
        /// <value>
        /// The language process.
        /// </value>
        private ILanguageProcess LanguageProcess { get; }

        /// <summary>
        /// Gets the time zone process.
        /// </summary>
        /// <value>
        /// The time zone process.
        /// </value>
        private ITimeZoneProcess TimeZoneProcess { get; }

        /// <summary>
        /// Gets the world region process.
        /// </summary>
        /// <value>
        /// The world region process.
        /// </value>
        private IWorldRegionProcess WorldRegionProcess { get; }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Countries";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Countries:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.Country.AbbreviatedName;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(68, FDC.Country.CountryFlag, "Flag", typeof(Image));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(80, FDC.Country.IsoCode, "ISO Code", typeof(String))
            {
                TextAlignment = TextAlignment.Centre
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Country.AbbreviatedName, "Abbreviated Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.Country.FullName, "Full Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.Country.NativeName, "Native Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Country.DialingCode, "Dialing Code", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Country.PostCodeFormat, "Postal Code DotNetFormat", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Country.CurrencyId, "Currency", typeof(String))
            {
                DataSource = CurrencyProcess.GetAll(excludeDeleted: false),
                ValueMember = CurrencyProcess.ComboBoxValueMember,
                DisplayMember = CurrencyProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Country.LanguageId, "Language", typeof(String))
            {
                DataSource = LanguageProcess.GetAll(excludeDeleted: false),
                ValueMember = LanguageProcess.ComboBoxValueMember,
                DisplayMember = LanguageProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Country.TimeZoneId, "Time Zone", typeof(String))
            {
                DataSource = TimeZoneProcess.GetAll(excludeDeleted: false),
                ValueMember = LanguageProcess.ComboBoxValueMember,
                DisplayMember = LanguageProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Country.WorldRegionId, "World Region", typeof(String))
            {
                DataSource = WorldRegionProcess.GetAll(excludeDeleted: false),
                ValueMember = WorldRegionProcess.ComboBoxValueMember,
                DisplayMember = WorldRegionProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
