//-----------------------------------------------------------------------
// <copyright file="ContractViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels.Core;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ContractViewModelTests
    /// </summary>
    [TestFixture]
    public class ContractViewModelTests : GenericDataGridViewModelTestBaseClass<IContract, IContractViewModel, IContractProcess>
    {
        protected override String ExpectedScreenTitle => "Contracts";
        protected override String ExpectedStatusBarText => "Number of Contracts:";

        protected override Boolean ExpectedHasOptionalDropDownParameter1 => true;
        protected override String ExpectedFilter1Name => "Contract Type:";
        protected override string ExpectedFilter1DisplayMemberPath => FDC.ContractType.Description;

        private IContractTypeProcess ContractTypeProcess { get; set; }

        protected override IContractViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IContractViewModel viewModel = new ContractViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess, ContractTypeProcess);

            return viewModel;
        }

        protected override IContractProcess CreateBusinessProcess()
        {
            ContractTypeProcess = Substitute.For<IContractTypeProcess>();
            IContractProcess process = Substitute.For<IContractProcess>();

            return process;
        }

        protected override IContract CreateModel()
        {
            IContract retVal = base.CreateModel();

            retVal.ContractTypeId = new EntityId(1);
            retVal.ContractReference = Guid.NewGuid().ToString();
            retVal.ShortName = Guid.NewGuid().ToString();
            retVal.FullName = Guid.NewGuid().ToString();
            retVal.StartDate = DateTimeService.SystemUtcDateTimeNow;
            retVal.EndDate = DateTimeService.SystemUtcDateTimeNow;

            return retVal;
        }

        protected override void SetupForRefreshData()
        {
            base.SetupForRefreshData();

            List<IContractType> allContractTypes = new List<IContractType>
            {
                CoreInstance.IoC.Get<IContractType>(),
            };
            ContractTypeProcess.GetAll().Returns(allContractTypes);

            List<IContract> filteredData = new List<IContract>();
            BusinessProcess.ApplyFilter(Arg.Any<List<IContract>>(), Arg.Any<IContractType>()).Returns(filteredData);
        }

        protected override Object CreateModelForDropDown1()
        {
            return CoreInstance.IoC.Get<IContactType>();
        }
    }
}
