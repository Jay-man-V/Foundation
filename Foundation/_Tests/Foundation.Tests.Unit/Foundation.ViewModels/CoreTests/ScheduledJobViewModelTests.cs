//-----------------------------------------------------------------------
// <copyright file="ScheduledJobViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ScheduledJobViewModelTests
    /// </summary>
    [TestFixture]
    public class ScheduledJobViewModelTests : GenericDataGridViewModelTestBaseClass<IScheduledJob, IScheduledJobViewModel, IScheduledJobProcess>
    {
        protected override String ExpectedScreenTitle => "Scheduled Jobs";
        protected override String ExpectedStatusBarText => "Number of Scheduled Jobs:";

        protected override IScheduledJobViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IScheduledJobViewModel viewModel = new ScheduledJobViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IScheduledJobProcess CreateBusinessProcess()
        {
            IScheduledJobProcess process = Substitute.For<IScheduledJobProcess>();

            return process;
        }

        protected override IScheduledJob CreateModel()
        {
            IScheduledJob retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.ScheduleIntervalId = new EntityId(1);
            retVal.LastRunDateTime = DateTimeService.SystemUtcDateTimeNow;
            retVal.NextRunDateTime = DateTimeService.SystemUtcDateTimeNow;
            retVal.StartTime = new TimeSpan(7, 0, 0);
            retVal.EndTime = new TimeSpan(19, 0, 0);
            retVal.Interval = 10;
            retVal.IsEnabled = true;
            retVal.TaskImplementationType = Guid.NewGuid().ToString();
            retVal.TaskParameters = Guid.NewGuid().ToString();
            retVal.ParentScheduledJobs.Add(new EntityId(3));
            retVal.ChildScheduledJobs.Add(new EntityId(4));
            retVal.IsRunning = false;

            return retVal;
        }
    }
}
