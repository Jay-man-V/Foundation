//-----------------------------------------------------------------------
// <copyright file="ContactTypeViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core.EnumViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Contact Type maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IContactType}" />
    [DependencyInjectionTransient]
    public class ContactTypeViewModel : GenericDataGridViewModelBase<IContactType>, IContactTypeViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ContactTypeViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="contactTypeProcess">The contact type process.</param>
        public ContactTypeViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IContactTypeProcess contactTypeProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                contactTypeProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, contactTypeProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
