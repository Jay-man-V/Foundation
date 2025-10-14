//-----------------------------------------------------------------------
// <copyright file="ApplicationTypeViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ApplicationTypeViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationTypeViewModelTests : GenericDataGridViewModelTests<IApplicationType, IApplicationTypeViewModel, IApplicationTypeProcess>
    {
        protected override IApplicationTypeProcess CreateBusinessProcess()
        {
            IApplicationTypeProcess process = Substitute.For<IApplicationTypeProcess>();

            return process;
        }

        protected override IApplicationType CreateBlankModel(Int32 entityId)
        {
            IApplicationType retVal = new ApplicationType();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApplicationType CreateModel(Int32 entityId)
        {
            IApplicationType retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IApplicationTypeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationTypeViewModel viewModel = new ApplicationTypeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
