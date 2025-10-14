//-----------------------------------------------------------------------
// <copyright file="NationalRegionViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for NationalRegionViewModelTests
    /// </summary>
    [TestFixture]
    public class NationalRegionViewModelTests : GenericDataGridViewModelTests<INationalRegion, INationalRegionViewModel, INationalRegionProcess>
    {
        protected override INationalRegionProcess CreateBusinessProcess()
        {
            INationalRegionProcess process = Substitute.For<INationalRegionProcess>();

            return process;
        }

        protected override INationalRegion CreateBlankModel(Int32 entityId)
        {
            INationalRegion retVal = new NationalRegion();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override INationalRegion CreateModel(Int32 entityId)
        {
            INationalRegion retVal = base.CreateModel(entityId);

            retVal.CountryId = new EntityId(1);
            retVal.Abbreviation = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.FullName = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override INationalRegionViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            INationalRegionViewModel viewModel = new NationalRegionViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
