//-----------------------------------------------------------------------
// <copyright file="MenuItemProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Drawing;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// The MenuItem Business Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class MenuItemProcess : CommonBusinessProcess<IMenuItem, IMenuItemRepository>, IMenuItemProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="MenuItemProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        /// <param name="applicationProcess">The application process.</param>
        public MenuItemProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IMenuItemRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            IApplicationProcess applicationProcess
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                repository,
                statusRepository,
                userProfileRepository
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, userProfileRepository, applicationProcess);

            ApplicationProcess = applicationProcess;

            LoggingHelpers.TraceCallReturn();
        }

        private IApplicationProcess ApplicationProcess { get; }


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter1"/>
        public override Boolean HasOptionalDropDownParameter1 => true;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1Name"/>
        public override String Filter1Name => "Application:";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1DisplayMemberPath"/>
        public override String Filter1DisplayMemberPath => ApplicationProcess.ComboBoxDisplayMember;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1SelectedValuePath"/>
        public override String Filter1SelectedValuePath => ApplicationProcess.ComboBoxValueMember;


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter2"/>
        public override Boolean HasOptionalDropDownParameter2 => true;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2Name"/>
        public override String Filter2Name => "Parent:";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2DisplayMemberPath"/>
        public override String Filter2DisplayMemberPath => ComboBoxDisplayMember;


        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Menu Items";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Menu Items:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.MenuItem.Caption;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(300, FDC.MenuItem.Icon, "Icon", typeof(Image));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.MenuItem.MultiInstance, "Multi Instance", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.MenuItem.ShowInTab, "Show in Tab", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.MenuItem.Depth, "Depth", typeof(Int32));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.MenuItem.ApplicationId, "Application", typeof(AppId))
            {
                TextAlignment = TextAlignment.Centre,
                DataSource = ApplicationProcess.GetAll(excludeDeleted: false),
                ValueMember = ApplicationProcess.ComboBoxValueMember,
                DisplayMember = ApplicationProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.MenuItem.ParentMenuItemId, "Parent Menu Item", typeof(String))
            {
                TextAlignment = TextAlignment.Centre,
                DataSource = GetAll(excludeDeleted: false),
                ValueMember = ComboBoxValueMember,
                DisplayMember = ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(115, FDC.MenuItem.Name, "Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(115, FDC.MenuItem.Caption, "Caption", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.MenuItem.HelpText, "Help text", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.MenuItem.ControllerAssembly, "Controller Assembly", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.MenuItem.ControllerType, "Controller Type", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.MenuItem.ViewAssembly, "View Assembly", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.MenuItem.ViewType, "View Type", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IMenuItemProcess.ApplyFilter(List{IMenuItem}, IApplication?, IMenuItem?)"/>
        public List<IMenuItem> ApplyFilter(List<IMenuItem> menuItems, IApplication? application, IMenuItem? parentMenuItem)
        {
            LoggingHelpers.TraceCallEnter(menuItems, parentMenuItem);

            List<IMenuItem> retVal = menuItems;

            // Application
            if (application != null)
            {
                retVal = retVal.Where(mi => (mi.ApplicationId == application.Id) ||                         // Matching Application
                                            (application.Id == ApplicationProcess.AllId) ||                 // All records
                                            (application.Id == ApplicationProcess.NoneId &&
                                             mi.ApplicationId == ApplicationProcess.NullId)                 // No Application
                                      ).ToList();
            }

            // Parent Menu Item
            if (parentMenuItem != null)
            {
                retVal = retVal.Where(mi => (mi.ParentMenuItemId == parentMenuItem.Id) ||                   // Matching Application
                                            (parentMenuItem.Id == this.AllId) ||                            // All records
                                            (parentMenuItem.Id == this.NoneId &&
                                             mi.Id == this.NullId)                                          // No Application
                ).ToList();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IMenuItemProcess.MakeListOfParentMenuItems(List{IMenuItem})"/>
        public List<IMenuItem> MakeListOfParentMenuItems(List<IMenuItem> menuItems)
        {
            LoggingHelpers.TraceCallEnter(menuItems);

            List<IMenuItem> retVal;

            IEnumerable<IMenuItem> menuItemsWithParents = menuItems.Where(mi => mi.ParentMenuItemId.ToInteger() > -1);
            IEnumerable<IMenuItem> localParentMenuItemsWithDuplicates = menuItems.Where(mi => menuItemsWithParents.Any(miwp => miwp.ParentMenuItemId == mi.Id));
            HashSet<IMenuItem> parentMenuItemsWithoutDuplicates = new HashSet<IMenuItem>(localParentMenuItemsWithDuplicates);
            retVal = parentMenuItemsWithoutDuplicates.OrderBy(mi => mi.Caption).ToList();

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
