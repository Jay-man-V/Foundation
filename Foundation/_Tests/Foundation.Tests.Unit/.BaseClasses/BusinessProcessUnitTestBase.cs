//-----------------------------------------------------------------------
// <copyright file="BusinessProcessUnitTestBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;
using Foundation.Tests.Unit.Support;

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

            FModels.Core.EnumModels.Status obj1 = (FModels.Core.EnumModels.Status)CoreInstance.IoC.Get<IStatus>();
            obj1.Id = new EntityId(-1);
            obj1.StatusId = new EntityId(EntityStatus.Active.Id());
            obj1.CreatedByUserProfileId = new EntityId(1);
            obj1.LastUpdatedByUserProfileId = new EntityId(1);
            obj1.CreatedOn = CreatedOnDateTime;
            obj1.LastUpdatedOn = LastUpdatedOnDateTime;
            obj1.ValidFrom = ValidFromDateTime;
            obj1.ValidTo = ApplicationDefaultValues.DefaultValidToDateTime;
            obj1.Name = "Inactive";
            obj1.Description = "Inactive Description";
            retVal.Add(obj1);

            FModels.Core.EnumModels.Status obj2 = (FModels.Core.EnumModels.Status)CoreInstance.IoC.Get<IStatus>();
            obj2.Id = new EntityId(0);
            obj2.StatusId = new EntityId(EntityStatus.Active.Id());
            obj2.CreatedByUserProfileId = new EntityId(1);
            obj2.LastUpdatedByUserProfileId = new EntityId(1);
            obj2.CreatedOn = CreatedOnDateTime;
            obj2.LastUpdatedOn = LastUpdatedOnDateTime;
            obj2.ValidFrom = ValidFromDateTime;
            obj2.ValidTo = ApplicationDefaultValues.DefaultValidToDateTime;
            obj2.Name = "Active";
            obj2.Description = "Active Description";
            retVal.Add(obj2);

            FModels.Core.EnumModels.Status obj3 = (FModels.Core.EnumModels.Status)CoreInstance.IoC.Get<IStatus>();
            obj3.Id = new EntityId(2);
            obj3.StatusId = new EntityId(EntityStatus.Active.Id());
            obj3.CreatedByUserProfileId = new EntityId(1);
            obj3.LastUpdatedByUserProfileId = new EntityId(1);
            obj3.CreatedOn = CreatedOnDateTime;
            obj3.LastUpdatedOn = LastUpdatedOnDateTime;
            obj3.ValidFrom = ValidFromDateTime;
            obj3.ValidTo = ApplicationDefaultValues.DefaultValidToDateTime;
            obj3.Name = "Approved";
            obj3.Description = "Approved Description";
            retVal.Add(obj3);

            FModels.Core.EnumModels.Status obj4 = (FModels.Core.EnumModels.Status)CoreInstance.IoC.Get<IStatus>();
            obj4.Id = new EntityId(3);
            obj4.StatusId = new EntityId(EntityStatus.Active.Id());
            obj4.CreatedByUserProfileId = new EntityId(1);
            obj4.LastUpdatedByUserProfileId = new EntityId(1);
            obj4.CreatedOn = CreatedOnDateTime;
            obj4.LastUpdatedOn = LastUpdatedOnDateTime;
            obj4.ValidFrom = ValidFromDateTime;
            obj4.ValidTo = ApplicationDefaultValues.DefaultValidToDateTime;
            obj4.Name = "PendingApproval";
            obj4.Description = "Pending Approval";
            retVal.Add(obj4);

            FModels.Core.EnumModels.Status obj5 = (FModels.Core.EnumModels.Status)CoreInstance.IoC.Get<IStatus>();
            obj5.Id = new EntityId(4);
            obj5.StatusId = new EntityId(EntityStatus.Active.Id());
            obj5.CreatedByUserProfileId = new EntityId(1);
            obj5.LastUpdatedByUserProfileId = new EntityId(1);
            obj5.CreatedOn = CreatedOnDateTime;
            obj5.LastUpdatedOn = LastUpdatedOnDateTime;
            obj5.ValidFrom = ValidFromDateTime;
            obj5.ValidTo = ApplicationDefaultValues.DefaultValidToDateTime;
            obj5.Name = "InComplete";
            obj5.Description = "In Complete";
            retVal.Add(obj5);

            return retVal;
        }

        protected List<ILoggedOnUser> GetListOfLoggedOnUsers()
        {
            List<ILoggedOnUser> retVal = [];

            FModels.Sec.LoggedOnUser obj1 = (FModels.Sec.LoggedOnUser)CoreInstance.IoC.Get<ILoggedOnUser>();
            retVal.Add(obj1);

            return retVal;
        }

        protected List<IUserProfile> GetListOfUserProfiles()
        {
            List<IUserProfile> retVal = [];

            FModels.Sec.UserProfile obj1 = (FModels.Sec.UserProfile)CoreInstance.IoC.Get<IUserProfile>();
            obj1.Id = new EntityId(1);
            obj1.StatusId = new EntityId(EntityStatus.Active.Id());
            obj1.CreatedByUserProfileId = new EntityId(1);
            obj1.LastUpdatedByUserProfileId = new EntityId(1);
            obj1.CreatedOn = CreatedOnDateTime;
            obj1.LastUpdatedOn = LastUpdatedOnDateTime;
            obj1.ValidFrom = ValidFromDateTime;
            obj1.ValidTo = ApplicationDefaultValues.DefaultValidToDateTime;
            obj1.Username = "System";
            obj1.DisplayName = "System Display Name";
            retVal.Add(obj1);

            FModels.Sec.UserProfile obj2 = (FModels.Sec.UserProfile)CoreInstance.IoC.Get<IUserProfile>();
            obj2.Id = new EntityId(2);
            obj2.StatusId = new EntityId(EntityStatus.Active.Id());
            obj2.CreatedByUserProfileId = new EntityId(1);
            obj2.LastUpdatedByUserProfileId = new EntityId(1);
            obj2.CreatedOn = CreatedOnDateTime;
            obj2.LastUpdatedOn = LastUpdatedOnDateTime;
            obj2.ValidFrom = ValidFromDateTime;
            obj2.ValidTo = ApplicationDefaultValues.DefaultValidToDateTime;
            obj2.Username = "EUROPA\\jayes";
            obj2.DisplayName = "Jayesh Varsani";
            retVal.Add(obj2);

            FModels.Sec.UserProfile obj3 = (FModels.Sec.UserProfile)CoreInstance.IoC.Get<IUserProfile>();
            obj3.Id = new EntityId(3);
            obj3.StatusId = new EntityId(EntityStatus.Active.Id());
            obj3.CreatedByUserProfileId = new EntityId(1);
            obj3.LastUpdatedByUserProfileId = new EntityId(1);
            obj3.CreatedOn = CreatedOnDateTime;
            obj3.LastUpdatedOn = LastUpdatedOnDateTime;
            obj3.ValidFrom = ValidFromDateTime;
            obj3.ValidTo = ApplicationDefaultValues.DefaultValidToDateTime;
            obj3.Username = "EUROPA\\DhanjiV";
            obj3.DisplayName = "Dhanji K Varsani";
            retVal.Add(obj3);

            FModels.Sec.UserProfile obj4 = (FModels.Sec.UserProfile)CoreInstance.IoC.Get<IUserProfile>();
            obj4.Id = new EntityId(4);
            obj4.StatusId = new EntityId(EntityStatus.Active.Id());
            obj4.CreatedByUserProfileId = new EntityId(1);
            obj4.LastUpdatedByUserProfileId = new EntityId(1);
            obj4.CreatedOn = CreatedOnDateTime;
            obj4.LastUpdatedOn = LastUpdatedOnDateTime;
            obj4.ValidFrom = ValidFromDateTime;
            obj4.ValidTo = ApplicationDefaultValues.DefaultValidToDateTime;
            obj4.Username = "EUROPA\\Priti";
            obj4.DisplayName = "Priti Fatania";
            retVal.Add(obj4);

            FModels.Sec.UserProfile obj5 = (FModels.Sec.UserProfile)CoreInstance.IoC.Get<IUserProfile>();
            obj5.Id = new EntityId(7);
            obj5.StatusId = new EntityId(EntityStatus.Active.Id());
            obj5.CreatedByUserProfileId = new EntityId(1);
            obj5.LastUpdatedByUserProfileId = new EntityId(1);
            obj5.CreatedOn = CreatedOnDateTime;
            obj5.LastUpdatedOn = LastUpdatedOnDateTime;
            obj5.ValidFrom = ValidFromDateTime;
            obj5.ValidTo = ApplicationDefaultValues.DefaultValidToDateTime;
            obj5.Username = "EUROPA\\UnitTestUserName";
            obj5.DisplayName = "UnitTestUserName DisplayName";
            retVal.Add(obj5);

            return retVal;
        }

        /// <summary>
        /// Initialises the test.
        /// </summary>
        public override void TestInitialise()
        {
            base.TestInitialise();

            IUserProfile userProfile = new FModels.Sec.UserProfile
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

            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();
            userProfileProcess.GetLoggedOnUserProfile(Arg.Any<AppId>()).Returns(userProfile);

            IApplication application = new FModels.Sec.Application
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

            ILoggedOnUserProcess loggedOnUserProcess = Substitute.For<ILoggedOnUserProcess>();

            CoreInstance = Core.Core.Initialise(null, RunTimeEnvironmentSettings, applicationProcess, userProfileProcess, loggedOnUserProcess);

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

            StatusRepository = Substitute.For<IStatusRepository>();
            StatusRepository.GetAllActive().Returns(StatusesList);

            StatusProcess = Substitute.For<IStatusProcess>();
            StatusProcess.GetAll(Arg.Any<Boolean>()).Returns(StatusesList);

            UserProfileRepository = Substitute.For<IUserProfileRepository>();
            UserProfileRepository.GetAllActive().Returns(UserProfileList);

            UserProfileProcess = Substitute.For<IUserProfileProcess>();
            UserProfileProcess.GetAll(Arg.Any<Boolean>()).Returns(UserProfileList);

            LoggedOnUserProcess = Substitute.For<ILoggedOnUserProcess>();
            LoggedOnUserProcess.GetLoggedOnUsers(Arg.Any<AppId>()).Returns(LoggedOnUsersList);
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

            FModels.Sec.Role systemAdministratorRole = new FModels.Sec.Role
            {
                Id = new EntityId(ApplicationRole.SystemAdministrator.Id())
            };
            userProfile.Roles.Add(systemAdministratorRole);

            FModels.Sec.Role creatorRole = new FModels.Sec.Role
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
