//-----------------------------------------------------------------------
// <copyright file="CoreTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

using NSubstitute;

using Foundation.Interfaces;

using Foundation.Tests.Unit.Support;

using FModels = Foundation.Models;

namespace Foundation.Tests.Unit.Foundation.Core
{
    /// <summary>
    /// The Core Tests
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
            global::Foundation.Core.Core._coreInstance = null;

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
        public void Test_TheInstance_Null()
        {
            InvalidOperationException? actualException = null;
            String expectedErrorMessage = "Foundation.Core has not been initialised";

            try
            {
                _ = global::Foundation.Core.Core.TheInstance;
            }
            catch (InvalidOperationException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(expectedErrorMessage));
        }

        [TestCase]
        public void Test_Properties_1()
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
        public void Test_Properties_2()
        {
            AppId expectedAppId = new AppId(1);
            String expectedApplicationName = String.Empty;

            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            applicationProcess.Get(ApplicationId).Returns(Application);

            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();
            userProfileProcess.GetLoggedOnUserProfile(Arg.Any<AppId>()).Returns(UserProfile);

            ICore theModel = global::Foundation.Core.Core.Initialise(null, RunTimeEnvironmentSettings, applicationProcess, userProfileProcess, LoggedOnUserProcess);

            Assert.That(theModel.ApplicationId, Is.EqualTo(expectedAppId));
            Assert.That(theModel.ApplicationName, Is.EqualTo(expectedApplicationName));
            Assert.That(theModel.Instance, Is.EqualTo(theModel));
            Assert.That(theModel.CurrentLoggedOnUser.UserProfile, Is.EqualTo(UserProfile));
            Assert.That(theModel.TraceLevel, Is.EqualTo(TraceLevel));
        }

        [TestCase]
        public void Test_ApplicationStartups()
        {
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            applicationProcess.Get(ApplicationId).Returns(Application);

            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();
            userProfileProcess.GetLoggedOnUserProfile(Arg.Any<AppId>()).Returns(UserProfile);

            ICore theModel = global::Foundation.Core.Core.Initialise(ApplicationId, RunTimeEnvironmentSettings, applicationProcess, userProfileProcess, LoggedOnUserProcess);
            global::Foundation.Core.Core.ExecuteApplicationStartups();
        }

        [TestCase]
        public void Test_InitialiseApplication_Exception()
        {
            const IApplication? application = null;
            IApplicationProcess applicationProcess = Substitute.For<IApplicationProcess>();
            applicationProcess.Get(ApplicationId).Returns(application);

            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();
            userProfileProcess.GetLoggedOnUserProfile(Arg.Any<AppId>()).Returns(UserProfile);

            String errorMessage = $"An application with Id '{ApplicationId}' cannot be loaded";
            ArgumentException? actualException = null;

            try
            {
                global::Foundation.Core.Core.Initialise(ApplicationId, RunTimeEnvironmentSettings, applicationProcess, userProfileProcess, LoggedOnUserProcess);
            }
            catch (ArgumentException exception)
            {
                actualException = exception;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_InitialiseLoggedOnUser_UserLogonException()
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