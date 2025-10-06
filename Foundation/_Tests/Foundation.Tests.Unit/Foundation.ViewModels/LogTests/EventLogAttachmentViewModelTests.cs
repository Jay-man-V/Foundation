//-----------------------------------------------------------------------
// <copyright file="EventLogAttachmentViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for EventLogAttachmentViewModelTests
    /// </summary>
    [TestFixture]
    public class EventLogAttachmentViewModelTests : GenericDataGridViewModelTestBaseClass<IEventLogAttachment, IEventLogAttachmentViewModel, IEventLogAttachmentProcess>
    {
        protected override String ExpectedScreenTitle => "Event Log Attachments";
        protected override String ExpectedStatusBarText => "Number of Event Log Attachments:";

        protected override IEventLogAttachmentViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IEventLogAttachmentViewModel viewModel = new EventLogAttachmentViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IEventLogAttachmentProcess CreateBusinessProcess()
        {
            IEventLogAttachmentProcess process = Substitute.For<IEventLogAttachmentProcess>();

            return process;
        }

        protected override IEventLogAttachment CreateModel()
        {
            IEventLogAttachment retVal = base.CreateModel();

            retVal.EventLogId = new LogId(1);
            retVal.AttachmentFileName = Guid.NewGuid().ToString();
            retVal.Attachment = new Byte[123];

            return retVal;
        }
    }
}
