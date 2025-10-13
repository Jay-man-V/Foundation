//-----------------------------------------------------------------------
// <copyright file="NationalRegionViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for NationalRegionViewModelTests
    /// </summary>
    [TestFixture]
    public class NationalRegionViewModelTests : GenericDataGridViewModelTestBaseClass<INationalRegion, INationalRegionViewModel, INationalRegionProcess>
    {
        protected override String ExpectedScreenTitle => "National Regions";
        protected override String ExpectedStatusBarText => "Number of National Regions:";

        protected override INationalRegionViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            INationalRegionViewModel viewModel = new NationalRegionViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override INationalRegionProcess CreateBusinessProcess()
        {
            INationalRegionProcess process = Substitute.For<INationalRegionProcess>();

            return process;
        }

        protected override INationalRegion CreateModel()
        {
            INationalRegion retVal = base.CreateModel();

            retVal.CountryId = new EntityId(1);
            retVal.Abbreviation = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.FullName = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
