//-----------------------------------------------------------------------
// <copyright file="EventLogViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Log;

namespace Foundation.Tests.Unit.Foundation.ViewModels.LogTests
{
    /// <summary>
    /// Summary description for EventLogViewModelTests
    /// </summary>
    [TestFixture]
    public class EventLogViewModelTests : GenericDataGridViewModelTestBaseClass<IEventLog, IEventLogViewModel, IEventLogProcess>
    {
        protected override String ExpectedScreenTitle => "Event Logs";
        protected override String ExpectedStatusBarText => "Number of Event Logs:";

        protected override IEventLogViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IEventLogViewModel viewModel = new EventLogViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IEventLogProcess CreateBusinessProcess()
        {
            IEventLogProcess process = Substitute.For<IEventLogProcess>();

            return process;
        }

        protected override IEventLog CreateModel()
        {
            IEventLog retVal = base.CreateModel();

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
    }
}
