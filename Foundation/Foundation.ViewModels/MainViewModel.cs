//-----------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

//using Foundation.BusinessProcess;
using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Views;

using FEnums = Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Main application
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IApprovalStatus}" />
    public class MainViewModel : ViewModelBase, IMainWindowViewModel
    {
        private Boolean _enabled;

        /// <summary>
        /// Initialises a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="targetWindow">The target window.</param>
        /// <param name="applicationProcess">The application process.</param>
        /// <param name="menuItemProcess">The menu item process.</param>
        public MainViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IWindow targetWindow,
            IApplicationProcess applicationProcess,
            IMenuItemProcess menuItemProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                ""
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, targetWindow);

            FileApi = fileApi;
            ApplicationProcess = applicationProcess;
            MenuItemProcess = menuItemProcess;

            LoggedOnUsername = Core.CurrentLoggedOnUser.Username;
            LoggedOnUserDisplayName = Core.CurrentLoggedOnUser.DisplayName;
            Version = "<None>";
            UserRole = "<None>";
            Environment = "Dev";

            foreach (IRole role in Core.CurrentLoggedOnUser.UserProfile.Roles)
            {
                if (UserRole.Length > 0) UserRole += "|";

                UserRole += role.Name;
            }

            LoggedOnUsersViewModel = new LoggedOnUserViewModel(Core, RunTimeEnvironmentSettings, DateTimeService, wpfApplicationObjects, FileApi, LoggedOnUserProcess);
            LoggedOnUsersViewModel.Initialise(targetWindow, this, "Logged on Users");

            TabItems = new ObservableCollection<TabItem>();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            IApplication application = ApplicationProcess.Get(new EntityId(Core.ApplicationId.ToInteger()));
            ApplicationName = application.Name;

            MenuItems = MenuItemProcess.GetAll(excludeDeleted: true);

            InitialiseMenuItems();

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets or sets the child window counter.
        /// </summary>
        /// <value>
        /// The child window counter.
        /// </value>
        private Int32 ChildWindowCounter { get; set; }

        /// <summary>
        /// Gets the logged on users view model.
        /// </summary>
        /// <value>
        /// The logged on users view model.
        /// </value>
        private LoggedOnUserViewModel LoggedOnUsersViewModel { get; }

        /// <summary>
        /// Gets the file service.
        /// </summary>
        /// <value>
        /// The file service.
        /// </value>
        protected IFileApi FileApi { get; }

        /// <summary>
        /// Gets the menu item process.
        /// </summary>
        /// <value>
        /// The menu item process.
        /// </value>
        protected IApplicationProcess ApplicationProcess { get; }

        /// <summary>
        /// Gets the menu item process.
        /// </summary>
        /// <value>
        /// The menu item process.
        /// </value>
        protected IMenuItemProcess MenuItemProcess { get; }

        /// <summary>
        /// Gets the menu items.
        /// </summary>
        /// <value>
        /// The menu items.
        /// </value>
        protected List<IMenuItem> MenuItems { get; private set; }

        /// <summary>
        /// Gets the application name.
        /// </summary>
        /// <value>
        /// The application name.
        /// </value>
        public String ApplicationName { get; private set; }

        /// <summary>
        /// Gets the version.
        /// </summary>
        /// <value>
        /// The version.
        /// </value>
        public String Version { get; }

        /// <summary>
        /// Gets the logged on username.
        /// </summary>
        /// <value>
        /// The logged on username.
        /// </value>
        public String LoggedOnUsername { get; }

        /// <summary>
        /// Gets the logged on user display name.
        /// </summary>
        /// <value>
        /// The logged on user display name.
        /// </value>
        public String LoggedOnUserDisplayName { get; }

        /// <summary>
        /// Gets the user role.
        /// </summary>
        /// <value>
        /// The user role.
        /// </value>
        public String UserRole { get; }

        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        public String Database { get; }

        /// <summary>
        /// Gets the environment.
        /// </summary>
        /// <value>
        /// The environment.
        /// </value>
        public String Environment { get; }

        /// <summary>
        /// Gets the re show last exception error dialog.
        /// </summary>
        /// <value>
        /// The re show last exception error dialog.
        /// </value>
        public ICommand ReShowLastExceptionErrorDialogCommand { get { return RelayCommandFactory.New(ReShowLastExceptionErrorDialog_Click, () => LastException != null); } }

        /// <summary>
        /// Gets the logged on user click command.
        /// </summary>
        /// <value>
        /// The logged on user click command.
        /// </value>
        public ICommand LoggedOnUserClickCommand => RelayCommandFactory.New(LoggedOnUserClickCommand_Click);

        /// <summary>
        /// Gets the sample command with argument.
        /// </summary>
        /// <value>
        /// The sample command with argument.
        /// </value>
        public ICommand SampleCmdWithArgument => RelayCommandFactory.New<Object>(OnSampleCmdWithArgument_Click);

        /// <summary>
        /// Gets the show about dialog command.
        /// </summary>
        /// <value>
        /// The show about dialog command.
        /// </value>
        public ICommand ShowAboutDialogCommand => RelayCommandFactory.New(OnShowAboutDialog_Click);

        /// <summary>
        /// Gets the open test form command.
        /// </summary>
        /// <value>
        /// The open test form command.
        /// </value>
        public ICommand OpenTestFormCommand => RelayCommandFactory.New(OnOpenTestForm_Click, RelayCommandFactory.AlwaysTrue);

        /// <summary>
        /// Gets the open new notification command.
        /// </summary>
        /// <value>
        /// The open new notification command.
        /// </value>
        public ICommand OpenNewNotificationCommand => RelayCommandFactory.New(OnOpenNewNotification_Click);

        /// <summary>
        /// Gets the open error dialog command.
        /// </summary>
        /// <value>
        /// The open error dialog command.
        /// </value>
        public ICommand OpenErrorDialogCommand => RelayCommandFactory.New(OnOpenErrorDialog_Click);

        /// <summary>
        /// Gets the Menu selection left click command.
        /// </summary>
        /// <value>
        /// The Menu selection left click command.
        /// </value>
        public ICommand MenuSelectionLeftClickCommand => RelayCommandFactory.New<IMenuItem>(OnMenuSelection_LeftClick);

        /// <summary>
        /// Gets the Menu selection right click command.
        /// </summary>
        /// <value>
        /// The Menu selection right click command.
        /// </value>
        public ICommand MenuSelectionRightClickCommand => RelayCommandFactory.New<IMenuItem>(OnMenuSelection_RightClick);

        /// <summary>
        /// Gets the save command.
        /// </summary>
        /// <value>
        /// The save command.
        /// </value>
        public ICommand SaveCommand { get { return RelayCommandFactory.New<IMenuItem>(OnSave_Click, () => _enabled); } }

        /// <summary>
        /// Gets the Menu selected item changed.
        /// </summary>
        /// <value>
        /// The Menu selected item changed.
        /// </value>
        public ICommand MenuSelectedItemChanged => RelayCommandFactory.New<IMenuItem>(MenuSelectedItemChanged_Click, RelayCommandFactory.AlwaysTrue);

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>
        /// The selected item.
        /// </value>
        public Object SelectedItem { get; set; }

        private ObservableCollection<TabItem> _tabItems;
        /// <summary>
        /// Gets or sets the tab items.
        /// </summary>
        /// <value>
        /// The tab items.
        /// </value>
        public ObservableCollection<TabItem> TabItems
        {
            get => _tabItems;
            set => SetPropertyValue(ref _tabItems, value);
        }

        private ObservableCollection<IMenuItem> _applicationMenuItems;
        /// <summary>
        /// Gets or sets the application menu items.
        /// </summary>
        /// <value>
        /// The application menu items.
        /// </value>
        public ObservableCollection<IMenuItem> ApplicationMenuItems
        {
            get => _applicationMenuItems;
            set => SetPropertyValue(ref _applicationMenuItems, value);
        }

        private IMenuItem _selectedApplicationMenuItem;
        /// <summary>
        /// Gets or sets the selected application menu item.
        /// </summary>
        /// <value>
        /// The selected application menu item.
        /// </value>
        public IMenuItem SelectedApplicationMenuItem
        {
            get => _selectedApplicationMenuItem;
            set
            {
                SetPropertyValue(ref _selectedApplicationMenuItem, value);
                IEnumerable<IMenuItem> applicationMenuItems = MenuItems.Where(mi => mi.ParentMenuItemId == _selectedApplicationMenuItem.Id);
                AvailableMenuItems = new ObservableCollection<IMenuItem>(applicationMenuItems);
            }
        }

        private ObservableCollection<IMenuItem> _availableMenuItems;
        /// <summary>
        /// Gets or sets the Available menu items.
        /// </summary>
        /// <value>
        /// The Available menu items.
        /// </value>
        public ObservableCollection<IMenuItem> AvailableMenuItems
        {
            get => _availableMenuItems;
            set => SetPropertyValue(ref _availableMenuItems, value);
        }

        private BindingList<IMenuItem> _menuBarItems;
        /// <summary>
        /// Gets or sets the menu bar items.
        /// </summary>
        /// <value>
        /// The menu bar items.
        /// </value>
        public BindingList<IMenuItem> MenuBarItems
        {
            get => _menuBarItems;
            set => SetPropertyValue(ref _menuBarItems, value);
        }

        /// <summary>
        /// Displays a message box to the user containing details of the <paramref name="exception" />
        /// </summary>
        /// <param name="exception"></param>
        public void DisplayUnhandledExceptionMessage(Exception exception)
        {
            Visibility continueVisibility = Visibility.Visible;
            MessageDialogForm theForm = new MessageDialogForm();
            ErrorDialogViewModel errorDialogViewModel = new ErrorDialogViewModel(Core, RunTimeEnvironmentSettings, DateTimeService, WpfApplicationObjects, theForm, this, exception, continueVisibility);

            // Show a message before closing application
            theForm.DataContext = errorDialogViewModel;
            theForm.Owner = ThisWindow as Window;
            theForm.Show();
        }

        /// <summary>
        /// Initialises the menu items.
        /// </summary>
        private void InitialiseMenuItems()
        {
            LoggingHelpers.TraceCallEnter();

            //List<IMenuItem> menuBarItems = ApplicationDefinition.ViewMenuItems.Where(mi => !String.IsNullOrEmpty(mi.Menu)).ToList();

            ApplicationMenuItems = new ObservableCollection<IMenuItem>(MenuItems.Where(mi => mi.ParentMenuItemId == MenuItemProcess.AllId));
            SelectedApplicationMenuItem = ApplicationMenuItems[0];

            //MenuBarItems = new BindingList<IMenuItem>(menuBarItems);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Logged on user click command click.
        /// </summary>
        private void LoggedOnUserClickCommand_Click()
        {
            LoggingHelpers.TraceCallEnter();

            StdContainerWindow theForm = new StdContainerWindow(this, typeof(LoggedOnUsersControl), LoggedOnUsersViewModel)
            {
                Owner = ThisWindow as Window
            };

            theForm.ShowDialog();

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [save click].
        /// </summary>
        /// <param name="menuItem">The menu item.</param>
        private void OnSave_Click(IMenuItem menuItem)
        {
            LoggingHelpers.TraceCallEnter(menuItem);

            Debug.Print($"{LocationUtils.GetFunctionName()} Called");

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [Menu selected item changed click].
        /// </summary>
        /// <param name="menuItem">The menu item.</param>
        private void MenuSelectedItemChanged_Click(IMenuItem menuItem)
        {
            LoggingHelpers.TraceCallEnter(menuItem);

            using (MouseCursor)
            {
                Debug.Print($"{LocationUtils.GetFunctionName()} - {menuItem.Caption}");
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [menu selection left click].
        /// </summary>
        /// <param name="menuItem">The menu item.</param>
        private void OnMenuSelection_LeftClick(IMenuItem menuItem)
        {
            LoggingHelpers.TraceCallEnter(menuItem);

            using (MouseCursor)
            {
                if (menuItem != null &&
                    menuItem.ControllerAssembly != null &&
                    menuItem.ViewAssembly != null)
                {
                    ChildWindowCounter++;

                    String controllerAssembly = menuItem.ControllerAssembly;
                    String controllerType = menuItem.ControllerType;
                    String viewAssembly = menuItem.ViewAssembly;
                    String viewType = menuItem.ViewType;
                    IViewModel viewModel;
                    try
                    {
                        viewModel = Core.IoC.Get<IViewModel>(controllerAssembly, controllerType);
                    }
                    catch (Exception exception)
                    {
                        throw new Exception($"Unable to create View Model: '{controllerType}' from '{controllerAssembly}'", exception);
                    }

                    ContentControl contentControl;
                    try
                    {
                        contentControl = Core.IoC.Get<ContentControl>(viewAssembly, viewType);
                        IWindow targetWindow = contentControl as IWindow;
                        viewModel.Initialise(targetWindow, this, menuItem.Caption);
                        contentControl.DataContext = viewModel;
                    }
                    catch (Exception exception)
                    {
                        throw new Exception($"Unable to View - {menuItem.Caption}: '{viewType}' from '{viewAssembly}'", exception);
                    }

                    TabItem tabItem = null;
                    Window window = null;

                    if (menuItem.ShowInTab)
                    {
                        // See if the view has been created already
                        tabItem = TabItems.FirstOrDefault(ti => menuItem.Name.Equals(ti.Tag));

                        if (tabItem == null ||
                            menuItem.MultiInstance)
                        {
                            tabItem = new TabItem
                            {
                                Tag = menuItem.Name,
                                Header = menuItem.Caption,
                                Content = contentControl,
                            };
                        }
                    }
                    else
                    {
                        foreach (Window openWindow in Application.Current.Windows)
                        {
                            if (menuItem.Name.Equals(openWindow.Tag))
                            {
                                window = openWindow;
                            }
                        }

                        if (window == null ||
                            menuItem.MultiInstance)
                        {
                            if (contentControl is Window control)
                            {
                                window = control;
                            }
                            else
                            {
                                window = new StdContainerWindow
                                {
                                    Tag = menuItem.Name,
                                    Title = menuItem.Caption,
                                    Content = contentControl,
                                };
                            }

                            window.Owner = Application.Current.MainWindow;
                        }
                    }

                    if (tabItem != null)
                    {
                        tabItem.IsSelected = true;
                        if (!TabItems.Any(ti => menuItem.Name.Equals(ti.Tag)))
                        {
                            TabItems.Add(tabItem);
                        }

                        if (menuItem.MultiInstance)
                        {
                            TabItems.Add(tabItem);
                        }
                    }
                    else
                    {
                        window.Show();
                        window.Activate();
                        window.Topmost = true;
                        window.Topmost = false;
                        window.Focus();
                    }
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [menu selection right click].
        /// </summary>
        /// <param name="menuItem">The menu item.</param>
        private void OnMenuSelection_RightClick(IMenuItem menuItem)
        {
            LoggingHelpers.TraceCallEnter(menuItem);

            using (MouseCursor)
            {
                Debug.Print($"{LocationUtils.GetFunctionName()} - {menuItem.Caption}");
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Res the show last exception error dialog click.
        /// </summary>
        private void ReShowLastExceptionErrorDialog_Click()
        {
            LoggingHelpers.TraceCallEnter();

            using (MouseCursor)
            {
                if (LastException != null)
                {
                    DisplayUnhandledExceptionMessage(LastException);
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [sample command with argument click].
        /// </summary>
        /// <param name="obj">The object.</param>
        private void OnSampleCmdWithArgument_Click(Object obj)
        {
            LoggingHelpers.TraceCallEnter(obj);

            using (MouseCursor)
            {

            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [show about dialog click].
        /// </summary>
        private void OnShowAboutDialog_Click()
        {
            LoggingHelpers.TraceCallEnter();

            using (MouseCursor)
            {
                LoggingHelpers.TraceMessage("Opening About dialog");
                IViewModel parentViewModel = this;
                AboutSplashScreenForm theForm = new AboutSplashScreenForm();
                AboutSplashScreenFormViewModel viewModel = new AboutSplashScreenFormViewModel(Core, RunTimeEnvironmentSettings, DateTimeService, WpfApplicationObjects, false);
                theForm.DataContext = viewModel;
                theForm.Show();
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [open new notification click].
        /// </summary>
        private void OnOpenNewNotification_Click()
        {
            LoggingHelpers.TraceCallEnter();

            using (MouseCursor)
            {
                IRandomService randomService = Core.IoC.Get<IRandomService>();
                FEnums.MessageType messageType = (FEnums.MessageType)randomService.NextInt32(1, 6);
                String messageHeader = messageType.ToString();
                String message = $"{messageType} Content";
                ShowNotificationMessage(messageType, messageHeader, message);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [open test form click].
        /// </summary>
        private void OnOpenTestForm_Click()
        {
            LoggingHelpers.TraceCallEnter();

            using (MouseCursor)
            {
                //TestForm theForm = new TestForm();
                //theForm.DataContext = new TestFormViewModel();

                //IOpenFolderDialogSettings openFolderDialogSettings = new OpenFolderDialogSettings();
                //IDialogService ds = Core.Core.Instance.Container.Get<IDialogService>();
                //DialogResult dialogResult = ds.ShowOpenFolderDialog(this, openFolderDialogSettings);

                //if (dialogResult == DialogResult.Ok)
                //{
                //    Debug.WriteLine(openFolderDialogSettings.FolderName);
                //}

                IRandomService randomService = Core.IoC.Get<IRandomService>();
                Int32[] iconIds = { 0, 16, 32, 48, 64, 16, 16, 48, 64 };
                FEnums.MessageBoxImage messageBoxImage = (FEnums.MessageBoxImage)iconIds[randomService.NextInt32(1, 9)];

                MessageDialogForm theForm = new MessageDialogForm();
                MessageDialogViewModel messageDialogViewModel = new MessageDialogViewModel(Core, RunTimeEnvironmentSettings, DateTimeService, WpfApplicationObjects, theForm, this);

                messageDialogViewModel.MessageBoxImage = messageBoxImage;
                messageDialogViewModel.FormTitle = $"Form Title - {messageDialogViewModel.MessageBoxImage}";
                messageDialogViewModel.ScreenInstructions = $"Screen instructions - {messageDialogViewModel.MessageBoxImage}";

                theForm.DataContext = messageDialogViewModel;
                theForm.Owner = ThisWindow as Window;
                theForm.ShowDialog();
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [open error dialog click].
        /// </summary>
        private void OnOpenErrorDialog_Click()
        {
            LoggingHelpers.TraceCallEnter();

            using (MouseCursor)
            {
                _enabled = !_enabled;

                const Boolean throwNew = false;
                const Boolean throwException = true;
                ExceptionManagementDemo d = new ExceptionManagementDemo();
                d.Method1(throwException, throwNew);
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
