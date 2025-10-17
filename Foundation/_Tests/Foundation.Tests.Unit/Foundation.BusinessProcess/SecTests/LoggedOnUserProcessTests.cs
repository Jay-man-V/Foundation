//-----------------------------------------------------------------------
// <copyright file="LoggedOnUserProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.BusinessProcess.Sec;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

using FDC = Foundation.Resources.Constants.DataColumns;
using FModels = Foundation.Models.Sec;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.SecTests
{
    /// <summary>
    /// Summary description for LoggedOnUserProcessTests
    /// </summary>
    [TestFixture]
    public class LoggedOnUserProcessTests : CommonBusinessProcessTests<ILoggedOnUser, ILoggedOnUserProcess, ILoggedOnUserRepository>
    {
        protected override Int32 ColumnDefinitionsCount => 11;
        protected override String ExpectedScreenTitle => "Logged On Users";
        protected override String ExpectedStatusBarText => "Number of Logged On Users:";

        protected override string ExpectedComboBoxDisplayMember => FDC.LoggedOnUser.DisplayName;

        protected override ILoggedOnUserRepository CreateRepository()
        {
            ILoggedOnUserRepository retVal = Substitute.For<ILoggedOnUserRepository>();

            retVal.HasValidityPeriodColumns.Returns(true);

            return retVal;
        }

        protected override ILoggedOnUserProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            IRoleProcess roleProcess = Substitute.For<IRoleProcess>();
            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();

            SetProperties(applicationProcess);
            SetProperties(roleProcess);
            SetProperties(userProfileProcess);

            ILoggedOnUserProcess process = new LoggedOnUserProcess(CoreInstance, RunTimeEnvironmentSettings, dateTimeService, LoggingService, TheRepository!, StatusRepository!, UserProfileRepository!, applicationProcess, roleProcess, userProfileProcess);

            return process;
        }

        protected override ILoggedOnUser CreateBlankEntity(Int32 entityId)
        {
            ILoggedOnUser retVal = new FModels.LoggedOnUser();

            retVal.Id = new EntityId(entityId);

            return retVal;
        }

        protected override ILoggedOnUser CreateEntity(ILoggedOnUserProcess process, Int32 entityId)
        {
            ILoggedOnUser retVal = CreateBlankEntity(entityId);

            retVal.CreatedOn = process.DefaultValidFromDateTime;

            retVal.ValidFrom = process.DefaultValidFromDateTime;
            retVal.ValidTo = process.DefaultValidToDateTime;

            retVal.ApplicationId = new AppId(1);
            retVal.UserProfileId = new EntityId(1);
            retVal.LoggedOn = DateTimeService.SystemUtcDateTimeNow;
            retVal.LastActive = DateTimeService.SystemUtcDateTimeNow;
            retVal.Command = Guid.NewGuid().ToString();
            
            return retVal;
        }

        protected override void CheckBlankEntry(ILoggedOnUser entity)
        {
            Assert.That(entity.ApplicationId, Is.EqualTo(new AppId(0)));
            Assert.That(entity.LoggedOn, Is.EqualTo(DateTime.MinValue));
            Assert.That(entity.LastActive, Is.EqualTo(DateTime.MinValue));
            Assert.That(entity.Command, Is.EqualTo(String.Empty));
        }

        protected override void CheckAllEntry(ILoggedOnUser entity)
        {
            Assert.That(entity.DisplayName, Is.EqualTo(ExpectedAllText));
        }

        protected override void CheckNoneEntry(ILoggedOnUser entity)
        {
            Assert.That(entity.DisplayName, Is.EqualTo(ExpectedNoneText));
        }

        protected override void CompareEntityProperties(ILoggedOnUser entity1, ILoggedOnUser entity2)
        {
            Assert.That(entity2.ValidFrom, Is.EqualTo(entity1.ValidFrom));
            Assert.That(entity2.ValidTo, Is.EqualTo(entity1.ValidTo));

            Assert.That(entity2.ApplicationId, Is.EqualTo(entity1.ApplicationId));
            Assert.That(entity2.LoggedOn, Is.EqualTo(entity1.LoggedOn));
            Assert.That(entity2.LastActive, Is.EqualTo(entity1.LastActive));
            Assert.That(entity2.Command, Is.EqualTo(entity1.Command));
        }

        protected override String GetCsvSampleData()
        {
            String retVal = String.Empty;
            retVal += "Id,Created By,Created On,Updated By,Updated On,Valid From,Valid To,Application Name,Display Name,Logged On Since,Last Active" + Environment.NewLine;
            retVal += "1,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300" + Environment.NewLine;
            retVal += "2,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300" + Environment.NewLine;
            retVal += "3,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300" + Environment.NewLine;
            retVal += "4,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300" + Environment.NewLine;
            retVal += "5,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300" + Environment.NewLine;
            retVal += "6,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300" + Environment.NewLine;
            retVal += "7,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300" + Environment.NewLine;
            retVal += "8,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300" + Environment.NewLine;
            retVal += "9,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300" + Environment.NewLine;
            retVal += "10,0,2022-11-28T13:11:54.300,0,0001-01-01T00:00:00.000,2022-11-28T13:11:54.300,2199-12-31T23:59:59.000,1,1,2022-11-28T13:11:54.300,2022-11-28T13:11:54.300" + Environment.NewLine;

            return retVal;
        }

        protected override void UpdateEntityProperties(ILoggedOnUser entity)
        {
            entity.LastActive = DateTimeService.SystemUtcDateTimeNow;
            entity.Command += " Updated";
        }

        [TestCase]
        public void Test_GetColumnDefinitionsForDisplayControl()
        {
            ResetLoggedOnUserProfile(CoreInstance.CurrentLoggedOnUser.UserProfile);
            List<IGridColumnDefinition> gridColumnDefinitions1 = TheProcess!.GetColumnDefinitionsForDisplayControl();
            Assert.That(gridColumnDefinitions1.Count, Is.EqualTo(7));

            RemoveRoleFromLoggedOnUser(ApplicationRole.SystemSupervisor);
            List<IGridColumnDefinition> gridColumnDefinitions2 = TheProcess!.GetColumnDefinitionsForDisplayControl();
            Assert.That(gridColumnDefinitions2.Count, Is.EqualTo(6));

            ResetLoggedOnUserProfile(CoreInstance.CurrentLoggedOnUser.UserProfile);
        }

        [TestCase]
        public void Test_SendQuitCommand()
        {
            AppId applicationId = new AppId(1);

            ILoggedOnUser loggedOnUser = CreateBlankEntity(1);

            TheProcess!.SendQuitCommand(applicationId, loggedOnUser);
        }

        [TestCase]
        public void Test_SendAbortCommand()
        {
            AppId applicationId = new AppId(1);

            ILoggedOnUser loggedOnUser = CreateBlankEntity(1);

            TheProcess!.SendAbortCommand(applicationId, loggedOnUser);
        }

        [TestCase]
        public void Test_SendMessageCommand()
        {
            AppId applicationId = new AppId(1);
            String message = "Testing message";

            ILoggedOnUser loggedOnUser = CreateBlankEntity(1);

            TheProcess!.SendMessageCommand(applicationId, loggedOnUser, message);
        }

        [TestCase]
        public void Test_ClearCommand()
        {
            AppId applicationId = new AppId(1);

            ILoggedOnUser loggedOnUser = CreateBlankEntity(1);

            TheProcess!.ClearCommand(applicationId, loggedOnUser);
        }

        [TestCase]
        public void Test_LogOnUser()
        {
            AppId applicationId = new AppId(1);

            TheProcess!.LogOnUser(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile);
        }

        [TestCase]
        public void Test_UpdateLoggedOnUser()
        {
            AppId applicationId = new AppId(1);

            TheProcess!.UpdateLoggedOnUser(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile);
        }

        [TestCase]
        public void Test_GetLoggedOnUsers()
        {
            AppId applicationId = new AppId(1);

            List<ILoggedOnUser> expectedLoggedOnUsers =
            [
                Substitute.For<ILoggedOnUser>(),
                Substitute.For<ILoggedOnUser>(),
                Substitute.For<ILoggedOnUser>(),
                Substitute.For<ILoggedOnUser>(),
                Substitute.For<ILoggedOnUser>(),
            ];

            expectedLoggedOnUsers[0].Id = new EntityId(1);
            expectedLoggedOnUsers[1].Id = new EntityId(2);
            expectedLoggedOnUsers[2].Id = new EntityId(3);
            expectedLoggedOnUsers[3].Id = new EntityId(4);
            expectedLoggedOnUsers[4].Id = new EntityId(5);

            TheRepository!.GetLoggedOnUsers(Arg.Any<AppId>()).Returns(expectedLoggedOnUsers);

            List<ILoggedOnUser> actualLoggedOnUsers = TheProcess!.GetLoggedOnUsers(applicationId);

            Assert.That(actualLoggedOnUsers.Count, Is.EqualTo(expectedLoggedOnUsers.Count));
            Assert.That(actualLoggedOnUsers[0].Id, Is.EqualTo(new EntityId(1)));
            Assert.That(actualLoggedOnUsers[1].Id, Is.EqualTo(new EntityId(2)));
            Assert.That(actualLoggedOnUsers[2].Id, Is.EqualTo(new EntityId(3)));
            Assert.That(actualLoggedOnUsers[3].Id, Is.EqualTo(new EntityId(4)));
            Assert.That(actualLoggedOnUsers[4].Id, Is.EqualTo(new EntityId(5)));
        }
    }
}
