//-----------------------------------------------------------------------
// <copyright file="EnumViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// Implements generic routines for a Data Grid based view model
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class EnumViewModel<TModel> : GenericDataGridViewModel<TModel>, IEnumViewModel<TModel>
        where TModel : IFoundationModel
    {
        /// <summary>Initialises a new instance of the <see cref="GenericDataGridViewModel{TModel}" /> class.</summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="commonBusinessProcess">The common business process.</param>
        protected EnumViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            ICommonBusinessProcess<TModel> commonBusinessProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                commonBusinessProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, commonBusinessProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
