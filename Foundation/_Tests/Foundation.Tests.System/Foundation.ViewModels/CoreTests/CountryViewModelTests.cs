//-----------------------------------------------------------------------
// <copyright file="CountryViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Core;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for CountryViewModelTests
    /// </summary>
    [TestFixture]
    public class CountryViewModelTests : GenericDataGridViewModelTestBaseClass<ICountry, ICountryViewModel, ICountryProcess>
    {
        protected override String ExpectedScreenTitle => "Countries";
        protected override String ExpectedStatusBarText => "Number of Countries:";

        protected override ICountryViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ICountryViewModel viewModel = new CountryViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override ICountryProcess CreateBusinessProcess()
        {
            ICountryProcess process = Substitute.For<ICountryProcess>();

            return process;
        }

        protected override ICountry CreateModel()
        {
            ICountry retVal = base.CreateModel();

            retVal.IsoCode = Guid.NewGuid().ToString();
            retVal.AbbreviatedName = Guid.NewGuid().ToString();
            retVal.FullName = Guid.NewGuid().ToString();
            retVal.NativeName = Guid.NewGuid().ToString();
            retVal.DialingCode = Guid.NewGuid().ToString();
            retVal.PostCodeFormat = Guid.NewGuid().ToString();
            retVal.CurrencyId = new EntityId(1);
            retVal.LanguageId = new EntityId(2);
            retVal.TimeZoneId = new EntityId(3);
            retVal.WorldRegionId = new EntityId(4);
            retVal.CountryFlag = new Byte[123];

            return retVal;
        }
    }
}
