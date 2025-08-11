//-----------------------------------------------------------------------
// <copyright file="EventLogRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the Event Log Data Access class
    /// </summary>
    /// <see cref="IEventLog" />
    [DependencyInjectionTransient]
    public class EventLogRepository : FoundationModelRepository<IEventLog>, IEventLogRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventLogRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="databaseProvider"></param>
        /// <param name="dateTimeService"></param>
        public EventLogRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ILogDatabaseProvider databaseProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                databaseProvider,
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, databaseProvider, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.HasValidityPeriodColumns"/>
        public override Boolean HasValidityPeriodColumns => false;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.EventLog.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.EventLog;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumCreateRole"/>
        protected override ApplicationRole RequiredMinimumCreateRole => ApplicationRole.None;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumEditRole"/>
        protected override ApplicationRole RequiredMinimumEditRole => ApplicationRole.None;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.VerifyCanCreate(TModel)"/>
        protected override void VerifyCanCreate(IEventLog entity)
        {
            // Everyone can Create an Event Log Entry
            // Does nothing
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.VerifyCanEdit(TModel)"/>
        protected override void VerifyCanEdit(IEventLog entity)
        {
            // Everyone can Edit an Event Log Entry
            // Does nothing
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.VerifyCanDelete(TModel)"/>
        protected override void VerifyCanDelete(IEventLog entity)
        {
            // Event Log Entries cannot be deleted
            throw new NotImplementedException("Event Log Entries cannot be deleted");
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.Delete(EntityId)"/>
        public override void Delete(EntityId entityId)
        {
            // Event Log Entries cannot be deleted
            throw new NotImplementedException("Event Log Entries cannot be deleted");
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.Delete(TModel)"/>
        public override IEventLog Delete(IEventLog entity)
        {
            // Event Log Entries cannot be deleted
            throw new NotImplementedException("Event Log Entries cannot be deleted");
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.Delete(List{TModel})"/>
        public override List<IEventLog> Delete(List<IEventLog> entities)
        {
            // Event Log Entries cannot be deleted
            throw new NotImplementedException("Event Log Entries cannot be deleted");
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.DeleteEntity(IDbConnection, EntityId)"/>
        protected override int DeleteEntity(IDbConnection conn, EntityId entityId)
        {
            // Event Log Entries cannot be deleted
            throw new NotImplementedException("Event Log Entries cannot be deleted");
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.DeleteEntity(IDbConnection, TModel)"/>
        protected override int DeleteEntity(IDbConnection conn, IEventLog entity)
        {
            // Event Log Entries cannot be deleted
            throw new NotImplementedException("Event Log Entries cannot be deleted");
        }

        /// <inheritdoc cref="IEventLogRepository.GetLatest(Boolean, EntityId, String, String, String)"/>
        public IEventLog GetLatest(Boolean isFinished, EntityId scheduledTaskId = new EntityId(), String? batchName = null, String? processName = null, String? taskName = null)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc cref="IEventLogRepository.Get(LogId)"/>
        public IEventLog Get(LogId logId)
        {
            LoggingHelpers.TraceCallEnter(logId);

            IEventLog retVal = base.Get(logId);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
