//-----------------------------------------------------------------------
// <copyright file="MenuItemRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

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
        /// <param name="databaseProvider"></param>
        /// <param name="dateTimeService"></param>
        public MenuItemRepository
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
        protected override String EntityName => FDC.MenuItem.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.MenuItem;

        /// <inheritdoc cref="FoundationModelRepository{IMenuItem}.GetAllSql(Boolean, Boolean)"/>
        protected override String GetAllSql(Boolean excludeDeleted, Boolean useValidityPeriod)
        {
            String retVal = String.Empty;

            retVal += "WITH MenuItemsCTE AS";
            retVal += "(";
            retVal += "    SELECT";
            retVal += "        Id,";
            retVal += "        Timestamp,";
            retVal += "        StatusId,";
            retVal += "        CreatedByUserProfileId,";
            retVal += "        LastUpdatedByUserProfileId,";
            retVal += "        CreatedOn,";
            retVal += "        LastUpdatedOn,";
            retVal += "        ValidFrom,";
            retVal += "        ValidTo,";
            retVal += "        ApplicationId,";
            retVal += "        ParentMenuItemId,";
            retVal += "        Name,";
            retVal += "        Caption,";
            retVal += "        ControllerAssembly,";
            retVal += "        ControllerType,";
            retVal += "        ViewAssembly,";
            retVal += "        ViewType,";
            retVal += "        HelpText,";
            retVal += "        MultiInstance,";
            retVal += "        ShowInTab,";
            retVal += "        Icon,";
            retVal += "        1 AS Depth";
            retVal += "    FROM";
            retVal += $"        {TableName} m";
            retVal += "    WHERE";
            retVal += "        ParentMenuItemId IS NULL";
            retVal += "    UNION ALL";
            retVal += "    SELECT";
            retVal += "        s.Id,";
            retVal += "        s.Timestamp,";
            retVal += "        s.StatusId,";
            retVal += "        s.CreatedByUserProfileId,";
            retVal += "        s.LastUpdatedByUserProfileId,";
            retVal += "        s.CreatedOn,";
            retVal += "        s.LastUpdatedOn,";
            retVal += "        s.ValidFrom,";
            retVal += "        s.ValidTo,";
            retVal += "        s.ApplicationId,";
            retVal += "        s.ParentMenuItemId,";
            retVal += "        s.Name,";
            retVal += "        s.Caption,";
            retVal += "        s.ControllerAssembly,";
            retVal += "        s.ControllerType,";
            retVal += "        s.ViewAssembly,";
            retVal += "        s.ViewType,";
            retVal += "        s.HelpText,";
            retVal += "        s.MultiInstance,";
            retVal += "        s.ShowInTab,";
            retVal += "        s.Icon,";
            retVal += "        Depth + 1 AS Depth";
            retVal += "    FROM";
            retVal += $"        {TableName} s";
            retVal += "            INNER JOIN MenuItemsCTE r ON";
            retVal += "            (";
            retVal += "                r.Id = s.ParentMenuItemId";
            retVal += "            )";
            retVal += ")";
            retVal += "SELECT";
            retVal += "    *";
            retVal += "FROM";
            retVal += "    MenuItemsCTE";

            return retVal;
        }
    }
}
