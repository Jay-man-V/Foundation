//-----------------------------------------------------------------------
// <copyright file="EntityViewModelBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.ViewModels.Services;

namespace Foundation.ViewModels
{
    /// <summary>
    /// Implements generic routines for an Entity based ViewModel
    /// </summary>
    public abstract class EntityViewModelBase<TEntity> : ViewModelBase, IEntityViewModel
        where TEntity : IFoundationModel
    {
        private IFoundationModel _data = default!;

        /// <summary>Initialises a new instance of the <see cref="EntityViewModelBase{TEntity}" /> class.</summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="formTitle">The form title</param>
        protected EntityViewModelBase
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            String formTitle
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                formTitle
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, formTitle);

            EntityStatusName = "<not set>";
            CreatedByUserProfileDisplayName = "<not set>";
            LastUpdatedByUserProfileDisplayName = "<not set>";

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="Initialise(IWindow, IViewModel, IFoundationModel, String)"/>
        public void Initialise(IWindow targetWindow, IViewModel parentViewModel, IFoundationModel entity, String formTitle)
        {
            LoggingHelpers.TraceCallEnter(targetWindow, parentViewModel, entity, formTitle);

            base.Initialise(targetWindow, parentViewModel, formTitle);

            Data = entity;

            Data.PropertyChanged -= EntityOrViewModel_PropertyChanged;
            Data.PropertyChanged += EntityOrViewModel_PropertyChanged;
            //PropertyChanged -= EntityOrViewModel_PropertyChanged;
            //PropertyChanged += EntityOrViewModel_PropertyChanged;

            HasChanges = false;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>Handles the PropertyChanged event of the entity.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PropertyChangedEventArgs" /> instance containing the event data.</param>
        private void EntityOrViewModel_PropertyChanged(Object? sender, PropertyChangedEventArgs e)
        {
            LoggingHelpers.TraceCallEnter(sender, e);

            // Do not want to record changes to the following list of variables
            //  * FormTitle
            //  * HasChanges
            // All other changes need to be recorded
            String[] viewModelProperties = [nameof(FormTitle), nameof(HasChanges)];
            if (!String.IsNullOrEmpty(e.PropertyName) &&
                !viewModelProperties.Contains(e.PropertyName))
            {
                HasChanges = true;
                NotifyPropertyChanged(e.PropertyName);
            }

            LoggingHelpers.TraceCallReturn();
        }

        private Boolean _hasChanges;
        /// <summary>Gets or sets a value indicating whether this instance has changes.</summary>
        /// <value>
        ///   <c>true</c> if this instance has changes; otherwise, <c>false</c>.</value>
        public Boolean HasChanges
        {
            get => _hasChanges;
            protected set => SetPropertyValue(ref _hasChanges, value);
        }

        /// <summary>Gets the data.</summary>
        /// <value>The data.</value>
        public IFoundationModel? Data
        {
            get => _data;
            private set
            {
                if (value == null)
                {
                    String message = $"{nameof(Data)} cannot be null";
                    throw new ArgumentNullException(nameof(Data), message);
                }

                _data = value;
                IStatus? entityStatus = StatusesList.FirstOrDefault(s => s.Id == _data.StatusId);
                IUserProfile? createdByUserProfile = UserProfilesList.FirstOrDefault(up => up.Id == _data.CreatedByUserProfileId);
                IUserProfile? lastUpdatedByUserProfile = UserProfilesList.FirstOrDefault(up => up.Id == _data.LastUpdatedByUserProfileId);

                // Check if the matched properties are null, if they are then throw a proper exception
                if (entityStatus == null)
                {
                    const String sourceField = nameof(IFoundationModel.StatusId);
                    const String lookupListName = nameof(ViewModelBase.StatusesList);
                    EntityId requestedId = _data.StatusId;
                    IFoundationModel sourceModel = _data;
                    throw new ValueNotInLookupListException(sourceField, lookupListName, requestedId, sourceModel);
                }

                if (createdByUserProfile == null)
                {
                    const String sourceField = nameof(IFoundationModel.CreatedByUserProfileId);
                    const String lookupListName = nameof(ViewModelBase.UserProfilesList);
                    EntityId requestedId = _data.StatusId;
                    IFoundationModel sourceModel = _data;
                    throw new ValueNotInLookupListException(sourceField, lookupListName, requestedId, sourceModel);
                }

                if (lastUpdatedByUserProfile == null)
                {
                    const String sourceField = nameof(IFoundationModel.LastUpdatedByUserProfileId);
                    const String lookupListName = nameof(ViewModelBase.UserProfilesList);
                    EntityId requestedId = _data.StatusId;
                    IFoundationModel sourceModel = _data;
                    throw new ValueNotInLookupListException(sourceField, lookupListName, requestedId, sourceModel);
                }

                EntityStatusName = entityStatus.Name;
                CreatedByUserProfileDisplayName = createdByUserProfile.DisplayName;
                LastUpdatedByUserProfileDisplayName = lastUpdatedByUserProfile.DisplayName;
            }
        }

        /// <summary>Gets the name of the entity status.</summary>
        /// <value>The name of the entity status.</value>
        public String EntityStatusName { get; private set; }

        /// <summary>Gets the display name of the created by user profile.</summary>
        /// <value>The display name of the created by user profile.</value>
        public String CreatedByUserProfileDisplayName { get; private set; }

        /// <summary>Gets the last name of the updated by user profile display.</summary>
        /// <value>The last name of the updated by user profile display.</value>
        public String LastUpdatedByUserProfileDisplayName { get; private set; }

        /// <inheritdoc cref="OnCloseWindowCommand_Execute(IWindow)"/>
        protected override void OnCloseWindowCommand_Execute(IWindow? window)
        {
            LoggingHelpers.TraceCallEnter(window);

            using (new MouseBusyCursor(WpfApplicationObjects))
            {
                if (HasChanges)
                {
                    DialogResult dialogResult = PromptSaveBeforeExit();
                    if (dialogResult == DialogResult.Yes)
                    {
                        SaveChanges();
                    }
                }

                base.OnCloseWindowCommand_Execute(window);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="PromptSaveBeforeExit()"/>
        public virtual DialogResult PromptSaveBeforeExit()
        {
            LoggingHelpers.TraceCallEnter();

            IMessageBoxSettings messageBoxSettings = new MessageBoxSettings
            {
                Button = MessageBoxButton.YesNoCancel,
                Caption = "Save changes",
                Icon = MessageBoxImage.Question,
                Text = $"The data has changed.{Environment.NewLine}Save changes before closing?",
            };

            DialogResult retVal = DialogService.ShowMessageBox(this, messageBoxSettings);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>Saves the changes.</summary>
        /// <exception cref="NotImplementedException"></exception>
        public virtual void SaveChanges()
        {
            LoggingHelpers.TraceCallEnter();

            // It is up to derived classes to implement this functionality
            String runningType = GetType().ToString();
            String message = String.Empty;
            message += $"{runningType} has not implemented a SaveChanges routine.{Environment.NewLine}";
            message += "The changes cannot be saved.";

            LoggingHelpers.TraceCallReturn(message);

            throw new NotImplementedException(message);
        }
    }
}
