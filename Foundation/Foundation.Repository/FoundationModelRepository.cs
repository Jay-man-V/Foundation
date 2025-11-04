//-----------------------------------------------------------------------
// <copyright file="FoundationModelRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;
using FEnums = Foundation.Interfaces;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the FoundationEntityDataAccess class
    /// Provides entity specific Data Access services
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <see cref="FoundationDataAccess" />
    public abstract class FoundationModelRepository<TModel> : IFoundationModelRepository<TModel> where TModel : IFoundationModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="IFoundationModelRepository{TModel}"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="foundationDataAccess">The foundation data access.</param>
        /// <param name="dataProvider">The data provider.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        protected FoundationModelRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            IFoundationDataAccess foundationDataAccess,
            IDataProvider dataProvider,
            IDateTimeService dateTimeService
        )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, foundationDataAccess, dataProvider, dateTimeService);

            Core = core;
            RunTimeEnvironmentSettings = runTimeEnvironmentSettings;
            FoundationDataAccess = new FoundationDataAccess(core, systemConfigurationService, dataProvider);
            DateTimeService = dateTimeService;

            _entityProperties = [];
            _entityInsertColumns = String.Empty;
            _entityInsertParametersSection = String.Empty;
            _entityInsertParametersSection = String.Empty;
            _entityUpdateColumnParameters = String.Empty;

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritDoc cref="IDisposable.Dispose()" />
        public void Dispose()
        {
            FoundationDataAccess.Dispose();
        }

        /// <summary>
        /// The Foundation Core service
        /// </summary>
        protected ICore Core { get; }

        /// <summary>
        /// The run time environment settings
        /// </summary>
        protected IRunTimeEnvironmentSettings RunTimeEnvironmentSettings { get; }

        /// <summary>
        /// Gets the foundation data access.
        /// </summary>
        /// <value>
        /// The foundation data access.
        /// </value>
        protected internal IFoundationDataAccess FoundationDataAccess { get; }

        /// <summary>
        /// Gets the data logic provider.
        /// </summary>
        /// <value>
        /// The data logic provider.
        /// </value>
        protected internal IDataLogicProvider DataLogicProvider => FoundationDataAccess.DataLogicProvider;

        /// <summary>
        /// Gets the date time service.
        /// </summary>
        /// <value>
        /// The date time service.
        /// </value>
        protected IDateTimeService DateTimeService { get; }

        /// <summary>
        /// The minimum role a user must have to Create records
        /// </summary>
        protected virtual ApplicationRole RequiredMinimumCreateRole => ApplicationRole.Creator;

        /// <summary>
        /// The minimum role a user must have to Edit records
        /// </summary>
        protected virtual ApplicationRole RequiredMinimumEditRole => ApplicationRole.OwnEditor;

        /// <summary>
        /// The minimum role a user must have to Delete records
        /// </summary>
        protected virtual ApplicationRole RequiredMinimumDeleteRole => ApplicationRole.OwnDelete;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has static data columns.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has static data columns; otherwise, <c>false</c>.
        /// </value>
        public virtual Boolean HasValidityPeriodColumns => true;

        /// <summary>
        /// Gets the entity key.
        /// </summary>
        /// <value>
        /// The entity key.
        /// </value>
        protected virtual String EntityKey => throw new NotImplementedException();

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>The name of the entity.</value>
        protected abstract String EntityName { get; }

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        protected abstract String TableName { get; }

        /// <summary>
        /// Adds the parameter.
        /// </summary>
        /// <param name="propertyInfo">The property information.</param>
        /// <param name="databaseParameters">The database parameters.</param>
        /// <param name="columnName">Name of the column.</param>
        /// <param name="entity">The entity.</param>
        /// <exception cref="Exception"></exception>
        protected virtual void AddParameter(PropertyInfo propertyInfo, DatabaseParameters databaseParameters, String columnName, TModel entity)
        {
            if (propertyInfo.PropertyType == typeof(String)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity), DataHelpers.DefaultString));
            else if (propertyInfo.PropertyType == typeof(DateTime)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity), DataHelpers.DefaultDateTime));
            else if (propertyInfo.PropertyType == typeof(DateTime?)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity), DataHelpers.DefaultDateTime));
            else if (propertyInfo.PropertyType == typeof(TimeSpan)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity), DataHelpers.DefaultTimeSpan));
            else if (propertyInfo.PropertyType == typeof(Boolean)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity), DataHelpers.DefaultBoolean));
            else if (propertyInfo.PropertyType == typeof(Byte[])) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity), DataHelpers.DefaultByteArray));
            else if (propertyInfo.PropertyType == typeof(Image)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity), DataHelpers.DefaultImage));
            else if (propertyInfo.PropertyType == typeof(Bitmap)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity), DataHelpers.DefaultImage));
            else if (propertyInfo.PropertyType == typeof(Decimal)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity), 0m));
            else if (propertyInfo.PropertyType.IsNumericType()) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity)));
            else if (propertyInfo.PropertyType == typeof(EntityId)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, (EntityId?)propertyInfo.GetValue(entity)));
            else if (propertyInfo.PropertyType == typeof(AppId)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, (AppId?)propertyInfo.GetValue(entity)));
            else if (propertyInfo.PropertyType == typeof(LogId)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, (LogId?)propertyInfo.GetValue(entity)));
            else if (propertyInfo.PropertyType == typeof(EmailAddress)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, (EmailAddress?)propertyInfo.GetValue(entity)));
            else if (propertyInfo.PropertyType == typeof(LogSeverity)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity), DataHelpers.DefaultLogSeverity));
            else if (propertyInfo.PropertyType == typeof(FEnums.TaskStatus)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity), DataHelpers.DefaultTaskStatus));
            else if (propertyInfo.PropertyType == typeof(Object)) databaseParameters.Add(FoundationDataAccess.CreateParameter(columnName, propertyInfo.GetValue(entity)));
            else
            {
                String errorMessage = $"{propertyInfo.PropertyType} is unknown. Unable to set the correct value";
                throw new ArgumentException(errorMessage);
            }
        }

        /// <summary>
        /// The entity properties
        /// </summary>
        private PropertyInfo[]? _entityProperties;
        /// <summary>
        /// Gets the entity properties.
        /// </summary>
        /// <value>
        /// The entity properties.
        /// </value>
        protected virtual PropertyInfo[] EntityProperties
        {
            get
            {
                if (_entityProperties == null || _entityProperties.Length == 0)
                {
                    BindingFlags bindingFlags = BindingFlags.DeclaredOnly |
                                                BindingFlags.Public |
                                                BindingFlags.Instance;

                    TModel instance = Core.IoC.Get<TModel>();
                    Type entityType = instance.GetType();
                    _entityProperties = entityType.GetProperties(bindingFlags);

                    _entityProperties = _entityProperties.Where(ep => ep.GetCustomAttributes<ColumnAttribute>().Any() &&
                                                                      (ep.GetCustomAttributes<NotMappedAttribute>().None() ||
                                                                       ep.GetCustomAttributes<ReadOnlyAttribute>().None())).ToArray();
                }

                return _entityProperties;
            }
        }

        /// <summary>
        /// The entity insert columns
        /// </summary>
        private String _entityInsertColumns;
        /// <summary>
        /// Gets the entity insert columns.
        /// </summary>
        /// <returns>List of column names that will be inserted into</returns>
        protected virtual String EntityInsertColumns
        {
            get
            {
                if (String.IsNullOrEmpty(_entityInsertColumns))
                {
                    _entityInsertColumns = String.Join(", ", EntityProperties.Where(ep => !ep.Name.Equals(FDC.FoundationEntity.Id)).Select(ep => ep.Name));
                }

                return _entityInsertColumns;
            }
        }

        /// <summary>
        /// The entity insert parameters section
        /// </summary>
        private String _entityInsertParametersSection;
        /// <summary>
        /// Gets the entity insert parameters.
        /// </summary>
        /// <returns>List of parameter names that hold the values</returns>
        protected virtual String EntityInsertParametersSection
        {
            get
            {
                if (String.IsNullOrEmpty(_entityInsertParametersSection))
                {
                    _entityInsertParametersSection = String.Join($", {DataLogicProvider.DatabaseParameterPrefix}", EntityProperties.Where(ep => !ep.Name.Equals(FDC.FoundationEntity.Id)).Select(ep => ep.Name));
                    _entityInsertParametersSection = $"{DataLogicProvider.DatabaseParameterPrefix}{_entityInsertParametersSection}";
                }

                return _entityInsertParametersSection;
            }
        }

        /// <summary>
        /// Adds the entity insert parameters.
        /// </summary>
        /// <param name="databaseParameters">The database parameters.</param>
        /// <param name="entity">The entity.</param>
        protected virtual void AddEntityInsertParameters(DatabaseParameters databaseParameters, TModel entity)
        {
            foreach (PropertyInfo? propertyInfo in EntityProperties)
            {
                if (propertyInfo.GetCustomAttribute<ColumnAttribute>() is { } columnAttribute &&
                    !String.IsNullOrEmpty(columnAttribute.Name))
                {
                    AddParameter(propertyInfo, databaseParameters, columnAttribute.Name, entity);
                }
            }
        }

        /// <summary>
        /// The entity update column parameters
        /// </summary>
        private String _entityUpdateColumnParameters;
        /// <summary>
        /// Gets the entity update column parameters.
        /// </summary>
        /// <returns>List of columns that will be updated</returns>
        protected virtual String EntityUpdateColumnParameters
        {
            get
            {
                if (String.IsNullOrEmpty(_entityUpdateColumnParameters))
                {
                    StringBuilder sb = new StringBuilder();

                    Boolean valueAdded = false;
                    foreach (PropertyInfo propertyInfo in EntityProperties.Where(ep => !ep.Name.Equals(FDC.FoundationEntity.Id)))
                    {
                        if (valueAdded) sb.AppendLine(",");

                        if (propertyInfo.GetCustomAttribute<ColumnAttribute>() is { } columnAttribute &&
                            !String.IsNullOrEmpty(columnAttribute.Name))
                        {
                            sb.Append($"{columnAttribute.Name} = {DataLogicProvider.DatabaseParameterPrefix}{columnAttribute.Name}");
                            valueAdded = true;
                        }
                    }

                    sb.AppendLine();

                    _entityUpdateColumnParameters = sb.ToString();
                }

                return _entityUpdateColumnParameters;
            }
        }

        /// <summary>
        /// Adds the entity update parameters.
        /// </summary>
        /// <param name="databaseParameters">The database parameters.</param>
        /// <param name="entity">The entity.</param>
        protected virtual void AddEntityUpdateParameters(DatabaseParameters databaseParameters, TModel entity)
        {
            foreach (PropertyInfo propertyInfo in EntityProperties.Where(ep => !ep.Name.Equals(FDC.FoundationEntity.Id)))
            {
                if (propertyInfo.GetCustomAttribute<ColumnAttribute>() is { } columnAttribute &&
                    !String.IsNullOrEmpty(columnAttribute.Name))
                {
                    AddParameter(propertyInfo, databaseParameters, columnAttribute.Name, entity);
                }
            }
        }

        /// <summary>
        /// Verifies that the <see cref="ICore.CurrentLoggedOnUser"/> has the correct permissions to create
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <exception cref="ApplicationPermissionsException">Not allowed to create</exception>
        protected virtual void VerifyCanCreate(TModel entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            Boolean canCreateRecord = Core.CurrentLoggedOnUser.UserProfile.Roles.Any(r => r.ApplicationRole == RequiredMinimumCreateRole);

            Boolean isSystemAdministrator = Core.CurrentLoggedOnUser.UserProfile.Roles.Any(r => r.ApplicationRole == ApplicationRole.SystemAdministrator || 
                                                                                                r.ApplicationRole == ApplicationRole.SystemDataAdministrator);

            if (!(canCreateRecord || isSystemAdministrator))
            {
                String processName = $"{nameof(VerifyCanCreate)}::{TableName}";
                throw new ApplicationPermissionsException(Core.ApplicationId, RunTimeEnvironmentSettings.UserFullLogonName, processName, ApplicationRole.Creator, entity);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Verifies that the <see cref="ICore.CurrentLoggedOnUser"/> has the correct permissions to edit
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <exception cref="ApplicationPermissionsException">Not allowed to edit</exception>
        protected virtual void VerifyCanEdit(TModel entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            Boolean canEditOwnRecord = Core.CurrentLoggedOnUser.UserProfile.Roles.Any(r => r.ApplicationRole == RequiredMinimumEditRole &&
                                                                                           Core.CurrentLoggedOnUser.Id == entity.CreatedByUserProfileId);

            Boolean canEditAllRecords = Core.CurrentLoggedOnUser.UserProfile.Roles.Any(r => r.ApplicationRole == ApplicationRole.AllEditor);

            Boolean isSystemAdministrator = Core.CurrentLoggedOnUser.UserProfile.Roles.Any(r => r.ApplicationRole == ApplicationRole.SystemAdministrator ||
                                                                                                r.ApplicationRole == ApplicationRole.SystemDataAdministrator);

            if (!(canEditOwnRecord || canEditAllRecords || isSystemAdministrator))
            {
                String processName = $"{nameof(VerifyCanEdit)}::{TableName}";
                throw new ApplicationPermissionsException(Core.ApplicationId, RunTimeEnvironmentSettings.UserFullLogonName, processName, ApplicationRole.OwnEditor, entity);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Verifies that the <see cref="ICore.CurrentLoggedOnUser"/> has the correct permissions to delete
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <exception cref="ApplicationPermissionsException">Not allowed to delete</exception>
        protected virtual void VerifyCanDelete(TModel entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            Boolean canDeleteOwnRecord = Core.CurrentLoggedOnUser.UserProfile.Roles.Any(r => r.ApplicationRole == RequiredMinimumDeleteRole &&
                                                                                             Core.CurrentLoggedOnUser.Id == entity.CreatedByUserProfileId);

            Boolean canDeleteAllRecords = Core.CurrentLoggedOnUser.UserProfile.Roles.Any(r => r.ApplicationRole == ApplicationRole.AllDelete);

            Boolean isSystemAdministrator = Core.CurrentLoggedOnUser.UserProfile.Roles.Any(r => r.ApplicationRole == ApplicationRole.SystemAdministrator ||
                                                                                                r.ApplicationRole == ApplicationRole.SystemDataAdministrator);

            if (!(canDeleteOwnRecord || canDeleteAllRecords || isSystemAdministrator))
            {
                String processName = $"{nameof(VerifyCanDelete)}::{TableName}";
                throw new ApplicationPermissionsException(Core.ApplicationId, RunTimeEnvironmentSettings.UserFullLogonName, processName, ApplicationRole.OwnDelete, entity);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the 'Order By' clause of a Sql statement
        /// </summary>
        /// <returns></returns>
        protected virtual String GetAllOrderByClause()
        {
            LoggingHelpers.TraceCallEnter();

            String retVal = String.Empty;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets all active.
        /// </summary>
        /// <returns>List of all active entities</returns>
        public virtual List<TModel> GetAllActive()
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}");

            const Boolean activeOnly = true;
            const Boolean useValidityPeriod = true;

            List<TModel> retVal = GetAll(activeOnly, useValidityPeriod);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="excludeDeleted">Whether to include deleted entities</param>
        /// <param name="useValidityPeriod">Whether to check an entities validity period for inclusion</param>
        /// <returns></returns>
        protected virtual String GetAllSql(Boolean excludeDeleted, Boolean useValidityPeriod)
        {
            StringBuilder retVal = new StringBuilder();
            retVal.AppendLine("SELECT");
            retVal.AppendLine("    *");
            retVal.AppendLine("FROM");
            retVal.AppendLine(TableName);

            Boolean whereClauseAdded = false;
            if (excludeDeleted)
            {
                whereClauseAdded = true;
                retVal.AppendLine("WHERE");
                retVal.AppendLine($"    ({FDC.FoundationEntity.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()}, {EntityStatus.PendingApproval.Id()}, {EntityStatus.Incomplete.Id()} ) )");
            }

            if (HasValidityPeriodColumns && useValidityPeriod)
            {
                retVal.AppendLine(!whereClauseAdded ? "WHERE" : "    AND");

                retVal.AppendLine("    (");
                retVal.AppendLine($"        ({DataLogicProvider.CurrentDateTimeFunction} BETWEEN {EntityName}.{FDC.FoundationEntity.ValidFrom} AND {EntityName}.{FDC.FoundationEntity.ValidTo})");
                retVal.AppendLine("        OR");
                retVal.AppendLine($"        ({EntityName}.{FDC.FoundationEntity.ValidFrom} IS NULL AND {EntityName}.{FDC.FoundationEntity.ValidTo} IS NULL)");
                retVal.AppendLine("        OR");
                retVal.AppendLine($"        ({DataLogicProvider.CurrentDateTimeFunction} >= {EntityName}.{FDC.FoundationEntity.ValidFrom} AND {EntityName}.{FDC.FoundationEntity.ValidTo} IS NULL)");
                retVal.AppendLine("    )");
            }

            String orderByClause = GetAllOrderByClause();

            if (orderByClause.Length > 0)
            {
                retVal.AppendLine("ORDER BY");
                retVal.AppendLine(orderByClause);
            }

            retVal.AppendLine(";");

            return retVal.ToString();
        }

        /// <summary>
        /// Gets all active.
        /// </summary>
        /// <param name="excludeDeleted">Whether to include deleted entities</param>
        /// <param name="useValidityPeriod">Whether to check an entities validity period for inclusion</param>
        /// <returns>List of all active entities</returns>
        public virtual List<TModel> GetAll(Boolean excludeDeleted, Boolean useValidityPeriod)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}");

            List<TModel> retVal = [];

            String sql = GetAllSql(excludeDeleted, useValidityPeriod);

            using (IDataReader dataReader = FoundationDataAccess.ExecuteReader(sql))
            {
                while (dataReader.Read())
                {
                    TModel entity = PopulateEntity<TModel>(dataReader);
                    retVal.Add(entity);
                }

                dataReader.Close();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual String GetSql()
        {
            StringBuilder retVal = new StringBuilder();
            retVal.AppendLine("SELECT");
            retVal.AppendLine("    *");
            retVal.AppendLine("FROM");
            retVal.AppendLine(TableName);
            retVal.AppendLine("WHERE");
            retVal.AppendLine($"    {EntityName}.{FDC.FoundationEntity.Id} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.Id}");

            return retVal.ToString();
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <returns>Loaded entity</returns>
        public virtual TModel Get(EntityId entityId)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", entityId);

            TModel retVal = Get<EntityId>(entityId);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="tEntityId">The entity identifier.</param>
        /// <returns>Loaded entity</returns>
        protected virtual TModel Get<TIdType>(TIdType tEntityId)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", tEntityId);

            TModel retVal = default!;

            String sql = GetSql();

            IDbDataParameter? dataParameter = null;

            if (tEntityId is EntityId entityId)
            {
                dataParameter = FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.Id}", entityId);
            }
            else if (tEntityId is AppId appId)
            {
                dataParameter = FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.Id}", appId);
            }
            else if (tEntityId is LogId logId)
            {
                dataParameter = FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.Id}", logId);
            }

            if (dataParameter == null)
            {
                String message = $"Unable to create Data Parameter for '{typeof(TIdType)}' with value '{tEntityId}'";
                throw new ArgumentNullException(nameof(dataParameter), message);
            }

            DatabaseParameters databaseParameters = [dataParameter];

            DataTable dataTable = FoundationDataAccess.ExecuteDataTable(sql, CommandType.Text, databaseParameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                retVal = PopulateEntity<TModel>(dr);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="entityIds">The entity identifiers.</param>
        /// <returns>Loaded entity</returns>
        public virtual List<TModel> Get(List<EntityId> entityIds)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", entityIds);

            List<TModel> retVal = [];

            String ids = String.Join(", ", entityIds.Select(e => e.ToInteger()));

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    *");
            sql.AppendLine("FROM");
            sql.AppendLine(TableName);
            sql.AppendLine("WHERE");
            sql.AppendLine($"    {EntityName}.{FDC.FoundationEntity.Id} IN ( {ids} )");

            IDataReader dataReader = FoundationDataAccess.ExecuteReader(sql.ToString());

            while (dataReader.Read())
            {
                TModel entity = PopulateEntity<TModel>(dataReader);
                retVal.Add(entity);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="entityKey">The entity identifier.</param>
        /// <returns>Loaded entity</returns>
        public virtual TModel Get(String entityKey)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", entityKey);

            TModel retVal = default!;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    *");
            sql.AppendLine("FROM");
            sql.AppendLine(TableName);
            sql.AppendLine("WHERE");
            sql.AppendLine($"    {EntityKey} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}entityKey");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{EntityName}entityKey", entityKey)
            ];

            DataTable dataTable = FoundationDataAccess.ExecuteDataTable(sql.ToString(), CommandType.Text, databaseParameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                retVal = PopulateEntity<TModel>(dr);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Deletes the entity with the <paramref name="entityId"/>
        /// </summary>
        /// <param name="entityId">The entity id.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entityId"/> is null</exception>
        public virtual void Delete(EntityId entityId)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", entityId);

            using (IDbConnection conn = FoundationDataAccess.GetConnection())
            {
                using (IDbTransaction transaction = FoundationDataAccess.BeginTransaction())
                {
                    DeleteEntity(conn, entityId);

                    transaction.Commit();
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Deletes the entity with the <paramref name="tEntityId"/>
        /// </summary>
        /// <param name="tEntityId">The entity id.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="tEntityId"/> is null</exception>
        protected virtual void Delete<TIdType>(TIdType tEntityId)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", tEntityId);

            if (tEntityId is EntityId entityId)
            {
                Delete(entityId);
            }
            else if (tEntityId is AppId appId)
            {
                Delete(appId);
            }
            else if (tEntityId is LogId)
            {
                throw new ArgumentException("It is not possible to delete Log entries");
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Deletes the <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public virtual TModel Delete(TModel entity)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", entity);

            TModel retVal;

            using (IDbConnection conn = FoundationDataAccess.GetConnection())
            {
                using (IDbTransaction transaction = FoundationDataAccess.BeginTransaction())
                {
                    entity.EntityLife = EntityLife.Deleted;
                    retVal = InternalSave(conn, entity);

                    transaction.Commit();
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Saves the <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entity"/> is null</exception>
        public virtual TModel Save(TModel entity)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", entity);

            TModel retVal;

            using (IDbConnection conn = FoundationDataAccess.GetConnection())
            {
                using (IDbTransaction transaction = FoundationDataAccess.BeginTransaction())
                {
                    retVal = InternalSave(conn, entity);

                    transaction.Commit();
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Deletes the provided list of <paramref name="entities"/>
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entities"/> is null</exception>
        public virtual List<TModel> Delete(List<TModel> entities)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", entities);

            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            List<TModel> retVal = [];

            using (IDbConnection conn = FoundationDataAccess.GetConnection())
            {
                using (IDbTransaction transaction = FoundationDataAccess.BeginTransaction())
                {
                    entities.ForEach(entity =>
                    {
                        entity.EntityLife = EntityLife.Deleted;
                        TModel deletedEntity = InternalSave(conn, entity);

                        retVal.Add(deletedEntity);
                    });

                    transaction.Commit();
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Saves the provided list of <paramref name="entities"/>
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <exception cref="ArgumentNullException"> if <paramref name="entities"/> is null</exception>
        public virtual List<TModel> Save(List<TModel> entities)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", entities);

            if (entities == null)
            {
                throw new ArgumentNullException(nameof(entities));
            }

            List<TModel> retVal = [];

            using (IDbConnection conn = FoundationDataAccess.GetConnection())
            {
                using (IDbTransaction transaction = FoundationDataAccess.BeginTransaction())
                {
                    entities.ForEach(entity =>
                    {
                        TModel savedEntity = InternalSave(conn, entity);

                        retVal.Add(savedEntity);
                    });

                    transaction.Commit();
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

#if (DEBUG)        
        /// <summary>
        /// Deletes all records. Only available in Debug builds
        /// </summary>
        public void DeleteAll()
        {
            LoggingHelpers.TraceCallEnter();

            String sql = $"DELETE FROM {TableName}";

            using (IDbConnection conn = FoundationDataAccess.GetConnection())
            {
                FoundationDataAccess.ExecuteNonQuery(conn, sql);
            }

            LoggingHelpers.TraceCallReturn();
        }
#endif

        /// <summary>
        /// Determines if the Entity should be Inserted, Updated, or Deleted
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ApplicationConcurrencyException">If no records were updated or deleted</exception>
        /// <exception cref="ApplicationException">If too many records were updated or deleted</exception>
        protected TModel InternalSave(IDbConnection conn, TModel entity)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", conn, entity);

            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (entity.CreatedByUserProfileId == -1)
            {
                entity.CreatedByUserProfileId = Core.CurrentLoggedOnUser.UserProfile.Id;
            }

            entity.LastUpdatedByUserProfileId = Core.CurrentLoggedOnUser.UserProfile.Id;

            Int32 recordCount = -1;

            EntityLife entityLife = entity.EntityLife;

            entity.LastUpdatedOn = DateTimeService.SystemUtcDateTimeNow;

            switch (entity.EntityLife)
            {
                case EntityLife.Created:
                {
                    VerifyCanCreate(entity);

                    entity.CreatedOn = DateTimeService.SystemUtcDateTimeNow;
                    EntityId newId = InsertNewEntity(conn, entity);
                    entity.Id = newId;

                    recordCount = 1;

                    break;
                }

                case EntityLife.Updated:
                {
                    VerifyCanEdit(entity);

                    recordCount = UpdateEntity(conn, entity);

                    break;
                }

                case EntityLife.Deleted:
                {
                    if (entity.Timestamp != null)
                    {
                        VerifyCanDelete(entity);

                        entity.EntityStatus = EntityStatus.Inactive;
                        entity.ValidTo = DateTimeService.SystemUtcDateTimeNow;
                        recordCount = DeleteEntity(conn, entity);
                    }

                    break;
                }
            }

            if (recordCount <= 0)
            {
                if (FoundationDataAccess.DatabaseTransaction is null)
                {
                    String message = "Database Transaction has not been setup/initialised. Unable to rollback with record count <= 0.";
                    throw new InvalidOperationException(message);
                }

                FoundationDataAccess.DatabaseTransaction.Rollback();

                TModel lastSavedEntity = Get(entity.Id);

                if (lastSavedEntity != null)
                {
                    IUserProfileRepository userProfileRepository = Core.IoC.Get<IUserProfileRepository>();
                    IUserProfile lastSavedByUserProfile = userProfileRepository.Get(lastSavedEntity.LastUpdatedByUserProfileId);
                    throw new ApplicationConcurrencyException(entity.Id, EntityName, TableName, lastSavedByUserProfile.Username, lastSavedByUserProfile.LastUpdatedOn, lastSavedEntity);
                }

                throw new ApplicationConcurrencyException(entity.Id, EntityName, TableName, lastSavedEntity);
            }
            
            switch (recordCount > 1)
            {
                case true when entityLife == EntityLife.Loaded:
                    if (FoundationDataAccess.DatabaseTransaction is null)
                    {
                        String message = "Database Transaction has not been setup/initialised. Unable to rollback with loaded entity.";
                        throw new InvalidOperationException(message);
                    }

                    FoundationDataAccess.DatabaseTransaction.Rollback();

                    throw new TooManyRecordsUpdatedException(entity.Id, EntityName, TableName, entity);
                case true when entityLife == EntityLife.Deleted:
                    if (FoundationDataAccess.DatabaseTransaction is null)
                    {
                        String message = "Database Transaction has not been setup/initialised. Unable to rollback with deleted entity.";
                        throw new InvalidOperationException(message);
                    }

                    FoundationDataAccess.DatabaseTransaction.Rollback();

                    throw new TooManyRecordsDeletedException(entity.Id, EntityName, TableName, entity);
            }

            entity.AcceptChanges();

            LoggingHelpers.TraceCallReturn(entityLife);

            return entity;
        }

        /// <summary>
        /// Inserts the new entity.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="entity">The entity.</param>
        protected virtual EntityId InsertNewEntity(IDbConnection conn, TModel entity)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", conn, entity);

            VerifyCanCreate(entity);

            EntityId retVal;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO");
            sql.AppendLine(TableName);
            sql.AppendLine("(");
            sql.AppendLine($"    {FDC.FoundationEntity.StatusId},");
            sql.AppendLine($"    {FDC.FoundationEntity.CreatedByUserProfileId},");
            sql.AppendLine($"    {FDC.FoundationEntity.LastUpdatedByUserProfileId},");
            sql.AppendLine($"    {FDC.FoundationEntity.CreatedOn},");
            sql.AppendLine($"    {FDC.FoundationEntity.LastUpdatedOn},");

            if (HasValidityPeriodColumns)
            {
                sql.AppendLine($"    {FDC.FoundationEntity.ValidFrom},");
                sql.AppendLine($"    {FDC.FoundationEntity.ValidTo},");
            }

            sql.AppendLine(EntityInsertColumns);
            sql.AppendLine(")");
            sql.AppendLine("VALUES");
            sql.AppendLine("(");
            sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.StatusId},");
            sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.CreatedByUserProfileId},");
            sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.LastUpdatedByUserProfileId},");
            sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.CreatedOn},");
            sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.LastUpdatedOn},");

            if (HasValidityPeriodColumns)
            {
                sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.ValidFrom},");
                sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.ValidTo},");
            }

            sql.AppendLine(EntityInsertParametersSection);
            sql.AppendLine(")");
            String identitySql = String.Format(DataLogicProvider.IdentityOfNewRowSql, TableName);
            sql.AppendLine(identitySql);

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.StatusId}", entity.EntityStatus),
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.CreatedByUserProfileId}", Core.CurrentLoggedOnUser.Id),
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.LastUpdatedByUserProfileId}", Core.CurrentLoggedOnUser.Id),
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.CreatedOn}", entity.CreatedOn),
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.LastUpdatedOn}", entity.LastUpdatedOn)
            ];

            if (HasValidityPeriodColumns)
            {
                databaseParameters.Add(FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.ValidFrom}", entity.ValidFrom));
                databaseParameters.Add(FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.ValidTo}", entity.ValidTo));
            }

            AddEntityInsertParameters(databaseParameters, entity);

            using (IDataReader dataReader = FoundationDataAccess.ExecuteReader(conn, sql.ToString(), CommandType.Text, databaseParameters))
            {
                if (dataReader.Read())
                {
                    entity.Id = DataHelpers.GetValue(dataReader[FDC.FoundationEntity.Id], new EntityId(0));
                    entity.Timestamp = DataHelpers.GetValue(dataReader[FDC.FoundationEntity.Timestamp], [0]);

                    retVal = entity.Id;
                }
                else
                {
                    throw new UnableToReadNewIdentityException(EntityName, TableName, entity);
                }

                dataReader.Close();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Updates the entity.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="entity">The entity.</param>
        protected virtual Int32 UpdateEntity(IDbConnection conn, TModel entity)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", conn, entity);

            VerifyCanEdit(entity);

            Int32 retVal = -1;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE");
            sql.AppendLine(TableName);
            sql.AppendLine("SET");
            sql.AppendLine($"    {FDC.FoundationEntity.StatusId} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.StatusId},");
            sql.AppendLine($"    {FDC.FoundationEntity.LastUpdatedByUserProfileId} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.LastUpdatedByUserProfileId},");
            sql.AppendLine($"    {FDC.FoundationEntity.LastUpdatedOn} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.LastUpdatedOn},");

            if (HasValidityPeriodColumns)
            {
                sql.AppendLine($"    {FDC.FoundationEntity.ValidFrom} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.ValidFrom},");
                sql.AppendLine($"    {FDC.FoundationEntity.ValidTo} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.ValidTo},");
            }

            sql.AppendLine(EntityUpdateColumnParameters);
            sql.AppendLine("WHERE");
            sql.AppendLine($"    {FDC.FoundationEntity.Id} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.Id} AND");
            sql.AppendLine($"    {FDC.FoundationEntity.Timestamp} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.Timestamp} ");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.StatusId}", entity.EntityStatus),
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.LastUpdatedByUserProfileId}", Core.CurrentLoggedOnUser.Id),
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.LastUpdatedOn}", DateTimeService.SystemUtcDateTimeNow)
            ];

            if (HasValidityPeriodColumns)
            {
                databaseParameters.Add(FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.ValidFrom}", entity.ValidFrom));
                databaseParameters.Add(FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.ValidTo}", entity.ValidTo));
            }

            AddEntityUpdateParameters(databaseParameters, entity);

            databaseParameters.Add(FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.Id}", entity.Id));
            databaseParameters.Add(FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.Timestamp}", entity.Timestamp));

            String timestampSql = String.Format(DataLogicProvider.TimestampOfUpdatedRowSql, TableName, $"{DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.Id}");
            sql.AppendLine(timestampSql);

            using (IDataReader dataReader = FoundationDataAccess.ExecuteReader(conn, sql.ToString(), CommandType.Text, databaseParameters))
            {
                if (dataReader.Read())
                {
                    retVal = DataHelpers.GetValue(dataReader["ROWCOUNT"], -1);
                    entity.Timestamp = DataHelpers.GetValue(dataReader[FDC.FoundationEntity.Timestamp], [0]);
                }

                dataReader.Close();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="entityId">The entity id.</param>
        protected virtual Int32 DeleteEntity(IDbConnection conn, EntityId entityId)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", conn, entityId);

            Int32 retVal = -1;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE");
            sql.AppendLine(TableName);
            sql.AppendLine("SET");
            sql.AppendLine($"    {FDC.FoundationEntity.StatusId} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.StatusId},");
            sql.AppendLine($"    {FDC.FoundationEntity.LastUpdatedByUserProfileId} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.LastUpdatedByUserProfileId},");
            sql.AppendLine($"    {FDC.FoundationEntity.LastUpdatedOn} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.LastUpdatedOn}");

            if (HasValidityPeriodColumns)
            {
                sql.AppendLine(",");
                sql.AppendLine($"    {FDC.FoundationEntity.ValidTo} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.ValidTo}");
            }

            sql.AppendLine("WHERE");
            sql.AppendLine($"    {FDC.FoundationEntity.Id} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.Id}");
            //sql.AppendLine($"    {FDC.Entity.Timestamp} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.Entity.Timestamp} ");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.StatusId}", EntityStatus.Inactive),
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.LastUpdatedByUserProfileId}", Core.CurrentLoggedOnUser.Id),
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.LastUpdatedOn}", DateTimeService.SystemUtcDateTimeNow)
            ];

            if (HasValidityPeriodColumns)
            {
                databaseParameters.Add(FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.ValidTo}", DateTimeService.SystemUtcDateTimeNow));
            }

            databaseParameters.Add(FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.Id}", entityId));
            //databaseParameters.Add(CreateParameter(FDC.Entity.Timestamp, entity.Timestamp));

            String timestampSql = String.Format(DataLogicProvider.TimestampOfUpdatedRowSql, TableName, $"{DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.Id}");
            sql.AppendLine(timestampSql);

            using (IDataReader dataReader = FoundationDataAccess.ExecuteReader(conn, sql.ToString(), CommandType.Text, databaseParameters))
            {
                if (dataReader.Read())
                {
                    retVal = DataHelpers.GetValue(dataReader["ROWCOUNT"], -1);
                    //entity.Timestamp = DataHelpers.GetValue(dataReader[FDC.Entity.Timestamp], new Byte[] { 0 });
                }

                dataReader.Close();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Deletes the entity.
        /// </summary>
        /// <param name="conn">The connection.</param>
        /// <param name="entity">The entity.</param>
        protected virtual Int32 DeleteEntity(IDbConnection conn, TModel entity)
        {
            LoggingHelpers.TraceCallEnter($"TableName: {TableName}", conn, entity);

            VerifyCanDelete(entity);

            Int32 retVal = -1;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE");
            sql.AppendLine(TableName);
            sql.AppendLine("SET");
            sql.AppendLine($"    {FDC.FoundationEntity.StatusId} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.StatusId},");
            sql.AppendLine($"    {FDC.FoundationEntity.LastUpdatedByUserProfileId} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.LastUpdatedByUserProfileId},");
            sql.AppendLine($"    {FDC.FoundationEntity.LastUpdatedOn} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.LastUpdatedOn}");

            if (HasValidityPeriodColumns)
            {
                sql.AppendLine(",");
                sql.AppendLine($"    {FDC.FoundationEntity.ValidTo} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.ValidTo}");
            }

            sql.AppendLine("WHERE");
            sql.AppendLine($"    {FDC.FoundationEntity.Id} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.Id} AND");
            sql.AppendLine(
                $"    {FDC.FoundationEntity.Timestamp} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.Timestamp} ");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.StatusId}", entity.EntityStatus),
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.LastUpdatedByUserProfileId}", Core.CurrentLoggedOnUser.Id),
                FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.LastUpdatedOn}", entity.LastUpdatedOn)
            ];

            if (HasValidityPeriodColumns)
            {
                databaseParameters.Add(FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.ValidTo}", entity.ValidTo));
            }

            databaseParameters.Add(FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.Id}", entity.Id));
            databaseParameters.Add(FoundationDataAccess.CreateParameter($"{EntityName}{FDC.FoundationEntity.Timestamp}", entity.Timestamp));

            String timestampSql = String.Format(DataLogicProvider.TimestampOfUpdatedRowSql, TableName, $"{DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.FoundationEntity.Id}");
            sql.AppendLine(timestampSql);

            using (IDataReader dataReader = FoundationDataAccess.ExecuteReader(conn, sql.ToString(), CommandType.Text, databaseParameters))
            {
                if (dataReader.Read())
                {
                    retVal = DataHelpers.GetValue(dataReader["ROWCOUNT"], -1);
                    entity.Timestamp = DataHelpers.GetValue(dataReader[FDC.FoundationEntity.Timestamp], [0]);
                }

                dataReader.Close();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Populates the entity.
        /// </summary>
        /// <param name="dataRow">The data row.</param>
        /// <returns></returns>
        protected virtual TType PopulateEntity<TType>(DataRow dataRow) where TType : IFoundationModel
        {
            LoggingHelpers.TraceCallEnter($"EntityName: {EntityName}", dataRow);

            TType retVal = Core.IoC.Get<TType>();
            retVal.Initialising = true;

            MapStandardProperties(retVal, dataRow);

            PopulateEntity(retVal, dataRow);

            retVal.Initialising = false;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Populates the entity.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <returns></returns>
        protected virtual TType PopulateEntity<TType>(IDataRecord dataRecord) where TType : IFoundationModel
        {
            LoggingHelpers.TraceCallEnter($"EntityName: {EntityName}", dataRecord);

            TType retVal = Core.IoC.Get<TType>();
            retVal.Initialising = true;

            MapStandardProperties(retVal, dataRecord);

            PopulateEntity(retVal, dataRecord);

            retVal.Initialising = false;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Populates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="dataRow">The data row.</param>
        protected virtual void PopulateEntity<TType>(TType entity, DataRow dataRow) where TType : IFoundationModel
        {
            foreach (PropertyInfo propertyInfo in EntityProperties)
            {
                if (propertyInfo.GetCustomAttribute<ColumnAttribute>() is { } columnAttribute &&
                    !String.IsNullOrEmpty(columnAttribute.Name))
                {
                    if (propertyInfo.PropertyType == typeof(String)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultString));
                    else if (propertyInfo.PropertyType == typeof(DateTime)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultDateTime));
                    else if (propertyInfo.PropertyType == typeof(DateTime?)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultDateTime));
                    else if (propertyInfo.PropertyType == typeof(TimeSpan)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultTimeSpan));
                    else if (propertyInfo.PropertyType == typeof(Boolean)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultBoolean));
                    else if (propertyInfo.PropertyType == typeof(Byte[])) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultByteArray));
                    else if (propertyInfo.PropertyType == typeof(Image)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultImage));
                    else if (propertyInfo.PropertyType == typeof(Bitmap)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultImage));
                    else if (propertyInfo.PropertyType == typeof(Decimal)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], 0m));
                    else if (propertyInfo.PropertyType.IsNumericType()) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], -1));
                    else if (propertyInfo.PropertyType == typeof(EntityId)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultEntityId));
                    else if (propertyInfo.PropertyType == typeof(AppId)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultAppId));
                    else if (propertyInfo.PropertyType == typeof(LogId)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultLogId));
                    else if (propertyInfo.PropertyType == typeof(EmailAddress)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultEmailAddress));
                    else if (propertyInfo.PropertyType == typeof(LogSeverity)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultLogSeverity));
                    else if (propertyInfo.PropertyType == typeof(FEnums.TaskStatus)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRow[columnAttribute.Name], DataHelpers.DefaultTaskStatus));
                    else if (propertyInfo.PropertyType == typeof(Object)) propertyInfo.SetValue(entity, dataRow[columnAttribute.Name]);
                    else
                    {
                        String errorMessage = $"{propertyInfo.PropertyType} is unknown. Unable to set the correct value";
                        throw new ArgumentException(errorMessage);
                    }
                }
            }
        }

        /// <summary>
        /// Populates the entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="dataRecord">The data row.</param>
        protected virtual void PopulateEntity<TType>(TType entity, IDataRecord dataRecord) where TType : IFoundationModel
        {
            foreach (PropertyInfo propertyInfo in EntityProperties)
            {
                if (propertyInfo.GetCustomAttribute<ColumnAttribute>() is { } columnAttribute &&
                    !String.IsNullOrEmpty(columnAttribute.Name))
                {
                    if (propertyInfo.PropertyType == typeof(String)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultString));
                    else if (propertyInfo.PropertyType == typeof(DateTime)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultDateTime));
                    else if (propertyInfo.PropertyType == typeof(DateTime?)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultDateTime));
                    else if (propertyInfo.PropertyType == typeof(TimeSpan)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultTimeSpan));
                    else if (propertyInfo.PropertyType == typeof(Boolean)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultBoolean));
                    else if (propertyInfo.PropertyType == typeof(Byte[])) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultByteArray));
                    else if (propertyInfo.PropertyType == typeof(Image)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultImage));
                    else if (propertyInfo.PropertyType == typeof(Bitmap)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultImage));
                    else if (propertyInfo.PropertyType == typeof(Decimal)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], 0m));
                    else if (propertyInfo.PropertyType.IsNumericType()) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], -1));
                    else if (propertyInfo.PropertyType == typeof(EntityId)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultEntityId));
                    else if (propertyInfo.PropertyType == typeof(AppId)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultAppId));
                    else if (propertyInfo.PropertyType == typeof(LogId)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultLogId));
                    else if (propertyInfo.PropertyType == typeof(EmailAddress)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultEmailAddress));
                    else if (propertyInfo.PropertyType == typeof(LogSeverity)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultLogSeverity));
                    else if (propertyInfo.PropertyType == typeof(FEnums.TaskStatus)) propertyInfo.SetValue(entity, DataHelpers.GetValue(dataRecord[columnAttribute.Name], DataHelpers.DefaultTaskStatus));
                    else if (propertyInfo.PropertyType == typeof(Object)) propertyInfo.SetValue(entity, dataRecord[columnAttribute.Name]);
                    else
                    {
                        String errorMessage = $"{propertyInfo.PropertyType} is unknown. Unable to set the correct value";
                        throw new ArgumentException(errorMessage);
                    }
                }
            }
        }

        /// <summary>
        /// Refreshes the stored cache data
        /// </summary>
        protected virtual void RefreshCacheData()
        {
            LoggingHelpers.TraceCallEnter();

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Maps the standard properties from a data row.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="dataRow">The data row.</param>
        protected void MapStandardProperties(IFoundationModel entity, DataRow dataRow)
        {
            LoggingHelpers.TraceCallEnter($"EntityName: {EntityName}", entity, dataRow);

            entity.EntityLife = EntityLife.Loaded;
            entity.EntityState = EntityState.Saved;

            entity.Id = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.Id], new EntityId(0));
            entity.Timestamp = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.Timestamp], [ 0 ]);
            entity.EntityStatus = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.StatusId], EntityStatus.Active);
            entity.CreatedByUserProfileId = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.CreatedByUserProfileId], new EntityId(0));
            entity.LastUpdatedByUserProfileId = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.LastUpdatedByUserProfileId], new EntityId(0));

            entity.CreatedOn = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.CreatedOn], DateTime.MinValue);
            entity.LastUpdatedOn = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.LastUpdatedOn], DateTime.MinValue);

            if (HasValidityPeriodColumns)
            {
                entity.ValidFrom = DataHelpers.GetNullableDateTimeValue(dataRow[FDC.FoundationEntity.ValidFrom]);
                entity.ValidTo = DataHelpers.GetNullableDateTimeValue(dataRow[FDC.FoundationEntity.ValidTo]);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Maps the standard properties from a Data Reader.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="dataRow">The data record.</param>
        protected void MapStandardProperties(IFoundationModel entity, IDataRecord dataRow)
        {
            LoggingHelpers.TraceCallEnter($"EntityName: {EntityName}", entity, dataRow);

            entity.EntityLife = EntityLife.Loaded;
            entity.EntityState = EntityState.Saved;

            entity.Id = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.Id], new EntityId(0));
            entity.Timestamp = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.Timestamp], [ 0 ]);
            entity.EntityStatus = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.StatusId], EntityStatus.Active);
            entity.CreatedByUserProfileId = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.CreatedByUserProfileId], new EntityId(0));
            entity.LastUpdatedByUserProfileId = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.LastUpdatedByUserProfileId], new EntityId(0));

            entity.CreatedOn = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.CreatedOn], DateTime.MinValue);
            entity.LastUpdatedOn = DataHelpers.GetValue(dataRow[FDC.FoundationEntity.LastUpdatedOn], DateTime.MinValue);

            if (HasValidityPeriodColumns)
            {
                entity.ValidFrom = DataHelpers.GetNullableDateTimeValue(dataRow[FDC.FoundationEntity.ValidFrom]);
                entity.ValidTo = DataHelpers.GetNullableDateTimeValue(dataRow[FDC.FoundationEntity.ValidTo]);
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
