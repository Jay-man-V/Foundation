//-----------------------------------------------------------------------
// <copyright file="GenericDataGridViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows.Input;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;
using Foundation.Resources;
using Foundation.ViewModels.Sec;

namespace Foundation.ViewModels
{
    /// <summary>
    /// Implements generic routines for a Data Grid based view model
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class GenericDataGridViewModel<TModel> : ViewModel, IGenericDataGridViewModel<TModel>
        where TModel : IFoundationModel
    {
        /// <summary>Initialises a new instance of the <see cref="GenericDataGridViewModel{TModel}" /> class.</summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="commonBusinessProcess">The common business process.</param>
        protected GenericDataGridViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            ICommonBusinessProcess<TModel> commonBusinessProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                commonBusinessProcess.ScreenTitle
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, commonBusinessProcess);

            _filter1DataSource = null;
            _filter2DataSource = null;
            _filter3DataSource = null;
            _filter4DataSource = null;

            _filter1SelectedItem = null;
            _filter2SelectedItem = null;
            _filter3SelectedItem = null;
            _filter4SelectedItem = null;

            _gridDataSource = default!;
            _selectedItem = default;

            RefreshCommandEnabled = true;

            FileApi = fileApi;
            CommonBusinessProcess = commonBusinessProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the file service.
        /// </summary>
        /// <value>The file service.</value>
        protected IFileApi FileApi { get; }

        /// <summary>
        /// Gets the common business process.
        /// </summary>
        /// <value>The common business process.</value>
        protected ICommonBusinessProcess<TModel> CommonBusinessProcess { get; }
        
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.CanRefreshData"/>
        public virtual Boolean CanRefreshData => CommonBusinessProcess.CanRefreshData();

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.RefreshButtonVisible"/>
        public virtual Boolean RefreshButtonVisible => CommonBusinessProcess.CanRefreshData();

        private Boolean _refreshButtonEnabled;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.RefreshCommandEnabled"/>
        public Boolean RefreshCommandEnabled
        {
            get => _refreshButtonEnabled;
            protected internal set => SetPropertyValue(ref _refreshButtonEnabled, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.RefreshCommand"/>
        public virtual ICommand RefreshCommand { get { return RelayCommandFactory.New(OnRefreshCommand_Execute, () => RefreshCommandEnabled); } }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.CanViewRecord"/>
        public virtual Boolean CanViewRecord => CommonBusinessProcess.CanViewRecord();

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.ViewButtonVisible"/>
        public virtual Boolean ViewButtonVisible => CommonBusinessProcess.CanViewRecord();

        private Boolean _viewButtonEnabled;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.ViewRecordCommandEnabled"/>
        public Boolean ViewRecordCommandEnabled
        {
            get => _viewButtonEnabled;
            protected internal set => SetPropertyValue(ref _viewButtonEnabled, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.ViewRecordCommand"/>
        public ICommand ViewRecordCommand { get { return RelayCommandFactory.New<TModel>(OnViewRecordCommand_Execute, () => ViewRecordCommandEnabled); } }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.CanAddRecord"/>
        public virtual Boolean CanAddRecord => CommonBusinessProcess.CanAddRecord();

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.AddButtonVisible"/>
        public virtual Boolean AddButtonVisible => CommonBusinessProcess.CanAddRecord();

        private Boolean _addButtonEnabled;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.AddRecordCommandEnabled"/>
        public Boolean AddRecordCommandEnabled
        {
            get => _addButtonEnabled;
            protected internal set => SetPropertyValue(ref _addButtonEnabled, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.AddRecordCommand"/>
        public ICommand AddRecordCommand { get { return RelayCommandFactory.New(OnAddRecordCommand_Execute, () => AddRecordCommandEnabled); } }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.CanEditRecord"/>
        public virtual Boolean CanEditRecord => CommonBusinessProcess.CanEditRecord();

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.EditButtonVisible"/>
        public virtual Boolean EditButtonVisible => CommonBusinessProcess.CanEditRecord();

        private Boolean _editButtonEnabled;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.EditRecordCommandEnabled"/>
        public Boolean EditRecordCommandEnabled
        {
            get => _editButtonEnabled;
            protected internal set => SetPropertyValue(ref _editButtonEnabled, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.EditRecordCommand"/>
        public ICommand EditRecordCommand { get { return RelayCommandFactory.New<TModel>(OnEditRecordCommand_Execute, () => EditRecordCommandEnabled); } }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.CanDeleteRecord"/>
        public virtual Boolean CanDeleteRecord => CommonBusinessProcess.CanDeleteRecord();

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.DeleteButtonVisible"/>
        public virtual Boolean DeleteButtonVisible => CommonBusinessProcess.CanDeleteRecord();

        private Boolean _deleteButtonEnabled;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.DeleteRecordCommandEnabled"/>
        public Boolean DeleteRecordCommandEnabled
        {
            get => _deleteButtonEnabled;
            protected internal set => SetPropertyValue(ref _deleteButtonEnabled, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.DeleteRecordCommand"/>
        public ICommand DeleteRecordCommand { get { return RelayCommandFactory.New<TModel>(OnDeleteRecordCommand_Execute, () => DeleteRecordCommandEnabled); } }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.HasOptionalAction1"/>
        public virtual Boolean HasOptionalAction1 => CommonBusinessProcess.HasOptionalAction1;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action1Name"/>
        public virtual String Action1Name => CommonBusinessProcess.Action1Name;

        private Boolean _action1CommandEnabled;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action1CommandEnabled"/>
        public Boolean Action1CommandEnabled
        {
            get => _action1CommandEnabled;
            protected internal set => SetPropertyValue(ref _action1CommandEnabled, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action1Command"/>
        public virtual ICommand Action1Command { get { return RelayCommandFactory.New(OnAction1Command_Execute, () => Action1CommandEnabled); } }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.HasOptionalAction2"/>
        public virtual Boolean HasOptionalAction2 => CommonBusinessProcess.HasOptionalAction2;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action2Name"/>
        public virtual String Action2Name => CommonBusinessProcess.Action2Name;

        private Boolean _action2CommandEnabled;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action2CommandEnabled"/>
        public Boolean Action2CommandEnabled
        {
            get => _action2CommandEnabled;
            protected internal set => SetPropertyValue(ref _action2CommandEnabled, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action2Command"/>
        public virtual ICommand Action2Command { get { return RelayCommandFactory.New(OnAction2Command_Execute, () => Action2CommandEnabled); } }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.HasOptionalAction3"/>
        public virtual Boolean HasOptionalAction3 => CommonBusinessProcess.HasOptionalAction3;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action3Name"/>
        public virtual String Action3Name => CommonBusinessProcess.Action3Name;

        private Boolean _action3CommandEnabled;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action3CommandEnabled"/>
        public Boolean Action3CommandEnabled
        {
            get => _action3CommandEnabled;
            protected internal set => SetPropertyValue(ref _action3CommandEnabled, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action3Command"/>
        public virtual ICommand Action3Command { get { return RelayCommandFactory.New(OnAction3Command_Execute, () => Action3CommandEnabled); } }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.HasOptionalAction4"/>
        public virtual Boolean HasOptionalAction4 => CommonBusinessProcess.HasOptionalAction4;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action4Name"/>
        public virtual String Action4Name => CommonBusinessProcess.Action4Name;

        private Boolean _action4CommandEnabled;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action4CommandEnabled"/>
        public Boolean Action4CommandEnabled
        {
            get => _action4CommandEnabled;
            protected internal set => SetPropertyValue(ref _action4CommandEnabled, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Action4Command"/>
        public virtual ICommand Action4Command { get { return RelayCommandFactory.New(OnAction4Command_Execute, () => Action4CommandEnabled); } }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.ActionsVisible"/>
        public virtual Boolean ActionsVisible =>
            HasOptionalAction1 ||
            HasOptionalAction2 ||
            HasOptionalAction3 ||
            HasOptionalAction4;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.HasOptionalDropDownParameter1"/>
        public virtual Boolean HasOptionalDropDownParameter1 => CommonBusinessProcess.HasOptionalDropDownParameter1;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter1Name"/>
        public virtual String Filter1Name => CommonBusinessProcess.Filter1Name;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter1DisplayMemberPath"/>
        public virtual String Filter1DisplayMemberPath => CommonBusinessProcess.Filter1DisplayMemberPath;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter1SelectedValuePath"/>
        public virtual String Filter1SelectedValuePath => CommonBusinessProcess.Filter1SelectedValuePath;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter1SelectionChangedCommand"/>
        public virtual ICommand Filter1SelectionChangedCommand => RelayCommandFactory.New<Object>(OnFilter1SelectionChangedCommand_Execute);

        private IEnumerable? _filter1DataSource;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter1DataSource"/>
        public virtual IEnumerable? Filter1DataSource
        {
            get => _filter1DataSource;
            protected internal set => SetPropertyValue(ref _filter1DataSource, value);
        }

        private Object? _filter1SelectedItem;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter1SelectedItem"/>
        public virtual Object? Filter1SelectedItem
        {
            get => _filter1SelectedItem;
            set => SetPropertyValue(ref _filter1SelectedItem, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.HasOptionalDropDownParameter2"/>
        public virtual Boolean HasOptionalDropDownParameter2 => CommonBusinessProcess.HasOptionalDropDownParameter2;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter2Name"/>
        public virtual String Filter2Name => CommonBusinessProcess.Filter2Name;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter2DisplayMemberPath"/>
        public virtual String Filter2DisplayMemberPath => CommonBusinessProcess.Filter2DisplayMemberPath;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter2SelectedValuePath"/>
        public virtual String Filter2SelectedValuePath => CommonBusinessProcess.Filter2SelectedValuePath;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter2SelectionChangedCommand"/>
        public virtual ICommand Filter2SelectionChangedCommand => RelayCommandFactory.New<Object>(OnFilter2SelectionChangedCommand_Execute);

        private IEnumerable? _filter2DataSource;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter2DataSource"/>
        public virtual IEnumerable? Filter2DataSource
        {
            get => _filter2DataSource;
            protected internal set => SetPropertyValue(ref _filter2DataSource, value);
        }

        private Object? _filter2SelectedItem;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter2SelectedItem"/>
        public virtual Object? Filter2SelectedItem
        {
            get => _filter2SelectedItem;
            set => SetPropertyValue(ref _filter2SelectedItem, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.HasOptionalDropDownParameter3"/>
        public virtual Boolean HasOptionalDropDownParameter3 => CommonBusinessProcess.HasOptionalDropDownParameter3;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter3Name"/>
        public virtual String Filter3Name => CommonBusinessProcess.Filter3Name;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter3DisplayMemberPath"/>
        public virtual String Filter3DisplayMemberPath => CommonBusinessProcess.Filter3DisplayMemberPath;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter3SelectedValuePath"/>
        public virtual String Filter3SelectedValuePath => CommonBusinessProcess.Filter3SelectedValuePath;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter3SelectionChangedCommand"/>
        public virtual ICommand Filter3SelectionChangedCommand => RelayCommandFactory.New<Object>(OnFilter3SelectionChangedCommand_Execute);

        private IEnumerable? _filter3DataSource;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter3DataSource"/>
        public virtual IEnumerable? Filter3DataSource
        {
            get => _filter3DataSource;
            protected internal set => SetPropertyValue(ref _filter3DataSource, value);
        }

        private Object? _filter3SelectedItem;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter3SelectedItem"/>
        public virtual Object? Filter3SelectedItem
        {
            get => _filter3SelectedItem;
            set => SetPropertyValue(ref _filter3SelectedItem, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.HasOptionalDropDownParameter4"/>
        public virtual Boolean HasOptionalDropDownParameter4 => CommonBusinessProcess.HasOptionalDropDownParameter4;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter4Name"/>
        public virtual String Filter4Name => CommonBusinessProcess.Filter4Name;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter4DisplayMemberPath"/>
        public virtual String Filter4DisplayMemberPath => CommonBusinessProcess.Filter4DisplayMemberPath;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter4SelectedValuePath"/>
        public virtual String Filter4SelectedValuePath => CommonBusinessProcess.Filter4SelectedValuePath;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter4SelectionChangedCommand"/>
        public virtual ICommand Filter4SelectionChangedCommand => RelayCommandFactory.New<Object>(OnFilter4_SelectionChanged);

        private IEnumerable? _filter4DataSource;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter4DataSource"/>
        public virtual IEnumerable? Filter4DataSource
        {
            get => _filter4DataSource;
            protected internal set => SetPropertyValue(ref _filter4DataSource, value);
        }

        private Object? _filter4SelectedItem;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.Filter4SelectedItem"/>
        public virtual Object? Filter4SelectedItem
        {
            get => _filter4SelectedItem;
            set => SetPropertyValue(ref _filter4SelectedItem, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.FiltersVisible"/>
        public virtual Boolean FiltersVisible =>
            HasOptionalDropDownParameter1 ||
            HasOptionalDropDownParameter2 ||
            HasOptionalDropDownParameter3 ||
            HasOptionalDropDownParameter4;

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.StatusBarText"/>
        public virtual String StatusBarText => CommonBusinessProcess.StatusBarText;

        private ObservableCollection<IGridColumnDefinition>? _dataGridColumns;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.DataGridColumns"/>
        public ObservableCollection<IGridColumnDefinition> DataGridColumns
        {
            get
            {
                if (_dataGridColumns == null ||
                    _dataGridColumns.Count == 0)
                {
                    _dataGridColumns = new ObservableCollection<IGridColumnDefinition>(LoadGridColumns());
                }

                return _dataGridColumns;
            }
        }

        private List<IGridColumnDefinition>? _gridExportColumns;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.GridExportColumns"/>
        public List<IGridColumnDefinition> GridExportColumns
        {
            get
            {
                if (_gridExportColumns == null ||
                    _gridExportColumns.Count == 0)
                {
                    _gridExportColumns = LoadGridColumns();
                }

                return _gridExportColumns;
            }
        }

        private TModel? _selectedItem;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.SelectedItem"/>
        public TModel? SelectedItem
        {
            get => _selectedItem;
            set => SetPropertyValue(ref _selectedItem, value);
        }

        private List<TModel> _gridDataSource;
        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.GridDataSource"/>
        public List<TModel> GridDataSource
        {
            get => _gridDataSource;
            protected internal set => SetPropertyValue(ref _gridDataSource, value);
        }

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.SelectedGridItemChangedCommand"/>
        public ICommand SelectedGridItemChangedCommand => RelayCommandFactory.New<TModel>(OnSelectedGrid_ItemChanged);

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.ExportGridToExcelCommand"/>
        public ICommand ExportGridToExcelCommand => RelayCommandFactory.New<List<TModel>>(OnExportGridToExcelCommand_Execute);

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.ExportGridToCsvCommand"/>
        public ICommand ExportGridToCsvCommand => RelayCommandFactory.New<List<TModel>>(OnExportGridToCsvCommand_Execute);

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.CopyGridToCsvCommand"/>
        public ICommand CopyGridToCsvCommand => RelayCommandFactory.New<List<TModel>>(OnCopyGridToCsvCommand_Execute);

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.CopyRowToCsvCommand"/>
        public ICommand CopyRowToCsvCommand => RelayCommandFactory.New<TModel>(OnCopyRowToCsvCommand_Execute);

        /// <inheritdoc cref="IGenericDataGridViewModel{TModel}.CopyCellValueCommand"/>
        public ICommand CopyCellValueCommand => RelayCommandFactory.New<Object>(OnCopyCellValueCommand_Execute);

        /// <summary>
        /// Executes the action1.
        /// </summary>
        protected virtual void ExecuteAction1()
        {
            LoggingHelpers.TraceCallEnter();

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Executes the action2.
        /// </summary>
        protected virtual void ExecuteAction2()
        {
            LoggingHelpers.TraceCallEnter();

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Executes the action3.
        /// </summary>
        protected virtual void ExecuteAction3()
        {
            LoggingHelpers.TraceCallEnter();

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Executes the action4.
        /// </summary>
        protected virtual void ExecuteAction4()
        {
            LoggingHelpers.TraceCallEnter();

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Applies the filter1.
        /// </summary>
        /// <param name="selectedFilter">The selected filter.</param>
        protected virtual void ApplyFilter1(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter();

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Applies the filter2.
        /// </summary>
        /// <param name="selectedFilter">The selected filter.</param>
        protected virtual void ApplyFilter2(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter();

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Applies the filter3.
        /// </summary>
        /// <param name="selectedFilter">The selected filter.</param>
        protected virtual void ApplyFilter3(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter();

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Applies the filter4.
        /// </summary>
        /// <param name="selectedFilter">The selected filter.</param>
        protected virtual void ApplyFilter4(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter();

            // Does nothing

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [action1 command execute].
        /// </summary>
        protected virtual void OnAction1Command_Execute()
        {
            LoggingHelpers.TraceCallEnter();

            using (MouseCursor)
            {
                ExecuteAction1();
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [action2 command execute].
        /// </summary>
        protected virtual void OnAction2Command_Execute()
        {
            LoggingHelpers.TraceCallEnter();

            using (MouseCursor)
            {
                ExecuteAction2();
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [action3 command execute].
        /// </summary>
        protected virtual void OnAction3Command_Execute()
        {
            LoggingHelpers.TraceCallEnter();

            using (MouseCursor)
            {
                ExecuteAction3();
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [action4 command execute].
        /// </summary>
        protected virtual void OnAction4Command_Execute()
        {
            LoggingHelpers.TraceCallEnter();

            using (MouseCursor)
            {
                ExecuteAction4();
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [filter1 selection changed command execute].
        /// </summary>
        /// <param name="selectedFilter">The selected filter.</param>
        protected virtual void OnFilter1SelectionChangedCommand_Execute(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            using (MouseCursor)
            {
                ApplyFilter1(selectedFilter);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [filter2 selection changed command execute].
        /// </summary>
        /// <param name="selectedFilter">The selected filter.</param>
        protected virtual void OnFilter2SelectionChangedCommand_Execute(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            using (MouseCursor)
            {
                ApplyFilter2(selectedFilter);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [filter3 selection changed command execute].
        /// </summary>
        /// <param name="selectedFilter">The selected filter.</param>
        protected virtual void OnFilter3SelectionChangedCommand_Execute(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            using (MouseCursor)
            {
                ApplyFilter3(selectedFilter);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [filter4 selection changed].
        /// </summary>
        /// <param name="selectedFilter">The selected filter.</param>
        protected virtual void OnFilter4_SelectionChanged(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            using (MouseCursor)
            {
                ApplyFilter4(selectedFilter);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [selected grid item changed].
        /// </summary>
        /// <param name="selectedEntity">The selected entity.</param>
        protected virtual void OnSelectedGrid_ItemChanged(TModel? selectedEntity)
        {
            LoggingHelpers.TraceCallEnter(selectedEntity);

            using (MouseCursor)
            {
                Boolean canView = CommonBusinessProcess.CanViewRecord(Core.CurrentLoggedOnUser.UserProfile, selectedEntity);
                Boolean canAdd = CommonBusinessProcess.CanAddRecord(Core.CurrentLoggedOnUser.UserProfile);
                Boolean canEdit = CommonBusinessProcess.CanEditRecord(Core.CurrentLoggedOnUser.UserProfile, selectedEntity);
                Boolean canDelete = CommonBusinessProcess.CanDeleteRecord(Core.CurrentLoggedOnUser.UserProfile, selectedEntity);
                Boolean enabled = SelectedItem != null;

                ViewRecordCommandEnabled = canView && enabled;
                AddRecordCommandEnabled = canAdd;
                EditRecordCommandEnabled = canEdit && enabled;
                DeleteRecordCommandEnabled = canDelete && enabled;
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [export grid to excel command execute].
        /// </summary>
        /// <param name="sourceData">The source data.</param>
        protected virtual void OnExportGridToExcelCommand_Execute(List<TModel>? sourceData)
        {
            LoggingHelpers.TraceCallEnter(sourceData);

            using (MouseCursor)
            {
                CommonBusinessProcess.ExportToExcel(GridExportColumns, sourceData);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [export grid to Csv command execute].
        /// </summary>
        /// <param name="sourceData">The source data.</param>
        protected virtual void OnExportGridToCsvCommand_Execute(List<TModel>? sourceData)
        {
            LoggingHelpers.TraceCallEnter(sourceData);

            using (MouseCursor)
            {
                if (sourceData != null &&
                    sourceData.Any())
                {
                    ISaveFileDialogSettings saveFileDialogSettings = new SaveFileDialogSettings
                    {
                        CheckPathExists = true,
                        CreatePrompt = true,
                        DefaultExtension = ".csv",
                        Filter = FileFilters.CsvFiles,
                        FilterIndex = 0,
                        OverwritePrompt = true,
                    };

                    DialogResult dialogResult = DialogService.ShowSaveFileDialog(this, saveFileDialogSettings);

                    if (dialogResult == DialogResult.Ok)
                    {
                        String filePath = saveFileDialogSettings.FileName;

                        Encoding encoding = Encoding.UTF8;

                        using (TextWriter textWriter = FileApi.OpenFileForWriting(filePath, encoding))
                        {
                            CommonBusinessProcess.ExportToCsv(textWriter, GridExportColumns, sourceData);
                        }
                    }
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [copy grid to CSV command execute].
        /// </summary>
        /// <param name="sourceData">The source data.</param>
        protected virtual void OnCopyGridToCsvCommand_Execute(List<TModel>? sourceData)
        {
            LoggingHelpers.TraceCallEnter(sourceData);

            using (MouseCursor)
            {
                if (sourceData != null &&
                    sourceData.Any())
                {
                    String csvData = CommonBusinessProcess.ExportToCsv(GridExportColumns, sourceData);
                    ClipBoardWrapper.SetText(csvData);
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [copy row to CSV command execute].
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected virtual void OnCopyRowToCsvCommand_Execute(TModel? entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            using (MouseCursor)
            {
                if (entity != null)
                {
                    List<TModel> sourceData = [entity];

                    String csvData = CommonBusinessProcess.ExportToCsv(GridExportColumns, sourceData);
                    ClipBoardWrapper.SetText(csvData);
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [copy cell value command execute].
        /// </summary>
        /// <param name="value">The value.</param>
        protected virtual void OnCopyCellValueCommand_Execute(Object? value)
        {
            LoggingHelpers.TraceCallEnter(value);

            using (MouseCursor)
            {
                if (value != null)
                {
                    String selectedTextValue = String.Empty;
                    if (value.IsNativeType())
                    {
                        selectedTextValue = value.ToString() ?? String.Empty;
                    }

                    if (!String.IsNullOrEmpty(selectedTextValue))
                    {
                        ClipBoardWrapper.SetText(selectedTextValue);
                    }
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="Initialise"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            RefreshData();

            Int32 rowCount = GridDataSource.Count;

            if (GetType() != typeof(LoggedOnUserViewModel))
            {
                MessageType messageType = MessageType.Information;
                if (rowCount == 0)
                {
                    messageType = MessageType.Warning;
                }

                ShowNotificationMessage(messageType, "Load", $"{rowCount} {FormTitle} records loaded");
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Loads the grid columns.
        /// </summary>
        /// <returns>
        ///   <br />
        /// </returns>
        protected virtual List<IGridColumnDefinition> LoadGridColumns()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = CommonBusinessProcess.GetColumnDefinitions();

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Refreshes the data.
        /// </summary>
        protected virtual List<TModel> RefreshData()
        {
            LoggingHelpers.TraceCallEnter();

            GridDataSource = CommonBusinessProcess.GetAll();

            LoggingHelpers.TraceCallReturn(GridDataSource);

            return GridDataSource;
        }

        /// <summary>
        /// Called when [refresh command execute].
        /// </summary>
        protected virtual void OnRefreshCommand_Execute()
        {
            LoggingHelpers.TraceCallEnter();

            using (MouseCursor)
            {
                RefreshData();

                if (GetType() != typeof(LoggedOnUserViewModel))
                {
                    // Int32 rowCount = GridDataSource.Count;
                    // TODO: ShowNotificationMessage(MessageType.Information, "Load", $"{rowCount} {FormTitle} records loaded");
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [view record command execute].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ApplicationPermissionsException"></exception>
        protected virtual void OnViewRecordCommand_Execute(TModel? entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            using (MouseCursor)
            {
                Boolean canViewRecord = CommonBusinessProcess.CanViewRecord(Core.CurrentLoggedOnUser.UserProfile, entity);

                if (!canViewRecord)
                {
                    String processName = $"{GetType()}::{nameof(OnViewRecordCommand_Execute)}";
                    throw new ApplicationPermissionsException(Core.ApplicationId, Core.CurrentLoggedOnUser.Username, processName, ApplicationRole.Reporter, entity);
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [add record command execute].
        /// </summary>
        /// <exception cref="ApplicationPermissionsException">null</exception>
        protected virtual void OnAddRecordCommand_Execute()
        {
            LoggingHelpers.TraceCallEnter();

            using (MouseCursor)
            {
                Boolean canAddRecord = CommonBusinessProcess.CanAddRecord(Core.CurrentLoggedOnUser.UserProfile);

                if (!canAddRecord)
                {
                    String processName = $"{GetType()}::{nameof(OnAddRecordCommand_Execute)}";
                    throw new ApplicationPermissionsException(Core.ApplicationId, Core.CurrentLoggedOnUser.Username, processName, ApplicationRole.Creator, null);
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [edit record command execute].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ApplicationPermissionsException"></exception>
        protected virtual void OnEditRecordCommand_Execute(TModel? entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            using (MouseCursor)
            {
                Boolean canEditRecord = CommonBusinessProcess.CanEditRecord(Core.CurrentLoggedOnUser.UserProfile, entity);

                if (!canEditRecord)
                {
                    String processName = $"{GetType()}::{nameof(OnEditRecordCommand_Execute)}";
                    ApplicationRole[] permissions = { ApplicationRole.OwnEditor, ApplicationRole.AllEditor };
                    throw new ApplicationPermissionsException(Core.ApplicationId, processName, permissions, entity, Core.CurrentLoggedOnUser.UserProfile);
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Called when [delete record command execute].
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ApplicationPermissionsException"></exception>
        protected virtual void OnDeleteRecordCommand_Execute(TModel? entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            using (MouseCursor)
            {
                Boolean canDeleteRecord = CommonBusinessProcess.CanDeleteRecord(Core.CurrentLoggedOnUser.UserProfile, entity);

                if (!canDeleteRecord)
                {
                    String processName = $"{GetType()}::{LocationUtils.GetFunctionName()}";
                    ApplicationRole[] permissions = { ApplicationRole.OwnDelete, ApplicationRole.AllDelete };
                    throw new ApplicationPermissionsException(Core.ApplicationId, processName, permissions, entity, Core.CurrentLoggedOnUser.UserProfile);
                }
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
