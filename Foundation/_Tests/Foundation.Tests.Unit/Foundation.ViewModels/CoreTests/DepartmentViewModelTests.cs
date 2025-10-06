//-----------------------------------------------------------------------
// <copyright file="DepartmentViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Core;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for DepartmentViewModelTests
    /// </summary>
    [TestFixture]
    public class DepartmentViewModelTests : GenericDataGridViewModelTestBaseClass<IDepartment, IDepartmentViewModel, IDepartmentProcess>
    {
        protected override String ExpectedScreenTitle => "Departments";
        protected override String ExpectedStatusBarText => "Number of Departments:";

        protected override IDepartmentViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IDepartmentViewModel viewModel = new DepartmentViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IDepartmentProcess CreateBusinessProcess()
        {
            IDepartmentProcess process = Substitute.For<IDepartmentProcess>();

            return process;
        }

        protected override IDepartment CreateModel()
        {
            IDepartment retVal = base.CreateModel();

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
