//-----------------------------------------------------------------------
// <copyright file="ApplicationApplicationTypeViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ApplicationApplicationTypeViewModelTests
    /// </summary>
    [TestFixture]
    public class ApplicationApplicationTypeViewModelTests : GenericDataGridViewModelTests<IApplicationApplicationType, IApplicationApplicationTypeViewModel, IApplicationApplicationTypeProcess>
    {
        protected override IApplicationApplicationTypeProcess CreateBusinessProcess()
        {
            IApplicationApplicationTypeProcess process = Substitute.For<IApplicationApplicationTypeProcess>();

            return process;
        }

        protected override IApplicationApplicationType CreateBlankModel(Int32 entityId)
        {
            IApplicationApplicationType retVal = new ApplicationApplicationType();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IApplicationApplicationType CreateModel(Int32 entityId)
        {
            IApplicationApplicationType retVal = base.CreateModel(entityId);

            retVal.ApplicationId = new AppId(1);
            retVal.ApplicationTypeId = new EntityId(2);

            return retVal;
        }

        protected override IApplicationApplicationTypeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IApplicationApplicationTypeViewModel viewModel = new ApplicationApplicationTypeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
