//-----------------------------------------------------------------------
// <copyright file="ScheduledJobViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ScheduledJobViewModelTests
    /// </summary>
    [TestFixture]
    public class ScheduledJobViewModelTests : GenericDataGridViewModelTests<IScheduledJob, IScheduledJobViewModel, IScheduledJobProcess>
    {
        protected override IScheduledJobProcess CreateBusinessProcess()
        {
            IScheduledJobProcess process = Substitute.For<IScheduledJobProcess>();

            return process;
        }

        protected override IScheduledJob CreateBlankModel(Int32 entityId)
        {
            IScheduledJob retVal = new ScheduledJob();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IScheduledJob CreateModel(Int32 entityId)
        {
            IScheduledJob retVal = base.CreateModel(entityId);

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

        protected override IScheduledJobViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IScheduledJobViewModel viewModel = new ScheduledJobViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
