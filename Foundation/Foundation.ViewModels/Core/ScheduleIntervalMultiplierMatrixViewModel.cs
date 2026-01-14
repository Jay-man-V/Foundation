//-----------------------------------------------------------------------
// <copyright file="ScheduleIntervalMultiplierMatrixViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core
{
    /// <summary>
    /// The User Interface interaction logic for Time Zone maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModel{IScheduleIntervalMultiplierMatrix}" />
    [DependencyInjectionTransient]
    public class ScheduleIntervalMultiplierMatrixViewModel : GenericDataGridViewModel<IScheduleIntervalMultiplierMatrix>, IScheduleIntervalMultiplierMatrixViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ScheduleIntervalMultiplierMatrixViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="scheduleIntervalMultiplierMatrixProcess">The schedule interval multiplier matrix process.</param>
        /// <param name="scheduleIntervalProcess">The schedule interval process.</param>
        public ScheduleIntervalMultiplierMatrixViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IScheduleIntervalMultiplierMatrixProcess scheduleIntervalMultiplierMatrixProcess,
            IScheduleIntervalProcess scheduleIntervalProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                scheduleIntervalMultiplierMatrixProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, scheduleIntervalMultiplierMatrixProcess);

            ScheduleIntervalMultiplierMatrixProcess = scheduleIntervalMultiplierMatrixProcess;
            ScheduleIntervalProcess = scheduleIntervalProcess;

            AllScheduleIntervalMultiplierMatrices = [];

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the scheduler interval multiplier process.
        /// </summary>
        /// <value>
        /// The contract process.
        /// </value>
        private IScheduleIntervalMultiplierMatrixProcess ScheduleIntervalMultiplierMatrixProcess { get; }

        /// <summary>
        /// Gets the Schedule Interval Process.
        /// </summary>
        /// <value>
        /// The contract process.
        /// </value>
        private IScheduleIntervalProcess ScheduleIntervalProcess { get; }

        /// <summary>
        /// Gets or sets all contracts.
        /// </summary>
        /// <value>
        /// All contracts.
        /// </value>
        private List<IScheduleIntervalMultiplierMatrix> AllScheduleIntervalMultiplierMatrices { get; set; }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            List<IScheduleInterval> allFromScheduleIntervals = ScheduleIntervalProcess.GetAll();

            ScheduleIntervalProcess.AddFilterOptionsAdditional(allFromScheduleIntervals);

            Filter1DataSource = allFromScheduleIntervals;
            Filter1SelectedItem = allFromScheduleIntervals[0];

            List<IScheduleInterval> allToScheduleIntervals = ScheduleIntervalProcess.GetAll();

            ScheduleIntervalProcess.AddFilterOptionsAdditional(allToScheduleIntervals);

            Filter2DataSource = allToScheduleIntervals;
            Filter2SelectedItem = allToScheduleIntervals[0];

            base.Initialise();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="RefreshData()"/>
        protected override List<IScheduleIntervalMultiplierMatrix> RefreshData()
        {
            LoggingHelpers.TraceCallEnter();

            AllScheduleIntervalMultiplierMatrices = base.RefreshData();
            ApplyFilter1(Filter1SelectedItem);

            LoggingHelpers.TraceCallReturn(AllScheduleIntervalMultiplierMatrices);

            return AllScheduleIntervalMultiplierMatrices;
        }

        /// <inheritdoc cref="ApplyFilter1(Object)"/>
        protected override void ApplyFilter1(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            if (selectedFilter is IScheduleInterval fromScheduleInterval &&
                Filter2SelectedItem is IScheduleInterval toScheduleInterval)
            {
                List<IScheduleIntervalMultiplierMatrix> filteredData = ScheduleIntervalMultiplierMatrixProcess.ApplyFilter(AllScheduleIntervalMultiplierMatrices, fromScheduleInterval, toScheduleInterval);

                GridDataSource = filteredData;
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ApplyFilter2(Object)"/>
        protected override void ApplyFilter2(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            if (Filter1SelectedItem is IScheduleInterval fromScheduleInterval &&
                selectedFilter is IScheduleInterval toScheduleInterval)
            {
                List<IScheduleIntervalMultiplierMatrix> filteredData = ScheduleIntervalMultiplierMatrixProcess.ApplyFilter(AllScheduleIntervalMultiplierMatrices, fromScheduleInterval, toScheduleInterval);

                GridDataSource = filteredData;
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
