//-----------------------------------------------------------------------
// <copyright file="PermissionMatrixViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for PermissionMatrixViewModelTests
    /// </summary>
    [TestFixture]
    public class PermissionMatrixViewModelTests : GenericDataGridViewModelTestBaseClass<IPermissionMatrix, IPermissionMatrixViewModel, IPermissionMatrixProcess>
    {
        protected override String ExpectedScreenTitle => "Permissions Matrix";
        protected override String ExpectedStatusBarText => "Number of Permission Matrices:";

        protected override IPermissionMatrixViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IPermissionMatrixViewModel viewModel = new PermissionMatrixViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IPermissionMatrixProcess CreateBusinessProcess()
        {
            IPermissionMatrixProcess process = Substitute.For<IPermissionMatrixProcess>();

            return process;
        }

        protected override IPermissionMatrix CreateModel()
        {
            IPermissionMatrix retVal = base.CreateModel();

            retVal.ApplicationId = new AppId(1);
            retVal.RoleId = new EntityId(1);
            retVal.UserProfileId = new EntityId(1);
            retVal.FunctionKey = Guid.NewGuid().ToString();
            retVal.Permission = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
