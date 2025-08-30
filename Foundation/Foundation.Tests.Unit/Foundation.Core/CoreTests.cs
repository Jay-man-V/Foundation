//-----------------------------------------------------------------------
// <copyright file="CoreTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.Support;

using NSubstitute;

using System.Diagnostics;

using FModels = Foundation.Models;

namespace Foundation.Tests.Unit.Foundation.Core
{
    /// <summary>
    /// The Current Logged On User Tests
    /// </summary>
    public class CoreTests // Do not inherit from UnitTestBase
    {
        private AppId ApplicationId { get; } = new (123);
        private String ApplicationName => "Unit Testing";
        private String ApplicationDescription => "Unit Testing Suite";
        private TraceLevel TraceLevel => TraceLevel.Off;

        private IRunTimeEnvironmentSettings? RunTimeEnvironmentSettings { get; set; }

        private ILoggedOnUserProcess? LoggedOnUserProcess { get; set; }

        private IApplication? Application { get; set; }
        private IUserProfile? UserProfile { get; set; }

        [SetUp]
        public void Setup()
        {
            typeof(global::Foundation.Core.Core).TypeInitializer!.Invoke(null, new object[0]);

            UserProfile = new FModels.UserProfile
            {
                Id = new EntityId(1),
                DisplayName = UserSecuritySupport.UnitTestAccountDisplayName,
                IsSystemSupport = true,
                Username = $@"{UserSecuritySupport.UnitTestAccountDomain}\{UserSecuritySupport.UnitTestAccountUserName}",
            };

            Application = new FModels.Application
            {
                Id = ApplicationId,
                Name = ApplicationName,
                Description = ApplicationDescription,
            };

            RunTimeEnvironmentSettings = Substitute.For<IRunTimeEnvironmentSettings>();
            RunTimeEnvironmentSettings.UserFullLogonName.Returns(UserProfile.Username);

            LoggedOnUserProcess = Substitute.For<ILoggedOnUserProcess>();
        }

        [TearDown]
        public void Teardown()
        {
            typeof(global::Foundation.Core.Core).TypeInitializer!.Invoke(null, []);
        }

        [TestCase]
        public void Test_Properties()
        {
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            applicationProcess.Get(ApplicationId).Returns(Application);

            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();
            userProfileProcess.GetLoggedOnUserProfile(Arg.Any<AppId>()).Returns(UserProfile);

            ICore theModel = global::Foundation.Core.Core.Initialise(ApplicationId, RunTimeEnvironmentSettings, applicationProcess, userProfileProcess, LoggedOnUserProcess);

            Assert.That(theModel.ApplicationId, Is.EqualTo(ApplicationId));
            Assert.That(theModel.ApplicationName, Is.EqualTo(ApplicationName));
            Assert.That(theModel.Instance, Is.EqualTo(theModel));
            Assert.That(theModel.CurrentLoggedOnUser.UserProfile, Is.EqualTo(UserProfile));
            Assert.That(theModel.TraceLevel, Is.EqualTo(TraceLevel));
        }

        [TestCase]
        public void Test_CurrentLoggedOnUser_UserLogonException()
        {
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            applicationProcess.Get(ApplicationId).Returns(Application);

            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();
            userProfileProcess.GetLoggedOnUserProfile(Arg.Any<AppId>()).Returns(UserProfile);

            ICore theModel = global::Foundation.Core.Core.Initialise(ApplicationId, RunTimeEnvironmentSettings, applicationProcess, userProfileProcess, LoggedOnUserProcess);

            Assert.That(theModel.ApplicationId, Is.EqualTo(ApplicationId));
            Assert.That(theModel.ApplicationName, Is.EqualTo(ApplicationName));
            Assert.That(theModel.Instance, Is.EqualTo(theModel));
            Assert.That(theModel.CurrentLoggedOnUser.UserProfile, Is.EqualTo(UserProfile));
            Assert.That(theModel.TraceLevel, Is.EqualTo(TraceLevel));
        }

        [TestCase]
        public void Test_UserLogonException()
        {
            String processName = "Application/System Logon";

            UserLogonException? actualException = null;
            String userLogonExceptionErrorMessage = "Cannot locate user credentials";

            UserCredentialsException? userCredentialsException = null;
            String userCredentialsExceptionErrorMessage = "Cannot locate user credentials";
            String userCredentialsExceptionUserCredentials = @".\UnitTestUserName";

            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            applicationProcess.Get(ApplicationId).Returns(Application);

            const IUserProfile? userProfile = null;
            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();
            userProfileProcess.GetLoggedOnUserProfile(Arg.Any<AppId>()).Returns(userProfile);
            //userProfileProcess.GetLoggedOnUserProfile(Arg.Any<AppId>()).Returns(UserProfile);

            try
            {
                global::Foundation.Core.Core.Initialise(ApplicationId, RunTimeEnvironmentSettings, applicationProcess, userProfileProcess, LoggedOnUserProcess);
            }
            catch (UserLogonException exception)
            {
                actualException = exception;
                userCredentialsException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.ApplicationId, Is.EqualTo(ApplicationId));
            Assert.That(actualException.ProcessName, Is.EqualTo(processName));
            Assert.That(actualException.Message, Is.EqualTo(userLogonExceptionErrorMessage));

            Assert.That(userCredentialsException, Is.Not.EqualTo(null));
            Assert.That(userCredentialsException.ApplicationId, Is.EqualTo(ApplicationId));
            Assert.That(userCredentialsException.ProcessName, Is.EqualTo(processName));
            Assert.That(userCredentialsException.Message, Is.EqualTo(userCredentialsExceptionErrorMessage));
            Assert.That(userCredentialsException.UserCredentials, Is.EqualTo(userCredentialsExceptionUserCredentials));
        }
    }
}