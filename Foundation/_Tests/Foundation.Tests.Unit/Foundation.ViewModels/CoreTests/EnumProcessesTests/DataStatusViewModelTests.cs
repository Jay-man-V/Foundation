//-----------------------------------------------------------------------
// <copyright file="DataStatusViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Core.EnumViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

using FModels = Foundation.Models.Core.EnumModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for DataStatusViewModelTests
    /// </summary>
    [TestFixture]
    public class DataStatusViewModelTests : GenericDataGridViewModelTests<IDataStatus, IDataStatusViewModel, IDataStatusProcess>
    {
        protected override IDataStatusProcess CreateBusinessProcess()
        {
            IDataStatusProcess process = Substitute.For<IDataStatusProcess>();

            return process;
        }

        protected override IDataStatus CreateBlankModel(Int32 entityId)
        {
            IDataStatus retVal = new FModels.DataStatus();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IDataStatus CreateModel(Int32 entityId)
        {
            IDataStatus retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IDataStatusViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IDataStatusViewModel viewModel = new DataStatusViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
