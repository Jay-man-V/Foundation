//-----------------------------------------------------------------------
// <copyright file="SearchEntityViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Dialogs
{
    /// <summary>
    /// The User Interface interaction logic for generic Entity Search screen
    /// </summary>
    public class SearchEntityViewModel : ViewModelBase
    {
        private List<string> _selectedListItems;
        private List<string> _availableListItems;

        /// <summary>Initialises a new instance of the <see cref="SearchEntityViewModel" /> class.</summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="targetWindow">The target window.</param>
        /// <param name="parentViewModel">The parent view model.</param>
        public SearchEntityViewModel
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
                "Search..."
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, targetWindow, parentViewModel);

            List<string> t1 = new List<string> { "1", "2", "3", "4", "5", "6" };
            List<string> t2 = new List<string> { "A", "B", "C", "D", "E", "F" };

            _selectedListItems = t1;
            _availableListItems = t2;

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            // Nothing to do

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>Gets or sets the selected list items.</summary>
        /// <value>The selected list items.</value>
        public List<string> SelectedListItems
        {
            get => _selectedListItems;
            set => SetPropertyValue(ref _selectedListItems, value);
        }

        /// <summary>Gets or sets the available list items.</summary>
        /// <value>The available list items.</value>
        public List<string> AvailableListItems
        {
            get => _availableListItems;
            set => SetPropertyValue(ref _availableListItems, value);
        }
    }
}
