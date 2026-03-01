//-----------------------------------------------------------------------
// <copyright file="ContractTypeViewModelTests.cs" company="JDV Software Ltd">
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
    /// Summary description for ContractTypeViewModelTests
    /// </summary>
    [TestFixture]
    public class ContractTypeViewModelTests : GenericDataGridViewModelTests<IContractType, IContractTypeViewModel, IContractTypeProcess>
    {
        protected override IContractTypeProcess CreateBusinessProcess()
        {
            IContractTypeProcess process = Substitute.For<IContractTypeProcess>();

            return process;
        }

        protected override IContractType CreateBlankModel(Int32 entityId)
        {
            IContractType retVal = new ContractType();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IContractType CreateModel(Int32 entityId)
        {
            IContractType retVal = base.CreateModel(entityId);

            retVal.Code = Guid.NewGuid().ToString();
            retVal.ShortDescription = Guid.NewGuid().ToString();
            retVal.LongDescription = Guid.NewGuid().ToString();

            return retVal;
        }

        protected override IContractTypeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IContractTypeViewModel viewModel = new ContractTypeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }
    }
}
