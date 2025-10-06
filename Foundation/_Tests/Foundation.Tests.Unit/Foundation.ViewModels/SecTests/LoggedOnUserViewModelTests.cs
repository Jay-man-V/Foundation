//-----------------------------------------------------------------------
// <copyright file="LoggedOnUserViewModelTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Helpers;
using Foundation.Interfaces;
using Foundation.Models.Sec;
using Foundation.Resources;
using Foundation.Tests.Unit.Foundation.ViewModels.Support;
using Foundation.ViewModels.Sec;

namespace Foundation.Tests.Unit.Foundation.ViewModels.SecTests
{
    /// <summary>
    /// Summary description for LoggedOnUserViewModelTests
    /// </summary>
    [TestFixture]
    public class LoggedOnUserViewModelTests : GenericDataGridViewModelTestBaseClass<ILoggedOnUser, ILoggedOnUserViewModel, ILoggedOnUserProcess>
    {
        protected override String ExpectedScreenTitle => "Logged On Users";
        protected override String ExpectedStatusBarText => "Number of Logged On Users:";

        protected override ILoggedOnUserViewModel CreateViewModel(IDateTimeService dateTimeService)
        {
            ICommandParser commandParser = new CommandParser(dateTimeService);

            ILoggedOnUserViewModel viewModel = new LoggedOnUserViewModel(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, WpfApplicationObjects, FileApi, BusinessProcess, commandParser);

            return viewModel;
        }

        protected override ILoggedOnUserProcess CreateBusinessProcess()
        {
            ILoggedOnUserProcess process = Substitute.For<ILoggedOnUserProcess>();

            return process;
        }

        protected override ILoggedOnUser CreateModel()
        {
            ILoggedOnUser retVal = base.CreateModel();
            LoggedOnUser loggedOnUser = (LoggedOnUser)retVal;

            retVal.ApplicationId = new AppId(1);
            retVal.UserProfileId = new EntityId(2);
            retVal.LoggedOn = DateTimeService.SystemUtcDateTimeNow;
            retVal.LastActive = DateTimeService.SystemUtcDateTimeNow;
            retVal.Command = String.Empty;
            loggedOnUser.Username = Guid.NewGuid().ToString();
            loggedOnUser.RoleId = new EntityId(3);
            loggedOnUser.IsSystemSupport = false;

            return retVal;
        }

        protected override void SetupForRefreshData()
        {
            List<ILoggedOnUser> entities = new List<ILoggedOnUser>
            {
                CreateModel(),
            };

            BusinessProcess.GetLoggedOnUsers(Arg.Any<AppId>()).Returns(entities);
        }

        [TestCase]
        public void Test_RefreshWithAbortCommand()
        {
            List<ILoggedOnUser> entities = new List<ILoggedOnUser>
            {
                CreateModel(),
            };

            String commandName = CommandNames.Abort;
            entities[0].Command = $"{commandName}=";

            BusinessProcess.GetLoggedOnUsers(Arg.Any<AppId>()).Returns(entities);

            ILoggedOnUserViewModel viewModel = CreateViewModel(DateTimeService);
            LoggedOnUserViewModel loggedOnUserViewModel = (LoggedOnUserViewModel)viewModel;
            loggedOnUserViewModel.RefreshCommand.Execute(null);

            Assert.That(loggedOnUserViewModel.ExternalCommandMessage, Is.EqualTo(String.Empty));
            Assert.That(loggedOnUserViewModel.ExternalCommandName, Is.EqualTo(commandName));
            Assert.That(loggedOnUserViewModel.ExternalCommandTime, Is.EqualTo(DateTime.MinValue));
        }

        [TestCase]
        public void Test_RefreshWithQuitCommand()
        {
            List<ILoggedOnUser> entities = new List<ILoggedOnUser>
            {
                CreateModel(),
            };

            String commandName = CommandNames.Quit;
            DateTime parameter = DateTimeService.SystemDateTimeNowWithoutMilliseconds.AddMinutes(15);
            entities[0].Command = $"{commandName}={parameter.ToString(Formats.DotNet.Iso8601DateTime)}";
            String expectedCommandMessage = $"Application will shutdown at: {parameter.ToString(Formats.DotNet.DateTimeSeconds)} for system maintenance";

            BusinessProcess.GetLoggedOnUsers(Arg.Any<AppId>()).Returns(entities);

            ILoggedOnUserViewModel viewModel = CreateViewModel(DateTimeService);
            LoggedOnUserViewModel loggedOnUserViewModel = (LoggedOnUserViewModel)viewModel;
            loggedOnUserViewModel.RefreshCommand.Execute(null);

            Assert.That(loggedOnUserViewModel.ExternalCommandMessage, Is.EqualTo(expectedCommandMessage));
            Assert.That(loggedOnUserViewModel.ExternalCommandName, Is.EqualTo(commandName));
            Assert.That(loggedOnUserViewModel.ExternalCommandTime, Is.EqualTo(parameter));
        }

        [TestCase]
        public void Test_RefreshWithMessage()
        {
            List<ILoggedOnUser> entities = new List<ILoggedOnUser>
            {
                CreateModel(),
            };

            String commandName = CommandNames.Message;
            DateTime parameter = DateTimeService.SystemDateTimeNowWithoutMilliseconds.AddDays(1);
            entities[0].Command = $"{commandName}={parameter.ToString(Formats.DotNet.Iso8601DateTime)}";

            BusinessProcess.GetLoggedOnUsers(Arg.Any<AppId>()).Returns(entities);

            ILoggedOnUserViewModel viewModel = CreateViewModel(DateTimeService);
            LoggedOnUserViewModel loggedOnUserViewModel = (LoggedOnUserViewModel)viewModel;
            loggedOnUserViewModel.RefreshCommand.Execute(null);

            Assert.That(loggedOnUserViewModel.ExternalCommandMessage, Is.EqualTo(parameter.ToString(Formats.DotNet.Iso8601DateTime)));
            Assert.That(loggedOnUserViewModel.ExternalCommandName, Is.EqualTo(commandName));
            Assert.That(loggedOnUserViewModel.ExternalCommandTime, Is.EqualTo(DateTime.MinValue));
        }

        [TestCase]
        public void Test_Properties()
        {
            ILoggedOnUserViewModel viewModel = CreateViewModel(DateTimeService);
            LoggedOnUserViewModel loggedOnUserViewModel = (LoggedOnUserViewModel)viewModel;

            String expectedExternalCommandMessage = Guid.NewGuid().ToString();
            String expectedExternalCommandName = Guid.NewGuid().ToString();
            DateTime expectedExternalCommandTime = new DateTime(2024, 04, 24, 20, 41, 45, 123);

            loggedOnUserViewModel.ExternalCommandMessage = expectedExternalCommandMessage;
            loggedOnUserViewModel.ExternalCommandName = expectedExternalCommandName;
            loggedOnUserViewModel.ExternalCommandTime = expectedExternalCommandTime;

            Assert.That(loggedOnUserViewModel.ExternalCommandMessage, Is.EqualTo(expectedExternalCommandMessage));
            Assert.That(loggedOnUserViewModel.ExternalCommandName, Is.EqualTo(expectedExternalCommandName));
            Assert.That(loggedOnUserViewModel.ExternalCommandTime, Is.EqualTo(expectedExternalCommandTime));
        }

        [TestCase]
        public void Test_SendQuitCommand()
        {
            ILoggedOnUserViewModel viewModel = CreateViewModel(DateTimeService);
            LoggedOnUserViewModel loggedOnUserViewModel = (LoggedOnUserViewModel)viewModel;
            ILoggedOnUser loggedOnUser = new LoggedOnUser();

            Assert.That(loggedOnUserViewModel.SendQuitCommandCommand.CanExecute(loggedOnUser));
            loggedOnUserViewModel.SendQuitCommandCommand.Execute(loggedOnUser);

            BusinessProcess.Received(1).SendQuitCommand(Arg.Any<AppId>(), Arg.Any<ILoggedOnUser>());
        }

        [TestCase]
        public void Test_SendQuitCommand_Null()
        {
            ILoggedOnUserViewModel viewModel = CreateViewModel(DateTimeService);
            LoggedOnUserViewModel loggedOnUserViewModel = (LoggedOnUserViewModel)viewModel;
            ILoggedOnUser? loggedOnUser = null;

            Assert.That(loggedOnUserViewModel.SendQuitCommandCommand.CanExecute(loggedOnUser));
            loggedOnUserViewModel.SendQuitCommandCommand.Execute(loggedOnUser);

            BusinessProcess.Received(0).SendQuitCommand(Arg.Any<AppId>(), Arg.Any<ILoggedOnUser>());
        }

        [TestCase]
        public void Test_SendAbortCommand()
        {
            ILoggedOnUserViewModel viewModel = CreateViewModel(DateTimeService);
            LoggedOnUserViewModel loggedOnUserViewModel = (LoggedOnUserViewModel)viewModel;
            ILoggedOnUser loggedOnUser = new LoggedOnUser();

            Assert.That(loggedOnUserViewModel.SendAbortCommandCommand.CanExecute(loggedOnUser));
            loggedOnUserViewModel.SendAbortCommandCommand.Execute(loggedOnUser);

            BusinessProcess.Received(1).SendAbortCommand(Arg.Any<AppId>(), Arg.Any<ILoggedOnUser>());
        }

        [TestCase]
        public void Test_SendAbortCommand_Null()
        {
            ILoggedOnUserViewModel viewModel = CreateViewModel(DateTimeService);
            LoggedOnUserViewModel loggedOnUserViewModel = (LoggedOnUserViewModel)viewModel;
            ILoggedOnUser? loggedOnUser = null;

            Assert.That(loggedOnUserViewModel.SendAbortCommandCommand.CanExecute(loggedOnUser));
            loggedOnUserViewModel.SendAbortCommandCommand.Execute(loggedOnUser);

            BusinessProcess.Received(0).SendAbortCommand(Arg.Any<AppId>(), Arg.Any<ILoggedOnUser>());
        }

        [TestCase]
        public void Test_SendMessageCommand()
        {
            ILoggedOnUserViewModel viewModel = CreateViewModel(DateTimeService);
            LoggedOnUserViewModel loggedOnUserViewModel = (LoggedOnUserViewModel)viewModel;
            ILoggedOnUser loggedOnUser = new LoggedOnUser();

            Assert.That(loggedOnUserViewModel.SendMessageCommandCommand.CanExecute(loggedOnUser));
            loggedOnUserViewModel.SendMessageCommandCommand.Execute(loggedOnUser);

            BusinessProcess.Received(1).SendMessageCommand(Arg.Any<AppId>(), Arg.Any<ILoggedOnUser>(), Arg.Any<String>());
        }

        [TestCase]
        public void Test_SendMessageCommand_Null()
        {
            ILoggedOnUserViewModel viewModel = CreateViewModel(DateTimeService);
            LoggedOnUserViewModel loggedOnUserViewModel = (LoggedOnUserViewModel)viewModel;
            ILoggedOnUser? loggedOnUser = null;

            Assert.That(loggedOnUserViewModel.SendMessageCommandCommand.CanExecute(loggedOnUser));
            loggedOnUserViewModel.SendMessageCommandCommand.Execute(loggedOnUser);

            BusinessProcess.Received(0).SendMessageCommand(Arg.Any<AppId>(), Arg.Any<ILoggedOnUser>(), Arg.Any<String>());
        }
    }
}
