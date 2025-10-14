//-----------------------------------------------------------------------
// <copyright file="EventLogViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Log;
using Foundation.ViewModels.Log;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.LogTests
{
    /// <summary>
    /// Summary description for EventLogViewModelTests
    /// </summary>
    [TestFixture]
    public class EventLogViewModelTests : GenericDataGridViewModelTests<IEventLog, IEventLogViewModel, IEventLogProcess>
    {
        protected override IEventLogProcess CreateBusinessProcess()
        {
            IEventLogProcess process = Substitute.For<IEventLogProcess>();

            return process;
        }

        protected override IEventLog CreateBlankModel(Int32 entityId)
        {
            IEventLog retVal = new EventLog();

            retVal.Id = new LogId(entityId);

            return retVal;
        }

        protected override IEventLog CreateModel(Int32 entityId)
        {
            IEventLog retVal = base.CreateModel(entityId);

            retVal.ApplicationId = new AppId(1);
            retVal.ParentId = new LogId(1);
            retVal.LogSeverityId = new EntityId(1);
            retVal.ScheduledTaskId = new EntityId(1);
            retVal.BatchName = Guid.NewGuid().ToString();
            retVal.ProcessName = Guid.NewGuid().ToString();
            retVal.TaskName = Guid.NewGuid().ToString();
            retVal.TaskStatusId = new EntityId(1);
            retVal.StartedOn = DateTimeService.SystemUtcDateTimeNow;
            retVal.FinishedOn = DateTimeService.SystemUtcDateTimeNow;
            retVal.Information = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IEventLogViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IEventLogViewModel viewModel = new EventLogViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
