//-----------------------------------------------------------------------
// <copyright file="NonWorkingDayRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Text;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;
using Foundation.Resources;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Core
{
    /// <summary>
    /// Defines the Non-Working Day Data Access class
    /// </summary>
    /// <see cref="INonWorkingDay" />
    [DependencyInjectionTransient]
    public class NonWorkingDayRepository : FoundationModelRepository<INonWorkingDay>, INonWorkingDayRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="NonWorkingDayRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="databaseProvider"></param>
        /// <param name="dateTimeService"></param>
        public NonWorkingDayRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ICoreDatabaseProvider databaseProvider,
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
        protected override String EntityName => FDC.NonWorkingDay.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.NonWorkingDay;

        /// <inheritdoc cref="INonWorkingDayRepository.Get(EntityId, DateTime)"/>
        public INonWorkingDay? Get(EntityId countryId, DateTime date)
        {
            LoggingHelpers.TraceCallEnter(countryId, date);

            INonWorkingDay? retVal = null;

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT");
            sql.AppendLine("    *");
            sql.AppendLine("FROM");
            sql.AppendLine($"    {FDC.TableNames.NonWorkingDay} nwd");
            sql.AppendLine("WHERE");
            sql.AppendLine($"    nwd.{FDC.NonWorkingDay.StatusId} IN ( SELECT {FDC.Status.Id} FROM {Functions.GetListOfActiveStatuses} (1) ) AND");
            sql.AppendLine(DataLogicProvider.GetDateComparisonSql($"nwd.{FDC.NonWorkingDay.Date}", DataLogicProvider.DatabaseParameterPrefix + FDC.NonWorkingDay.EntityName + FDC.NonWorkingDay.Date, " = 0 AND"));
            sql.AppendLine($"    nwd.{FDC.NonWorkingDay.CountryId} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.NonWorkingDay.EntityName}{FDC.NonWorkingDay.CountryId}");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.NonWorkingDay.EntityName}{FDC.NonWorkingDay.CountryId}", countryId),
                FoundationDataAccess.CreateParameter($"{FDC.NonWorkingDay.EntityName}{FDC.NonWorkingDay.Date}", date)
            ];

            DataTable dataTable = FoundationDataAccess.ExecuteDataTable(sql.ToString(), CommandType.Text, databaseParameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                retVal = PopulateEntity<INonWorkingDay>(dr);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
