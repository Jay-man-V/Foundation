//-----------------------------------------------------------------------
// <copyright file="BusinessProcessUnitTestBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Sec;
using Foundation.Common;
using Foundation.Core;
using Foundation.Interfaces;
using Foundation.Models.App;
using Foundation.Models.Sec;
using Foundation.Resources;
using Foundation.Tests.Unit.Support;

using NSubstitute;

using FModels = Foundation.Models;

namespace Foundation.Tests.Unit.BaseClasses
{
    /// <summary>
    /// The Business Process Unit Test Base class
    /// </summary>
    [TestFixture]
    public abstract class BusinessProcessUnitTestBase : UnitTestBase
    {
        protected DateTime CreatedOnDateTime => new DateTime(2000, 01, 01, 00, 00, 00, DateTimeKind.Utc);
        protected DateTime LastUpdatedOnDateTime => new DateTime(2001, 12, 31, 11, 55, 22, DateTimeKind.Utc);
        protected DateTime ValidFromDateTime => new DateTime(2000, 01, 01, 00, 00, 00, DateTimeKind.Utc);

        protected ICore CoreInstance { get; set; }
        protected IApplicationConfigurationService ApplicationConfigurationService { get; set; }
        protected IStatusRepository? StatusRepository { get; set; }
        protected IUserProfileRepository? UserProfileRepository { get; set; }
        protected IStatusProcess StatusProcess { get; set; }
        protected IUserProfileProcess UserProfileProcess { get; set; }
        protected ILoggedOnUserProcess LoggedOnUserProcess { get; set; }

        protected List<IStatus> StatusesList { get; set; }
        protected List<IUserProfile> UserProfileList { get; set; }
        protected List<ILoggedOnUser> LoggedOnUsersList { get; set; }

        protected List<IStatus> GetListOfStatuses()
        {
            List<IStatus> retVal = [];

            FModels.Core.EnumModels.Status obj1 = new FModels.Core.EnumModels.Status
            {
                Id = new EntityId(-1),
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedByUserProfileId = new EntityId(1),
                LastUpdatedByUserProfileId = new EntityId(1),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,
                Name = "Inactive",
                Description = "Inactive Description"
            };
            retVal.Add(obj1);

            FModels.Core.EnumModels.Status obj2 = new FModels.Core.EnumModels.Status
            {
                Id = new EntityId(0),
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedByUserProfileId = new EntityId(1),
                LastUpdatedByUserProfileId = new EntityId(1),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,
                Name = "Active",
                Description = "Active Description"
            };
            retVal.Add(obj2);

            FModels.Core.EnumModels.Status obj3 = new FModels.Core.EnumModels.Status
            {
                Id = new EntityId(2),
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedByUserProfileId = new EntityId(1),
                LastUpdatedByUserProfileId = new EntityId(1),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,
                Name = "Approved",
                Description = "Approved Description"
            };
            retVal.Add(obj3);

            FModels.Core.EnumModels.Status obj4 = new FModels.Core.EnumModels.Status
            {
                Id = new EntityId(3),
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedByUserProfileId = new EntityId(1),
                LastUpdatedByUserProfileId = new EntityId(1),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,
                Name = "PendingApproval",
                Description = "Pending Approval"
            };
            retVal.Add(obj4);

            FModels.Core.EnumModels.Status obj5 = new FModels.Core.EnumModels.Status
            {
                Id = new EntityId(4),
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedByUserProfileId = new EntityId(1),
                LastUpdatedByUserProfileId = new EntityId(1),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,
                Name = "InComplete",
                Description = "In Complete"
            };
            retVal.Add(obj5);

            return retVal;
        }

        protected List<ILoggedOnUser> GetListOfLoggedOnUsers()
        {
            List<ILoggedOnUser> retVal = [];

            LoggedOnUser loggedOnUser = new LoggedOnUser();
            retVal.Add(loggedOnUser);

            return retVal;
        }

        protected List<IUserProfile> GetListOfUserProfiles()
        {
            List<IUserProfile> retVal = [];

            UserProfile obj1 = new UserProfile
            {
                Id = new EntityId(1),
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedByUserProfileId = new EntityId(1),
                LastUpdatedByUserProfileId = new EntityId(1),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,
                Username = "System",
                DisplayName = "System Display Name"
            };
            retVal.Add(obj1);

            UserProfile obj2 = new UserProfile
            {
                Id = new EntityId(2),
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedByUserProfileId = new EntityId(1),
                LastUpdatedByUserProfileId = new EntityId(1),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,
                Username = "EUROPA\\jayes",
                DisplayName = "Jayesh Varsani"
            };
            retVal.Add(obj2);

            UserProfile obj3 = new UserProfile
            {
                Id = new EntityId(3),
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedByUserProfileId = new EntityId(1),
                LastUpdatedByUserProfileId = new EntityId(1),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,
                Username = "EUROPA\\DhanjiV",
                DisplayName = "Dhanji K Varsani"
            };
            retVal.Add(obj3);

            UserProfile obj4 = new UserProfile
            {
                Id = new EntityId(4),
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedByUserProfileId = new EntityId(1),
                LastUpdatedByUserProfileId = new EntityId(1),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,
                Username = "EUROPA\\Priti",
                DisplayName = "Priti Fatania"
            };
            retVal.Add(obj4);

            UserProfile obj5 = new UserProfile
            {
                Id = new EntityId(7),
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedByUserProfileId = new EntityId(1),
                LastUpdatedByUserProfileId = new EntityId(1),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,
                Username = "EUROPA\\UnitTestUserName",
                DisplayName = "UnitTestUserName DisplayName"
            };
            retVal.Add(obj5);

            return retVal;
        }

        /// <summary>
        /// Initialises the test.
        /// </summary>
        public override void TestInitialise()
        {
            base.TestInitialise();

            IUserProfile userProfile = new UserProfile
            {
                Id = new EntityId(1),
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,

                DisplayName = UserSecuritySupport.UnitTestAccountDisplayName,
                IsSystemSupport = true,
                Username = $@"{UserSecuritySupport.UnitTestAccountDomain}\{UserSecuritySupport.UnitTestAccountUserName}",
            };

            ResetLoggedOnUserProfile(userProfile);

            IApplication application = new Application
            {
                Id = TestingApplicationId,
                StatusId = new EntityId(EntityStatus.Active.Id()),
                CreatedOn = CreatedOnDateTime,
                LastUpdatedOn = LastUpdatedOnDateTime,
                ValidFrom = ValidFromDateTime,
                ValidTo = ApplicationDefaultValues.DefaultValidToDateTime,

                CreatedByUserProfileId = userProfile.Id,
                LastUpdatedByUserProfileId = userProfile.Id,
                Name = "Unit Testing",
                Description = "Unit Testing suite",
            };

            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            applicationProcess.Get(TestingApplicationId).Returns(application);

            UserProfileRepository = Substitute.For<IUserProfileRepository>();
            UserProfileRepository.GetAllActive().Returns(UserProfileList);

            UserProfileProcess = Substitute.For<IUserProfileProcess>();
            UserProfileProcess.GetLoggedOnUserProfile(Arg.Any<AppId>()).Returns(userProfile);
            UserProfileProcess.GetAll(Arg.Any<Boolean>()).Returns(UserProfileList);

            LoggedOnUserProcess = Substitute.For<ILoggedOnUserProcess>();

            CoreInstance = Core.Core.Initialise(null, RunTimeEnvironmentSettings, applicationProcess, UserProfileProcess, LoggedOnUserProcess);
            //CoreInstance = Substitute.For<ICore>();
            //CoreInstance.ApplicationName.Returns(TestingApplicationName);
            //CoreInstance.ApplicationId.Returns(TestingApplicationId);
            //CoreInstance.CurrentLoggedOnUser.Returns(loggedOnUser);

            _ = new LoggingHelpers(CoreInstance, RunTimeEnvironmentSettings, DateTimeService);

            ApplicationConfigurationService = Substitute.For<IApplicationConfigurationService>();
            ApplicationConfigurationService.Get<String>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostUsername).Returns(EmailSmtpHostUsername);
            ApplicationConfigurationService.Get<String>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostPassword).Returns(EmailSmtpHostPassword);
            ApplicationConfigurationService.Get<Int32>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostPort).Returns(EmailSmtpHostPort);
            ApplicationConfigurationService.Get<String>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostAddress).Returns(EmailSmtpHostAddress);
            ApplicationConfigurationService.Get<Boolean>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostEnableSsl).Returns(EmailSmtpHostEnableSsl);

            ApplicationConfigurationService.Get<String>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailFromAddress).Returns(EmailFromAddress);
            ApplicationConfigurationService.Get<String>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailFromDisplayName).Returns(EmailFromDisplayName);

            StatusesList = GetListOfStatuses();
            UserProfileList = GetListOfUserProfiles();
            LoggedOnUsersList = GetListOfLoggedOnUsers();
            LoggedOnUserProcess.GetLoggedOnUsers(Arg.Any<AppId>()).Returns(LoggedOnUsersList);

            StatusRepository = Substitute.For<IStatusRepository>();
            StatusRepository.GetAllActive().Returns(StatusesList);

            StatusProcess = Substitute.For<IStatusProcess>();
            StatusProcess.GetAll(Arg.Any<Boolean>()).Returns(StatusesList);
        }

        /// <summary>
        /// Cleans up after the test has finished running.
        /// </summary>
        public override void TestCleanup()
        {
            StatusRepository?.Dispose();

            UserProfileRepository?.Dispose();

            StatusRepository = null;
            UserProfileRepository = null;

            base.TestCleanup();
        }

        protected IUserProfile ResetLoggedOnUserProfile(IUserProfile userProfile)
        {
            userProfile.Roles.Clear();

            userProfile.IsSystemSupport = true;

            Role systemAdministratorRole = new Role
            {
                Id = new EntityId(ApplicationRole.SystemAdministrator.Id())
            };
            userProfile.Roles.Add(systemAdministratorRole);

            Role creatorRole = new Role
            {
                Id = new EntityId(ApplicationRole.Creator.Id())
            };
            userProfile.Roles.Add(creatorRole);

            return userProfile;
        }

        protected void RemoveRoleFromLoggedOnUser(ApplicationRole applicationRoleToRemove)
        {
            IRole? roleToRemove = CoreInstance.CurrentLoggedOnUser.UserProfile.Roles.FirstOrDefault(r => r.ApplicationRole == applicationRoleToRemove);

            if (roleToRemove != null)
            {
                CoreInstance.CurrentLoggedOnUser.UserProfile.Roles.Remove(roleToRemove);
            }

            if (applicationRoleToRemove == ApplicationRole.SystemSupervisor)
            {
                CoreInstance.CurrentLoggedOnUser.UserProfile.IsSystemSupport = false;
            }
        }
    }
}
