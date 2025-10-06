//-----------------------------------------------------------------------
// <copyright file="ApplicationTypeViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ApplicationTypeViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationTypeViewModelTests : GenericDataGridViewModelTestBaseClass<IApplicationType, IApplicationTypeViewModel, IApplicationTypeProcess>
    {
        protected override String ExpectedScreenTitle => "Application Types";
        protected override String ExpectedStatusBarText => "Number of Application Types:";

        protected override IApplicationTypeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationTypeViewModel viewModel = new ApplicationTypeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IApplicationTypeProcess CreateBusinessProcess()
        {
            IApplicationTypeProcess process = Substitute.For<IApplicationTypeProcess>();

            return process;
        }

        protected override IApplicationType CreateModel()
        {
            IApplicationType retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
