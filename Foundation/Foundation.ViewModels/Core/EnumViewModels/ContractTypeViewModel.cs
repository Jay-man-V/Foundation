//-----------------------------------------------------------------------
// <copyright file="ContractTypeViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Contract Type maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IContractType}" />
    [DependencyInjectionTransient]
    public class ContractTypeViewModel : GenericDataGridViewModelBase<IContractType>, IContractTypeViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ContractTypeViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="contractTypeProcess">The contract type process.</param>
        public ContractTypeViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IContractTypeProcess contractTypeProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                contractTypeProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, contractTypeProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
