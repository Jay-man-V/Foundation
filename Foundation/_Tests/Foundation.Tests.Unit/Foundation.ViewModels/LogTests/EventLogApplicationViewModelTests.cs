//-----------------------------------------------------------------------
// <copyright file="EventLogApplicationViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for EventLogApplicationViewModelTests
    /// </summary>
    [TestFixture]
    public class EventLogApplicationViewModelTests : GenericDataGridViewModelTests<IEventLogApplication, IEventLogApplicationViewModel, IEventLogApplicationProcess>
    {
        protected override IEventLogApplicationProcess CreateBusinessProcess()
        {
            IEventLogApplicationProcess process = Substitute.For<IEventLogApplicationProcess>();

            return process;
        }

        protected override IEventLogApplication CreateBlankModel(Int32 entityId)
        {
            IEventLogApplication retVal = Substitute.For<IEventLogApplication>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IEventLogApplication CreateModel(Int32 entityId)
        {
            IEventLogApplication retVal = base.CreateModel(entityId);

            retVal.ApplicationId = new AppId(1);
            retVal.ProcessName = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IEventLogApplicationViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IEventLogApplicationViewModel viewModel = new EventLogApplicationViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
