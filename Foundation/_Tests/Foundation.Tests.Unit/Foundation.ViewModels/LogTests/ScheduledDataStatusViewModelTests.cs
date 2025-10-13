//-----------------------------------------------------------------------
// <copyright file="ScheduledDataStatusViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Log;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.LogTests
{
    /// <summary>
    /// Summary description for ScheduledDataStatusViewModelTests
    /// </summary>
    [TestFixture]
    public class ScheduledDataStatusViewModelTests : GenericDataGridViewModelTests<IScheduledDataStatus, IScheduledDataStatusViewModel, IScheduledDataStatusProcess>
    {
        protected override IScheduledDataStatusProcess CreateBusinessProcess()
        {
            IScheduledDataStatusProcess process = Substitute.For<IScheduledDataStatusProcess>();

            return process;
        }

        protected override IScheduledDataStatus CreateBlankModel(Int32 entityId)
        {
            IScheduledDataStatus retVal = Substitute.For<IScheduledDataStatus>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IScheduledDataStatus CreateModel(Int32 entityId)
        {
            IScheduledDataStatus retVal = base.CreateModel(entityId);

            retVal.DataDate = DateTimeService.SystemUtcDateTimeNow;
            retVal.Name = Guid.NewGuid().ToString();
            retVal.DataStatusId = new EntityId(1);

            return retVal;
        }

        protected override IScheduledDataStatusViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IScheduledDataStatusViewModel viewModel = new ScheduledDataStatusViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
