//-----------------------------------------------------------------------
// <copyright file="EventLog.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;
using FEnums = Foundation.Interfaces;

namespace Foundation.Models.Log
{
    /// <summary>
    /// Event Log class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IEventLog" />
    [DependencyInjectionTransient]
    public class EventLog : FoundationModel, IEventLog, IEquatable<IEventLog>
    {
        private LogId _id;
        private AppId _applicationId;
        private LogId _parentId;
        private EntityId _logSeverityId;
        private EntityId _scheduledTaskId;
        private String _batchName = String.Empty;
        private String _processName = String.Empty;
        private String _taskName = String.Empty;
        private EntityId _taskStatusId;
        private DateTime _startedOn;
        private DateTime _finishedOn;
        private String _information = String.Empty;

        /// <inheritdoc cref="IEventLog.LogSeverity"/>
        [NotMapped]
        public FEnums.LogSeverity LogSeverity => (FEnums.LogSeverity)LogSeverityId.ToInteger();

        /// <inheritdoc cref="IEventLog.TaskStatus"/>
        [NotMapped]
        public FEnums.TaskStatus TaskStatus => (FEnums.TaskStatus)TaskStatusId.ToInteger();

        /// <inheritdoc cref="IApplication.Id"/>
        [Column(nameof(FDC.Application.Id))]
        public new LogId Id
        {
            get => _id;
            set
            {
                _id = value;
                base.Id = new EntityId(value.ToInteger());
            }
        }

        /// <inheritdoc cref="IEventLog.ApplicationId"/>
        [Column(nameof(FDC.EventLog.ApplicationId))]
        [RequiredAppId]
        public AppId ApplicationId
        {
            get => this._applicationId;
            set => this.SetPropertyValue(ref _applicationId, value);
        }

        /// <inheritdoc cref="IEventLog.ParentId"/>
        [Column(nameof(FDC.EventLog.ParentId))]
        [RequiredLogId]
        public LogId ParentId
        {
            get => this._parentId;
            set => this.SetPropertyValue(ref _parentId, value);
        }

        /// <inheritdoc cref="IEventLog.LogSeverityId"/>
        [Column(nameof(FDC.EventLog.LogSeverityId))]
        [RequiredEntityId(EntityName = "Log Severity")]
        public EntityId LogSeverityId
        {
            get => this._logSeverityId;
            set => this.SetPropertyValue(ref _logSeverityId, value);
        }

        /// <inheritdoc cref="IEventLog.ScheduledTaskId"/>
        [Column(nameof(FDC.EventLog.ScheduledTaskId))]
        [RequiredEntityId(EntityName = "Scheduled Task")]
        public EntityId ScheduledTaskId
        {
            get => this._scheduledTaskId;
            set => this.SetPropertyValue(ref _scheduledTaskId, value);
        }

        /// <inheritdoc cref="IEventLog.BatchName"/>
        [Column(nameof(FDC.EventLog.BatchName))]
        [MaxLength(FDC.EventLog.Lengths.BatchName)]
        [Required(AllowEmptyStrings = true)]
        public String BatchName
        {
            get => this._batchName;
            set => this.SetPropertyValue(ref _batchName, value, FDC.EventLog.Lengths.BatchName);
        }

        /// <inheritdoc cref="IEventLog.ProcessName"/>
        [Column(nameof(FDC.EventLog.ProcessName))]
        [MaxLength(FDC.EventLog.Lengths.ProcessName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Process Name must be provided")]
        public String ProcessName
        {
            get => this._processName;
            set => this.SetPropertyValue(ref _processName, value, FDC.EventLog.Lengths.ProcessName);
        }

        /// <inheritdoc cref="IEventLog.TaskName"/>
        [Column(nameof(FDC.EventLog.TaskName))]
        [MaxLength(FDC.EventLog.Lengths.TaskName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Task Name must be provided")]
        public String TaskName
        {
            get => this._taskName;
            set => this.SetPropertyValue(ref _taskName, value, FDC.EventLog.Lengths.TaskName);
        }

        /// <inheritdoc cref="IEventLog.TaskStatusId"/>
        [Column(nameof(FDC.EventLog.TaskStatusId))]
        [RequiredEntityId(EntityName = "Task Status")]
        public EntityId TaskStatusId
        {
            get => this._taskStatusId;
            set => this.SetPropertyValue(ref _taskStatusId, value);
        }

        /// <inheritdoc cref="IEventLog.StartedOn"/>
        [Column(nameof(FDC.EventLog.StartedOn))]
        public DateTime StartedOn
        {
            get => this._startedOn;
            set => this.SetPropertyValue(ref _startedOn, value);
        }

        /// <inheritdoc cref="IEventLog.FinishedOn"/>
        [Column(nameof(FDC.EventLog.FinishedOn))]
        public DateTime FinishedOn
        {
            get => this._finishedOn;
            set => this.SetPropertyValue(ref _finishedOn, value);
        }

        /// <inheritdoc cref="IEventLog.Information"/>
        [Column(nameof(FDC.EventLog.Information)), MaxLength(FDC.EventLog.Lengths.Information)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Information must be provided")]
        public String Information
        {
            get => this._information;
            set => this.SetPropertyValue(ref _information, value, FDC.EventLog.Lengths.Information);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ApplicationId): retVal = ApplicationId; break;
                case nameof(ParentId): retVal = ParentId; break;
                case nameof(LogSeverityId): retVal = LogSeverityId; break;
                case nameof(ScheduledTaskId): retVal = ScheduledTaskId; break;
                case nameof(BatchName): retVal = BatchName; break;
                case nameof(ProcessName): retVal = ProcessName; break;
                case nameof(TaskName): retVal = TaskName; break;
                case nameof(TaskStatusId): retVal = TaskStatusId; break;
                case nameof(StartedOn): retVal = StartedOn; break;
                case nameof(FinishedOn): retVal = FinishedOn; break;
                case nameof(Information): retVal = Information; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            EventLog retVal = (EventLog)base.Clone();
            retVal.Initialising = true;

            retVal._id = this._id;
            retVal._applicationId = this._applicationId;
            retVal._parentId = this._parentId;
            retVal._logSeverityId = this._logSeverityId;
            retVal._scheduledTaskId = this._scheduledTaskId;
            retVal._batchName = this._batchName;
            retVal._processName = this._processName;
            retVal._taskName = this._taskName;
            retVal._taskStatusId = this._taskStatusId;
            retVal._startedOn = this._startedOn;
            retVal._finishedOn = this._finishedOn;
            retVal._information = this._information;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IEventLog? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is EventLog eventLog)
            {
                retVal = InternalEquals(eventLog);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<LogId>.Default.GetHashCode(Id);
            hashCode = hashCode * constant + EqualityComparer<AppId>.Default.GetHashCode(ApplicationId);
            hashCode = hashCode * constant + EqualityComparer<LogId>.Default.GetHashCode(ParentId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(LogSeverityId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ScheduledTaskId);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(BatchName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ProcessName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(TaskName);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(TaskStatusId);
            hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(StartedOn);
            hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(FinishedOn);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Information);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IEventLog? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<LogId>.Default.Equals(this.Id, right.Id);
                retVal &= EqualityComparer<AppId>.Default.Equals(this.ApplicationId, right.ApplicationId);
                retVal &= EqualityComparer<LogId>.Default.Equals(this.ParentId, right.ParentId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(this.LogSeverityId, right.LogSeverityId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(this.ScheduledTaskId, right.ScheduledTaskId);
                retVal &= EqualityComparer<String>.Default.Equals(this.BatchName, right.BatchName);
                retVal &= EqualityComparer<String>.Default.Equals(this.ProcessName, right.ProcessName);
                retVal &= EqualityComparer<String>.Default.Equals(this.TaskName, right.TaskName);
                retVal &= EqualityComparer<EntityId>.Default.Equals(this.TaskStatusId, right.TaskStatusId);
                retVal &= EqualityComparer<DateTime>.Default.Equals(this.StartedOn, right.StartedOn);
                retVal &= EqualityComparer<DateTime>.Default.Equals(this.FinishedOn, right.FinishedOn);
                retVal &= EqualityComparer<String>.Default.Equals(this.Information, right.Information);
            }

            return retVal;
        }
    }
}
