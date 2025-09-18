//-----------------------------------------------------------------------
// <copyright file="ICommonBusinessProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces.Helpers;

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICommonBusinessProcess : ICommonProcess
    {
        /// <summary>
        /// The Screen Title
        /// </summary>
        String ScreenTitle { get; }

        /// <summary>
        /// The Status Bar Text
        /// </summary>
        String StatusBarText { get; }

        /// <summary>
        /// Null Id or Unset Id = -1
        /// </summary>
        EntityId NullId { get; }

        /// <summary>
        /// Used in Combo boxes, has id -1
        /// </summary>
        EntityId AllId { get; }

        /// <summary>
        /// Used in Combo boxes, has id -2
        /// </summary>
        EntityId NoneId { get; }

        /// <summary>
        /// The Text "&lt;All&gt;" used in Combo boxes
        /// </summary>
        String AllText { get; }

        /// <summary>
        /// The Text "&lt;None&gt;" used in ComboBoxes
        /// </summary>
        String NoneText { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has optional drop down parameter1.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has optional drop down parameter1; otherwise, <c>false</c>.
        /// </value>
        Boolean HasOptionalDropDownParameter1 { get; }

        /// <summary>
        /// The filter 1 Name
        /// </summary>
        String Filter1Name { get; }

        /// <summary>
        /// Gets the <seealso cref="Filter1Name"/> display member path.
        /// </summary>
        /// <value>
        /// The <seealso cref="Filter1Name"/> display member path.
        /// </value>
        String Filter1DisplayMemberPath { get; }

        /// <summary>
        /// Gets the <seealso cref="Filter1Name"/> selected value path.
        /// </summary>
        /// <value>
        /// The <seealso cref="Filter1Name"/> selected value path.
        /// </value>
        String Filter1SelectedValuePath { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has optional <seealso cref="Action1Name"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has optional <seealso cref="Action1Name"/>; otherwise, <c>false</c>.
        /// </value>
        Boolean HasOptionalAction1 { get; }

        /// <summary>
        /// The Action 1 Name
        /// </summary>
        String Action1Name { get; }


        /// <summary>
        /// Gets a value indicating whether this instance has optional drop down parameter2.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has optional drop down parameter2; otherwise, <c>false</c>.
        /// </value>
        Boolean HasOptionalDropDownParameter2 { get; }

        /// <summary>
        /// The filter 2 Name
        /// </summary>
        String Filter2Name { get; }

        /// <summary>
        /// Gets the <seealso cref="Filter2Name"/> display member path.
        /// </summary>
        /// <value>
        /// The <seealso cref="Filter2Name"/> display member path.
        /// </value>
        String Filter2DisplayMemberPath { get; }

        /// <summary>
        /// Gets the <seealso cref="Filter2Name"/> selected value path.
        /// </summary>
        /// <value>
        /// The <seealso cref="Filter2Name"/> selected value path.
        /// </value>
        String Filter2SelectedValuePath { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has optional <seealso cref="Action2Name"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has optional <seealso cref="Action2Name"/>; otherwise, <c>false</c>.
        /// </value>
        Boolean HasOptionalAction2 { get; }

        /// <summary>
        /// The Action 2 Name
        /// </summary>
        String Action2Name { get; }


        /// <summary>
        /// Gets a value indicating whether this instance has optional drop down parameter3.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has optional drop down parameter3; otherwise, <c>false</c>.
        /// </value>
        Boolean HasOptionalDropDownParameter3 { get; }

        /// <summary>
        /// The filter 3 Name
        /// </summary>
        String Filter3Name { get; }

        /// <summary>
        /// Gets the <seealso cref="Filter3Name"/> display member path.
        /// </summary>
        /// <value>
        /// The <seealso cref="Filter3Name"/> display member path.
        /// </value>
        String Filter3DisplayMemberPath { get; }

        /// <summary>
        /// Gets the <seealso cref="Filter3Name"/> selected value path.
        /// </summary>
        /// <value>
        /// The <seealso cref="Filter3Name"/> selected value path.
        /// </value>
        String Filter3SelectedValuePath { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has optional <seealso cref="Action3Name"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has optional <seealso cref="Action3Name"/>; otherwise, <c>false</c>.
        /// </value>
        Boolean HasOptionalAction3 { get; }

        /// <summary>
        /// The Action 3 Name
        /// </summary>
        String Action3Name { get; }


        /// <summary>
        /// Gets a value indicating whether this instance has optional drop down parameter4.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has optional drop down parameter4; otherwise, <c>false</c>.
        /// </value>
        Boolean HasOptionalDropDownParameter4 { get; }

        /// <summary>
        /// The filter 4 Name
        /// </summary>
        String Filter4Name { get; }

        /// <summary>
        /// Gets the <seealso cref="Filter4Name"/> display member path.
        /// </summary>
        /// <value>
        /// The <seealso cref="Filter4Name"/> display member path.
        /// </value>
        String Filter4DisplayMemberPath { get; }

        /// <summary>
        /// Gets the <seealso cref="Filter4Name"/> selected value path.
        /// </summary>
        /// <value>
        /// The <seealso cref="Filter4Name"/> selected value path.
        /// </value>
        String Filter4SelectedValuePath { get; }

        /// <summary>
        /// Gets a value indicating whether this instance has optional <seealso cref="Action4Name"/>.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has optional <seealso cref="Action4Name"/>; otherwise, <c>false</c>.
        /// </value>
        Boolean HasOptionalAction4 { get; }

        /// <summary>
        /// The Action 4 Name
        /// </summary>
        String Action4Name { get; }


        /// <summary>
        /// The default Valid From date/time that is used throughout the application.
        /// <para>
        /// This is normally the current date/time
        /// </para>
        /// </summary>
        DateTime DefaultValidFromDateTime { get; }

        /// <summary>
        /// The default Valid To date/time that is used throughout the application
        /// <para>
        /// This is normally the '2199-Dec-31 23:59:59'
        /// </para>
        /// </summary>
        DateTime DefaultValidToDateTime { get; }

        /// <summary>
        /// The Combo Box Display Member
        /// </summary>
        String ComboBoxDisplayMember { get; }

        /// <summary>
        /// The Combo Box Value Member
        /// </summary>
        String ComboBoxValueMember { get; }

        /// <summary>
        /// When implemented in derived classes, returns a list of Column definitions used in Grids
        /// </summary>
        /// <returns><see cref="List{GridColumnDefinition}"/></returns>
        List<IGridColumnDefinition> GetColumnDefinitions();

        /// <summary>
        /// Adds the "&lt;All&gt;" items to the <paramref name="listItems"/>
        /// </summary>
        /// <param name="listItems"></param>
        void AddFilterOptionAll(List<String> listItems);

        /// <summary>
        /// Adds the "&lt;None&gt;" items to the <paramref name="listItems"/>
        /// </summary>
        /// <param name="listItems"></param>
        void AddFilterOptionNone(List<String> listItems);

        /// <summary>
        /// Adds the "&lt;All&gt;" and "&lt;None&gt;" items to the <paramref name="listItems"/>
        /// </summary>
        /// <param name="listItems"></param>
        void AddFilterOptionsAdditional(List<String> listItems);

        /// <summary>
        /// Gets a value indicating whether this instance can refresh the data.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can view record; otherwise, <c>false</c>.
        /// </value>
        Boolean CanRefreshData();

        /// <summary>
        /// Gets a value indicating whether this instance can view record.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can view record; otherwise, <c>false</c>.
        /// </value>
        Boolean CanViewRecord();

        /// <summary>
        /// Gets a value indicating whether this instance can add record.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can add record; otherwise, <c>false</c>.
        /// </value>
        Boolean CanAddRecord();

        /// <summary>
        /// Determines if the user specified by <paramref name="userProfile"/> is allowed to Add records
        /// </summary>
        /// <param name="userProfile">The User Profile</param>
        /// <returns></returns>
        Boolean CanAddRecord(IUserProfile userProfile);

        /// <summary>
        /// Gets a value indicating whether this instance can edit record.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can edit record; otherwise, <c>false</c>.
        /// </value>
        Boolean CanEditRecord();

        /// <summary>
        /// Gets a value indicating whether this instance can delete record.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance can delete record; otherwise, <c>false</c>.
        /// </value>
        Boolean CanDeleteRecord();

        /// <summary>
        /// Deletes the entity from the data store
        /// </summary>
        /// <param name="entityId">The id of the entity to be deleted</param>
        void Delete(EntityId entityId);


        /// <summary>
        /// Exports the supplied data to an Excel file
        /// </summary>
        /// <param name="gridColumnDefinitions"></param>
        /// <param name="sourceData"></param>
        void ExportToExcel(List<IGridColumnDefinition> gridColumnDefinitions, IEnumerable? sourceData);

        /// <summary>
        /// Exports the supplied data to Csv
        /// </summary>
        /// <param name="gridColumnDefinitions"></param>
        /// <param name="sourceData"></param>
        String ExportToCsv(List<IGridColumnDefinition>? gridColumnDefinitions, IEnumerable? sourceData);

        /// <summary>
        /// Exports the supplied data to Csv
        /// </summary>
        /// <param name="outputStream"></param>
        /// <param name="gridColumnDefinitions"></param>
        /// <param name="sourceData"></param>
        void ExportToCsv(TextWriter outputStream, List<IGridColumnDefinition>? gridColumnDefinitions, IEnumerable? sourceData);
    }

    /// <summary>
    /// Defines common business process behaviours and actions
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public interface ICommonBusinessProcess<TModel> : ICommonBusinessProcess
        where TModel : IFoundationModel
    {
        /// <summary>
        /// Adds the "&lt;All&gt;" items to the <paramref name="listItems"/>
        /// </summary>
        /// <param name="listItems"></param>
        void AddFilterOptionAll(List<TModel> listItems);

        /// <summary>
        /// Adds the "&lt;None&gt;" items to the <paramref name="listItems"/>
        /// </summary>
        /// <param name="listItems"></param>
        void AddFilterOptionNone(List<TModel> listItems);

        /// <summary>
        /// Adds the "&lt;All&gt;" and "&lt;None&gt;" items to the <paramref name="listItems"/>
        /// </summary>
        /// <param name="listItems"></param>
        void AddFilterOptionsAdditional(List<TModel> listItems);

        /// <summary>
        /// Gets the blank entry.
        /// </summary>
        /// <returns>
        /// </returns>
        TModel GetBlankEntry();

        /// <summary>
        /// Gets the "&lt;All&gt;" entry.
        /// </summary>
        /// <returns></returns>
        TModel GetAllEntry();

        /// <summary>
        /// Gets the "&lt;None&gt;" entry.
        /// </summary>
        /// <returns></returns>
        TModel GetNoneEntry();

        /// <summary>
        /// Invokes the validation of the <paramref name="entity" />.
        /// If the validation fails, an <see cref="AggregateException" /> is thrown with a list of <see cref="ValidationException" />
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="validateAllProperties"></param>
        /// <exception cref="AggregateException"></exception>
        void ValidateEntity(TModel entity, Boolean validateAllProperties = true);

        /// <summary>
        /// Invokes the validation of the <paramref name="entity" />.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="validateAllProperties"></param>
        /// <exception cref="AggregateException"></exception>
        List<ValidationException> IsValidEntity(TModel entity, Boolean validateAllProperties = true);

        /// <summary>
        /// Determines if the user specified by <paramref name="userProfile"/> is allowed to View the record
        /// </summary>
        /// <param name="userProfile">The User Profile</param>
        /// <param name="entity">The entity to be viewed</param>
        /// <returns></returns>
        Boolean CanViewRecord(IUserProfile userProfile, TModel? entity);

        /// <summary>
        /// Determines if the user specified by <paramref name="userProfile"/> is allowed to Edit the record
        /// </summary>
        /// <param name="userProfile">The User Profile</param>
        /// <param name="entity">The entity to be edited</param>
        /// <returns></returns>
        Boolean CanEditRecord(IUserProfile userProfile, TModel? entity);

        /// <summary>
        /// Determines if the user specified by <paramref name="userProfile"/> is allowed to Delete the record
        /// </summary>
        /// <param name="userProfile">The User Profile</param>
        /// <param name="entity">The entity to be Deleted</param>
        /// <returns></returns>
        Boolean CanDeleteRecord(IUserProfile userProfile, TModel? entity);

        /// <summary>
        /// Saves the entity to the data store
        /// </summary>
        /// <param name="entity">The entity to be saved</param>
        TModel Save(TModel entity);

        /// <summary>
        /// Saves the list of entities to the data store
        /// </summary>
        /// <param name="entities">The list of entities to be saved</param>
        List<TModel> Save(List<TModel> entities);

        /// <summary>
        /// Deletes the entity from the data store
        /// </summary>
        /// <param name="entity">The entity to be deleted</param>
        TModel Delete(TModel entity);

        /// <summary>
        /// Deletes the list of entities to the data store
        /// </summary>
        /// <param name="entities">The list of entities to be deleted</param>
        List<TModel> Delete(List<TModel> entities);

        /// <summary>
        /// Loads the entity from the data store
        /// </summary>
        /// <param name="entityId">The Id of the entity to be loaded</param>
        TModel Get(EntityId entityId);

        /// <summary>
        /// Loads the entities from the data store
        /// </summary>
        /// <param name="entityIds">The Ids of the entities to be loaded</param>
        List<TModel> Get(List<EntityId> entityIds);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        List<TModel> GetAll();

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="excludeDeleted">if set to <c>false</c> includes Deleted records</param>
        /// <returns></returns>
        List<TModel> GetAll(Boolean excludeDeleted);
    }
}
