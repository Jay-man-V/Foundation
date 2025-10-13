//-----------------------------------------------------------------------
// <copyright file="ContractTypeViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

using NUnit.Framework;

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Core.EnumViewModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.CoreTests
{
    /// <summary>
    /// Summary description for ContractTypeViewModelTests
    /// </summary>
    [TestFixture]
    public class ContractTypeViewModelTests : GenericDataGridViewModelTestBaseClass<IContractType, IContractTypeViewModel, IContractTypeProcess>
    {
        protected override String ExpectedScreenTitle => "Contract Types";
        protected override String ExpectedStatusBarText => "Number of Contract Types:";

        protected override IContractTypeViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            IContractTypeViewModel viewModel = new ContractTypeViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess);

            return viewModel;
        }

        protected override IContractTypeProcess CreateBusinessProcess()
        {
            IContractTypeProcess process = Substitute.For<IContractTypeProcess>();

            return process;
        }

        protected override IContractType CreateModel()
        {
            IContractType retVal = base.CreateModel();

            retVal.Name = Guid.NewGuid().ToString();
            retVal.Description = Guid.NewGuid().ToString();

            return retVal;
        }
    }
}
