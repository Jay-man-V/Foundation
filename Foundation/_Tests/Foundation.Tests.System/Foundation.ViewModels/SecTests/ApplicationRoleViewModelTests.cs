//-----------------------------------------------------------------------
// <copyright file="ApplicationRoleViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Sec.EnumViewModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.SecTests
{
    /// <summary>
    /// Summary description for ApplicationRoleViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationRoleViewModelTests : GenericDataGridViewModelTestBaseClass<IApplicationRole, IApplicationRoleViewModel, IApplicationRoleProcess>
    {
        protected override String ExpectedScreenTitle => "Application Roles";
        protected override String ExpectedStatusBarText => "Number of Application Roles:";

        protected override IApplicationRoleViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationRoleViewModel viewModel = new ApplicationRoleViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IApplicationRoleProcess CreateBusinessProcess()
        {
            IApplicationRoleProcess process = Substitute.For<IApplicationRoleProcess>();

            return process;
        }

        protected override IApplicationRole CreateModel()
        {
            IApplicationRole retVal = base.CreateModel();

            retVal.ApplicationId = new AppId(1);
            retVal.RoleId = new EntityId(2);

            return retVal;
        }
    }
}
