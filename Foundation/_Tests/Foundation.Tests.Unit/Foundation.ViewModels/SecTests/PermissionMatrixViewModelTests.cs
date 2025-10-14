//-----------------------------------------------------------------------
// <copyright file="PermissionMatrixViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for PermissionMatrixViewModelTests
    /// </summary>
    [TestFixture]
    public class PermissionMatrixViewModelTests : GenericDataGridViewModelTests<IPermissionMatrix, IPermissionMatrixViewModel, IPermissionMatrixProcess>
    {
        protected override IPermissionMatrixProcess CreateBusinessProcess()
        {
            IPermissionMatrixProcess process = Substitute.For<IPermissionMatrixProcess>();

            return process;
        }

        protected override IPermissionMatrix CreateBlankModel(Int32 entityId)
        {
            IPermissionMatrix retVal = new PermissionMatrix();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IPermissionMatrix CreateModel(Int32 entityId)
        {
            IPermissionMatrix retVal = base.CreateModel(entityId);

            retVal.ApplicationId = new AppId(1);
            retVal.RoleId = new EntityId(1);
            retVal.UserProfileId = new EntityId(1);
            retVal.FunctionKey = Guid.NewGuid().ToString();
            retVal.Permission = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IPermissionMatrixViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IPermissionMatrixViewModel viewModel = new PermissionMatrixViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
