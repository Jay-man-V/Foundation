//-----------------------------------------------------------------------
// <copyright file="ViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
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
        protected abstract String ExpectedFormTitle { get; }

        protected TViewModel? TheViewModel { get; set; }
        protected ViewModel? TheViewModelBase => TheViewModel as ViewModel;

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

        protected abstract void SetupFilterOptionsForReferencedBusinessProcess();

        [TestCase]
        public void Test_StaticConstructorAndMembers()
        {
            Assert.That(ViewModel.StatusProcess, Is.Not.EqualTo(null));
            Assert.That(ViewModel.UserProfileProcess, Is.Not.EqualTo(null));
            Assert.That(ViewModel.LoggedOnUserProcess, Is.Not.EqualTo(null));

            Assert.That(ViewModel.StatusesList, Is.Not.EqualTo(null));
            Assert.That(ViewModel.UserProfilesList, Is.Not.EqualTo(null));
            Assert.That(ViewModel.LoggedOnUsersList, Is.Not.EqualTo(null));

            Assert.That(ViewModel.StatusesList.Count, Is.EqualTo(5));
            Assert.That(ViewModel.UserProfilesList.Count, Is.EqualTo(5));
            Assert.That(ViewModel.LoggedOnUsersList.Count, Is.EqualTo(1));

            Assert.That(ViewModel.StatusesList, Is.EqualTo(StatusesList));
            Assert.That(ViewModel.UserProfilesList, Is.EqualTo(UserProfileList));
            Assert.That(ViewModel.LoggedOnUsersList, Is.EqualTo(LoggedOnUsersList));

            Assert.That(ViewModel.StatusesList.ToList(), Is.EquivalentTo(StatusesList.ToList()));
            Assert.That(ViewModel.UserProfilesList.ToList(), Is.EquivalentTo(UserProfileList.ToList()));
            Assert.That(ViewModel.LoggedOnUsersList.ToList(), Is.EquivalentTo(LoggedOnUsersList.ToList()));
        }


        [TestCase]
        public void Test_ViewModelBaseConstructor()
        {
            Assert.That(TheViewModel!.FormTitle, Is.EqualTo(ExpectedFormTitle));
            Assert.That(TheViewModel.Parameters, Is.InstanceOf<Dictionary<String, Object>>());
            Assert.That(TheViewModel.Parameters.Count, Is.EqualTo(0));
        }

        [TestCase]
        public void Test_Properties_InitialValues()
        {
            Assert.That(TheViewModelBase!.ApplicationWrapper, Is.Not.EqualTo(null));
            Assert.That(TheViewModelBase.ClipBoardWrapper, Is.Not.EqualTo(null));
            Assert.That(TheViewModelBase.CloseWindowCommand, Is.Not.EqualTo(null));
            Assert.That(TheViewModelBase.DateTimeService, Is.Not.EqualTo(null));
            Assert.That(TheViewModelBase.DialogService, Is.Not.EqualTo(null));
            Assert.That(TheViewModelBase.DispatchTimerWrapper, Is.Not.EqualTo(null));
            Assert.That(TheViewModelBase.ExitApplicationCommand, Is.Not.EqualTo(null));
            Assert.That(TheViewModelBase.MouseCursor, Is.Not.Null);
            Assert.That(TheViewModelBase.RunTimeEnvironmentSettings, Is.Not.EqualTo(null));
            Assert.That(TheViewModelBase.WpfApplicationObjects, Is.Not.EqualTo(null));

            Assert.That(TheViewModelBase.Parameters, Is.InstanceOf<Dictionary<String, Object>>());
            Assert.That(TheViewModelBase.Parameters.Count, Is.EqualTo(0));

            Assert.That(TheViewModelBase.IsSystemSupport, Is.EqualTo(true));
            Assert.That(TheViewModelBase.FormTitle, Is.Not.EqualTo(null));
            Assert.That(TheViewModelBase.HasPreviousNotificationMessage, Is.EqualTo(false));
            Assert.That(TheViewModelBase.LastMessage, Is.EqualTo(String.Empty));
            Assert.That(TheViewModelBase.LastMessageHeader, Is.EqualTo(String.Empty));
            Assert.That(TheViewModelBase.LastMessageType, Is.EqualTo(MessageType.NotSet));
            Assert.That(TheViewModelBase.MessageBoxImage, Is.EqualTo(MessageBoxImage.None));
            Assert.That(TheViewModelBase.ScreenInstructions, Is.EqualTo(String.Empty));
        }

        [TestCase]
        public void Test_Properties_SetValue()
        {
            String expectedFormTitle = Guid.NewGuid().ToString();
            String expectedScreenInstructions = Guid.NewGuid().ToString();
            MessageBoxImage expectedImage = MessageBoxImage.Information;

            TheViewModelBase!.FormTitle = expectedFormTitle;
            TheViewModelBase.MessageBoxImage = expectedImage;
            TheViewModelBase.ScreenInstructions = expectedScreenInstructions;

            Assert.That(TheViewModelBase.FormTitle, Is.EqualTo(expectedFormTitle));
            Assert.That(TheViewModelBase.HasPreviousNotificationMessage, Is.EqualTo(false));
            Assert.That(TheViewModelBase.LastMessage, Is.EqualTo(String.Empty));
            Assert.That(TheViewModelBase.LastMessageHeader, Is.EqualTo(String.Empty));
            Assert.That(TheViewModelBase.LastMessageType, Is.EqualTo(MessageType.NotSet));
            Assert.That(TheViewModelBase.MessageBoxImage, Is.EqualTo(expectedImage));
            Assert.That(TheViewModelBase.ScreenInstructions, Is.EqualTo(expectedScreenInstructions));
        }

        [TestCase]
        public void Test_Initialise()
        {
            IWindow targetWindow = Substitute.For<IWindow>();
            targetWindow.DataContext = Guid.NewGuid();

            IViewModel parentViewModel = Substitute.For<IViewModel>();

            String formTitle = Guid.NewGuid().ToString();

            TheViewModel!.Initialise(targetWindow, parentViewModel, formTitle);

            Assert.That(TheViewModelBase!.ThisWindow, Is.EqualTo(targetWindow));
            Assert.That(TheViewModelBase.ThisWindow!.DataContext, Is.EqualTo(targetWindow.DataContext));

            Assert.That(TheViewModel.ParentViewModel, Is.EqualTo(parentViewModel));

            Assert.That(TheViewModel.FormTitle, Is.EqualTo(formTitle));

            Assert.That(ViewModel.LoggedOnUsersList.Count, Is.EqualTo(1));
            Assert.That(ViewModel.StatusesList.Count, Is.EqualTo(5));
            Assert.That(ViewModel.LoggedOnUsersList.Count, Is.EqualTo(1));
        }

        [TestCase]
        public void Test_NotifyPropertyChanged()
        {
            Int32 expectedChangedCount = 2;
            Int32 changedPropertiesCount = 0;

            String propertyName = "Property name not set";
            TheViewModel!.PropertyChanged += (_, args) =>
            {
                Assert.That(args.PropertyName, Is.EqualTo(propertyName));
                changedPropertiesCount++;
            };

            propertyName = nameof(TheViewModelBase.FormTitle);
            TheViewModelBase!.FormTitle = Guid.NewGuid().ToString();

            propertyName = nameof(TheViewModelBase.ScreenInstructions);
            TheViewModelBase.ScreenInstructions = Guid.NewGuid().ToString();

            Assert.That(changedPropertiesCount, Is.EqualTo(expectedChangedCount));
        }

        [TestCase]
        public void Test_OpenLastNotificationCommand_HasMessage()
        {
            MessageType messageType = MessageType.Information;
            String messageHeader = Guid.NewGuid().ToString();
            String message = Guid.NewGuid().ToString();

            TheViewModelBase!.HasPreviousNotificationMessage = true;
            Boolean canExecute = TheViewModelBase.OpenLastNotificationCommand.CanExecute(null);
            Assert.That(canExecute, Is.EqualTo(true));

            TheViewModelBase.ShowNotificationMessage(messageType, messageHeader, message);
            DialogService.Received().ShowNotificationMessage(messageType, messageHeader, message);

            TheViewModelBase.OpenLastNotificationCommand.Execute(null);
            DialogService.Received().ShowNotificationMessage(messageType, messageHeader, message);

            Assert.That(TheViewModelBase.LastMessageType, Is.EqualTo(messageType));
            Assert.That(TheViewModelBase.LastMessageHeader, Is.EqualTo(messageHeader));
            Assert.That(TheViewModelBase.LastMessage, Is.EqualTo(message));
        }

        [TestCase]
        public void Test_OpenLastNotificationCommand_NoMessage()
        {
            MessageType messageType = MessageType.Information;
            String messageHeader = Guid.NewGuid().ToString();
            String message = Guid.NewGuid().ToString();

            TheViewModelBase!.OpenLastNotificationCommand.Execute(null);
            DialogService.DidNotReceive().ShowNotificationMessage(messageType, messageHeader, message);
        }

        [TestCase]
        public void Test_OpenLastNotificationCommand_Disabled()
        {
            TheViewModelBase!.HasPreviousNotificationMessage = false;
            Boolean canExecute = TheViewModelBase.OpenLastNotificationCommand.CanExecute(null);
            Assert.That(canExecute, Is.EqualTo(false));

            TheViewModelBase.OpenLastNotificationCommand.Execute(null);
            DialogService.DidNotReceiveWithAnyArgs().ShowNotificationMessage(Arg.Any<MessageType>(), Arg.Any<String>(), Arg.Any<String>());
        }

        [TestCase]
        public void Test_OnCloseWindowCommand_Execute()
        {
            IWindow window = Substitute.For<IWindow>();

            String formTitle = LocationUtils.GetFunctionName();

            TheViewModel!.Initialise(window, null, formTitle);

            Boolean canExecute = TheViewModelBase!.CloseWindowCommand.CanExecute(null);
            Assert.That(canExecute, Is.EqualTo(true));

            TheViewModelBase.CloseWindowCommand.Execute(window);

            window.Received().Close();
        }

        [TestCase]
        public void Test_OnExitApplicationCommand_Execute()
        {
            IWindow window = Substitute.For<IWindow>();

            String formTitle = LocationUtils.GetFunctionName();

            TheViewModel!.Initialise(window, null, formTitle);

            Boolean canExecute = TheViewModelBase!.ExitApplicationCommand.CanExecute(null);
            Assert.That(canExecute, Is.EqualTo(true));

            TheViewModelBase.ExitApplicationCommand.Execute(window);

            ApplicationWrapper.MainWindow.Received().Close();
        }

        [TestCase]
        public void Test_ShowNotificationMessage()
        {
            MessageType messageType = MessageType.Information;
            String messageHeader = Guid.NewGuid().ToString();
            String message = Guid.NewGuid().ToString();

            TheViewModelBase!.ShowNotificationMessage(messageType, messageHeader, message);

            DialogService.Received().ShowNotificationMessage(messageType, messageHeader, message);
        }

        [TestCase]
        public void Test_CanExecuteParamIsNotNull_Null()
        {
            Boolean canExecute = TheViewModelBase!.CanExecuteParamIsNotNull(null);
            Assert.That(canExecute, Is.EqualTo(false));
        }

        [TestCase]
        public void Test_CanExecuteParamIsNotNull_NotNull()
        {
            Boolean canExecute = TheViewModelBase!.CanExecuteParamIsNotNull(new Object());
            Assert.That(canExecute, Is.EqualTo(true));
        }
    }
}
