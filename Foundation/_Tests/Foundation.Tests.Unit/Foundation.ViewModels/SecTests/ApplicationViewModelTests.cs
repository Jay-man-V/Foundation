//-----------------------------------------------------------------------
// <copyright file="ApplicationViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ApplicationViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationViewModelTests : GenericDataGridViewModelTests<IApplication, IApplicationViewModel, IApplicationProcess>
    {
        protected override IApplicationProcess CreateBusinessProcess()
        {
            IApplicationProcess process = Substitute.For<IApplicationProcess>();

            return process;
        }

        protected override IApplication CreateBlankModel(Int32 entityId)
        {
            IApplication retVal = new Application();

            retVal.Id = new AppId(entityId);

            return retVal;
        }

        protected override IApplication CreateModel(Int32 entityId)
        {
            IApplication retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IApplicationViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationViewModel viewModel = new ApplicationViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
