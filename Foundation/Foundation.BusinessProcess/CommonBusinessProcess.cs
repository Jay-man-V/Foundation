//-----------------------------------------------------------------------
// <copyright file="CommonBusinessProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Models.Specialised;
using Foundation.Resources;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// Defines common business process behaviours and actions
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TRepository"></typeparam>
    public abstract class CommonBusinessProcess<TEntity, TRepository> : CommonProcess, ICommonBusinessProcess<TEntity>
        where TEntity : IFoundationModel
        where TRepository : IFoundationModelRepository<TEntity>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="CommonBusinessProcess{TEntity, TRepository}" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="statusRepository">The status repository.</param>
        /// <param name="userProfileRepository">The user profile repository.</param>
        protected CommonBusinessProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            TRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, userProfileRepository);

            EntityRepository = repository;
            StatusRepository = statusRepository;
            UserProfileRepository = userProfileRepository;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// When implemented in derived classes, refers to the specific Data Access class
        /// </summary>
        protected TRepository EntityRepository { get; }

        /// <summary>
        /// Gets the status data access.
        /// </summary>
        /// <value>
        /// The status data access.
        /// </value>
        protected IStatusRepository StatusRepository { get; }

        /// <summary>
        /// Gets the user profile data access.
        /// </summary>
        /// <value>
        /// The user profile data access.
        /// </value>
        protected IUserProfileRepository UserProfileRepository { get; }


        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public virtual String ScreenTitle => String.Empty;

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public virtual String StatusBarText => "Number of rows:";


        /// <inheritdoc cref="ICommonBusinessProcess.NullId"/>
        public EntityId NullId => new EntityId(-1);

        /// <inheritdoc cref="ICommonBusinessProcess.AllId"/>
        public EntityId AllId => new EntityId(-1);

        /// <inheritdoc cref="ICommonBusinessProcess.NoneId"/>
        public EntityId NoneId => new EntityId(-2);

        /// <inheritdoc cref="ICommonBusinessProcess.AllText"/>
        public String AllText => "<All>";

        /// <inheritdoc cref="ICommonBusinessProcess.NoneText"/>
        public String NoneText => "<None>";


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter1"/>
        public virtual Boolean HasOptionalDropDownParameter1 => false;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1Name"/>
        public virtual String Filter1Name => "Filter1";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1DisplayMemberPath"/>
        public virtual String Filter1DisplayMemberPath => String.Empty;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1SelectedValuePath"/>
        public virtual String Filter1SelectedValuePath => FDC.FoundationEntity.Id;

        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalAction1"/>
        public virtual Boolean HasOptionalAction1 => false;

        /// <inheritdoc cref="ICommonBusinessProcess.Action1Name"/>
        public virtual String Action1Name => "Action1";


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter2"/>
        public virtual Boolean HasOptionalDropDownParameter2 => false;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2Name"/>
        public virtual String Filter2Name => "Filter2";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2DisplayMemberPath"/>
        public virtual String Filter2DisplayMemberPath => String.Empty;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2SelectedValuePath"/>
        public virtual String Filter2SelectedValuePath => FDC.FoundationEntity.Id;

        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalAction2"/>
        public virtual Boolean HasOptionalAction2 => false;

        /// <inheritdoc cref="ICommonBusinessProcess.Action2Name"/>
        public virtual String Action2Name => "Action2";


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter3"/>
        public virtual Boolean HasOptionalDropDownParameter3 => false;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter3Name"/>
        public virtual String Filter3Name => "Filter3";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter3DisplayMemberPath"/>
        public virtual String Filter3DisplayMemberPath => String.Empty;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter3SelectedValuePath"/>
        public virtual String Filter3SelectedValuePath => FDC.FoundationEntity.Id;

        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalAction3"/>
        public virtual Boolean HasOptionalAction3 => false;

        /// <inheritdoc cref="ICommonBusinessProcess.Action3Name"/>
        public virtual String Action3Name => "Action3";


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter4"/>
        public virtual Boolean HasOptionalDropDownParameter4 => false;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter4Name"/>
        public virtual String Filter4Name => "Filter4";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter4DisplayMemberPath"/>
        public virtual String Filter4DisplayMemberPath => String.Empty;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter4SelectedValuePath"/>
        public virtual String Filter4SelectedValuePath => FDC.FoundationEntity.Id;
    
        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalAction4"/>
        public virtual Boolean HasOptionalAction4 => false;

        /// <inheritdoc cref="ICommonBusinessProcess.Action4Name"/>
        public virtual String Action4Name => "Action4";


        /// <inheritdoc cref="ICommonBusinessProcess.DefaultValidFromDateTime"/>
        public DateTime DefaultValidFromDateTime => DateTimeService.SystemDateTimeNow;

        /// <inheritdoc cref="ICommonBusinessProcess.DefaultValidToDateTime"/>
        public DateTime DefaultValidToDateTime => ApplicationDefaultValues.DefaultValidToDateTime;


        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember"/>
        public virtual String ComboBoxDisplayMember => String.Empty;

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxValueMember"/>
        public virtual String ComboBoxValueMember => FDC.FoundationEntity.Id;


        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()"/>
        public abstract List<IGridColumnDefinition> GetColumnDefinitions();

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.AddFilterOptionAll(List{TEntity})"/>
        public virtual void AddFilterOptionAll(List<TEntity> listItems)
        {
            LoggingHelpers.TraceCallEnter(listItems);

            TEntity allItem = GetAllEntry();
            listItems.Insert(0, allItem);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.AddFilterOptionNone(List{TEntity})"/>
        public virtual void AddFilterOptionNone(List<TEntity> listItems)
        {
            LoggingHelpers.TraceCallEnter(listItems);

            TEntity noneItem = GetNoneEntry();
            listItems.Insert(0, noneItem);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.AddFilterOptionsAdditional(List{TEntity})"/>
        public virtual void AddFilterOptionsAdditional(List<TEntity> listItems)
        {
            LoggingHelpers.TraceCallEnter(listItems);

            AddFilterOptionNone(listItems);
            AddFilterOptionAll(listItems);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess.AddFilterOptionAll(List{String})"/>
        public virtual void AddFilterOptionAll(List<String> listItems)
        {
            LoggingHelpers.TraceCallEnter(listItems);

            listItems.Insert(0, AllText);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess.AddFilterOptionNone(List{String})"/>
        public virtual void AddFilterOptionNone(List<String> listItems)
        {
            LoggingHelpers.TraceCallEnter(listItems);

            listItems.Insert(0, NoneText);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess.AddFilterOptionsAdditional(List{String})"/>
        public virtual void AddFilterOptionsAdditional(List<String> listItems)
        {
            LoggingHelpers.TraceCallEnter(listItems);

            AddFilterOptionNone(listItems);
            AddFilterOptionAll(listItems);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the blank entry with a specific <see cref="EntityId"/>.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        protected virtual TEntity GetBlankEntry(EntityId entityId)
        {
            LoggingHelpers.TraceCallEnter(entityId);

            TEntity retVal = Core.IoC.Get<TEntity>();
            retVal.Id = entityId;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.GetBlankEntry()"/>
        public TEntity GetBlankEntry()
        {
            LoggingHelpers.TraceCallEnter();

            TEntity retVal = GetBlankEntry(NullId);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.GetAllEntry()"/>
        public TEntity GetAllEntry()
        {
            LoggingHelpers.TraceCallEnter();

            TEntity retVal = GetBlankEntry(AllId);
            SetFilterItemProperties(retVal, AllText);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.GetNoneEntry()"/>
        public TEntity GetNoneEntry()
        {
            LoggingHelpers.TraceCallEnter();

            TEntity retVal = GetBlankEntry(NoneId);
            SetFilterItemProperties(retVal, NoneText);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Sets the displayText on a newly created <paramref name="entity"/>
        /// </summary>
        /// <param name="entity">The entity to set the values on</param>
        /// <param name="displayText">The value to be set</param>
        /// <exception cref="ArgumentNullException">Raised when the <see cref="CommonBusinessProcess{TEntity, TRepository}.ComboBoxDisplayMember"/> has not been set</exception>
        /// <exception cref="MissingMemberException">Raised when the <paramref name="entity"/> does not have the member designated by <see cref="CommonBusinessProcess{TEntity, TRepository}.ComboBoxDisplayMember"/></exception>
        protected virtual void SetFilterItemProperties(TEntity entity, String displayText)
        {
            LoggingHelpers.TraceCallEnter(entity, displayText);

            Type entityType = entity.GetType();

            if (String.IsNullOrEmpty(ComboBoxDisplayMember))
            {
                String errorMessage = $"Empty {nameof(ComboBoxDisplayMember)} passed to {GetType()}.SetFilterItemProperties";
                throw new ArgumentNullException(nameof(ComboBoxDisplayMember), errorMessage);
            }

            PropertyInfo? propertyInfo = entityType.GetProperty(ComboBoxDisplayMember);

            if (propertyInfo == null)
            {
                throw new MissingMemberException(entityType.ToString(), ComboBoxDisplayMember);
            }

            propertyInfo.SetValue(entity, displayText);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.ValidateEntity(TEntity, Boolean)"/>
        public void ValidateEntity(TEntity entity, Boolean validateAllProperties = true)
        {
            List<ValidationException> validationExceptions = IsValidEntity(entity, validateAllProperties);

            if (validationExceptions.Any())
            {
                throw new AggregateException(validationExceptions);
            }
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.IsValidEntity(TEntity, Boolean)"/>
        public List<ValidationException> IsValidEntity(TEntity entity, Boolean validateAllProperties = false)
        {
            List<ValidationException> retVal = new List<ValidationException>();

            const IServiceProvider? serviceProvider = null;
            const IDictionary<Object, Object?>? items = null;
            ValidationContext context = new ValidationContext(entity, serviceProvider, items);
            List<ValidationResult> validationResults = new List<ValidationResult>();

            Boolean isValid = Validator.TryValidateObject(entity, context, validationResults, validateAllProperties);
            if (isValid)
            {
                Debug.WriteLine($"{entity} - ({entity.Id}) - Valid");
            }
            else
            {
                Debug.WriteLine($"{entity} - ({entity.Id}) - Not Valid");
                foreach (ValidationResult validationResult in validationResults)
                {
                    Debug.WriteLine($"{String.Join(",", validationResult.MemberNames)} - {validationResult.ErrorMessage}");
                    ValidationException validationException = new ValidationException(validationResult.ErrorMessage);

                    retVal.Add(validationException);
                }
            }

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess.CanRefreshData()"/>
        public virtual Boolean CanRefreshData() => true;

        /// <inheritdoc cref="ICommonBusinessProcess.CanViewRecord()"/>
        public virtual Boolean CanViewRecord() => false;

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.CanViewRecord(IUserProfile, TEntity?)"/>
        public virtual Boolean CanViewRecord(IUserProfile userProfile, TEntity? entity)
        {
            LoggingHelpers.TraceCallEnter(userProfile, entity);

            Boolean userCanView = CanViewRecord(userProfile);
            Boolean userOwnsView = CanViewOwnRecord(userProfile, entity);
            Boolean recordCanView = CanViewRecord(entity);

            Boolean retVal = (userCanView && recordCanView) || userOwnsView;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines if the user specified by <paramref name="userProfile"/> is allowed to View the record
        /// </summary>
        /// <param name="userProfile">The User Profile</param>
        /// <param name="entity">The entity to be viewed</param>
        /// <returns></returns>
        protected virtual Boolean CanViewOwnRecord(IUserProfile userProfile, TEntity? entity)
        {
            LoggingHelpers.TraceCallEnter(userProfile, entity);

            Boolean retVal = false;

            if (entity != null)
            {
                Boolean userOwnsRecord = userProfile.Id == entity.CreatedByUserProfileId;
                Boolean userHasOwnEdit = userProfile.Roles.Any(r => r.Id == ApplicationRole.OwnEditor.Id());

                retVal = userOwnsRecord && userHasOwnEdit;
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines if the user specified by <paramref name="userProfile"/> is allowed to View records
        /// </summary>
        /// <param name="userProfile">The User Profile</param>
        /// <returns></returns>
        protected virtual Boolean CanViewRecord(IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(userProfile);

            Boolean isSystemSupport = userProfile.IsSystemSupport;
            Boolean userCanView = userProfile.Roles.Any(r => r.Id.ToInteger() >= ApplicationRole.Reporter.Id());

            Boolean retVal = isSystemSupport || userCanView;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines if the record can be viewed
        /// </summary>
        /// <param name="entity">The entity to be viewed</param>
        /// <returns></returns>
        protected virtual Boolean CanViewRecord(TEntity? entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            const Boolean recordCanView = true;

            const Boolean retVal = recordCanView;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess.CanAddRecord()"/>
        public virtual Boolean CanAddRecord() => false;

        /// <inheritdoc cref="ICommonBusinessProcess.CanAddRecord(IUserProfile)"/>
        public virtual Boolean CanAddRecord(IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(userProfile);

            //Boolean userCanAdd = CanAddRecord(userProfile);

            //Boolean retVal = userCanAdd;

            Boolean isSystemSupport = userProfile.IsSystemSupport;
            Boolean userCanCreate = userProfile.Roles.Any(r => r.Id.ToInteger() >= ApplicationRole.Creator.Id());

            Boolean retVal = isSystemSupport || userCanCreate;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess.CanEditRecord()"/>
        public virtual Boolean CanEditRecord() => false;

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.CanEditRecord(IUserProfile, TEntity?)"/>
        public virtual Boolean CanEditRecord(IUserProfile userProfile, TEntity? entity)
        {
            LoggingHelpers.TraceCallEnter(userProfile, entity);

            Boolean userCanEdit = CanEditRecord(userProfile); // System Support or All Editor
            Boolean userOwnsEdit = CanEditOwnRecord(userProfile, entity); // Own Editor
            Boolean recordCanEdit = CanEditRecord(entity); // Record can be edited

            Boolean retVal = (userCanEdit && recordCanEdit) || userOwnsEdit;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines if the user specified by <paramref name="userProfile"/> is allowed to Edit the record
        /// </summary>
        /// <param name="userProfile">The User Profile</param>
        /// <param name="entity">The entity to be edited</param>
        /// <returns></returns>
        protected virtual Boolean CanEditOwnRecord(IUserProfile userProfile, TEntity? entity)
        {
            LoggingHelpers.TraceCallEnter(userProfile, entity);

            Boolean retVal = false;

            if (entity != null)
            {
                Boolean userOwnsRecord = userProfile.Id == entity.CreatedByUserProfileId;
                Boolean userHasOwnEdit = userProfile.Roles.Any(r => r.Id == ApplicationRole.OwnEditor.Id());

                retVal = userOwnsRecord && userHasOwnEdit;
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines if the user specified by <paramref name="userProfile"/> is allowed to Edit records
        /// </summary>
        /// <param name="userProfile">The User Profile</param>
        /// <returns></returns>
        protected virtual Boolean CanEditRecord(IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(userProfile);

            Boolean isSystemSupport = userProfile.IsSystemSupport;
            Boolean userCanEdit = userProfile.Roles.Any(r => r.Id.ToInteger() >= ApplicationRole.AllEditor.Id());

            Boolean retVal = isSystemSupport || userCanEdit;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines if the record can be edited
        /// </summary>
        /// <param name="entity">The entity to be edited</param>
        /// <returns></returns>
        protected virtual Boolean CanEditRecord(TEntity? entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            const Boolean recordCanEdit = true;

            const Boolean retVal = recordCanEdit;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess.CanDeleteRecord()"/>
        public virtual Boolean CanDeleteRecord() => false;

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.CanDeleteRecord(IUserProfile, TEntity?)"/>
        public virtual Boolean CanDeleteRecord(IUserProfile userProfile, TEntity? entity)
        {
            LoggingHelpers.TraceCallEnter(userProfile, entity);

            Boolean userCanDelete = CanDeleteRecord(userProfile);
            Boolean userOwnsDelete = CanDeleteOwnRecord(userProfile, entity);
            Boolean recordCanDelete = CanDeleteRecord(entity);

            Boolean retVal = (userCanDelete && recordCanDelete) || userOwnsDelete;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines if the user specified by <paramref name="userProfile"/> is allowed to Delete the record
        /// </summary>
        /// <param name="userProfile">The User Profile</param>
        /// <param name="entity">The entity to be Deleted</param>
        /// <returns></returns>
        protected virtual Boolean CanDeleteOwnRecord(IUserProfile userProfile, TEntity? entity)
        {
            LoggingHelpers.TraceCallEnter(userProfile, entity);

            Boolean retVal = false;

            if (entity != null)
            {
                Boolean userOwnsRecord = userProfile.Id == entity.CreatedByUserProfileId;
                Boolean userHasOwnDelete = userProfile.Roles.Any(r => r.Id == ApplicationRole.OwnDelete.Id());

                retVal = userOwnsRecord && userHasOwnDelete;
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines if the user specified by <paramref name="userProfile"/> is allowed to Delete records
        /// </summary>
        /// <param name="userProfile">The User Profile</param>
        /// <returns></returns>
        protected virtual Boolean CanDeleteRecord(IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(userProfile);

            Boolean isSystemSupport = userProfile.IsSystemSupport;
            Boolean userCanDelete = userProfile.Roles.Any(r => r.Id.ToInteger() >= ApplicationRole.AllDelete.Id());

            Boolean retVal = isSystemSupport || userCanDelete;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Determines if the record can be edited
        /// </summary>
        /// <param name="entity">The entity to be edited</param>
        /// <returns></returns>
        protected virtual Boolean CanDeleteRecord(TEntity? entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            const Boolean recordCanDelete = true;

            const Boolean retVal = recordCanDelete;

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.Save(TEntity)"/>
        public virtual TEntity Save(TEntity entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            TEntity retVal = EntityRepository.Save(entity);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.Save(List{TEntity})"/>
        public virtual List<TEntity> Save(List<TEntity> entities)
        {
            LoggingHelpers.TraceCallEnter(entities);

            List<TEntity> retVal = EntityRepository.Save(entities);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess.Delete(EntityId)"/>
        public virtual void Delete(EntityId entityId)
        {
            LoggingHelpers.TraceCallEnter(entityId);

            EntityRepository.Delete(entityId);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.Delete(TEntity)"/>
        public virtual TEntity Delete(TEntity entity)
        {
            LoggingHelpers.TraceCallEnter(entity);

            TEntity retVal = EntityRepository.Delete(entity);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.Delete(List{TEntity})"/>
        public virtual List<TEntity> Delete(List<TEntity> entities)
        {
            LoggingHelpers.TraceCallEnter(entities);

            List<TEntity> retVal = EntityRepository.Delete(entities);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.Get(EntityId)"/>
        public virtual TEntity Get(EntityId entityId)
        {
            LoggingHelpers.TraceCallEnter(entityId);

            TEntity retVal = EntityRepository.Get(entityId);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.Get(List{EntityId})"/>
        public List<TEntity> Get(List<EntityId> entityIds)
        {
            List<TEntity> retVal = EntityRepository.Get(entityIds);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.GetAll()"/>
        public virtual List<TEntity> GetAll()
        {
            LoggingHelpers.TraceCallEnter();

            List<TEntity> retVal = EntityRepository.GetAllActive();

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess{TEntity}.GetAll(Boolean)"/>
        public virtual List<TEntity> GetAll(Boolean excludeDeleted)
        {
            LoggingHelpers.TraceCallEnter(excludeDeleted);

            const Boolean activeOnly = false;
            List<TEntity> retVal = EntityRepository.GetAll(excludeDeleted, activeOnly);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="ICommonBusinessProcess.ExportToExcel(List{IGridColumnDefinition}, IEnumerable?)"/>
        // TODO: Not properly implemented/tested. Looks like it is the CSV function just copy/pasted
        public void ExportToExcel(List<IGridColumnDefinition> gridColumnDefinitions, IEnumerable? sourceData)
        {
            LoggingHelpers.TraceCallEnter(gridColumnDefinitions, sourceData);

            if (gridColumnDefinitions == null)
            {
                String errorMessage = $"Empty {nameof(gridColumnDefinitions)} passed to {this.GetType()}.ExportToExcel";
                throw new ArgumentNullException(nameof(gridColumnDefinitions), errorMessage);
            }

            if (sourceData == null)
            {
                String errorMessage = $"Empty {nameof(sourceData)} passed to {this.GetType()}.ExportToExcel";
                throw new ArgumentNullException(nameof(sourceData), errorMessage);
            }

            // TODO: Put Export To Excel Code here

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess.ExportToCsv(List{IGridColumnDefinition}, IEnumerable)"/>
        public String ExportToCsv(List<IGridColumnDefinition> gridColumnDefinitions, IEnumerable sourceData)
        {
            LoggingHelpers.TraceCallEnter(gridColumnDefinitions, sourceData);

            StringBuilder retVal = new StringBuilder();

            using (TextWriter textWriter = new StringWriter(retVal, CultureInfo.InvariantCulture))
            {
                ExportToCsv(textWriter, gridColumnDefinitions, sourceData);
                textWriter.Flush();
                textWriter.Close();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal.ToString();
        }

        /// <inheritdoc cref="ICommonBusinessProcess.ExportToCsv(TextWriter, List{IGridColumnDefinition}, IEnumerable?)"/>
        public void ExportToCsv(TextWriter outputStream, List<IGridColumnDefinition> gridColumnDefinitions, IEnumerable? sourceData)
        {
            LoggingHelpers.TraceCallEnter(gridColumnDefinitions, sourceData);

            if (gridColumnDefinitions == null)
            {
                String errorMessage = $"Empty {nameof(gridColumnDefinitions)} passed to {this.GetType()}.ExportToCsv";
                throw new ArgumentNullException(nameof(gridColumnDefinitions), errorMessage);
            }

            if (sourceData == null)
            {
                String errorMessage = $"Empty {nameof(sourceData)} passed to {this.GetType()}.ExportToCsv";
                throw new ArgumentNullException(nameof(sourceData), errorMessage);
            }

            String retVal = String.Empty;
            String columnHeaders = CsvAddColumnHeaders(gridColumnDefinitions);
            outputStream.WriteLine(columnHeaders);

            foreach (Object item in sourceData)
            {
                Boolean firstValue = true;
                Type itemType = item.GetType();
                foreach (IGridColumnDefinition gridColumnDefinition in gridColumnDefinitions)
                {
                    // Multiple/not uniquely named property get method 
                    List<PropertyInfo> propertyInfos = itemType.GetRuntimeProperties().ToList();

                    PropertyInfo? propertyInfo = null;
                    Int32 propertyCount = propertyInfos.Count(pi => pi.Name == gridColumnDefinition.DataMemberName);

                    if (propertyCount == 1)
                    {
                        propertyInfo = propertyInfos.First(pi => pi.Name == gridColumnDefinition.DataMemberName);
                    }
                    else if (propertyCount > 1)
                    {
                        // Sometimes the property IFoundationObjectId.Id is overridden in the derived class, we want to use
                        // the derived class version
                        propertyInfo = propertyInfos.First(pi => pi.Name == gridColumnDefinition.DataMemberName &&
                                                                 pi.DeclaringType != typeof(IFoundationObjectId));
                    }

                    // NullReferenceException is expected from the below code
                    Object? objValue = GetPropertyValue(item, itemType, propertyInfo, gridColumnDefinition);
                    String value = String.Empty;

                    if (objValue != null)
                    {
                        value = objValue.ToString() ?? String.Empty;
                    }

                    if (!firstValue)
                    {
                        outputStream.Write(",");
                    }

                    value = value.Replace(Environment.NewLine, String.Empty);
                    value = value.Replace("\r", String.Empty);
                    value = value.Replace("\n", String.Empty);

                    if (value.Contains(","))
                    {
                        value = $"\"{value}\"";
                    }

                    outputStream.Write(value);

                    firstValue = false;
                }

                outputStream.WriteLine();
                outputStream.Flush();
            }

            LoggingHelpers.TraceCallReturn(retVal);
        }

        /// <summary>
        /// Extracts the property value from the <paramref name="item"/>
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemType"></param>
        /// <param name="propertyInfo"></param>
        /// <param name="gridColumnDefinition"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        private Object? GetPropertyValue(Object item, Type itemType, PropertyInfo? propertyInfo, IGridColumnDefinition gridColumnDefinition)
        {
            LoggingHelpers.TraceCallEnter(item, itemType, propertyInfo, gridColumnDefinition);

            if (propertyInfo == null)
            {
                String errorMessage = $"Cannot find property called '{gridColumnDefinition.DataMemberName}' in type {itemType}. {this.GetType()}.ExportToExcel.";
                throw new ArgumentNullException(gridColumnDefinition.DataMemberName, errorMessage);
            }

            Object? retVal = propertyInfo.GetValue(item);

            if (retVal is DateTime dt)
            {
                retVal = dt.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Adds the headers in the <paramref name="gridColumnDefinitions"/> to a CSV based list
        /// </summary>
        /// <param name="gridColumnDefinitions"></param>
        /// <returns></returns>
        private String CsvAddColumnHeaders(IEnumerable<IGridColumnDefinition> gridColumnDefinitions)
        {
            LoggingHelpers.TraceCallEnter(gridColumnDefinitions);

            StringBuilder retVal = new StringBuilder();

            foreach (IGridColumnDefinition gridColumnDefinition in gridColumnDefinitions)
            {
                if (gridColumnDefinition.DataMemberName.Length > 0)
                {
                    if (retVal.Length > 0) retVal.Append(",");

                    retVal.Append(gridColumnDefinition.ColumnHeaderName);
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal.ToString();
        }

        /// <summary>
        /// Gets the standard entity column definitions.
        /// </summary>
        /// <returns>List of <see cref="GridColumnDefinition"/></returns>
        protected virtual List<IGridColumnDefinition> GetStandardEntityColumnDefinitions(Boolean includeStatusColumn = false, Type? idColumnType = null)
        {
            LoggingHelpers.TraceCallEnter(includeStatusColumn);

            List<IGridColumnDefinition> retVal = [];
            IGridColumnDefinition gridColumnDefinition;

            if (idColumnType == null)
            {
                idColumnType = typeof(EntityId);
            }

            gridColumnDefinition = new GridColumnDefinition(50, FDC.FoundationEntity.Id, "Id", idColumnType);
            retVal.Add(gridColumnDefinition);

            if (includeStatusColumn)
            {
                gridColumnDefinition = new GridColumnDefinition(75, FDC.FoundationEntity.StatusId, "Status", typeof(String))
                {
                    DataSource = StatusRepository.GetAll(excludeDeleted: false, useValidityPeriod: false),
                    ValueMember = FDC.Status.Id,
                    DisplayMember = FDC.Status.Name,
                };
                retVal.Add(gridColumnDefinition);
            }

            gridColumnDefinition = new GridColumnDefinition(150, FDC.FoundationEntity.CreatedByUserProfileId, "Created By", typeof(String))
            {
                DataSource = UserProfileRepository.GetAll(excludeDeleted: false, useValidityPeriod: false),
                ValueMember = FDC.UserProfile.Id,
                DisplayMember = FDC.UserProfile.DisplayName,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(170, FDC.FoundationEntity.CreatedOn, "Created On", typeof(DateTime))
            {
                DotNetFormat = Formats.DotNet.CreatedDateTime,
                ExcelFormat = Formats.Excel.CreatedDateTime,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.FoundationEntity.LastUpdatedByUserProfileId, "Updated By", typeof(String))
            {
                DataSource = UserProfileRepository.GetAll(excludeDeleted: false, useValidityPeriod: false),
                ValueMember = FDC.UserProfile.Id,
                DisplayMember = FDC.UserProfile.DisplayName,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(170, FDC.FoundationEntity.LastUpdatedOn, "Updated On", typeof(DateTime))
            {
                DotNetFormat = Formats.DotNet.UpdatedDateTime,
                ExcelFormat = Formats.Excel.CreatedDateTime,
            };
            retVal.Add(gridColumnDefinition);

            if (EntityRepository.HasValidityPeriodColumns)
            {
                gridColumnDefinition = new GridColumnDefinition(170, FDC.FoundationEntity.ValidFrom, "Valid From", typeof(DateTime))
                {
                    DotNetFormat = Formats.DotNet.FromDate,
                };
                retVal.Add(gridColumnDefinition);

                gridColumnDefinition = new GridColumnDefinition(170, FDC.FoundationEntity.ValidTo, "Valid To", typeof(DateTime))
                {
                    DotNetFormat = Formats.DotNet.ToDate,
                };
                retVal.Add(gridColumnDefinition);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
