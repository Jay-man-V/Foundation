//-----------------------------------------------------------------------
// <copyright file="MenuItemViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.App
{
    /// <summary>
    /// The User Interface interaction logic for MenuItem maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IMenuItem}" />
    [DependencyInjectionTransient]
    public class MenuItemViewModel : GenericDataGridViewModelBase<IMenuItem>, IMenuItemViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="MenuItemViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="menuItemProcess">The MenuItem process.</param>
        /// <param name="applicationProcess">The Application process.</param>
        public MenuItemViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IMenuItemProcess menuItemProcess,
            IApplicationProcess applicationProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                menuItemProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, menuItemProcess, applicationProcess);

            MenuItemProcess = menuItemProcess;
            ApplicationProcess = applicationProcess;

            AllMenuItems = [];

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the MenuItem process.
        /// </summary>
        /// <value>
        /// The MenuItem process.
        /// </value>
        private IMenuItemProcess MenuItemProcess { get; }

        /// <summary>
        /// Gets the Application process.
        /// </summary>
        /// <value>
        /// The Application process.
        /// </value>
        private IApplicationProcess ApplicationProcess { get; }

        /// <summary>
        /// Gets or sets all MenuItems.
        /// </summary>
        /// <value>
        /// All MenuItems.
        /// </value>
        private List<IMenuItem> AllMenuItems { get; set; }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            List<IApplication> allApplications = ApplicationProcess.GetAll();

            ApplicationProcess.AddFilterOptionsAdditional(allApplications);

            Filter1DataSource = allApplications;
            Filter1SelectedItem = allApplications[0];

            base.Initialise();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="RefreshData()"/>
        protected override List<IMenuItem> RefreshData()
        {
            LoggingHelpers.TraceCallEnter();

            AllMenuItems = base.RefreshData();

            OnFilter1SelectionChangedCommand_Execute(Filter1SelectedItem);

            List<IMenuItem> parentMenuItems = MenuItemProcess.MakeListOfParentMenuItems(AllMenuItems);

            MenuItemProcess.AddFilterOptionsAdditional(parentMenuItems);

            Filter2DataSource = parentMenuItems;
            Filter2SelectedItem = parentMenuItems[0];
            ApplyFilter2(Filter2SelectedItem);

            LoggingHelpers.TraceCallReturn(parentMenuItems);

            return parentMenuItems;
        }

        /// <inheritdoc cref="ApplyFilter1(Object)"/>
        protected override void ApplyFilter1(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            if (selectedFilter is IApplication application &&
                Filter2SelectedItem is IMenuItem menuItem)
            {
                List<IMenuItem> filteredData = MenuItemProcess.ApplyFilter(AllMenuItems, application, menuItem);

                GridDataSource = filteredData;
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ApplyFilter2(Object)"/>
        protected override void ApplyFilter2(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            if (Filter1SelectedItem is IApplication application &&
                selectedFilter is IMenuItem menuItem)
            {
                List<IMenuItem> filteredData = MenuItemProcess.ApplyFilter(AllMenuItems, application, menuItem);

                GridDataSource = filteredData;
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
