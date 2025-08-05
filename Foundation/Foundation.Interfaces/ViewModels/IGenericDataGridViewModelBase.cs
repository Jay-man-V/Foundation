//-----------------------------------------------------------------------
// <copyright file="IGenericDataGridViewModelBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Generic DataGrid View Model Base
    /// </summary>
    public interface IGenericDataGridViewModelBase<TModel> : IViewModel
        where TModel : IFoundationModel
    {
        /// <summary>Gets the status bar text.</summary>
        /// <value>The status bar text.</value>
        String StatusBarText { get; }

        /// <summary>
        /// Gets a value indicating whether this instance can refresh the data.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can view record; otherwise, <c>false</c>.
        /// </value>
        Boolean CanRefreshData { get; }

        /// <summary>Gets the refresh button visibility.</summary>
        /// <value>The refresh button visibility.</value>
        Boolean RefreshButtonVisible { get; }

        /// <summary>Gets or sets a value indicating whether [refresh command enabled].</summary>
        /// <value>
        ///   <c>true</c> if [refresh command enabled]; otherwise, <c>false</c>.</value>
        Boolean RefreshCommandEnabled { get; }

        /// <summary>
        /// Gets the refresh command.
        /// </summary>
        /// <value>The refresh command.</value>
        ICommand RefreshCommand { get; }

        /// <summary>Gets or sets a value indicating whether [view record command enabled].</summary>
        /// <value>
        ///   <c>true</c> if [view record command enabled]; otherwise, <c>false</c>.</value>
        Boolean ViewRecordCommandEnabled { get; }

        /// <summary>
        /// Handles the view record.
        /// </summary>
        ICommand ViewRecordCommand { get; }

        /// <summary>
        /// Gets a value indicating whether this instance can view record.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can view record; otherwise, <c>false</c>.
        /// </value>
        Boolean CanViewRecord { get; }

        /// <summary>Gets the view button visibility.</summary>
        /// <value>The view button visibility.</value>
        Boolean ViewButtonVisible { get; }

        /// <summary>
        /// Gets a value indicating whether this instance can add record.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can add record; otherwise, <c>false</c>.
        /// </value>
        Boolean CanAddRecord { get; }

        /// <summary>Gets the add button visibility.</summary>
        /// <value>The add button visibility.</value>
        Boolean AddButtonVisible { get; }

        /// <summary>Gets or sets a value indicating whether [add record command enabled].</summary>
        /// <value>
        ///   <c>true</c> if [add record command enabled]; otherwise, <c>false</c>.</value>
        Boolean AddRecordCommandEnabled { get; }

        /// <summary>
        /// Handles the add record.
        /// </summary>
        ICommand AddRecordCommand { get; }

        /// <summary>
        /// Gets a value indicating whether this instance can edit record.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can edit record; otherwise, <c>false</c>.
        /// </value>
        Boolean CanEditRecord { get; }

        /// <summary>Gets the edit button visibility.</summary>
        /// <value>The edit button visibility.</value>
        Boolean EditButtonVisible { get; }

        /// <summary>Gets or sets a value indicating whether [edit record command enabled].</summary>
        /// <value>
        ///   <c>true</c> if [edit record command enabled]; otherwise, <c>false</c>.</value>
        Boolean EditRecordCommandEnabled { get; }

        /// <summary>
        /// Handles the edit record.
        /// </summary>
        ICommand EditRecordCommand { get; }

        /// <summary>
        /// Gets a value indicating whether this instance can delete record.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can delete record; otherwise, <c>false</c>.
        /// </value>
        Boolean CanDeleteRecord { get; }

        /// <summary>Gets the delete button visibility.</summary>
        /// <value>The delete button visibility.</value>
        Boolean DeleteButtonVisible { get; }

        /// <summary>Gets or sets a value indicating whether [delete record command enabled].</summary>
        /// <value>
        ///   <c>true</c> if [delete record command enabled]; otherwise, <c>false</c>.</value>
        Boolean DeleteRecordCommandEnabled { get; }

        /// <summary>
        /// Handles the delete record.
        /// </summary>
        ICommand DeleteRecordCommand { get; }

        /// <summary>Gets a value indicating whether this instance has optional action1.</summary>
        /// <value>
        ///   <c>true</c> if this instance has optional action1; otherwise, <c>false</c>.</value>
        Boolean HasOptionalAction1 { get; }

        /// <summary>Gets the name of the action1.</summary>
        /// <value>The name of the action1.</value>
        String Action1Name { get; }

        /// <summary>Gets or sets a value indicating whether [action1 command enabled].</summary>
        /// <value>
        ///   <c>true</c> if [action1 command enabled]; otherwise, <c>false</c>.</value>
        Boolean Action1CommandEnabled { get; }

        /// <summary>Gets the action1 command.</summary>
        /// <value>The action1 command.</value>
        ICommand Action1Command { get; }

        /// <summary>Gets a value indicating whether this instance has optional action2.</summary>
        /// <value>
        ///   <c>true</c> if this instance has optional action2; otherwise, <c>false</c>.</value>
        Boolean HasOptionalAction2 { get; }

        /// <summary>Gets the name of the action2.</summary>
        /// <value>The name of the action2.</value>
        String Action2Name { get; }

        /// <summary>Gets or sets a value indicating whether [action2 command enabled].</summary>
        /// <value>
        ///   <c>true</c> if [action2 command enabled]; otherwise, <c>false</c>.</value>
        Boolean Action2CommandEnabled { get; }

        /// <summary>Gets the action2 command.</summary>
        /// <value>The action2 command.</value>
        ICommand Action2Command { get; }

        /// <summary>Gets a value indicating whether this instance has optional action3.</summary>
        /// <value>
        ///   <c>true</c> if this instance has optional action3; otherwise, <c>false</c>.</value>
        Boolean HasOptionalAction3 { get; }

        /// <summary>Gets the name of the action3.</summary>
        /// <value>The name of the action3.</value>
        String Action3Name { get; }

        /// <summary>Gets or sets a value indicating whether [action3 command enabled].</summary>
        /// <value>
        ///   <c>true</c> if [action3 command enabled]; otherwise, <c>false</c>.</value>
        Boolean Action3CommandEnabled { get; }

        /// <summary>Gets the action3 command.</summary>
        /// <value>The action3 command.</value>
        ICommand Action3Command { get; }

        /// <summary>Gets a value indicating whether this instance has optional action4.</summary>
        /// <value>
        ///   <c>true</c> if this instance has optional action4; otherwise, <c>false</c>.</value>
        Boolean HasOptionalAction4 { get; }

        /// <summary>Gets the name of the action4.</summary>
        /// <value>The name of the action4.</value>
        String Action4Name { get; }

        /// <summary>Gets or sets a value indicating whether [action4 command enabled].</summary>
        /// <value>
        ///   <c>true</c> if [action4 command enabled]; otherwise, <c>false</c>.</value>
        Boolean Action4CommandEnabled { get; }

        /// <summary>Gets the action4 command.</summary>
        /// <value>The action4 command.</value>
        ICommand Action4Command { get; }

        /// <summary>Gets the action visibility.</summary>
        /// <value>The action visibility.</value>
        Boolean ActionsVisible { get; }

        /// <summary>Gets a value indicating whether this instance has optional drop down parameter1.</summary>
        /// <value>
        ///   <c>true</c> if this instance has optional drop down parameter1; otherwise, <c>false</c>.</value>
        Boolean HasOptionalDropDownParameter1 { get; }

        /// <summary>Gets the name of the filter1.</summary>
        /// <value>The name of the filter1.</value>
        String Filter1Name { get; }

        /// <summary>Gets the filter1 display member path.</summary>
        /// <value>The filter1 display member path.</value>
        String Filter1DisplayMemberPath { get; }

        /// <summary>Gets the filter1 selected value path.</summary>
        /// <value>The filter1 selected value path.</value>
        String Filter1SelectedValuePath { get; }

        /// <summary>Gets the filter1 selection changed command.</summary>
        /// <value>The filter1 selection changed command.</value>
        ICommand Filter1SelectionChangedCommand { get; }

        /// <summary>Gets the filter1 data source.</summary>
        /// <value>The filter1 data source.</value>
        IEnumerable? Filter1DataSource { get; }

        /// <summary>Gets or sets the filter1 selected item.</summary>
        /// <value>The filter1 selected item.</value>
        Object? Filter1SelectedItem { get; set; }

        /// <summary>Gets a value indicating whether this instance has optional drop down parameter2.</summary>
        /// <value>
        ///   <c>true</c> if this instance has optional drop down parameter2; otherwise, <c>false</c>.</value>
        Boolean HasOptionalDropDownParameter2 { get; }

        /// <summary>Gets the name of the filter2.</summary>
        /// <value>The name of the filter2.</value>
        String Filter2Name { get; }

        /// <summary>Gets the filter2 display member path.</summary>
        /// <value>The filter2 display member path.</value>
        String Filter2DisplayMemberPath { get; }

        /// <summary>Gets the filter2 selected value path.</summary>
        /// <value>The filter2 selected value path.</value>
        String Filter2SelectedValuePath { get; }

        /// <summary>Gets the filter2 selection changed command.</summary>
        /// <value>The filter2 selection changed command.</value>
        ICommand Filter2SelectionChangedCommand { get; }

        /// <summary>Gets the filter2 data source.</summary>
        /// <value>The filter2 data source.</value>
        IEnumerable? Filter2DataSource { get; }

        /// <summary>Gets or sets the filter2 selected item.</summary>
        /// <value>The filter2 selected item.</value>
        Object? Filter2SelectedItem { get; set; }

        /// <summary>Gets a value indicating whether this instance has optional drop down parameter3.</summary>
        /// <value>
        ///   <c>true</c> if this instance has optional drop down parameter3; otherwise, <c>false</c>.</value>
        Boolean HasOptionalDropDownParameter3 { get; }

        /// <summary>Gets the name of the filter3.</summary>
        /// <value>The name of the filter3.</value>
        String Filter3Name { get; }

        /// <summary>Gets the filter3 display member path.</summary>
        /// <value>The filter3 display member path.</value>
        String Filter3DisplayMemberPath { get; }

        /// <summary>Gets the filter3 selected value path.</summary>
        /// <value>The filter3 selected value path.</value>
        String Filter3SelectedValuePath { get; }

        /// <summary>Gets the filter3 selection changed command.</summary>
        /// <value>The filter3 selection changed command.</value>
        ICommand Filter3SelectionChangedCommand { get; }

        /// <summary>Gets the filter3 data source.</summary>
        /// <value>The filter3 data source.</value>
        IEnumerable? Filter3DataSource { get; }

        /// <summary>Gets or sets the filter3 selected item.</summary>
        /// <value>The filter3 selected item.</value>
        Object? Filter3SelectedItem { get; set; }

        /// <summary>Gets a value indicating whether this instance has optional drop down parameter4.</summary>
        /// <value>
        ///   <c>true</c> if this instance has optional drop down parameter4; otherwise, <c>false</c>.</value>
        Boolean HasOptionalDropDownParameter4 { get; }

        /// <summary>Gets the name of the filter4.</summary>
        /// <value>The name of the filter4.</value>
        String Filter4Name { get; }

        /// <summary>Gets the filter4 display member path.</summary>
        /// <value>The filter4 display member path.</value>
        String Filter4DisplayMemberPath { get; }

        /// <summary>Gets the filter4 selected value path.</summary>
        /// <value>The filter4 selected value path.</value>
        String Filter4SelectedValuePath { get; }

        /// <summary>Gets the filter4 selection changed command.</summary>
        /// <value>The filter4 selection changed command.</value>
        ICommand Filter4SelectionChangedCommand { get; }

        /// <summary>Gets the filter4 data source.</summary>
        /// <value>The filter4 data source.</value>
        IEnumerable? Filter4DataSource { get; }

        /// <summary>Gets or sets the filter4 selected item.</summary>
        /// <value>The filter4 selected item.</value>
        Object? Filter4SelectedItem { get; set; }

        /// <summary>Gets the filter visibility.</summary>
        /// <value>The filter visibility.</value>
        Boolean FiltersVisible { get; }

        /// <summary>Gets the data grid columns.</summary>
        /// <value>The data grid columns.</value>
        ObservableCollection<IGridColumnDefinition> DataGridColumns { get; }

        /// <summary>Gets the grid export columns.</summary>
        /// <value>The grid export columns.</value>
        List<IGridColumnDefinition> GridExportColumns { get; }

        /// <summary>Gets or sets the selected item.</summary>
        /// <value>The selected item.</value>
        TModel? SelectedItem { get; set; }

        /// <summary>Gets the grid data source.</summary>
        /// <value>The grid data source.</value>
        List<TModel>? GridDataSource { get; }

        /// <summary>Gets the selected grid item changed command.</summary>
        /// <value>The selected grid item changed command.</value>
        ICommand SelectedGridItemChangedCommand { get; }

        /// <summary>
        /// Gets the export grid to excel command.
        /// </summary>
        /// <value>The export grid to excel command.</value>
        ICommand ExportGridToExcelCommand { get; }

        /// <summary>
        /// Gets the export grid to CSV command.
        /// </summary>
        /// <value>The export grid to CSV command.</value>
        ICommand ExportGridToCsvCommand { get; }

        /// <summary>
        /// Gets the copy grid to CSV command.
        /// </summary>
        /// <value>The copy grid to CSV command.</value>
        ICommand CopyGridToCsvCommand { get; }

        /// <summary>
        /// Gets the copy row to CSV command.
        /// </summary>
        /// <value>The copy row to CSV command.</value>
        ICommand CopyRowToCsvCommand { get; }

        /// <summary>
        /// Gets the copy cell value command.
        /// </summary>
        /// <value>The copy cell value command.</value>
        ICommand CopyCellValueCommand { get; }
    }
}