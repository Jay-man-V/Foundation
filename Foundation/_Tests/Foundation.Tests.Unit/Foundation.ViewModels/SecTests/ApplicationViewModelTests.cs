//-----------------------------------------------------------------------
// <copyright file="ApplicationViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ApplicationViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationViewModelTests : GenericDataGridViewModelTestBaseClass<IApplication, IApplicationViewModel, IApplicationProcess>
    {
        protected override String ExpectedScreenTitle => "Applications";
        protected override String ExpectedStatusBarText => "Number of Applications:";

        protected override IApplicationViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationViewModel viewModel = new ApplicationViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IApplicationProcess CreateBusinessProcess()
        {
            IApplicationProcess process = Substitute.For<IApplicationProcess>();

            return process;
        }

        protected override IApplication CreateModel()
        {
            IApplication retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
