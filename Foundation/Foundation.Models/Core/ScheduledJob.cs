//-----------------------------------------------------------------------
// <copyright file="ScheduledJob.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Common.DataColumns;
using FEnums = Foundation.Interfaces;

namespace Foundation.Models
{
    /// <summary>
    /// Scheduled Job class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IScheduledJob" />
    [DependencyInjectionTransient]
    public class ScheduledJob : FoundationModel, IScheduledJob, IEquatable<IScheduledJob>
    {
        private String _name = String.Empty;
        private EntityId _scheduleIntervalId;
        private Boolean _runImmediately;
        private TimeSpan _startTime;
        private TimeSpan _endTime;
        private Int32 _interval;
        private Boolean _isEnabled;
        private String _taskImplementationType = String.Empty;
        private String _taskParameters = String.Empty;

        /// <summary>
        /// Initialises a new instance of the <see cref="ScheduledJob"/> class.
        /// </summary>
        public ScheduledJob()
        {
            ParentScheduledJobs = new();
            ChildScheduledJobs = new();

            FirstRun = true;
        }

        /// <inheritdoc cref="IScheduledJob.ScheduleInterval"/>
        [NotMapped]
        public FEnums.ScheduleInterval ScheduleInterval => (FEnums.ScheduleInterval)this._scheduleIntervalId.ToInteger();

        /// <inheritdoc cref="IScheduledJob.IsRunning"/>
        [NotMapped]
        public Boolean IsRunning { get; set; }

        /// <inheritdoc cref="IScheduledJob.FirstRun"/>
        [NotMapped]
        public Boolean FirstRun { get; set; }

        /// <inheritdoc cref="IScheduledJob.CancellationRequested"/>
        [NotMapped]
        public Boolean CancellationRequested { get; set; }

        /// <inheritdoc cref="IScheduledJob.ScheduledTask"/>
        [NotMapped]
        public IScheduledTask? ScheduledTask { get; set; }

        /// <inheritdoc cref="IScheduledJob.LastRunDateTime"/>
        [NotMapped]
        public DateTime LastRunDateTime { get; set; }

        /// <inheritdoc cref="IScheduledJob.NextRunDateTime"/>
        [NotMapped]
        public DateTime NextRunDateTime { get; set; }

        /// <inheritdoc cref="IScheduledJob.ParentScheduledJobs"/>
        [NotMapped]
        public List<EntityId> ParentScheduledJobs { get; private set; }

        /// <inheritdoc cref="IScheduledJob.ChildScheduledJobs"/>
        [NotMapped]
        public List<EntityId> ChildScheduledJobs { get; private set; }

        /// <inheritdoc cref="IScheduledJob.Name"/>
        [Column(nameof(FDC.ScheduledJob.Name))]
        [MaxLength(FDC.ScheduledJob.Lengths.Name)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be provided")]
        public String Name
        {
            get => this._name;
            set => this.SetPropertyValue(ref _name, value, FDC.ScheduledJob.Lengths.Name);
        }

        /// <inheritdoc cref="IScheduledJob.ScheduleIntervalId"/>
        [Column(nameof(FDC.ScheduledJob.ScheduleIntervalId))]
        [RequiredEntityId(EntityName = "Schedule Interval")]
        public EntityId ScheduleIntervalId
        {
            get => this._scheduleIntervalId;
            set => this.SetPropertyValue(ref _scheduleIntervalId, value);
        }

        /// <inheritdoc cref="IScheduledJob.RunImmediately"/>
        [Column(nameof(FDC.ScheduledJob.RunImmediately))]
        public Boolean RunImmediately
        {
            get => this._runImmediately;
            set => this.SetPropertyValue(ref _runImmediately, value);
        }

        /// <inheritdoc cref="IScheduledJob.StartTime"/>
        [Column(nameof(FDC.ScheduledJob.StartTime))]
        public TimeSpan StartTime
        {
            get => this._startTime;
            set => this.SetPropertyValue(ref _startTime, value);
        }

        /// <inheritdoc cref="IScheduledJob.EndTime"/>
        [Column(nameof(FDC.ScheduledJob.EndTime))]
        public TimeSpan EndTime
        {
            get => this._endTime;
            set => this.SetPropertyValue(ref _endTime, value);
        }

        /// <inheritdoc cref="IScheduledJob.Interval"/>
        [Column(nameof(FDC.ScheduledJob.Interval))]
        public Int32 Interval
        {
            get => this._interval;
            set => this.SetPropertyValue(ref _interval, value);
        }

        /// <inheritdoc cref="IScheduledJob.IsEnabled"/>
        [Column(nameof(FDC.ScheduledJob.IsEnabled))]
        public Boolean IsEnabled
        {
            get => this._isEnabled;
            set => this.SetPropertyValue(ref _isEnabled, value);
        }

        /// <inheritdoc cref="IScheduledJob.TaskImplementationType"/>
        [Column(nameof(FDC.ScheduledJob.TaskImplementationType)), MaxLength(FDC.ScheduledJob.Lengths.TaskImplementationType)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Task Implementation Type must be provided")]
        public String TaskImplementationType
        {
            get => this._taskImplementationType;
            set => this.SetPropertyValue(ref _taskImplementationType, value, FDC.ScheduledJob.Lengths.TaskImplementationType);
        }

        /// <inheritdoc cref="IScheduledJob.TaskParameters"/>
        [Column(nameof(FDC.ScheduledJob.TaskParameters)), MaxLength(FDC.ScheduledJob.Lengths.TaskParameters)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Task Parameters must be provided")]
        public String TaskParameters
        {
            get => this._taskParameters;
            set => this.SetPropertyValue(ref _taskParameters, value, FDC.ScheduledJob.Lengths.TaskParameters);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(IsRunning): retVal = IsRunning; break;
                case nameof(FirstRun): retVal = FirstRun; break;
                case nameof(CancellationRequested): retVal = CancellationRequested; break;
                case nameof(ScheduledTask): retVal = ScheduledTask; break;
                case nameof(LastRunDateTime): retVal = LastRunDateTime; break;
                case nameof(NextRunDateTime): retVal = NextRunDateTime; break;
                case nameof(ParentScheduledJobs): retVal = ParentScheduledJobs; break;
                case nameof(ChildScheduledJobs): retVal = ChildScheduledJobs; break;

                case nameof(Name): retVal = Name; break;
                case nameof(ScheduleIntervalId): retVal = ScheduleIntervalId; break;
                case nameof(RunImmediately): retVal = RunImmediately; break;
                case nameof(StartTime): retVal = StartTime; break;
                case nameof(EndTime): retVal = EndTime; break;
                case nameof(Interval): retVal = Interval; break;
                case nameof(IsEnabled): retVal = IsEnabled; break;
                case nameof(TaskImplementationType): retVal = TaskImplementationType; break;
                case nameof(TaskParameters): retVal = TaskParameters; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            ScheduledJob retVal = (ScheduledJob)base.Clone();
            retVal.Initialising = true;

            retVal.IsRunning = this.IsRunning;
            retVal.FirstRun = this.FirstRun;
            retVal.CancellationRequested = this.CancellationRequested;
            retVal.ScheduledTask = this.ScheduledTask;
            retVal.LastRunDateTime = this.LastRunDateTime;
            retVal.NextRunDateTime = this.NextRunDateTime;
            retVal.ParentScheduledJobs = this.ParentScheduledJobs.Clone() as List<EntityId>;
            retVal.ChildScheduledJobs = this.ChildScheduledJobs.Clone() as List<EntityId>;

            retVal._name = this._name;
            retVal._scheduleIntervalId = this._scheduleIntervalId;
            retVal._runImmediately = this._runImmediately;
            retVal._startTime = this._startTime;
            retVal._endTime = this._endTime;
            retVal._interval = this._interval;
            retVal._isEnabled = this._isEnabled;
            retVal._taskImplementationType = this._taskImplementationType;
            retVal._taskParameters = this._taskParameters;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IScheduledJob? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj.IsNotNull() &&
                obj is ScheduledJob scheduledJob)
            {
                retVal = InternalEquals(this, scheduledJob);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(IsRunning);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(FirstRun);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(CancellationRequested);
            hashCode = hashCode * constant + EqualityComparer<IScheduledTask?>.Default.GetHashCode(ScheduledTask);
            hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(LastRunDateTime);
            hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(NextRunDateTime);

            foreach (EntityId parentTask in ParentScheduledJobs)
            {
                hashCode = hashCode * constant + parentTask.GetHashCode();
            }

            foreach (EntityId childTask in ChildScheduledJobs)
            {
                hashCode = hashCode * constant + childTask.GetHashCode();
            }

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Name);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(RunImmediately);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ScheduleIntervalId);
            hashCode = hashCode * constant + EqualityComparer<TimeSpan>.Default.GetHashCode(StartTime);
            hashCode = hashCode * constant + EqualityComparer<TimeSpan>.Default.GetHashCode(EndTime);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(Interval);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(IsEnabled);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(TaskImplementationType);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(TaskParameters);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IScheduledJob? left, IScheduledJob? right)
        {
            Boolean retVal;

            if (left == null && right == null)
            {
                retVal = true;
            }
            else if (left == null || right == null)
            {
                retVal = false;
            }
            else
            {
                retVal = FoundationModel.InternalEquals(left, right);

                retVal &= left.IsRunning == right.IsRunning;
                retVal &= left.FirstRun == right.FirstRun;
                retVal &= left.CancellationRequested == right.CancellationRequested;
                retVal &= left.ScheduledTask == right.ScheduledTask;
                retVal &= left.LastRunDateTime == right.LastRunDateTime;
                retVal &= left.NextRunDateTime == right.NextRunDateTime;

                retVal &= EqualityComparer<String>.Default.Equals(left.Name, right.Name);
                retVal &= EqualityComparer<Boolean>.Default.Equals(left.RunImmediately, right.RunImmediately);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.ScheduleIntervalId, right.ScheduleIntervalId);
                retVal &= EqualityComparer<TimeSpan>.Default.Equals(left.StartTime, right.StartTime);
                retVal &= EqualityComparer<TimeSpan>.Default.Equals(left.EndTime, right.EndTime);
                retVal &= EqualityComparer<Int32>.Default.Equals(left.Interval, right.Interval);
                retVal &= EqualityComparer<Boolean>.Default.Equals(left.IsEnabled, right.IsEnabled);
                retVal &= EqualityComparer<String>.Default.Equals(left.TaskImplementationType, right.TaskImplementationType);
                retVal &= EqualityComparer<String>.Default.Equals(left.TaskParameters, right.TaskParameters);
            }

            return retVal;
        }
    }
}
