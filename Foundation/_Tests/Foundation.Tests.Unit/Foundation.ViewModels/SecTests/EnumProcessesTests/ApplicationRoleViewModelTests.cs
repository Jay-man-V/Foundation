//-----------------------------------------------------------------------
// <copyright file="ApplicationRoleViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Sec.EnumViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.SecTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for ApplicationRoleViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationRoleViewModelTests : GenericDataGridViewModelTests<IApplicationRole, IApplicationRoleViewModel, IApplicationRoleProcess>
    {
        protected override IApplicationRoleProcess CreateBusinessProcess()
        {
            IApplicationRoleProcess process = Substitute.For<IApplicationRoleProcess>();

            return process;
        }

        protected override IApplicationRole CreateBlankModel(int entityId)
        {
            IApplicationRole retVal = Substitute.For<IApplicationRole>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApplicationRole CreateModel(Int32 entityId)
        {
            IApplicationRole retVal = base.CreateModel(entityId);

            retVal.ApplicationId = new AppId(1);
            retVal.RoleId = new EntityId(2);

            return retVal;
        }

        protected override IApplicationRoleViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationRoleViewModel viewModel = new ApplicationRoleViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
