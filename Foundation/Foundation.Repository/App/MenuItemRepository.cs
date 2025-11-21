//-----------------------------------------------------------------------
// <copyright file="MenuItemRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Repository.DataProvider;

using System;
using System.Data;
using System.IO;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.App
{
    /// <summary>
    /// Defines the Menu Item Data Access class
    /// </summary>
    /// <see cref="ICountry" />
    [DependencyInjectionTransient]
    public class MenuItemRepository : FoundationModelRepository<IMenuItem>, IMenuItemRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="MenuItemRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="coreDataProvider">The core data provider.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public MenuItemRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ICoreDataProvider coreDataProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                coreDataProvider,
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, coreDataProvider, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.MenuItem.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.MenuItem;

        /// <inheritdoc cref="FoundationModelRepository{IMenuItem}.GetAllSql(Boolean, Boolean)"/>
        protected override String GetAllSql(Boolean excludeDeleted, Boolean useValidityPeriod)
        {
            String retVal = File.ReadAllText(@"Sql\App\GetAll.sql");

            return retVal;
        }

        protected override IDatabaseParameters GetAllDatabaseParameters(Boolean excludeDeleted, Boolean useValidityPeriod)
        {
            IDatabaseParameters retVal = base.GetAllDatabaseParameters(excludeDeleted, useValidityPeriod);

            retVal.Add(FoundationDataAccess.CreateParameter("applicationId", Core.ApplicationId));
            retVal.Add(FoundationDataAccess.CreateParameter("useValidityPeriod", useValidityPeriod));
            retVal.Add(FoundationDataAccess.CreateParameter("excludeDeleted", excludeDeleted));

            return retVal;
        }
    }
}
