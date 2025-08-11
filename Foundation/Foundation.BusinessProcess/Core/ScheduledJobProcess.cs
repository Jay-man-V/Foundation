//-----------------------------------------------------------------------
// <copyright file="ScheduledJobProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ServiceProcess;
using System.Timers;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;
using FEnums = Foundation.Interfaces;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// The Scheduled Job Business Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class ScheduledJobProcess : CommonBusinessProcess<IScheduledJob, IScheduledJobRepository>, IScheduledJobProcess
    {
        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<CreateScheduledTaskEventArgs>? AlternateCreateScheduledTaskCalled;

        /// <summary>
        /// Initialises a new instance of the <see cref="ScheduledJobProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        /// <param name="loggingService">The logging service.</param>
        /// <param name="scheduleIntervalProcess">The schedule interval process.</param>
        /// <param name="calendarProcess">The calendar process.</param>
        public ScheduledJobProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IScheduledJobRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            ILoggingService loggingService,
            IScheduleIntervalProcess scheduleIntervalProcess,
            ICalendarProcess calendarProcess
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
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, userProfileRepository, scheduleIntervalProcess, calendarProcess, loggingService);

            LoggingService = loggingService;
            ScheduleIntervalProcess = scheduleIntervalProcess;
            CalendarProcess = calendarProcess;

            ScheduledTimers = new Dictionary<String, ServerProcessTimer>();

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the logging service
        /// </summary>
        /// <value>
        /// The logging service
        /// </value>
        private ILoggingService LoggingService { get; }

        /// <summary>
        /// Gets the schedule interval process.
        /// </summary>
        /// <value>
        /// The schedule interval process.
        /// </value>
        private IScheduleIntervalProcess ScheduleIntervalProcess { get; }

        /// <summary>
        /// Gets the calendar process.
        /// </summary>
        /// <value>
        /// The calendar process.
        /// </value>
        private ICalendarProcess CalendarProcess { get; }

        /// <summary>
        /// Collection of Scheduled Timers
        /// </summary>
        internal Dictionary<String, ServerProcessTimer> ScheduledTimers { get; }

        /// <summary>
        /// List of scheduled jobs
        /// </summary>
        private IEnumerable<IScheduledJob>? ScheduledJobs { get; set; }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Scheduled Jobs";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Scheduled Jobs:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.ScheduledJob.Name;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition? gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ScheduledJob.Name, "Job Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(70, FDC.ScheduledJob.ScheduleIntervalId, "Schedule Type", typeof(String))
            {
                DataSource = ScheduleIntervalProcess.GetAll(excludeDeleted: false),
                ValueMember = ScheduleIntervalProcess.ComboBoxValueMember,
                DisplayMember = ScheduleIntervalProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(170, FDC.ScheduledJob.LastRunDateTime, "Last Run Date Time", typeof(DateTime));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(170, FDC.ScheduledJob.NextRunDateTime, "Next Run Date Time", typeof(DateTime));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(70, FDC.ScheduledJob.RunImmediately, "Run Immediately", typeof(Boolean));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(70, FDC.ScheduledJob.StartTime, "Start Time", typeof(TimeSpan));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(70, FDC.ScheduledJob.EndTime, "End Time", typeof(TimeSpan));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ScheduledJob.Interval, "Interval", typeof(Int32));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(70, FDC.ScheduledJob.IsEnabled, "Enabled", typeof(Boolean));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ScheduledJob.TaskImplementationType, "Implementation Type", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(70, FDC.ScheduledJob.TaskParameters, "Parameters", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IScheduledJobProcess.InitialiseJobs(LogId)"/>
        public void InitialiseJobs(LogId parentLogId)
        {
            LoggingHelpers.TraceCallEnter();

            String batchName = "Batch Scheduler";
            String processName = nameof(ScheduledJobProcess);
            String taskName = LocationUtils.GetFunctionName();

            LogId logId = LoggingService.CreateLogEntry(parentLogId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, "Initialising jobs");

            ScheduledJobs = GetAll();

            String jobNames = String.Join(", ", ScheduledJobs.Select(sj => sj.Name));

            LoggingService.CreateLogEntry(logId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, $"{ScheduledJobs.Count()} jobs found ({jobNames})");

            foreach (IScheduledJob scheduledJob in ScheduledJobs)
            {
                LogId jobLogId = LoggingService.CreateLogEntry(logId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, $"Initialising Job: {scheduledJob.Name}");

                if (!ScheduledTimers.TryGetValue(scheduledJob.Name, out ServerProcessTimer? serverProcessTimer))
                {
                    TimeSpan zeroTimeSpan = new TimeSpan();
                    TimeSpan temp = zeroTimeSpan.Add(scheduledJob.ScheduleInterval, scheduledJob.Interval);

                    scheduledJob.ScheduledTask = CreateScheduledTask(scheduledJob);
                    serverProcessTimer = new ServerProcessTimer(scheduledJob)
                    {
                        Interval = temp.TotalMilliseconds,
                        Enabled = false,
                    };

                    if (scheduledJob.RunImmediately)
                    {
                        serverProcessTimer.Interval = new TimeSpan(0, 0, 10).TotalMilliseconds;
                        serverProcessTimer.Enabled = true;
                    }

                    serverProcessTimer.Elapsed += ServerProcessTimerOnElapsed;

                    ScheduledTimers.Add(serverProcessTimer.Name, serverProcessTimer);
                }

                LoggingService.CreateLogEntry(jobLogId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, $"Job Initialised: {scheduledJob.Name}");
            }

            LoggingService.CreateLogEntry(logId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, "All active jobs Initialised");

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IScheduledJobProcess.StartJobs(LogId)"/>
        public void StartJobs(LogId parentLogId)
        {
            LoggingHelpers.TraceCallEnter();

            String batchName = "Batch Scheduler";
            String processName = nameof(ScheduledJobProcess);
            String taskName = LocationUtils.GetFunctionName();

            LogId logId = LoggingService.CreateLogEntry(parentLogId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, "Starting jobs");

            if (ScheduledJobs == null)
            {
                InitialiseJobs(logId);
            }

            if (ScheduledJobs == null ||
                !ScheduledJobs.Any())
            {
                LoggingService.CreateLogEntry(logId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, "No jobs found to start");
            }
            else
            {
                foreach (IScheduledJob scheduledJob in ScheduledJobs)
                {
                    LogId jobLogId = LoggingService.CreateLogEntry(logId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, $"Starting job: {scheduledJob.Name}");

                    if (ScheduledTimers.TryGetValue(scheduledJob.Name, out ServerProcessTimer? serverProcessTimer))
                    {
                        serverProcessTimer.Enabled = true;
                        serverProcessTimer.Start();
                    }

                    LoggingService.CreateLogEntry(jobLogId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, $"Job started: {scheduledJob.Name}");
                }
            }

            LoggingService.CreateLogEntry(logId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, "All active jobs started");

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IScheduledJobProcess.ResumeJobs(LogId)"/>
        public void ResumeJobs(LogId parentLogId)
        {
            LoggingHelpers.TraceCallEnter();

            foreach (var kvpScheduledJob in ScheduledTimers)
            {
                ServerProcessTimer serverProcessTimer = kvpScheduledJob.Value;
                serverProcessTimer.Start();
                serverProcessTimer.Enabled = true;
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IScheduledJobProcess.StopJobs(LogId)"/>
        public void StopJobs(LogId parentLogId)
        {
            LoggingHelpers.TraceCallEnter();

            String batchName = "Batch Scheduler";
            String processName = nameof(ScheduledJobProcess);
            String taskName = LocationUtils.GetFunctionName();

            LogId logId = LoggingService.CreateLogEntry(parentLogId, ApplicationSettings.ApplicationId, batchName, processName, taskName, LogSeverity.Information, "Stopping jobs");

            foreach (var kvpScheduledJob in ScheduledTimers)
            {
                ServerProcessTimer serverProcessTimer = kvpScheduledJob.Value;
                IScheduledJob scheduledJob = serverProcessTimer.ScheduledJob;

                LogId jobLogId = LoggingService.CreateLogEntry(logId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, $"Stopping job: {scheduledJob.Name}");

                scheduledJob.CancellationRequested = true;

                Boolean forceExit = true;
                DateTime startShutdownTime = DateTimeService.SystemDateTimeNow.AddSeconds(60);
                Int32 loopCount = 0;
                while (scheduledJob.IsRunning && forceExit)
                {
                    Thread.Sleep(250);

                    // Allow for 60 * 4 seconds worth of checking for the job to stop
                    forceExit = (loopCount < (60 * 4) &&
                                 scheduledJob.IsRunning &&
                                 startShutdownTime > DateTimeService.SystemDateTimeNow);

                    loopCount++;
                }

                serverProcessTimer.Stop();
                serverProcessTimer.Enabled = false;

                LoggingService.CreateLogEntry(jobLogId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, $"Job stopped: {scheduledJob.Name}");
            }

            LoggingService.CreateLogEntry(logId, Core.ApplicationId, batchName, processName, taskName, LogSeverity.Information, "All active jobs stopped");

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IScheduledJobProcess.CreateScheduledTask(IScheduledJob)"/>
        public IScheduledTask CreateScheduledTask(IScheduledJob scheduledJob)
        {
            LoggingHelpers.TraceCallEnter(scheduledJob);

            IScheduledTask? retVal = null;

            FullyQualifiedTypeName fullyQualifiedTypeName = scheduledJob.TaskImplementationType;

            EventHandler<CreateScheduledTaskEventArgs>? handler = AlternateCreateScheduledTaskCalled;
            if (handler != null)
            {
                CreateScheduledTaskEventArgs args = new CreateScheduledTaskEventArgs(fullyQualifiedTypeName);
                handler(this, args);
                retVal = args.ServiceInstance;
            }

            if (retVal == null)
            {
                retVal = Core.IoC.Get<IScheduledTask>(fullyQualifiedTypeName.AssemblyName, fullyQualifiedTypeName.TypeName, null);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IScheduledJobProcess.GetServiceStatus(String, String)"/>
        public ServiceStatus GetServiceStatus(String serverName, String serviceName)
        {
            ServiceStatus retVal = ServiceStatus.NotSet;

            ServiceController serviceController = new ServiceController(serviceName, serverName);

            switch (serviceController.Status)
            {
                case ServiceControllerStatus.Stopped: retVal = ServiceStatus.Stopped; break;

                case ServiceControllerStatus.StartPending: retVal = ServiceStatus.StartPending; break;

                case ServiceControllerStatus.StopPending: retVal = ServiceStatus.StopPending; break;

                case ServiceControllerStatus.Running: retVal = ServiceStatus.Running; break;

                case ServiceControllerStatus.ContinuePending: retVal = ServiceStatus.ContinuePending; break;

                case ServiceControllerStatus.PausePending: retVal = ServiceStatus.PauseEnding; break;

                case ServiceControllerStatus.Paused: retVal = ServiceStatus.Paused; break;
            }
            return retVal;
        }

        /// <inheritdoc cref="IScheduledJobProcess.GetServiceStatus(IScheduledJob)"/>
        public ServiceStatus GetServiceStatus(IScheduledJob scheduledJob)
        {
            ServiceStatus retVal;

            if (scheduledJob == null)
            {
                throw new ArgumentNullException(nameof(scheduledJob));
            }

            if (ScheduledTimers == null ||
                !ScheduledTimers.Any() ||
                ScheduledJobs == null ||
                !ScheduledJobs.Any())
            {
                throw new InvalidOperationException($"{nameof(ScheduledJobProcess)} has not been initialised");
            }

            if (ScheduledTimers.TryGetValue(scheduledJob.Name, out ServerProcessTimer? serverProcessTimer))
            {
                if (serverProcessTimer.Enabled)
                {
                    retVal = ServiceStatus.Running;
                }
                else
                {
                    retVal = ServiceStatus.Stopped;
                    if (serverProcessTimer.ScheduledJob.IsRunning)
                    {
                        retVal = ServiceStatus.Running;
                    }
                }
            }
            else
            {
                String exception = $"Scheduled Job with name '{scheduledJob.Name}' does not exist or was not loaded";
                throw new ArgumentException(exception, nameof(scheduledJob));
            }

            return retVal;
        }

        /// <inheritdoc cref="IScheduledJobProcess.GetJobLastRunStatus(IScheduledJob)"/>
        public FEnums.TaskStatus GetJobLastRunStatus(IScheduledJob scheduledJob)
        {
            FEnums.TaskStatus retVal = FEnums.TaskStatus.NotSet;

            if (scheduledJob == null)
            {
                throw new ArgumentNullException(nameof(scheduledJob));
            }

            if (ScheduledJobs == null)
            {
                throw new InvalidOperationException($"{nameof(ScheduledJobProcess)} has not been initialised");
            }

            if (!ScheduledJobs.Any())
            {
                throw new InvalidOperationException("No scheduled jobs available");
            }

            if (ScheduledTimers.TryGetValue(scheduledJob.Name, out ServerProcessTimer? _))
            {
                const Boolean isFinished = true;
                EntityId scheduledJobId = scheduledJob.Id;
                IEventLog? eventLog = LoggingService.GetLatest(isFinished, scheduledJobId);
                if (eventLog != null)
                {
                    retVal = eventLog.TaskStatus;
                }
            }
            else
            {
                String exception = $"Scheduled Job with name '{scheduledJob.Name}' does not exist or was not loaded";
                throw new ArgumentException(exception, nameof(scheduledJob));
            }

            return retVal;
        }

        /// <inheritdoc cref="IScheduledJobProcess.RunJob(LogId, IScheduledJob)"/>
        public LogId RunJob(LogId parentLogId, IScheduledJob scheduledJob)
        {
            LoggingHelpers.TraceCallEnter(scheduledJob);

            LogId retVal = InternalRunJob(parentLogId, scheduledJob);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Calculates the next time the job is to run
        /// </summary>
        /// <param name="scheduledJob"></param>
        /// <param name="scheduleInterval"></param>
        protected virtual void ScheduleNextRun(IScheduledJob scheduledJob, Int32 scheduleInterval)
        {
            LoggingHelpers.TraceCallEnter(scheduledJob);

            DateTime lastRunDateTime = scheduledJob.LastRunDateTime;
            DateTime nextRunDateTime = scheduledJob.NextRunDateTime;

            // If we haven't been given a specific interval, use the pre-configured interval
            DateTime expectedNextRunDateTime;
            if (scheduleInterval == 0)
            {
                expectedNextRunDateTime = lastRunDateTime.Add(scheduledJob.ScheduleInterval, scheduledJob.Interval, scheduledJob.StartTime);
            }
            else
            {
                expectedNextRunDateTime = lastRunDateTime.AddMilliseconds(scheduleInterval);
            }

            // Check to make sure it's a working day
            expectedNextRunDateTime = CalendarProcess.CheckIsWorkingDayOrGetNextWorkingDay(RunTimeEnvironmentSettings.StandardCountryCode, expectedNextRunDateTime.Date) + expectedNextRunDateTime.TimeOfDay;

            // When should the task be next scheduled?
            // Case 1 - Later in the same day
            // Case 2 - The next working day?

            if (expectedNextRunDateTime <= nextRunDateTime)
            {
                if (scheduleInterval == 0)
                {
                    // The task has been run before the normal Start Time
                    scheduledJob.NextRunDateTime = nextRunDateTime;
                }
                else
                {
                    scheduledJob.NextRunDateTime = expectedNextRunDateTime;
                }
            }
            else
            {
                // The task has been run after the normal End Time
                scheduledJob.NextRunDateTime = expectedNextRunDateTime;
            }

            LoggingHelpers.TraceCallReturn();
        }

        private Boolean CanExecute(IScheduledJob scheduledJob)
        {
            LoggingHelpers.TraceCallEnter();

            Boolean retVal;

            DateTime currentDatetime = DateTimeService.SystemDateTimeNow;

            DateTime currentDate = currentDatetime.Date;
            TimeSpan currentTime = currentDatetime.TimeOfDay;

            // No job is to run on the weekend, week days only
            Boolean dayOfWeekCheck = (currentDate.DayOfWeek != DayOfWeek.Saturday &&
                                      currentDate.DayOfWeek != DayOfWeek.Sunday);

            // Only run between the configured start and end times
            Boolean timeWindowCheck = currentTime.IsBetween(scheduledJob.StartTime, scheduledJob.EndTime);

            // Only run if the current date/time is after the next scheduled run date/time
            Boolean timeOfDayCheck = currentDatetime >= scheduledJob.NextRunDateTime;

            retVal = (dayOfWeekCheck && timeWindowCheck && timeOfDayCheck) || scheduledJob.FirstRun;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Elapsed event is raised when the timer interval is reached
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ServerProcessTimerOnElapsed(Object? sender, ElapsedEventArgs e)
        {
            LoggingHelpers.TraceCallEnter(sender, e);

            ServerProcessTimer? serverProcessTimer = (ServerProcessTimer?)sender;

            if (serverProcessTimer == null ||
                //serverProcessTimer.ScheduledJob == null ||
                serverProcessTimer.ScheduledJob.ScheduledTask == null)
            {
                return;
            }

            IScheduledJob scheduledJob = serverProcessTimer.ScheduledJob;

            // Default to reschedule based on the Interval
            Int32 rescheduleInterval = 0;

            LogId logId = new LogId(0);

            try
            {
                serverProcessTimer.Stop();

                Boolean canExecute = CanExecute(scheduledJob);

                if (canExecute)
                {
                    String batchName = "Scheduled batch run";
                    String processName = scheduledJob.GetType().ToString();
                    String taskName = "Task starting";

                    logId = LoggingService.StartTask(scheduledJob.ScheduledTask.ApplicationId, batchName, processName, taskName);

                    scheduledJob.IsRunning = true;
                    scheduledJob.LastRunDateTime = DateTimeService.SystemDateTimeNowWithoutMilliseconds;

                    InternalRunJob(logId, scheduledJob);
                    LoggingService.EndTask(logId, LogSeverity.Success, "Job completed");

                    scheduledJob.FirstRun = false;
                }
            }
            catch (Exception exception)
            {
                LoggingHelpers.LogErrorMessage(exception);

                LoggingService.CreateLogEntry(logId, Core.ApplicationId, LogSeverity.Error, exception);

                // Reschedule in 5 minutes in case of an error
                rescheduleInterval = (Int32)(new TimeSpan(0, 5, 0).TotalMilliseconds);

#if (DEBUG)
                // Reschedule in 30 seconds in debug build
                rescheduleInterval = (Int32)(new TimeSpan(0, 0, 60).TotalMilliseconds);
#endif

                LoggingService.EndTask(logId, LogSeverity.Error, exception);
            }
            finally
            {
                scheduledJob.IsRunning = false;

                ScheduleNextRun(scheduledJob, rescheduleInterval);

                serverProcessTimer.Start();
            }

            LoggingHelpers.TraceCallReturn();
        }

        private LogId InternalRunJob(LogId parentLogId, IScheduledJob scheduledJob)
        {
            LoggingHelpers.TraceCallEnter(scheduledJob);

            LogId logId = new LogId(0);

            if (scheduledJob.ScheduledTask != null)
            {
                IScheduledTask scheduledTask = scheduledJob.ScheduledTask;

                String batchName = "Scheduled batch run";
                String processName = scheduledTask.GetType().ToString();
                String taskName = "Task starting";

                logId = LoggingService.StartTask(scheduledTask.ApplicationId, batchName, processName, taskName);

                if (scheduledJob.IsEnabled)
                {
                    scheduledJob.IsRunning = true;
                    scheduledJob.LastRunDateTime = DateTimeService.SystemDateTimeNowWithoutMilliseconds;

                    scheduledTask.Process(logId, scheduledJob.TaskParameters);
                    LoggingService.EndTask(logId, LogSeverity.Success, "Job completed");

                    scheduledJob.FirstRun = false;

                    ScheduleNextRun(scheduledJob, 0);
                }
                else
                {
                    LoggingService.EndTask(logId, LogSeverity.Success, "Job is disabled in configuration");
                }
            }

            LoggingHelpers.TraceCallReturn(logId);

            return logId;
        }

    }
}
