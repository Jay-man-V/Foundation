//-----------------------------------------------------------------------
// <copyright file="PermissionMatrixRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Text;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;

using FDC = Foundation.Common.DataColumns;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the Permission Matrix Data Access class
    /// </summary>
    /// <see cref="IPermissionMatrix" />
    [DependencyInjectionTransient]
    public class PermissionMatrixRepository : FoundationModelRepository<IPermissionMatrix>, IPermissionMatrixRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="PermissionMatrixRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="databaseProvider"></param>
        /// <param name="dateTimeService"></param>
        public PermissionMatrixRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ISecurityDatabaseProvider databaseProvider,
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

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.PermissionMatrix.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.PermissionMatrix;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumCreateRole"/>
        protected override ApplicationRole RequiredMinimumCreateRole => ApplicationRole.SystemDataAdministrator;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumEditRole"/>
        protected override ApplicationRole RequiredMinimumEditRole => ApplicationRole.SystemDataAdministrator;

        /// <inheritdoc cref="IPermissionMatrixRepository.CanUserPerformFunction(ref AuthenticationToken, String)"/>
        public Boolean CanUserPerformFunction(ref AuthenticationToken authenticationToken, String functionKey)
        {
            LoggingHelpers.TraceCallEnter(authenticationToken, functionKey);

            Boolean retVal = false;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("    pm.*, ");
            sql.AppendLine("FROM ");
            sql.AppendLine($"    {FDC.TableNames.PermissionMatrix} pm ");
            sql.AppendLine($"        INNER JOIN {FDC.TableNames.Application} a ON");
            sql.AppendLine("        (");
            sql.AppendLine($"             a.{FDC.Application.Id} = pm.{FDC.PermissionMatrix.ApplicationId} ");
            sql.AppendLine("        )");
            sql.AppendLine($"        INNER JOIN {FDC.TableNames.Role} r ON");
            sql.AppendLine("        (");
            sql.AppendLine($"             a.{FDC.Role.Id} = pm.{FDC.PermissionMatrix.RoleId} ");
            sql.AppendLine("        )");
            sql.AppendLine("WHERE ");
            sql.AppendLine($"    pm.{FDC.PermissionMatrix.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND ");
            sql.AppendLine($"    pm.{FDC.Application.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND ");
            sql.AppendLine($"    r.{FDC.Role.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND ");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN pm.{FDC.PermissionMatrix.ValidFrom} AND a.{FDC.PermissionMatrix.ValidTo} AND ");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN a.{FDC.Application.ValidFrom} AND a.{FDC.Application.ValidTo} AND ");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN r.{FDC.Role.ValidFrom} AND r.{FDC.Role.ValidTo} AND ");
            sql.AppendLine($"    pm.{FDC.PermissionMatrix.ApplicationId} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.PermissionMatrix.EntityName}{FDC.PermissionMatrix.ApplicationId} AND ");
            sql.AppendLine($"    pm.{FDC.PermissionMatrix.UserProfileId} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.PermissionMatrix.EntityName}{FDC.PermissionMatrix.UserProfileId} AND ");
            sql.AppendLine($"    pm.{FDC.PermissionMatrix.FunctionKey} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.PermissionMatrix.EntityName}{FDC.PermissionMatrix.FunctionKey} ");
            sql.AppendLine("ORDER BY");
            sql.AppendLine($"    {FDC.PermissionMatrix.RoleId} DESC, {FDC.PermissionMatrix.Permission} ASC");

            DatabaseParameters databaseParameters = new DatabaseParameters
            {
                FoundationDataAccess.CreateParameter($"{FDC.PermissionMatrix.EntityName}{FDC.PermissionMatrix.ApplicationId}", authenticationToken.ApplicationId),
                FoundationDataAccess.CreateParameter($"{FDC.PermissionMatrix.EntityName}{FDC.PermissionMatrix.UserProfileId}", authenticationToken.UserProfileId),
                FoundationDataAccess.CreateParameter($"{FDC.PermissionMatrix.EntityName}{FDC.PermissionMatrix.FunctionKey}", functionKey),
            };

            Int32 recordCount = FoundationDataAccess.ExecuteGetRowCount(sql.ToString(), CommandType.Text, databaseParameters);

            retVal = recordCount > 0;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
