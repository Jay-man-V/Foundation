//-----------------------------------------------------------------------
// <copyright file="TaskStatusViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for TaskStatusViewModelTests
    /// </summary>
    [TestFixture]
    public class TaskStatusViewModelTests : GenericDataGridViewModelTestBaseClass<ITaskStatus, ITaskStatusViewModel, ITaskStatusProcess>
    {
        protected override String ExpectedScreenTitle => "Task Statuses";
        protected override String ExpectedStatusBarText => "Number of Task Statuses:";

        protected override ITaskStatusViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ITaskStatusViewModel viewModel = new TaskStatusViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override ITaskStatusProcess CreateBusinessProcess()
        {
            ITaskStatusProcess process = Substitute.For<ITaskStatusProcess>();

            return process;
        }

        protected override ITaskStatus CreateModel()
        {
            ITaskStatus retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
