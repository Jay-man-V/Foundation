//-----------------------------------------------------------------------
// <copyright file="WorldRegionViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for WorldRegionViewModelTests
    /// </summary>
    [TestFixture]
    public class WorldRegionViewModelTests : GenericDataGridViewModelTestBaseClass<IWorldRegion, IWorldRegionViewModel, IWorldRegionProcess>
    {
        protected override String ExpectedScreenTitle => "World Regions";
        protected override String ExpectedStatusBarText => "Number of World Regions:";

        protected override IWorldRegionViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IWorldRegionViewModel viewModel = new WorldRegionViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IWorldRegionProcess CreateBusinessProcess()
        {
            IWorldRegionProcess process = Substitute.For<IWorldRegionProcess>();

            return process;
        }

        protected override IWorldRegion CreateModel()
        {
            IWorldRegion retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
