//-----------------------------------------------------------------------
// <copyright file="ApprovalStatusViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ApprovalStatusViewModelTests
    /// </summary>
    [TestFixture]
    public class ApprovalStatusViewModelTests : GenericDataGridViewModelTestBaseClass<IApprovalStatus, IApprovalStatusViewModel, IApprovalStatusProcess>
    {
        protected override String ExpectedScreenTitle => "Approval Statuses";
        protected override String ExpectedStatusBarText => "Number of Approval Statuses:";

        protected override IApprovalStatusViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApprovalStatusViewModel viewModel = new ApprovalStatusViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IApprovalStatusProcess CreateBusinessProcess()
        {
            IApprovalStatusProcess process = Substitute.For<IApprovalStatusProcess>();

            return process;
        }

        protected override IApprovalStatus CreateModel()
        {
            IApprovalStatus retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
