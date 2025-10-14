//-----------------------------------------------------------------------
// <copyright file="TaskStatusViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for TaskStatusViewModelTests
    /// </summary>
    [TestFixture]
    public class TaskStatusViewModelTests : GenericDataGridViewModelTests<ITaskStatus, ITaskStatusViewModel, ITaskStatusProcess>
    {
        protected override ITaskStatusProcess CreateBusinessProcess()
        {
            ITaskStatusProcess process = Substitute.For<ITaskStatusProcess>();

            return process;
        }

        protected override ITaskStatus CreateBlankModel(Int32 entityId)
        {
            ITaskStatus retVal = new FModels.TaskStatus();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ITaskStatus CreateModel(Int32 entityId)
        {
            ITaskStatus retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override ITaskStatusViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ITaskStatusViewModel viewModel = new TaskStatusViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
