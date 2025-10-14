//-----------------------------------------------------------------------
// <copyright file="WorldRegionViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for WorldRegionViewModelTests
    /// </summary>
    [TestFixture]
    public class WorldRegionViewModelTests : GenericDataGridViewModelTests<IWorldRegion, IWorldRegionViewModel, IWorldRegionProcess>
    {
        protected override IWorldRegionProcess CreateBusinessProcess()
        {
            IWorldRegionProcess process = Substitute.For<IWorldRegionProcess>();

            return process;
        }

        protected override IWorldRegion CreateBlankModel(Int32 entityId)
        {
            IWorldRegion retVal = new WorldRegion();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IWorldRegion CreateModel(Int32 entityId)
        {
            IWorldRegion retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IWorldRegionViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IWorldRegionViewModel viewModel = new WorldRegionViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
