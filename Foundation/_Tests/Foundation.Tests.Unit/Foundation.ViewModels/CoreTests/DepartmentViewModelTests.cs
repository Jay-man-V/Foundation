//-----------------------------------------------------------------------
// <copyright file="DepartmentViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Core;
using Foundation.ViewModels.Core;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for DepartmentViewModelTests
    /// </summary>
    [TestFixture]
    public class DepartmentViewModelTests : GenericDataGridViewModelTests<IDepartment, IDepartmentViewModel, IDepartmentProcess>
    {
        protected override IDepartmentProcess CreateBusinessProcess()
        {
            IDepartmentProcess process = Substitute.For<IDepartmentProcess>();

            return process;
        }

        protected override IDepartment CreateBlankModel(Int32 entityId)
        {
            IDepartment retVal = new Department();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IDepartment CreateModel(Int32 entityId)
        {
            IDepartment retVal = base.CreateModel(entityId);

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IDepartmentViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IDepartmentViewModel viewModel = new DepartmentViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
