//-----------------------------------------------------------------------
// <copyright file="ApplicationUserRoleViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Sec;
using Foundation.ViewModels.Sec;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.SecTests
{
    /// <summary>
    /// Summary description for ApplicationUserRoleViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationUserRoleViewModelTests : GenericDataGridViewModelTests<IApplicationUserRole, IApplicationUserRoleViewModel, IApplicationUserRoleProcess>
    {
        protected override IApplicationUserRoleProcess CreateBusinessProcess()
        {
            IApplicationUserRoleProcess process = Substitute.For<IApplicationUserRoleProcess>();

            return process;
        }

        protected override IApplicationUserRole CreateBlankModel(Int32 entityId)
        {
            IApplicationUserRole retVal = new ApplicationUserRole();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApplicationUserRole CreateModel(Int32 entityId)
        {
            IApplicationUserRole retVal = base.CreateModel(entityId);

            retVal.ApplicationId = new AppId(1);
            retVal.UserProfileId = new EntityId(2);
            retVal.RoleId = new EntityId(3);

            return retVal;
        }

        protected override IApplicationUserRoleViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationUserRoleViewModel viewModel = new ApplicationUserRoleViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
