//-----------------------------------------------------------------------
// <copyright file="ScheduleIntervalMultiplierMatrixProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Core.EnumProcesses;
using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Core
{
    /// <summary>
    /// The Time Zone Business Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class ScheduleIntervalMultiplierMatrixProcess : CommonBusinessProcess<IScheduleIntervalMultiplierMatrix, IScheduleIntervalMultiplierMatrixRepository>, IScheduleIntervalMultiplierMatrixProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ScheduleIntervalMultiplierMatrixProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        /// <param name="repository">The data access</param>
        /// <param name="statusRepository">The status data access</param>
        /// <param name="userProfileRepository">The user profile data access</param>
        /// <param name="reportGenerator">The report generator service</param>
        /// <param name="scheduleIntervalProcess">The schedule interval process</param>
        public ScheduleIntervalMultiplierMatrixProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            IScheduleIntervalMultiplierMatrixRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            IReportGenerator reportGenerator,
            IScheduleIntervalProcess scheduleIntervalProcess
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService,
                repository,
                statusRepository,
                userProfileRepository,
                reportGenerator
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, repository, statusRepository, userProfileRepository, reportGenerator, scheduleIntervalProcess);

            ScheduleIntervalProcess = scheduleIntervalProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the schedule interval process.
        /// </summary>
        /// <value>
        /// The schedule interval process.
        /// </value>
        private IScheduleIntervalProcess ScheduleIntervalProcess { get; }

        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter1"/>
        public override Boolean HasOptionalDropDownParameter1 => true;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1Name"/>
        public override String Filter1Name => "From Schedule Interval:";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1DisplayMemberPath"/>
        public override String Filter1DisplayMemberPath => ScheduleIntervalProcess.ComboBoxDisplayMember;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1SelectedValuePath"/>
        public override String Filter1SelectedValuePath => ScheduleIntervalProcess.ComboBoxValueMember;


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter2"/>
        public override Boolean HasOptionalDropDownParameter2 => true;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2Name"/>
        public override String Filter2Name => "To Schedule Interval:";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2DisplayMemberPath"/>
        public override String Filter2DisplayMemberPath => ScheduleIntervalProcess.ComboBoxDisplayMember;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2SelectedValuePath"/>
        public override String Filter2SelectedValuePath => ScheduleIntervalProcess.ComboBoxValueMember;


        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Schedule Interval Multiplier Matrix";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Schedule Interval Multiplier Matrices:";

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ScheduleIntervalMultiplierMatrix.FromScheduleIntervalId, "From Schedule Interval", typeof(String))
            {
                DataSource = ScheduleIntervalProcess.GetAll(excludeDeleted: false),
                ValueMember = ScheduleIntervalProcess.ComboBoxValueMember,
                DisplayMember = ScheduleIntervalProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ScheduleIntervalMultiplierMatrix.ToScheduleIntervalId, "To Schedule Interval", typeof(String))
            {
                DataSource = ScheduleIntervalProcess.GetAll(excludeDeleted: false),
                ValueMember = ScheduleIntervalProcess.ComboBoxValueMember,
                DisplayMember = ScheduleIntervalProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ScheduleIntervalMultiplierMatrix.Multiplier, "Multiplier", typeof(Decimal));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(400, FDC.ScheduleIntervalMultiplierMatrix.Description, "Description", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IScheduleIntervalMultiplierMatrixProcess.ApplyFilter(List{IScheduleIntervalMultiplierMatrix}, IScheduleInterval?, IScheduleInterval?)" />
        public List<IScheduleIntervalMultiplierMatrix> ApplyFilter(List<IScheduleIntervalMultiplierMatrix> scheduleIntervalMultiplierMatrices, IScheduleInterval? fromScheduleInterval, IScheduleInterval? toScheduleInterval)
        {
            LoggingHelpers.TraceCallEnter(scheduleIntervalMultiplierMatrices, fromScheduleInterval, toScheduleInterval);

            List<IScheduleIntervalMultiplierMatrix> retVal = scheduleIntervalMultiplierMatrices;

            if (fromScheduleInterval != null)
            {
                retVal = retVal.Where(f => (f.FromScheduleIntervalId == fromScheduleInterval.Id) ||         // Matching From Schedule Interval
                                           (fromScheduleInterval.Id == ScheduleIntervalProcess.AllId) ||    // All records
                                           (fromScheduleInterval.Id == ScheduleIntervalProcess.NoneId &&
                                            f.FromScheduleIntervalId == ScheduleIntervalProcess.NullId)     // No Schedule Interval
                ).ToList();
            }

            if (toScheduleInterval != null)
            {
                retVal = retVal.Where(t => t.ToScheduleIntervalId == toScheduleInterval.Id ||               // Matching To Schedule Interval
                                           (toScheduleInterval.Id == ScheduleIntervalProcess.AllId) ||      // All records
                                           (toScheduleInterval.Id == ScheduleIntervalProcess.NoneId &&
                                            t.ToScheduleIntervalId == ScheduleIntervalProcess.NullId)       // No Schedule Interval
                ).ToList();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IScheduleIntervalMultiplierMatrixProcess.MakeListOfFromSchedulerIntervals(List{IScheduleIntervalMultiplierMatrix})" />
        public List<IScheduleInterval> MakeListOfFromSchedulerIntervals(List<IScheduleIntervalMultiplierMatrix> scheduleIntervalMultiplierMatrices)
        {
            LoggingHelpers.TraceCallEnter(scheduleIntervalMultiplierMatrices);

            List<IScheduleInterval> retVal;

            IEnumerable<EntityId> scheduleIntervalIds = scheduleIntervalMultiplierMatrices.Select(simm => simm.FromScheduleIntervalId);
            List<EntityId> uniqueScheduleIntervalIds = scheduleIntervalIds.Distinct().ToList();

            retVal = ScheduleIntervalProcess.Get(uniqueScheduleIntervalIds);

            ScheduleIntervalProcess.AddFilterOptionAll(retVal);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IScheduleIntervalMultiplierMatrixProcess.MakeListOfToSchedulerIntervals(List{IScheduleIntervalMultiplierMatrix})" />
        public List<IScheduleInterval> MakeListOfToSchedulerIntervals(List<IScheduleIntervalMultiplierMatrix> scheduleIntervalMultiplierMatrices)
        {
            LoggingHelpers.TraceCallEnter(scheduleIntervalMultiplierMatrices);

            List<IScheduleInterval> retVal;

            IEnumerable<EntityId> scheduleIntervalIds = scheduleIntervalMultiplierMatrices.Select(simm => simm.ToScheduleIntervalId);
            List<EntityId> uniqueScheduleIntervalIds = scheduleIntervalIds.Distinct().ToList();

            retVal = ScheduleIntervalProcess.Get(uniqueScheduleIntervalIds);

            ScheduleIntervalProcess.AddFilterOptionAll(retVal);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
