//-----------------------------------------------------------------------
// <copyright file="ScheduledDataStatusViewModelTests.cs" company="JDV Software Ltd">
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

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ScheduledDataStatusViewModelTests
    /// </summary>
    [TestFixture]
    public class ScheduledDataStatusViewModelTests : GenericDataGridViewModelTestBaseClass<IScheduledDataStatus, IScheduledDataStatusViewModel, IScheduledDataStatusProcess>
    {
        protected override String ExpectedScreenTitle => "Scheduled Data Statuses";
        protected override String ExpectedStatusBarText => "Number of Scheduled Data Statuses:";

        protected override IScheduledDataStatusViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IScheduledDataStatusViewModel viewModel = new ScheduledDataStatusViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IScheduledDataStatusProcess CreateBusinessProcess()
        {
            IScheduledDataStatusProcess process = Substitute.For<IScheduledDataStatusProcess>();

            return process;
        }

        protected override IScheduledDataStatus CreateModel()
        {
            IScheduledDataStatus retVal = base.CreateModel();

            retVal.DataDate = DateTimeService.SystemUtcDateTimeNow;
            retVal.Name = Guid.NewGuid().ToString();
            retVal.DataStatusId = new EntityId(1);

            return retVal;
        }
    }
}
