//-----------------------------------------------------------------------
// <copyright file="EventLogAttachmentViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for EventLogAttachmentViewModelTests
    /// </summary>
    [TestFixture]
    public class EventLogAttachmentViewModelTests : GenericDataGridViewModelTests<IEventLogAttachment, IEventLogAttachmentViewModel, IEventLogAttachmentProcess>
    {
        protected override IEventLogAttachmentProcess CreateBusinessProcess()
        {
            IEventLogAttachmentProcess process = Substitute.For<IEventLogAttachmentProcess>();

            return process;
        }

        protected override IEventLogAttachment CreateBlankModel(Int32 entityId)
        {
            IEventLogAttachment retVal = new EventLogAttachment();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IEventLogAttachment CreateModel(Int32 entityId)
        {
            IEventLogAttachment retVal = base.CreateModel(entityId);

            retVal.EventLogId = new LogId(1);
            retVal.AttachmentFileName = Guid.NewGuid().ToString();
            retVal.Attachment = new Byte[123];

            return retVal;
        }

        protected override IEventLogAttachmentViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IEventLogAttachmentViewModel viewModel = new EventLogAttachmentViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
