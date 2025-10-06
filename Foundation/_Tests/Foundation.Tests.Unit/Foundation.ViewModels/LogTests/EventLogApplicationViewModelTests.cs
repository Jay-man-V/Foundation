//-----------------------------------------------------------------------
// <copyright file="EventLogApplicationViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for EventLogApplicationViewModelTests
    /// </summary>
    [TestFixture]
    public class EventLogApplicationViewModelTests : GenericDataGridViewModelTestBaseClass<IEventLogApplication, IEventLogApplicationViewModel, IEventLogApplicationProcess>
    {
        protected override String ExpectedScreenTitle => "Event Log Applications";
        protected override String ExpectedStatusBarText => "Number of Event Log Applications:";

        protected override IEventLogApplicationViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IEventLogApplicationViewModel viewModel = new EventLogApplicationViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IEventLogApplicationProcess CreateBusinessProcess()
        {
            IEventLogApplicationProcess process = Substitute.For<IEventLogApplicationProcess>();

            return process;
        }

        protected override IEventLogApplication CreateModel()
        {
            IEventLogApplication retVal = base.CreateModel();

            retVal.ApplicationId = new AppId(1);
            retVal.ProcessName = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
