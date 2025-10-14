//-----------------------------------------------------------------------
// <copyright file="StatusViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Core.EnumModels;
using Foundation.ViewModels.Core.EnumViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for StatusViewModelTests
    /// </summary>
    [TestFixture]
    public class StatusViewModelTests : GenericDataGridViewModelTests<IStatus, IStatusViewModel, IStatusProcess>
    {
        protected override IStatusProcess CreateBusinessProcess()
        {
            IStatusProcess process = Substitute.For<IStatusProcess>();

            return process;
        }

        protected override IStatus CreateBlankModel(Int32 entityId)
        {
            IStatus retVal = new Status();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IStatus CreateModel(Int32 entityId)
        {
            IStatus retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IStatusViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IStatusViewModel viewModel = new StatusViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
