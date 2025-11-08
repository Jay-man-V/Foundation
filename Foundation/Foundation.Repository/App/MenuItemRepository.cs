//-----------------------------------------------------------------------
// <copyright file="MenuItemRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Text;

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
            StringBuilder retVal = new StringBuilder();

            retVal.AppendLine("WITH MenuItemsCTE AS");
            retVal.AppendLine("(");
            retVal.AppendLine("    SELECT");
            retVal.AppendLine($"        m.{FDC.MenuItem.Id},");
            retVal.AppendLine($"        m.{FDC.MenuItem.Timestamp},");
            retVal.AppendLine($"        m.{FDC.MenuItem.StatusId},");
            retVal.AppendLine($"        m.{FDC.MenuItem.CreatedByUserProfileId},");
            retVal.AppendLine($"        m.{FDC.MenuItem.LastUpdatedByUserProfileId},");
            retVal.AppendLine($"        m.{FDC.MenuItem.CreatedOn},");
            retVal.AppendLine($"        m.{FDC.MenuItem.LastUpdatedOn},");
            retVal.AppendLine($"        m.{FDC.MenuItem.ValidFrom},");
            retVal.AppendLine($"        m.{FDC.MenuItem.ValidTo},");
            retVal.AppendLine($"        m.{FDC.MenuItem.ApplicationId},");
            retVal.AppendLine($"        m.{FDC.MenuItem.ParentMenuItemId},");
            retVal.AppendLine($"        m.{FDC.MenuItem.Name},");
            retVal.AppendLine($"        m.{FDC.MenuItem.Caption},");
            retVal.AppendLine($"        m.{FDC.MenuItem.ControllerAssembly},");
            retVal.AppendLine($"        m.{FDC.MenuItem.ControllerType},");
            retVal.AppendLine($"        m.{FDC.MenuItem.ViewAssembly},");
            retVal.AppendLine($"        m.{FDC.MenuItem.ViewType},");
            retVal.AppendLine($"        m.{FDC.MenuItem.HelpText},");
            retVal.AppendLine($"        m.{FDC.MenuItem.MultiInstance},");
            retVal.AppendLine($"        m.{FDC.MenuItem.ShowInTab},");
            retVal.AppendLine($"        m.{FDC.MenuItem.Icon},");
            retVal.AppendLine("        1 AS Depth");
            retVal.AppendLine("    FROM");
            retVal.AppendLine($"        {TableName} m");
            retVal.AppendLine("    WHERE");
            retVal.AppendLine($"        m.{FDC.MenuItem.ParentMenuItemId} IS NULL");
            retVal.AppendLine("    UNION ALL");
            retVal.AppendLine("    SELECT");
            retVal.AppendLine($"        s.{FDC.MenuItem.Id},");
            retVal.AppendLine($"        s.{FDC.MenuItem.Timestamp},");
            retVal.AppendLine($"        s.{FDC.MenuItem.StatusId},");
            retVal.AppendLine($"        s.{FDC.MenuItem.CreatedByUserProfileId},");
            retVal.AppendLine($"        s.{FDC.MenuItem.LastUpdatedByUserProfileId},");
            retVal.AppendLine($"        s.{FDC.MenuItem.CreatedOn},");
            retVal.AppendLine($"        s.{FDC.MenuItem.LastUpdatedOn},");
            retVal.AppendLine($"        s.{FDC.MenuItem.ValidFrom},");
            retVal.AppendLine($"        s.{FDC.MenuItem.ValidTo},");
            retVal.AppendLine($"        s.{FDC.MenuItem.ApplicationId},");
            retVal.AppendLine($"        s.{FDC.MenuItem.ParentMenuItemId},");
            retVal.AppendLine($"        s.{FDC.MenuItem.Name},");
            retVal.AppendLine($"        s.{FDC.MenuItem.Caption},");
            retVal.AppendLine($"        s.{FDC.MenuItem.ControllerAssembly},");
            retVal.AppendLine($"        s.{FDC.MenuItem.ControllerType},");
            retVal.AppendLine($"        s.{FDC.MenuItem.ViewAssembly},");
            retVal.AppendLine($"        s.{FDC.MenuItem.ViewType},");
            retVal.AppendLine($"        s.{FDC.MenuItem.HelpText},");
            retVal.AppendLine($"        s.{FDC.MenuItem.MultiInstance},");
            retVal.AppendLine($"        s.{FDC.MenuItem.ShowInTab},");
            retVal.AppendLine($"        s.{FDC.MenuItem.Icon},");
            retVal.AppendLine("        Depth + 1 AS Depth");
            retVal.AppendLine("    FROM");
            retVal.AppendLine($"        {TableName} s");
            retVal.AppendLine("            INNER JOIN MenuItemsCTE r ON");
            retVal.AppendLine("            (");
            retVal.AppendLine($"                r.Id = s.{FDC.MenuItem.ParentMenuItemId}");
            retVal.AppendLine("            )");
            retVal.AppendLine(")");
            retVal.AppendLine("SELECT");
            retVal.AppendLine("    *");
            retVal.AppendLine("FROM");
            retVal.AppendLine("    MenuItemsCTE");

            return retVal.ToString();
        }
    }
}
