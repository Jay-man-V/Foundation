//-----------------------------------------------------------------------
// <copyright file="ContractViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core
{
    /// <summary>
    /// The User Interface interaction logic for Contract maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IContract}" />
    [DependencyInjectionTransient]
    public class ContractViewModel : GenericDataGridViewModelBase<IContract>, IContractViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ContractViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="contractProcess">The contract process.</param>
        /// <param name="contractTypeProcess">The contract type process.</param>
        public ContractViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IContractProcess contractProcess,
            IContractTypeProcess contractTypeProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                contractProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, contractProcess, contractTypeProcess);

            ContractProcess = contractProcess;
            ContractTypeProcess = contractTypeProcess;

            AllContracts = [];

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the contract process.
        /// </summary>
        /// <value>
        /// The contract process.
        /// </value>
        private IContractProcess ContractProcess { get; }

        /// <summary>
        /// Gets the contract type process.
        /// </summary>
        /// <value>
        /// The contract type process.
        /// </value>
        private IContractTypeProcess ContractTypeProcess { get; }

        /// <summary>
        /// Gets or sets all contracts.
        /// </summary>
        /// <value>
        /// All contracts.
        /// </value>
        private List<IContract> AllContracts { get; set; }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            List<IContractType> allContractTypes = ContractTypeProcess.GetAll();

            ContractTypeProcess.AddFilterOptionsAdditional(allContractTypes);

            Filter1DataSource = allContractTypes;
            Filter1SelectedItem = allContractTypes[0];

            base.Initialise();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="RefreshData()"/>
        protected override List<IContract> RefreshData()
        {
            LoggingHelpers.TraceCallEnter();

            AllContracts = base.RefreshData();
            ApplyFilter1(Filter1SelectedItem);

            LoggingHelpers.TraceCallReturn(AllContracts);

            return AllContracts;
        }

        /// <inheritdoc cref="ApplyFilter1(Object)"/>
        protected override void ApplyFilter1(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            if (selectedFilter is IContractType contractType)
            {
                List<IContract> filteredData = ContractProcess.ApplyFilter(AllContracts, contractType);

                GridDataSource = filteredData;
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
