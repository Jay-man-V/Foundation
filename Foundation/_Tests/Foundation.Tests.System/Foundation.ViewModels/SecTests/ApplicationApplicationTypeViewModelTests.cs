//-----------------------------------------------------------------------
// <copyright file="ApplicationApplicationTypeViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ApplicationApplicationTypeViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationApplicationTypeViewModelTests : GenericDataGridViewModelTestBaseClass<IApplicationApplicationType, IApplicationApplicationTypeViewModel, IApplicationApplicationTypeProcess>
    {
        protected override String ExpectedScreenTitle => "Application/Application Types";
        protected override String ExpectedStatusBarText => "Number of Application/Application Types:";

        protected override IApplicationApplicationTypeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationApplicationTypeViewModel viewModel = new ApplicationApplicationTypeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IApplicationApplicationTypeProcess CreateBusinessProcess()
        {
            IApplicationApplicationTypeProcess process = Substitute.For<IApplicationApplicationTypeProcess>();

            return process;
        }

        protected override IApplicationApplicationType CreateModel()
        {
            IApplicationApplicationType retVal = base.CreateModel();

            retVal.ApplicationId = new AppId(1);
            retVal.ApplicationTypeId = new EntityId(2);

            return retVal;
        }
    }
}
