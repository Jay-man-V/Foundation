//-----------------------------------------------------------------------
// <copyright file="ContractProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;

using FDC = Foundation.Common.DataColumns;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// The Contract Business Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class ContractProcess : CommonBusinessProcess<IContract, IContractRepository>, IContractProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ContractProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        /// <param name="contractTypeProcess">The contract type process.</param>
        public ContractProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IContractRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            IContractTypeProcess contractTypeProcess
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                repository,
                statusRepository,
                userProfileRepository
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, userProfileRepository, contractTypeProcess);

            ContractTypeProcess = contractTypeProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the contract type process.
        /// </summary>
        /// <value>
        /// The contract type process.
        /// </value>
        private IContractTypeProcess ContractTypeProcess { get; }

        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter1"/>
        public override Boolean HasOptionalDropDownParameter1 => true;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1Name"/>
        public override String Filter1Name => "Contract Type:";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1DisplayMemberPath"/>
        public override String Filter1DisplayMemberPath => ContractTypeProcess.ComboBoxDisplayMember;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1SelectedValuePath"/>
        public override String Filter1SelectedValuePath => ContractTypeProcess.ComboBoxValueMember;


        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Contracts";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Contracts:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.Contract.ShortName;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Contract.ContractTypeId, "Type", typeof(String))
            {
                TextAlignment = TextAlignment.Centre,
                DataSource = ContractTypeProcess.GetAll(excludeDeleted: false),
                ValueMember = ContractTypeProcess.ComboBoxValueMember,
                DisplayMember = ContractTypeProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Contract.ContractReference, "Reference", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(115, FDC.Contract.StartDate, "Start Date", typeof(DateTime))
            {
                DotNetFormat = Formats.DotNet.DateOnly,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(115, FDC.Contract.EndDate, "End Date", typeof(DateTime))
            {
                DotNetFormat = Formats.DotNet.DateOnly,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Contract.ShortName, "Short Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.Contract.FullName, "Full Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IContractProcess.ApplyFilter(List{IContract}, IContractType)"/>
        public List<IContract> ApplyFilter(List<IContract> contracts, IContractType contractType)
        {
            LoggingHelpers.TraceCallEnter(contracts, contractType);

            List<IContract> retVal = contracts;

            if (contractType != null)
            {
                retVal = retVal.Where(c => (c.ContractTypeId == contractType.Id) ||                         // Matching Contract Type
                                           (contractType.Id == ContractTypeProcess.AllId) ||                // All records
                                           (contractType.Id == ContractTypeProcess.NoneId &&
                                            c.ContractTypeId == ContractTypeProcess.NullId)                 // No Contract Type
                                      ).ToList();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
