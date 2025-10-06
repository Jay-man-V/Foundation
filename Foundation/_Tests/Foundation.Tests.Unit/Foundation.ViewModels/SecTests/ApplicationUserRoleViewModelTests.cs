//-----------------------------------------------------------------------
// <copyright file="ApplicationUserRoleViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Sec;

namespace Foundation.Tests.Unit.Foundation.ViewModels.SecTests
{
    /// <summary>
    /// Summary description for ApplicationUserRoleViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationUserRoleViewModelTests : GenericDataGridViewModelTestBaseClass<IApplicationUserRole, IApplicationUserRoleViewModel, IApplicationUserRoleProcess>
    {
        protected override String ExpectedScreenTitle => "Application/User/Roles";
        protected override String ExpectedStatusBarText => "Number of Application/User/Roles:";

        protected override IApplicationUserRoleViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationUserRoleViewModel viewModel = new ApplicationUserRoleViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IApplicationUserRoleProcess CreateBusinessProcess()
        {
            IApplicationUserRoleProcess process = Substitute.For<IApplicationUserRoleProcess>();

            return process;
        }

        protected override IApplicationUserRole CreateModel()
        {
            IApplicationUserRole retVal = base.CreateModel();

            retVal.ApplicationId = new AppId(1);
            retVal.UserProfileId = new EntityId(2);
            retVal.RoleId = new EntityId(3);

            return retVal;
        }
    }
}
