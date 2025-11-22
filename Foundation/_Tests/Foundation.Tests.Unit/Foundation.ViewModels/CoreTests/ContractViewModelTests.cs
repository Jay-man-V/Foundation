//-----------------------------------------------------------------------
// <copyright file="ContractViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Core;
using Foundation.ViewModels.Core;

using Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ContractViewModelTests
    /// </summary>
    [TestFixture]
    public class ContractViewModelTests : GenericDataGridViewModelTests<IContract, IContractViewModel, IContractProcess>
    {
        private IContractTypeProcess? ContractTypeProcess { get; set; }

        protected override IContractProcess CreateBusinessProcess()
        {
            ContractTypeProcess = Substitute.For<IContractTypeProcess>();
            IContractProcess process = Substitute.For<IContractProcess>();

            return process;
        }

        protected override IContract CreateBlankModel(int entityId)
        {
            IContract retVal = new Contract();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override IContract CreateModel(Int32 entityId)
        {
            IContract retVal = base.CreateModel(entityId);

            retVal.ContractTypeId = new EntityId(1);
            retVal.ContractReference = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.FullName = Guid.NewGuid().ToString();
            retVal.StartDate = DateTimeService.SystemUtcDateTimeNow;
            retVal.EndDate = DateTimeService.SystemUtcDateTimeNow;

            return retVal;
        }

        protected override IContractViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IContractViewModel viewModel = new ContractViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess, ContractTypeProcess!);

            return viewModel;
        }

        protected override void SetupForRefreshData()
        {
            base.SetupForRefreshData();

            List<IContractType> allContractTypes =
            [
                Substitute.For<IContractType>(),
            ];
            ContractTypeProcess!.GetAll().Returns(allContractTypes);

            List<IContract> filteredData = new List<IContract>();
            BusinessProcess.ApplyFilter(Arg.Any<List<IContract>>(), Arg.Any<IContractType>()).Returns(filteredData);
        }

        protected override Object CreateModelForDropDown1()
        {
            return Substitute.For<IContactType>();
        }
    }
}
