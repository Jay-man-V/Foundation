//-----------------------------------------------------------------------
// <copyright file="LanguageViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core
{
    /// <summary>
    /// The User Interface interaction logic for Language maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{ILanguage}" />
    [DependencyInjectionTransient]
    public class LanguageViewModel : GenericDataGridViewModelBase<ILanguage>, ILanguageViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LanguageViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="languageProcess">The language process.</param>
        public LanguageViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            ILanguageProcess languageProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                languageProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, languageProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
