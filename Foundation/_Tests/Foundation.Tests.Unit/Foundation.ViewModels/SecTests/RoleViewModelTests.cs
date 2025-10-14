//-----------------------------------------------------------------------
// <copyright file="RoleViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for RoleViewModelTests
    /// </summary>
    [TestFixture]
    public class RoleViewModelTests : GenericDataGridViewModelTests<IRole, IRoleViewModel, IRoleProcess>
    {
        protected override IRoleProcess CreateBusinessProcess()
        {
            IRoleProcess process = Substitute.For<IRoleProcess>();

            return process;
        }

        protected override IRole CreateBlankModel(Int32 entityId)
        {
            IRole retVal = new Role();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IRole CreateModel(Int32 entityId)
        {
            IRole retVal = base.CreateModel(entityId);
            Role role = (Role)retVal;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();
            role.SystemSupportOnly = true;

            return retVal;
        }

        protected override IRoleViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IRoleViewModel viewModel = new RoleViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
