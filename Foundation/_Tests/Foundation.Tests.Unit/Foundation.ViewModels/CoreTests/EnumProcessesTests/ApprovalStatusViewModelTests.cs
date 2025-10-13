//-----------------------------------------------------------------------
// <copyright file="ApprovalStatusViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Core.EnumViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ApprovalStatusViewModelTests
    /// </summary>
    [TestFixture]
    public class ApprovalStatusViewModelTests : GenericDataGridViewModelTests<IApprovalStatus, IApprovalStatusViewModel, IApprovalStatusProcess>
    {
        protected override IApprovalStatusProcess CreateBusinessProcess()
        {
            IApprovalStatusProcess process = Substitute.For<IApprovalStatusProcess>();

            return process;
        }

        protected override IApprovalStatus CreateBlankModel(Int32 entityId)
        {
            IApprovalStatus retVal = Substitute.For<IApprovalStatus>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApprovalStatus CreateModel(Int32 entityId)
        {
            IApprovalStatus retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IApprovalStatusViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApprovalStatusViewModel viewModel = new ApprovalStatusViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
