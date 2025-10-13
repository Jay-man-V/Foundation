//-----------------------------------------------------------------------
// <copyright file="EntityViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses
{
    /// <summary>
    /// Summary description for EntityViewModelTests
    /// </summary>
    public abstract class EntityViewModelTests<TViewModel> : ViewModelTests<TViewModel>
        where TViewModel : IViewModel
    {
        //protected override String ExpectedScreenTitle => "Mock View Model";

        //protected override IMockModelViewModel CreateViewModel(IDateTimeService dateTimeService)
        //{
        //    IMockModelViewModel entityViewModel = new MockModelViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects);

        //    return entityViewModel;
        //}

        //protected override IMockFoundationModelProcess CreateBusinessProcess()
        //{
        //    IMockFoundationModelProcess process = Substitute.For<IMockFoundationModelProcess>();

        //    return process;
        //}

        //protected override IMockFoundationModel CreateModel()
        //{
        //    IMockFoundationModel retVal = base.CreateModel();

        //    retVal.Name = Guid.NewGuid().ToString();
        //    retVal.Description = Guid.NewGuid().ToString();

        //    return retVal;
        //}

        //protected override string NameOfModelPropertyToBeChangedForPropertyChangedEvent => nameof(IMockFoundationModel.IsOpen);
        //protected override string NameOfViewModelPropertyToBeChangedForPropertyChangedEvent => nameof(IMockModelViewModel.StringProperty);

        //protected override void ChangePropertyForPropertyChangedEvent(IMockModelViewModel viewModel, IMockFoundationModel model)
        //{
        //    viewModel.StringProperty = Guid.NewGuid().ToString();
        //    model.IsOpen = !model.IsOpen;
        //}

        //protected TBusinessProcess BusinessProcess { get; private set; }
        //protected TModelViewModel EntityViewModel { get; private set; }
        //protected EntityViewModel<TModel> EntityViewModelBase { get; private set; }
        //protected TModel Model { get; private set; }
        //protected IWindow TargetWindow { get; private set; }
        //protected IViewModel ParentViewModel { get; private set; }
        //protected String FormTitle { get; private set; }

        //protected abstract TBusinessProcess CreateBusinessProcess();

        //protected abstract String NameOfModelPropertyToBeChangedForPropertyChangedEvent { get; }
        //protected abstract String NameOfViewModelPropertyToBeChangedForPropertyChangedEvent { get; }
        //protected abstract void ChangePropertyForPropertyChangedEvent(TModelViewModel viewModel, TModel model);

        //protected TModel CreateBlankModel()
        //{
        //    TModel retVal = CoreInstance.IoC.Get<TModel>();

        //    return retVal;
        //}

        //protected virtual TModel CreateModel()
        //{
        //    TModel retVal = CreateBlankModel();

        //    retVal.EntityStatus = EntityStatus.Active;

        //    retVal.CreatedOn = CreatedOnDateTime;
        //    retVal.CreatedByUserProfileId = new EntityId(1);

        //    retVal.LastUpdatedOn = LastUpdatedOnDateTime;
        //    retVal.LastUpdatedByUserProfileId = new EntityId(2);

        //    retVal.ValidFrom = ValidFromDateTime;
        //    retVal.ValidTo = ValidToDateTime;

        //    return retVal;
        //}

        //public override void TestInitialise()
        //{
        //    base.TestInitialise();

        //    BusinessProcess = CreateBusinessProcess();

        //    Model = CreateModel();
        //    EntityViewModel = CreateViewModel();
        //    EntityViewModelBase = EntityViewModel as EntityViewModel<TModel>;

        //    TargetWindow = Substitute.For<IWindow>();
        //    TargetWindow.DataContext = EntityViewModel;
        //    ParentViewModel = Substitute.For<IViewModel>();
        //    FormTitle = Guid.NewGuid().ToString();
        //}

        //protected virtual void Check_CloseWindowCommand_DoNotSaveChanges()
        //{
        //    String executingType = EntityViewModel.ToString();
        //    String expectedMessage1 = $"{executingType} has not implemented a SaveChanges routine.\r\nThe changes cannot be saved.";

        //    Exception actualException = null;

        //    try
        //    {
        //        EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);

        //        ChangePropertyForPropertyChangedEvent(EntityViewModel, Model);

        //        DialogService.ShowMessageBox(Arg.Any<Object>(), Arg.Any<MessageBoxSettings>()).Returns(DialogResult.Yes);

        //        EntityViewModelBase.CloseWindowCommand.Execute(TargetWindow);
        //    }
        //    catch (Exception exception)
        //    {
        //        actualException = exception;
        //    }

        //    Assert.That(actualException, Is.Not.Null);
        //    Assert.That(actualException, Is.InstanceOf<NotImplementedException>());

        //    NotImplementedException specificException = (NotImplementedException)actualException;

        //    String actualMessage1 = specificException.Message;
        //    Assert.That(actualMessage1, Is.EqualTo(expectedMessage1));
        //}

        //[TestCase]
        //public void Test_InitialiseEntityEntityViewModel()
        //{
        //    Assert.That(EntityViewModelBase.Data, Is.Null);
        //    Assert.That(EntityViewModel.HasChanges, Is.EqualTo(false));

        //    EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);

        //    Assert.That(EntityViewModelBase.Data, Is.Not.Null);
        //    Assert.That(EntityViewModel.HasChanges, Is.EqualTo(false));

        //    Assert.That(EntityViewModelBase.Data, Is.EqualTo(Model));
        //}

        //[TestCase]
        //public void Test_InitialiseEntityEntityViewModel_PropertyChangedEvent()
        //{
        //    EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);

        //    //Boolean viewModelPropertyChangedEventRaised = false;
        //    //EntityViewModelBase.PropertyChanged += (sender, args) =>
        //    //{
        //    //    if (!String.IsNullOrEmpty(NameOfViewModelPropertyToBeChangedForPropertyChangedEvent))
        //    //    {
        //    //        viewModelPropertyChangedEventRaised = args.PropertyName == NameOfViewModelPropertyToBeChangedForPropertyChangedEvent;
        //    //    }
        //    //};

        //    Boolean modelPropertyChangedEventRaised = false;
        //    Model.PropertyChanged += (sender, args) =>
        //    {
        //        if (!String.IsNullOrEmpty(NameOfModelPropertyToBeChangedForPropertyChangedEvent))
        //        {
        //            modelPropertyChangedEventRaised = args.PropertyName == NameOfModelPropertyToBeChangedForPropertyChangedEvent;
        //        }
        //    };

        //    ChangePropertyForPropertyChangedEvent(EntityViewModel, Model);

        //    //if (!String.IsNullOrEmpty(NameOfViewModelPropertyToBeChangedForPropertyChangedEvent))
        //    //{
        //    //    Assert.That(viewModelPropertyChangedEventRaised, Is.EqualTo(true));

        //    //}

        //    if (!String.IsNullOrEmpty(NameOfModelPropertyToBeChangedForPropertyChangedEvent))
        //    {
        //        Assert.That(modelPropertyChangedEventRaised, Is.EqualTo(true));
        //    }
        //}

        //[TestCase]
        //public void Test_HasChangesProperty()
        //{
        //    EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);

        //    Assert.That(EntityViewModel.HasChanges, Is.EqualTo(false));

        //    ChangePropertyForPropertyChangedEvent(EntityViewModel, Model);

        //    Assert.That(EntityViewModel.HasChanges, Is.EqualTo(true));
        //}

        //[TestCase]
        //public void Test_DataProperty()
        //{
        //    EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);

        //    Assert.That(EntityViewModelBase.Data, Is.EqualTo(Model));
        //}

        //[TestCase]
        //public void Test_Data_ExceptionForEntityStatus()
        //{
        //    String sourceField = nameof(IFoundationModel.StatusId);
        //    String lookupListName = nameof(ViewModel.StatusesList);
        //    String statusId = Model.StatusId.ToString();
        //    String entityType = Model.GetType().ToString();
        //    String entityId = Model.Id.ToString();
        //    String expectedMessage1 = String.Format(ValueNotInLookupListException.ErrorMessageTemplate1, sourceField, lookupListName, statusId, entityType, entityId);

        //    Exception actualException = null;

        //    List<IStatus> initialStatusList = ViewModel.StatusesList;
        //    try
        //    {
        //        ViewModel.StatusesList = new List<IStatus>();
        //        EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);
        //    }
        //    catch (Exception exception)
        //    {
        //        actualException = exception;
        //    }
        //    finally
        //    {
        //        ViewModel.StatusesList = initialStatusList;
        //    }

        //    Assert.That(actualException, Is.Not.Null);
        //    Assert.That(actualException, Is.InstanceOf<ValueNotInLookupListException>());

        //    ValueNotInLookupListException specificException = (ValueNotInLookupListException)actualException;

        //    String actualMessage1 = specificException.Message;
        //    Assert.That(actualMessage1, Is.EqualTo(expectedMessage1));

        //    Assert.That(specificException.SourceField, Is.EqualTo(sourceField));
        //    Assert.That(specificException.LookUpListName, Is.EqualTo(lookupListName));
        //    Assert.That(specificException.RequestedId.ToString(), Is.EqualTo(statusId));
        //    Assert.That(specificException.SourceModel.GetType().ToString(), Is.EqualTo(entityType));
        //    Assert.That(specificException.SourceModel.Id.ToString(), Is.EqualTo(entityId));
        //}

        //[TestCase]
        //public void Test_Data_ExceptionForCreatedByUserProfile()
        //{
        //    Model.CreatedByUserProfileId = new EntityId(-1);
        //    String sourceField = nameof(IFoundationModel.CreatedByUserProfileId);
        //    String lookupListName = nameof(ViewModel.UserProfilesList);
        //    String statusId = Model.StatusId.ToString();
        //    String entityType = Model.GetType().ToString();
        //    String entityId = Model.Id.ToString();
        //    String expectedMessage1 = String.Format(ValueNotInLookupListException.ErrorMessageTemplate1, sourceField, lookupListName, statusId, entityType, entityId);

        //    Exception actualException = null;

        //    try
        //    {
        //        EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);
        //    }
        //    catch (Exception exception)
        //    {
        //        actualException = exception;
        //    }

        //    Assert.That(actualException, Is.Not.Null);
        //    Assert.That(actualException, Is.InstanceOf<ValueNotInLookupListException>());

        //    ValueNotInLookupListException specificException = (ValueNotInLookupListException)actualException;

        //    String actualMessage1 = specificException.Message;
        //    Assert.That(actualMessage1, Is.EqualTo(expectedMessage1));

        //    Assert.That(specificException.SourceField, Is.EqualTo(sourceField));
        //    Assert.That(specificException.LookUpListName, Is.EqualTo(lookupListName));
        //    Assert.That(specificException.RequestedId.ToString(), Is.EqualTo(statusId));
        //    Assert.That(specificException.SourceModel.GetType().ToString(), Is.EqualTo(entityType));
        //    Assert.That(specificException.SourceModel.Id.ToString(), Is.EqualTo(entityId));
        //}

        //[TestCase]
        //public void Test_Data_ExceptionForLastUpdatedByUserProfile()
        //{
        //    Model.LastUpdatedByUserProfileId = new EntityId(-1);
        //    String sourceField = nameof(IFoundationModel.LastUpdatedByUserProfileId);
        //    String lookupListName = nameof(ViewModel.UserProfilesList);
        //    String statusId = Model.StatusId.ToString();
        //    String entityType = Model.GetType().ToString();
        //    String entityId = Model.Id.ToString();
        //    String expectedMessage1 = String.Format(ValueNotInLookupListException.ErrorMessageTemplate1, sourceField, lookupListName, statusId, entityType, entityId);

        //    Exception actualException = null;

        //    try
        //    {
        //        EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);
        //    }
        //    catch (Exception exception)
        //    {
        //        actualException = exception;
        //    }

        //    Assert.That(actualException, Is.Not.Null);
        //    Assert.That(actualException, Is.InstanceOf<ValueNotInLookupListException>());

        //    ValueNotInLookupListException specificException = (ValueNotInLookupListException)actualException;

        //    String actualMessage1 = specificException.Message;
        //    Assert.That(actualMessage1, Is.EqualTo(expectedMessage1));

        //    Assert.That(specificException.SourceField, Is.EqualTo(sourceField));
        //    Assert.That(specificException.LookUpListName, Is.EqualTo(lookupListName));
        //    Assert.That(specificException.RequestedId.ToString(), Is.EqualTo(statusId));
        //    Assert.That(specificException.SourceModel.GetType().ToString(), Is.EqualTo(entityType));
        //    Assert.That(specificException.SourceModel.Id.ToString(), Is.EqualTo(entityId));
        //}

        //[TestCase]
        //public void Test_EntityStatusName()
        //{
        //    String expectedEntityStatusName = "Active";
        //    EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);

        //    Assert.That(EntityViewModelBase.EntityStatusName, Is.EqualTo(expectedEntityStatusName));
        //}

        //[TestCase]
        //public void Test_CreatedByUserProfileDisplayName()
        //{
        //    String expectedCreatedByUserProfileDisplayName = "System Display Name";
        //    EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);

        //    Assert.That(EntityViewModelBase.CreatedByUserProfileDisplayName, Is.EqualTo(expectedCreatedByUserProfileDisplayName));
        //}

        //[TestCase]
        //public void Test_LastUpdatedByUserProfileDisplayName()
        //{
        //    String expectedLastUpdatedByUserProfileDisplayName = "Jayesh Varsani";
        //    EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);

        //    Assert.That(EntityViewModelBase.LastUpdatedByUserProfileDisplayName, Is.EqualTo(expectedLastUpdatedByUserProfileDisplayName));
        //}

        //[TestCase]
        //public void Test_CloseWindowCommand_NoChanges()
        //{
        //    EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);

        //    EntityViewModelBase.CloseWindowCommand.Execute(TargetWindow);

        //    DialogService.DidNotReceive().ShowMessageBox(Arg.Any<Object>(), Arg.Any<MessageBoxSettings>());
        //    TargetWindow.Received().Close();
        //}

        //[TestCase]
        //public void Test_CloseWindowCommand_DoNotSaveChanges()
        //{
        //    EntityViewModelBase.Initialise(TargetWindow, ParentViewModel, Model, FormTitle);

        //    ChangePropertyForPropertyChangedEvent(EntityViewModel, Model);

        //    DialogService.ShowMessageBox(Arg.Any<Object>(), Arg.Any<MessageBoxSettings>()).Returns(DialogResult.No);

        //    EntityViewModelBase.CloseWindowCommand.Execute(TargetWindow);

        //    DialogService.Received().ShowMessageBox(Arg.Any<Object>(), Arg.Any<MessageBoxSettings>());
        //    TargetWindow.Received().Close();
        //}

        //[TestCase]
        //public void Test_CloseWindowCommand_SaveChanges()
        //{
        //    Check_CloseWindowCommand_DoNotSaveChanges();
        //}



    }
}
