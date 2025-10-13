//-----------------------------------------------------------------------
// <copyright file="ScheduleIntervalViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Core.EnumViewModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ScheduleIntervalViewModelTests
    /// </summary>
    [TestFixture]
    public class ScheduleIntervalViewModelTests : GenericDataGridViewModelTestBaseClass<IScheduleInterval, IScheduleIntervalViewModel, IScheduleIntervalProcess>
    {
        protected override String ExpectedScreenTitle => "Scheduled Intervals";
        protected override String ExpectedStatusBarText => "Number of Schedule Intervals:";

        protected override IScheduleIntervalViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IScheduleIntervalViewModel viewModel = new ScheduleIntervalViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IScheduleIntervalProcess CreateBusinessProcess()
        {
            IScheduleIntervalProcess process = Substitute.For<IScheduleIntervalProcess>();

            return process;
        }

        protected override IScheduleInterval CreateModel()
        {
            IScheduleInterval retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
