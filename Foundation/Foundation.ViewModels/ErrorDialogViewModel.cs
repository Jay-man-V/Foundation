//-----------------------------------------------------------------------
// <copyright file="ErrorDialogViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;

using Foundation.Common;
using Foundation.Interfaces;

using FEnums = Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Error Dialogs
    /// </summary>
    public class ErrorDialogViewModel : MessageDialogViewModel
    {
        /// <summary>Initialises a new instance of the <see cref="ErrorDialogViewModel" /> class.</summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="targetWindow">The target window.</param>
        /// <param name="parentViewModel">The parent view model.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="continueVisibility">The continue visibility.</param>
        public ErrorDialogViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IWindow targetWindow,
            IViewModel parentViewModel,
            Exception exception,
            Visibility continueVisibility
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                targetWindow,
                parentViewModel,
                FEnums.MessageBoxImage.Error,
                exception,
                "Application Error"
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, targetWindow, parentViewModel, exception, continueVisibility);

            ContinueVisibility = continueVisibility;

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            // Nothing to do

            LoggingHelpers.TraceCallReturn();
        }
    }
}
