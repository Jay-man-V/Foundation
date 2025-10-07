//-----------------------------------------------------------------------
// <copyright file="ViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.ViewModels;

namespace Foundation.Tests.Unit.Foundation.ViewModels.BaseClasses
{
    /// <summary>
    /// Summary description for ViewModelUnitTests
    /// </summary>
    [TestFixture]
    public abstract class ViewModelTests<TViewModel> : ViewModelUnitTestsBase
        where TViewModel : IViewModel
    {
        protected TViewModel? TheViewModel { get; set; }

        protected virtual TViewModel CreateViewModel()
        {
            TViewModel viewModel = CreateViewModel(DateTimeService);

            return viewModel;
        }

        protected abstract TViewModel CreateViewModel(IDateTimeService dateTimeService);

        public override void TestInitialise()
        {
            base.TestInitialise();
        }

        [TestCase]
        public void Test_CommonProcess_Properties()
        {
            ViewModel? viewModel = TheViewModel as ViewModel;
            Assert.That(viewModel!.RunTimeEnvironmentSettings, Is.Not.EqualTo(null));
            Assert.That(viewModel.CloseWindowCommand, Is.Not.EqualTo(null));
            Assert.That(viewModel.DateTimeService, Is.Not.EqualTo(null));
            Assert.That(viewModel.ExitApplicationCommand, Is.Not.EqualTo(null));
            Assert.That(viewModel.FormTitle, Is.Not.EqualTo(null));
            Assert.That(viewModel.HasPreviousNotificationMessage, Is.Not.EqualTo(null));
            Assert.That(viewModel.IsSystemSupport, Is.Not.EqualTo(null));
            Assert.That(viewModel.LastMessage, Is.Not.EqualTo(null));
            Assert.That(viewModel.LastMessageHeader, Is.Not.EqualTo(null));
            Assert.That(viewModel.LastMessageType, Is.Not.EqualTo(null));
            Assert.That(viewModel.MessageBoxImage, Is.Not.EqualTo(null));
        }

        //protected abstract String ExpectedScreenTitle { get; }


        //protected virtual void CheckBaseClassProperties(TViewModel viewModel)
        //{

        //}

        //protected virtual void InitialiseViewModel()
        //{

        //}


        //[TestCase]
        //public void Test_StaticConstructorAndMembers()
        //{
        //    ViewModel.StatusesList = null;
        //    ViewModel.UserProfilesList = null;
        //    ViewModel.LoggedOnUsersList = null;

        //    Assert.That(ViewModel.StatusProcess, Is.Not.Null);
        //    Assert.That(ViewModel.UserProfileProcess, Is.Not.Null);
        //    Assert.That(ViewModel.LoggedOnUserProcess, Is.Not.Null);

        //    Assert.That(ViewModel.StatusesList, Is.Not.Null);
        //    Assert.That(ViewModel.UserProfilesList, Is.Not.Null);
        //    Assert.That(ViewModel.LoggedOnUsersList, Is.Not.Null);

        //    Assert.That(ViewModel.StatusesList, Is.EqualTo(StatusesList));
        //    Assert.That(ViewModel.UserProfilesList, Is.EqualTo(UserProfileList));
        //    Assert.That(ViewModel.LoggedOnUsersList, Is.EqualTo(LoggedOnUsersList));

        //    Assert.That(ViewModel.StatusesList.ToList(), Is.EquivalentTo(StatusesList.ToList()));
        //    Assert.That(ViewModel.UserProfilesList.ToList(), Is.EquivalentTo(UserProfileList.ToList()));
        //    Assert.That(ViewModel.LoggedOnUsersList.ToList(), Is.EquivalentTo(LoggedOnUsersList.ToList()));
        //}

        //[TestCase]
        //public void Test_ViewModelBaseConstructor()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    Assert.That(viewModel.FormTitle, Is.EqualTo(ExpectedScreenTitle));
        //    Assert.That(viewModel.Parameters, Is.InstanceOf<Dictionary<String, Object>>());
        //    Assert.That(viewModel.Parameters.Count, Is.EqualTo(0));

        //    Assert.That(viewModelBase.DateTimeService, Is.Not.Null);
        //    Assert.That(viewModelBase.RunTimeEnvironmentSettings, Is.Not.Null);
        //}

        //[TestCase]
        //public void Test_MouseBusyCursor()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    Assert.That(viewModelBase.MouseCursor, Is.Not.Null);
        //}

        //[TestCase]
        //public void Test_CurrentApplication()
        //{
        //    //TViewModel viewModel = CreateViewModel();
        //    //ViewModelBase viewModelBase = viewModel as ViewModelBase;

        //    //Application application = Application.Current;
        //    //if (application == null)
        //    //{
        //    //    application = new Application();
        //    //}

        //    //viewModelBase.CurrentApplication = application;

        //    //Assert.That(viewModelBase.CurrentApplication, Is.Not.Null);
        //    //Assert.That(viewModelBase.CurrentApplication, Is.EqualTo(application));
        //}

        //[TestCase]
        //public void Test_CurrentDispatcher()
        //{
        //    //TViewModel viewModel = CreateViewModel();
        //    //ViewModelBase viewModelBase = viewModel as ViewModelBase;
        //    //viewModelBase.CurrentDispatcher = Substitute.For<Dispatcher>();

        //    //Assert.That(viewModelBase.CurrentDispatcher, Is.Not.Null);
        //}

        //[TestCase]
        //public void Test_ViewModelBaseInitialise()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    IWindow targetWindow = Substitute.For<IWindow>();
        //    targetWindow.DataContext = Guid.NewGuid();

        //    IViewModel parentViewModel = Substitute.For<IViewModel>();

        //    String formTitle = Guid.NewGuid().ToString();

        //    InitialiseViewModel();

        //    viewModel.Initialise(targetWindow, parentViewModel, formTitle);

        //    Assert.That(viewModelBase.ThisWindow, Is.EqualTo(targetWindow));
        //    Assert.That(viewModelBase.ThisWindow.DataContext, Is.EqualTo(targetWindow.DataContext));

        //    Assert.That(viewModel.ParentViewModel, Is.EqualTo(parentViewModel));

        //    Assert.That(viewModel.FormTitle, Is.EqualTo(formTitle));

        //    Assert.That(ViewModel.LoggedOnUsersList!.Count, Is.EqualTo(1));
        //    Assert.That(ViewModel.StatusesList!.Count, Is.EqualTo(5));
        //    Assert.That(ViewModel.LoggedOnUsersList.Count, Is.EqualTo(1));
        //}

        //[TestCase]
        //public void Test_ViewModelBaseProperties()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    String expectedFormTitle = Guid.NewGuid().ToString();
        //    viewModelBase.FormTitle = expectedFormTitle;

        //    String expectedScreenInstructions = Guid.NewGuid().ToString();
        //    viewModelBase.ScreenInstructions = expectedScreenInstructions;

        //    MessageBoxImage expectedImage = MessageBoxImage.Information;
        //    viewModelBase.MessageBoxImage = expectedImage;

        //    Assert.That(viewModelBase.FormTitle, Is.EqualTo(expectedFormTitle));
        //    Assert.That(viewModelBase.ScreenInstructions, Is.EqualTo(expectedScreenInstructions));
        //    Assert.That(viewModelBase.IsSystemSupport, Is.EqualTo(CoreInstance.CurrentLoggedOnUser.IsSystemSupport));
        //    Assert.That(viewModelBase.MessageBoxImage, Is.EqualTo(expectedImage));
        //}

        //[TestCase]
        //public void Test_OpenLastNotificationCommand_Disabled()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    viewModelBase.HasPreviousNotificationMessage = false;
        //    Boolean canExecute = viewModelBase.OpenLastNotificationCommand.CanExecute(null);
        //    Assert.That(canExecute, Is.EqualTo(false));

        //    viewModelBase.OpenLastNotificationCommand.Execute(null);
        //    DialogService.DidNotReceiveWithAnyArgs().ShowNotificationMessage(Arg.Any<MessageType>(), Arg.Any<String>(), Arg.Any<String>());
        //}

        //[TestCase]
        //public void Test_OpenLastNotificationCommand_HasMessage()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    MessageType messageType = MessageType.Information;
        //    String messageHeader = Guid.NewGuid().ToString();
        //    String message = Guid.NewGuid().ToString();

        //    viewModelBase.HasPreviousNotificationMessage = true;
        //    Boolean canExecute = viewModelBase.OpenLastNotificationCommand.CanExecute(null);
        //    Assert.That(canExecute, Is.EqualTo(true));

        //    viewModelBase.ShowNotificationMessage(messageType, messageHeader, message);
        //    DialogService.Received().ShowNotificationMessage(messageType, messageHeader, message);

        //    viewModelBase.OpenLastNotificationCommand.Execute(null);
        //    DialogService.Received().ShowNotificationMessage(messageType, messageHeader, message);

        //    Assert.That(viewModelBase.LastMessageType, Is.EqualTo(messageType));
        //    Assert.That(viewModelBase.LastMessageHeader, Is.EqualTo(messageHeader));
        //    Assert.That(viewModelBase.LastMessage, Is.EqualTo(message));
        //}

        //[TestCase]
        //public void Test_OpenLastNotificationCommand_NoMessage()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    MessageType messageType = MessageType.Information;
        //    String messageHeader = Guid.NewGuid().ToString();
        //    String message = Guid.NewGuid().ToString();

        //    viewModelBase.OpenLastNotificationCommand.Execute(null);
        //    DialogService.DidNotReceive().ShowNotificationMessage(messageType, messageHeader, message);
        //}

        //[TestCase]
        //public void Test_OnCloseWindowCommand_Execute()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    IWindow window = Substitute.For<IWindow>();

        //    String formTitle = LocationUtils.GetFunctionName();

        //    InitialiseViewModel();

        //    viewModel.Initialise(window, null, formTitle);

        //    Boolean canExecute = viewModelBase.CloseWindowCommand.CanExecute(null);
        //    Assert.That(canExecute, Is.EqualTo(true));

        //    viewModelBase.CloseWindowCommand.Execute(window);

        //    window.Received().Close();
        //}

        //[TestCase]
        //public void Test_OnExitApplicationCommand_Execute()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    IWindow window = Substitute.For<IWindow>();

        //    String formTitle = LocationUtils.GetFunctionName();

        //    InitialiseViewModel();

        //    viewModel.Initialise(window, null, formTitle);

        //    Boolean canExecute = viewModelBase.ExitApplicationCommand.CanExecute(null);
        //    Assert.That(canExecute, Is.EqualTo(true));

        //    //viewModelBase.CurrentApplication = CurrentApplication;
        //    //System.Windows.Window mainWindow = Substitute.For<System.Windows.Window>();
        //    //viewModelBase.CurrentApplication.MainWindow = mainWindow;

        //    viewModelBase.ExitApplicationCommand.Execute(window);

        //    //mainWindow.Received().Close();
        //}

        //[TestCase]
        //public void Test_ShowNotificationMessage()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    MessageType messageType = MessageType.Information;
        //    String messageHeader = Guid.NewGuid().ToString();
        //    String message = Guid.NewGuid().ToString();

        //    viewModelBase.ShowNotificationMessage(messageType, messageHeader, message);

        //    DialogService.Received().ShowNotificationMessage(messageType, messageHeader, message);
        //}

        //[TestCase]
        //public void Test_NotifyPropertyChanged()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    Int32 propertyCount = 2;
        //    Int32 changedPropertiesCount = 0;

        //    String propertyName = "Property name not set";
        //    viewModel.PropertyChanged += (_, args) =>
        //    {
        //        Assert.That(args.PropertyName, Is.EqualTo(propertyName));
        //        changedPropertiesCount++;
        //    };

        //    propertyName = nameof(viewModelBase.FormTitle);
        //    viewModelBase.FormTitle = Guid.NewGuid().ToString();

        //    propertyName = nameof(viewModelBase.ScreenInstructions);
        //    viewModelBase.ScreenInstructions = Guid.NewGuid().ToString();

        //    Assert.That(changedPropertiesCount, Is.EqualTo(propertyCount));
        //}

        //[TestCase]
        //public void Test_CanExecuteParamIsNotNull_Null()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    Boolean canExecute = viewModelBase.CanExecuteParamIsNotNull(null);
        //    Assert.That(canExecute, Is.EqualTo(false));
        //}

        //[TestCase]
        //public void Test_CanExecuteParamIsNotNull_NotNull()
        //{
        //    IViewModel viewModel = CreateViewModel();
        //    ViewModel viewModelBase = (ViewModel)viewModel;

        //    Boolean canExecute = viewModelBase.CanExecuteParamIsNotNull(new Object());
        //    Assert.That(canExecute, Is.EqualTo(true));
        //}
    }
}
