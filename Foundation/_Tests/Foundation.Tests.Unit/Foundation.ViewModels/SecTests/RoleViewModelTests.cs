//-----------------------------------------------------------------------
// <copyright file="RoleViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models;
using Foundation.Models.Sec;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Sec;

namespace Foundation.Tests.Unit.Foundation.ViewModels.SecTests
{
    /// <summary>
    /// Summary description for RoleViewModelTests
    /// </summary>
    [TestFixture]
    public class RoleViewModelTests : GenericDataGridViewModelTestBaseClass<IRole, IRoleViewModel, IRoleProcess>
    {
        protected override String ExpectedScreenTitle => "Roles";
        protected override String ExpectedStatusBarText => "Number of Roles:";

        protected override IRoleViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IRoleViewModel viewModel = new RoleViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IRoleProcess CreateBusinessProcess()
        {
            IRoleProcess process = Substitute.For<IRoleProcess>();

            return process;
        }

        protected override IRole CreateModel()
        {
            IRole retVal = base.CreateModel();
            Role role = (Role)retVal;

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();
            role.SystemSupportOnly = true;

            return retVal;
        }
    }
}
