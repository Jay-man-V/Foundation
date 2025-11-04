//-----------------------------------------------------------------------
// <copyright file="EventLogAttachmentRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Repository.DataProvider;

using System.Data;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Log
{
    /// <summary>
    /// Defines the Event Log Data Access class
    /// </summary>
    /// <see cref="IEventLogAttachment" />
    [DependencyInjectionTransient]
    public class EventLogAttachmentRepository : FoundationModelRepository<IEventLogAttachment>, IEventLogAttachmentRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventLogAttachmentRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="foundationDataAccess">The foundation data access.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public EventLogAttachmentRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            IFoundationDataAccess foundationDataAccess,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                foundationDataAccess,
                new LogDataProvider(),
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, foundationDataAccess, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.HasValidityPeriodColumns"/>
        public override Boolean HasValidityPeriodColumns => false;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.EventLogAttachment.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.EventLogAttachment;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumCreateRole"/>
        protected override ApplicationRole RequiredMinimumCreateRole => ApplicationRole.None;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumEditRole"/>
        protected override ApplicationRole RequiredMinimumEditRole => ApplicationRole.None;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.VerifyCanCreate(TModel)"/>
        protected override void VerifyCanCreate(IEventLogAttachment entity)
        {
            // Everyone can Create an Event Log Entry
            // Does nothing
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.VerifyCanEdit(TModel)"/>
        protected override void VerifyCanEdit(IEventLogAttachment entity)
        {
            // Everyone can Edit an Event Log Entry
            // Does nothing
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.VerifyCanDelete(TModel)"/>
        protected override void VerifyCanDelete(IEventLogAttachment entity)
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
        public override IEventLogAttachment Delete(IEventLogAttachment entity)
        {
            // Event Log Entries cannot be deleted
            throw new NotImplementedException("Event Log Entries cannot be deleted");
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.Delete(List{TModel})"/>
        public override List<IEventLogAttachment> Delete(List<IEventLogAttachment> entities)
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
        protected override int DeleteEntity(IDbConnection conn, IEventLogAttachment entity)
        {
            // Event Log Entries cannot be deleted
            throw new NotImplementedException("Event Log Entries cannot be deleted");
        }
    }
}
