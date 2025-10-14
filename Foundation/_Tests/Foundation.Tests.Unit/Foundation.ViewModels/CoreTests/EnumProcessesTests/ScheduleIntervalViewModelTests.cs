//-----------------------------------------------------------------------
// <copyright file="ScheduleIntervalViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Core.EnumViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

using FModels = Foundation.Models.Core.EnumModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ScheduleIntervalViewModelTests
    /// </summary>
    [TestFixture]
    public class ScheduleIntervalViewModelTests : GenericDataGridViewModelTests<IScheduleInterval, IScheduleIntervalViewModel, IScheduleIntervalProcess>
    {
        protected override IScheduleIntervalProcess CreateBusinessProcess()
        {
            IScheduleIntervalProcess process = Substitute.For<IScheduleIntervalProcess>();

            return process;
        }

        protected override IScheduleInterval CreateBlankModel(Int32 entityId)
        {
            IScheduleInterval retVal = new FModels.ScheduleInterval();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IScheduleInterval CreateModel(Int32 entityId)
        {
            IScheduleInterval retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IScheduleIntervalViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IScheduleIntervalViewModel viewModel = new ScheduleIntervalViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
