//-----------------------------------------------------------------------
// <copyright file="ProgressBarViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Support
{
    /// <summary>
    /// The User Interface interaction logic for the Progress Bar
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IApprovalStatus}" />
    public class ProgressBarViewModel : ViewModelBase
    {
        /// <summary>Initialises a new instance of the <see cref="ProgressBarViewModel" /> class.</summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="targetWindow">The target window.</param>
        /// <param name="parentViewModel">The parent view model.</param>
        public ProgressBarViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IWindow targetWindow,
            IViewModel parentViewModel
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                "Progress Bar"
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, targetWindow, parentViewModel);

            DisplayedWindow = null;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets or sets the displayed window.
        /// </summary>
        /// <value>
        /// The displayed window.
        /// </value>
        public IWindow? DisplayedWindow { get; set; }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            // Nothing to do

            LoggingHelpers.TraceCallReturn();
        }
    }
}
