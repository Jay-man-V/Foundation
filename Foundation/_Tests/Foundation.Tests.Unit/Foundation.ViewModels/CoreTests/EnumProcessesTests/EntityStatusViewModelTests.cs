//-----------------------------------------------------------------------
// <copyright file="EntityStatusViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Core.EnumViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests.EnumProcessesTests
{
    /// <summary>
    /// Summary description for EntityStatusViewModelTests
    /// </summary>
    [TestFixture]
    public class EntityStatusViewModelTests : GenericDataGridViewModelTests<IEntityStatus, IEntityStatusViewModel, IEntityStatusProcess>
    {
        protected override IEntityStatusProcess CreateBusinessProcess()
        {
            IEntityStatusProcess process = Substitute.For<IEntityStatusProcess>();

            return process;
        }

        protected override IEntityStatus CreateBlankModel(Int32 entityId)
        {
            IEntityStatus retVal = Substitute.For<IEntityStatus>();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IEntityStatus CreateModel(Int32 entityId)
        {
            IEntityStatus retVal = base.CreateModel(entityId);

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IEntityStatusViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IEntityStatusViewModel viewModel = new EntityStatusViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
