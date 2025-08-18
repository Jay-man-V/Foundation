//-----------------------------------------------------------------------
// <copyright file="UnitTestBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;
using Foundation.Services.Application;

using NSubstitute;

using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

using FModels = Foundation.Models;

namespace Foundation.Tests.Unit.Support
{
    /// <summary>
    /// The Unit Test Base class
    /// </summary>
    [TestFixture]
    public abstract class UnitTestBase
    {
        protected static Object SyncLock = new Object();

        protected String DatabaseServer = "Callisto";
        protected String BaseTemporaryOutputsPath => @"D:\Projects\JDVSoftware\TempOutputs\";

        protected DateTime CreatedOnDateTime => new DateTime(2000, 01, 01, 00, 00, 00, DateTimeKind.Utc);
        protected DateTime LastUpdatedOnDateTime => new DateTime(2001, 12, 31, 11, 55, 22, DateTimeKind.Utc);
        protected DateTime ValidFromDateTime => new DateTime(2000, 01, 01, 00, 00, 00, DateTimeKind.Utc);
        protected DateTime ValidToDateTime => new DateTime(2199, 12, 31, 23, 59, 59, DateTimeKind.Utc);
        protected DateTime SystemDateTime => new DateTime(2022, 11, 28, 13, 11, 54, DateTimeKind.Utc);
        protected DateTime SystemDateTimeMs => new DateTime(2022, 11, 28, 13, 11, 54, 300, DateTimeKind.Utc);

        protected String EmailSmtpHostUsername => "email.smtp.host.username";
        protected String EmailSmtpHostPassword => "email.smtp.host.password";
        protected Int32 EmailSmtpHostPort => 123;
        protected String EmailSmtpHostAddress => "email.smtp.host.address";
        protected Boolean EmailSmtpHostEnableSsl => true;
        protected String EmailFromAddress => "no.reply.test@datalore.me.uk";
        protected String EmailFromDisplayName => "Automated Unit Test Program";

        protected String EmailToAddress => "Unit.Testing@datalore.me.uk";
        protected String EmailSubject => $"Test Email Subject - {DateTime.Now.ToString(Formats.DotNet.DateTimeSeconds)}";
        protected String EmailBody => $"Test Email Body - {DateTime.Now.ToString(Formats.DotNet.DateTimeSeconds)}";

        protected String StandardCountryCode = "GB";
        protected String MachineName = "MachineName";

        protected ICore CoreInstance { get; set; }
        protected IRunTimeEnvironmentSettings RunTimeEnvironmentSettings { get; set; }
        protected IDateTimeService DateTimeService { get; set; }
        protected IApplicationConfigurationService ApplicationConfigurationService { get; set; }
        protected IStatusRepository? StatusRepository { get; set; }
        protected IUserProfileRepository? UserProfileRepository { get; set; }
        protected IStatusProcess StatusProcess { get; set; }
        protected IUserProfileProcess UserProfileProcess { get; set; }
        protected ILoggedOnUserProcess LoggedOnUserProcess { get; set; }

        protected List<IStatus> StatusesList { get; set; }
        protected List<IUserProfile> UserProfileList { get; set; }
        protected List<ILoggedOnUser> LoggedOnUsersList { get; set; }

        protected static class ErrorMessages
        {
            public static readonly String ArgumentNullExpectedErrorMessage = $"Value cannot be null.{Environment.NewLine}Parameter name: {{0}}";
        }
        protected List<IStatus> GetListOfStatuses()
        {
            List<IStatus> retVal = new List<IStatus>();

            FModels.Status obj1 = (FModels.Status)CoreInstance.IoC.Get<IStatus>();
            obj1.Id = new EntityId(-1);
            obj1.StatusId = new EntityId(0);
            obj1.CreatedByUserProfileId = new EntityId(1);
            obj1.LastUpdatedByUserProfileId = new EntityId(1);
            obj1.CreatedOn = CreatedOnDateTime;
            obj1.LastUpdatedOn = LastUpdatedOnDateTime;
            obj1.ValidFrom = ValidFromDateTime;
            obj1.ValidTo = ValidToDateTime;
            obj1.Name = "Inactive";
            obj1.Description = "Inactive Description";
            retVal.Add(obj1);

            FModels.Status obj2 = (FModels.Status)CoreInstance.IoC.Get<IStatus>();
            obj2.Id = new EntityId(0);
            obj2.StatusId = new EntityId(0);
            obj2.CreatedByUserProfileId = new EntityId(1);
            obj2.LastUpdatedByUserProfileId = new EntityId(1);
            obj2.CreatedOn = CreatedOnDateTime;
            obj2.LastUpdatedOn = LastUpdatedOnDateTime;
            obj2.ValidFrom = ValidFromDateTime;
            obj2.ValidTo = ValidToDateTime;
            obj2.Name = "Active";
            obj2.Description = "Active Description";
            retVal.Add(obj2);

            FModels.Status obj3 = (FModels.Status)CoreInstance.IoC.Get<IStatus>();
            obj3.Id = new EntityId(2);
            obj3.StatusId = new EntityId(0);
            obj3.CreatedByUserProfileId = new EntityId(1);
            obj3.LastUpdatedByUserProfileId = new EntityId(1);
            obj3.CreatedOn = CreatedOnDateTime;
            obj3.LastUpdatedOn = LastUpdatedOnDateTime;
            obj3.ValidFrom = ValidFromDateTime;
            obj3.ValidTo = ValidToDateTime;
            obj3.Name = "Approved";
            obj3.Description = "Approved Description";
            retVal.Add(obj3);

            FModels.Status obj4 = (FModels.Status)CoreInstance.IoC.Get<IStatus>();
            obj4.Id = new EntityId(3);
            obj4.StatusId = new EntityId(0);
            obj4.CreatedByUserProfileId = new EntityId(1);
            obj4.LastUpdatedByUserProfileId = new EntityId(1);
            obj4.CreatedOn = CreatedOnDateTime;
            obj4.LastUpdatedOn = LastUpdatedOnDateTime;
            obj4.ValidFrom = ValidFromDateTime;
            obj4.ValidTo = ValidToDateTime;
            obj4.Name = "PendingApproval";
            obj4.Description = "Pending Approval";
            retVal.Add(obj4);

            FModels.Status obj5 = (FModels.Status)CoreInstance.IoC.Get<IStatus>();
            obj5.Id = new EntityId(4);
            obj5.StatusId = new EntityId(0);
            obj5.CreatedByUserProfileId = new EntityId(1);
            obj5.LastUpdatedByUserProfileId = new EntityId(1);
            obj5.CreatedOn = CreatedOnDateTime;
            obj5.LastUpdatedOn = LastUpdatedOnDateTime;
            obj5.ValidFrom = ValidFromDateTime;
            obj5.ValidTo = ValidToDateTime;
            obj5.Name = "InComplete";
            obj5.Description = "In Complete";
            retVal.Add(obj5);

            return retVal;
        }

        protected List<ILoggedOnUser> GetListOfLoggedOnUsers()
        {
            List<ILoggedOnUser> retVal = new List<ILoggedOnUser>();

            FModels.LoggedOnUser obj1 = (FModels.LoggedOnUser)CoreInstance.IoC.Get<ILoggedOnUser>();
            retVal.Add(obj1);

            return retVal;
        }

        protected List<IUserProfile> GetListOfUserProfiles()
        {
            List<IUserProfile> retVal = new List<IUserProfile>();

            FModels.UserProfile obj1 = (FModels.UserProfile)CoreInstance.IoC.Get<IUserProfile>();
            obj1.Id = new EntityId(1);
            obj1.StatusId = new EntityId(0);
            obj1.CreatedByUserProfileId = new EntityId(1);
            obj1.LastUpdatedByUserProfileId = new EntityId(1);
            obj1.CreatedOn = CreatedOnDateTime;
            obj1.LastUpdatedOn = LastUpdatedOnDateTime;
            obj1.ValidFrom = ValidFromDateTime;
            obj1.ValidTo = ValidToDateTime;
            obj1.Username = "System";
            obj1.DisplayName = "System Display Name";
            retVal.Add(obj1);

            FModels.UserProfile obj2 = (FModels.UserProfile)CoreInstance.IoC.Get<IUserProfile>();
            obj2.Id = new EntityId(2);
            obj2.StatusId = new EntityId(0);
            obj2.CreatedByUserProfileId = new EntityId(1);
            obj2.LastUpdatedByUserProfileId = new EntityId(1);
            obj2.CreatedOn = CreatedOnDateTime;
            obj2.LastUpdatedOn = LastUpdatedOnDateTime;
            obj2.ValidFrom = ValidFromDateTime;
            obj2.ValidTo = ValidToDateTime;
            obj2.Username = "EUROPA\\jayes";
            obj2.DisplayName = "Jayesh Varsani";
            retVal.Add(obj2);

            FModels.UserProfile obj3 = (FModels.UserProfile)CoreInstance.IoC.Get<IUserProfile>();
            obj3.Id = new EntityId(3);
            obj3.StatusId = new EntityId(0);
            obj3.CreatedByUserProfileId = new EntityId(1);
            obj3.LastUpdatedByUserProfileId = new EntityId(1);
            obj3.CreatedOn = CreatedOnDateTime;
            obj3.LastUpdatedOn = LastUpdatedOnDateTime;
            obj3.ValidFrom = ValidFromDateTime;
            obj3.ValidTo = ValidToDateTime;
            obj3.Username = "EUROPA\\DhanjiV";
            obj3.DisplayName = "Dhanji K Varsani";
            retVal.Add(obj3);

            FModels.UserProfile obj4 = (FModels.UserProfile)CoreInstance.IoC.Get<IUserProfile>();
            obj4.Id = new EntityId(4);
            obj4.StatusId = new EntityId(0);
            obj4.CreatedByUserProfileId = new EntityId(1);
            obj4.LastUpdatedByUserProfileId = new EntityId(1);
            obj4.CreatedOn = CreatedOnDateTime;
            obj4.LastUpdatedOn = LastUpdatedOnDateTime;
            obj4.ValidFrom = ValidFromDateTime;
            obj4.ValidTo = ValidToDateTime;
            obj4.Username = "EUROPA\\Priti";
            obj4.DisplayName = "Priti Fatania";
            retVal.Add(obj4);

            FModels.UserProfile obj5 = (FModels.UserProfile)CoreInstance.IoC.Get<IUserProfile>();
            obj5.Id = new EntityId(7);
            obj5.StatusId = new EntityId(0);
            obj5.CreatedByUserProfileId = new EntityId(1);
            obj5.LastUpdatedByUserProfileId = new EntityId(1);
            obj5.CreatedOn = CreatedOnDateTime;
            obj5.LastUpdatedOn = LastUpdatedOnDateTime;
            obj5.ValidFrom = ValidFromDateTime;
            obj5.ValidTo = ValidToDateTime;
            obj5.Username = "EUROPA\\UnitTestUserName";
            obj5.DisplayName = "UnitTestUserName DisplayName";
            retVal.Add(obj5);

            return retVal;
        }

        /// <summary>
        /// Initialises the test.
        /// </summary>
        [SetUp]
        public virtual void TestInitialise()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-GB");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-GB");

            UserSecuritySupport.CreateTestingUserAccounts();

            DirectoryInfo baseDirectoryDi = new DirectoryInfo(BaseTemporaryOutputsPath);
            if (!baseDirectoryDi.Exists) { baseDirectoryDi.Create(); }

            UserSecuritySupport.CreateTestingUserAccounts();

            // These two lines slow down the testing
            //WindowsIdentity windowsIdentity = WindowsIdentity.GetCurrent();
            //UserPrincipal userPrincipal = UserPrincipal.Current;

            //SecurityProcess.Initialise();

            RunTimeEnvironmentSettings = Substitute.For<IRunTimeEnvironmentSettings>();
            RunTimeEnvironmentSettings.StandardCountryCode.Returns(StandardCountryCode);
            RunTimeEnvironmentSettings.UserDomainName.Returns(UserSecuritySupport.UnitTestAccountDomain);
            RunTimeEnvironmentSettings.UserName.Returns(UserSecuritySupport.UnitTestAccountUserName);
            RunTimeEnvironmentSettings.MachineName.Returns(MachineName);

            DateTimeService = Substitute.For<IDateTimeService>();
            DateTimeService.SystemDateTimeNowWithoutMilliseconds.Returns(SystemDateTime);
            DateTimeService.SystemDateTimeNow.Returns(SystemDateTimeMs);

            _ = new LoggingHelpers(RunTimeEnvironmentSettings, DateTimeService);

            IUserProfile userProfile = new FModels.UserProfile
            {
                Id = new EntityId(1),
                DisplayName = UserSecuritySupport.UnitTestAccountDisplayName,
                IsSystemSupport = true,
                Username = $@"{UserSecuritySupport.UnitTestAccountDomain}\{UserSecuritySupport.UnitTestAccountUserName}",
            };

            IUserProfileProcess userProfileProcess = Substitute.For<IUserProfileProcess>();
            userProfileProcess.GetLoggedOnUserProfile(Arg.Any<AppId>()).Returns(userProfile);

            ILoggedOnUserProcess loggedOnUserProcess = Substitute.For<ILoggedOnUserProcess>();
            loggedOnUserProcess.LogOnUser(Arg.Any<AppId>(), Arg.Any<IUserProfile>());

            CoreInstance = Core.Core.Initialise(ApplicationSettings.ApplicationId, RunTimeEnvironmentSettings, userProfileProcess, loggedOnUserProcess);
            CoreInstance.CurrentLoggedOnUser.SetLoggedOnUser(userProfile);

            ApplicationConfigurationService = Substitute.For<IApplicationConfigurationService>();
            ApplicationConfigurationService.Get<String>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostUsername).Returns(EmailSmtpHostUsername);
            ApplicationConfigurationService.Get<String>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostPassword).Returns(EmailSmtpHostPassword);
            ApplicationConfigurationService.Get<Int32>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostPort).Returns(EmailSmtpHostPort);
            ApplicationConfigurationService.Get<String>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostAddress).Returns(EmailSmtpHostAddress);
            ApplicationConfigurationService.Get<Boolean>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailSmtpHostEnableSsl).Returns(EmailSmtpHostEnableSsl);

            ApplicationConfigurationService.Get<String>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailFromAddress).Returns(EmailFromAddress);
            ApplicationConfigurationService.Get<String>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ApplicationConfigurationKeys.EmailFromDisplayName).Returns(EmailFromDisplayName);

            FModels.Role systemAdministratorRole = new FModels.Role
            {
                Id = new EntityId(ApplicationRole.SystemAdministrator.Id())
            };
            CoreInstance.CurrentLoggedOnUser.UserProfile.Roles.Add(systemAdministratorRole);

            FModels.Role creatorRole = new FModels.Role
            {
                Id = new EntityId(ApplicationRole.Creator.Id())
            };
            CoreInstance.CurrentLoggedOnUser.UserProfile.Roles.Add(creatorRole);

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
        [TearDown]
        public virtual void TestCleanup()
        {
            //UserSecuritySupport.RemoveUnitTestUserOnLocalComputer(UserSecuritySupport.UnitTestAccountUserName);

            if (StatusRepository != null)
            {
                StatusRepository.Dispose();
            }

            if (UserProfileRepository != null)
            {
                UserProfileRepository.Dispose();
            }

            StatusRepository = null;
            UserProfileRepository = null;
        }

        protected void RemoveRoleFromLoggedOnUser(ApplicationRole applicationRoleToRemove)
        {
            IRole? roleToRemove = CoreInstance.CurrentLoggedOnUser.UserProfile.Roles.FirstOrDefault(r => r.ApplicationRole == applicationRoleToRemove);

            if (roleToRemove != null)
            {
                CoreInstance.CurrentLoggedOnUser.UserProfile.Roles.Remove(roleToRemove);
            }
        }

        protected String ByteArrayToStringRepresentationForCode(Byte[] input)
        {
            String retVal = "{" + String.Join(", ", input) + "}";

            return retVal;
        }

        /// <summary>
        /// Replaces the date time with constant.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Original String value with Date/Time values replaced</returns>
        protected String ReplaceDateTimeWithConstant(String inputString)
        {
            String retVal = inputString;
            String pattern1 = @"\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)-\d{4} \d\d:\d\d:\d\d.\d\d\d";
            String pattern2 = @"\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)-\d{4} \d\d:\d\d:\d\d";
            String pattern3 = @"([\d]{8}T[\d]{6})|([\d]{4}-[\d]{2}-[\d]{2} [\d]{2}_[\d]{2}_[\d]{2})";

            Regex regex = new Regex(pattern1);
            Match match = regex.Match(retVal);
            if (match.Success)
            {
                retVal = regex.Replace(retVal, "<<dd-MMM-yyyy HH:mm:ss.fff>>");
            }

            regex = new Regex(pattern2);
            match = regex.Match(retVal);
            if (match.Success)
            {
                retVal = regex.Replace(retVal, "<<dd-MMM-yyyy HH:mm:ss>>");
            }

            regex = new Regex(pattern3);
            match = regex.Match(retVal);
            if (match.Success)
            {
                retVal = regex.Replace(retVal, "<<Date/Time>>");
            }

            return retVal;
        }

        /// <summary>
        /// Replaces the file path with constant.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Original String value with output file path values replaced</returns>
        protected String ReplaceFilePathWithConstant(String inputString)
        {
            String retVal = inputString;

            String[] patterns =
            {
                @"file:\/\/\/(.*\\)",
                @"([a-zA-Z]:[\\/]{1}.+[\\\/])",
                @"\w.\\\w.{1,}\\(Out|Debug)",
                @"\w.\\\w.{1,}\\Foundation\\",
                @"\w.\\\w.{1,}\\Foundation.Net - 4.8\\",
                @"\w.\\\w.{1,}\\Foundation.Net\\",
                @"\w.\\\w.{1,}\\netcoreapp\d\.\d",
                "<<Output Folder>>(Debug|Out)",
            };

            foreach (String pattern in patterns)
            {
                Regex regex = new Regex(pattern);
                Match match = regex.Match(retVal);
                if (match.Success)
                {
                    retVal = regex.Replace(retVal, "<<Output Folder>>");
                }
            }

            return retVal;
        }

        /// <summary>
        /// Replaces the line number with a constant.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Original String value with output file path values replaced</returns>
        protected String ReplaceLineNumberWithConstant(String inputString)
        {
            String retVal = inputString;
            String[] patterns = { @":line \d+" };

            foreach (String pattern in patterns)
            {
                Regex regex = new Regex(pattern);
                Match match = regex.Match(retVal);
                if (match.Success)
                {
                    retVal = regex.Replace(retVal, ":line <<line number>>");
                }
            }

            return retVal;
        }

        /// <summary>
        /// Replaces the userName with constant.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Original String value with output file path values replaced</returns>
        protected String ReplaceUserNameWithConstant(String inputString)
        {
            String retVal = inputString;
            String[] patterns1 =
            {
                @"User logon: \w+\\\w+",
                @"User logon: \.\\\w+",
            };

            String[] patterns2 =
            {
                @"User: \w+\\\w+",
                @"User: \.\\\w+",
            };

            String[] patterns3 =
            {
                @"User: '\w+\\\w+'",
            };

            for (Int32 counter = 0; counter < patterns1.Length; counter++)
            {
                Regex regex = new Regex(patterns1[counter]);
                Match match = regex.Match(retVal);
                if (match.Success)
                {
                    retVal = regex.Replace(retVal, @"User logon: <<domain\user>>");
                }
            }

            for (Int32 counter = 0; counter < patterns2.Length; counter++)
            {
                Regex regex = new Regex(patterns2[counter]);
                Match match = regex.Match(retVal);
                if (match.Success)
                {
                    retVal = regex.Replace(retVal, @"User: <<domain\user>>");
                }
            }

            for (Int32 counter = 0; counter < patterns3.Length; counter++)
            {
                Regex regex = new Regex(patterns3[counter]);
                Match match = regex.Match(retVal);
                if (match.Success)
                {
                    retVal = regex.Replace(retVal, @"User: '<<domain\user>>'");
                }
            }

            return retVal;
        }

        /// <summary>
        /// Replaces the Entry Assembly with constant.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Original String value with output file path values replaced</returns>
        protected String ReplaceEntryAssemblyWithConstant(String inputString)
        {
            String retVal = inputString;
            String pattern1 = @"Entry assembly: [\w.]*";

            Regex regex = new Regex(pattern1);
            Match match = regex.Match(retVal);
            if (match.Success)
            {
                retVal = regex.Replace(retVal, "Entry assembly: <<EntryAssembly>>");
            }

            return retVal;
        }

        /// <summary>
        /// Replaces the Public Key Token with constant.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Original String value with output file path values replaced</returns>
        protected String ReplacePublicKeyTokenWithConstant(String inputString)
        {
            String retVal = inputString;
            String pattern1 = @"PublicKeyToken=\w*";

            Regex regex = new Regex(pattern1);
            Match match = regex.Match(retVal);
            if (match.Success)
            {
                retVal = regex.Replace(retVal, "PublicKeyToken=<<PublicKeyToken>>");
            }

            return retVal;
        }

        /// <summary>
        /// Replaces the Assembly Version with constant.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Original String value with output file path values replaced</returns>
        protected String ReplaceAssemblyVersionWithConstant(String inputString)
        {
            String retVal = inputString;
            String pattern1 = @"Version=\d{1,}\.\d{1,}\.\d{1,}\.\d{1,}";

            Regex regex = new Regex(pattern1);
            Match match = regex.Match(retVal);
            if (match.Success)
            {
                retVal = regex.Replace(retVal, "Version=<<Version>>");
            }

            return retVal;
        }

        /// <summary>
        /// Replaces the Assembly Target Framework with constant.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Original String value with output file path values replaced</returns>
        protected String ReplaceAssemblyTargetFrameworkWithConstant(String inputString)
        {
            String retVal = inputString;
            String pattern1 = @"Assembly target framework: \W.{1,}";

            Regex regex = new Regex(pattern1);
            Match match = regex.Match(retVal);
            if (match.Success)
            {
                retVal = regex.Replace(retVal, "Assembly target framework: <<Target Framework>>");
            }

            return retVal;
        }

        /// <summary>
        /// Replaces the Assembly Target Framework with constant.
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Original String value with output file path values replaced</returns>
        protected String ReplaceServerNameWithConstant(String inputString)
        {
            String retVal = inputString;
            String pattern1 = @"Server name: \w+";

            Regex regex = new Regex(pattern1);
            Match match = regex.Match(retVal);
            if (match.Success)
            {
                retVal = regex.Replace(retVal, "Server name: <<Server name>>");
            }

            return retVal;
        }

        /// <summary>
        /// Replaces a Guid string with known constants.
        /// e.g. 0c80873c-8894-42bf-a225-88b5d9aace9f with
        /// </summary>
        /// <param name="inputString">The input string.</param>
        /// <returns>Original String value with output file path values replaced</returns>
        protected String ReplaceGuidWithConstant(String inputString)
        {
            String retVal = inputString;
            String pattern1 = @"[\w]*-[\w]*-[\w]*-[\w]*-[\w]*";

            Regex regex = new Regex(pattern1);
            Match match = regex.Match(retVal);
            if (match.Success)
            {
                retVal = regex.Replace(retVal, "anananan-anan-anan-anan-anananananan");
            }

            return retVal;
        }

        protected String FixUpStringWithReplacements(String inputString)
        {
            String retVal = inputString;
            retVal = ReplaceDateTimeWithConstant(retVal);
            retVal = ReplaceFilePathWithConstant(retVal);
            retVal = ReplaceLineNumberWithConstant(retVal);
            retVal = ReplaceUserNameWithConstant(retVal);
            retVal = ReplaceEntryAssemblyWithConstant(retVal);
            retVal = ReplacePublicKeyTokenWithConstant(retVal);
            retVal = ReplaceAssemblyVersionWithConstant(retVal);
            retVal = ReplaceAssemblyTargetFrameworkWithConstant(retVal);
            retVal = ReplaceServerNameWithConstant(retVal);
            retVal = ReplaceGuidWithConstant(retVal);

            return retVal;
        }

        protected FieldInfo[] GetFieldInfosForType(Type theType)
        {
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static;
            FieldInfo[] retVal = theType.GetFields(bindingFlags);

            return retVal;
        }

        protected MethodInfo[] GetMethodInfosForType(Type theType)
        {
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Static;
            MethodInfo[] retVal = theType.GetMethods(bindingFlags);

            return retVal;
        }

        protected PropertyInfo[] GetInstancePropertyInfosForType(Type theType)
        {
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] retVal = theType.GetProperties(bindingFlags);

            return retVal;
        }

        protected PropertyInfo[] GetInstanceOnlyPropertyInfosForType(Type theType)
        {
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            PropertyInfo[] retVal = theType.GetProperties(bindingFlags);

            return retVal;
        }

        protected PropertyInfo[] GetStaticPropertyInfosForType(Type theType)
        {
            BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static;
            PropertyInfo[] retVal = theType.GetProperties(bindingFlags);

            return retVal;
        }

        /// <summary>
        /// Find all the Types in Foundation.Common assembly.
        /// Use the <paramref name="lambda"/> parameter to filter the Types loaded
        /// </summary>
        protected List<Type> GetListOfValidTypes(Func<Type, Boolean> lambda)
        {
            Assembly foundationCommonAssembly = typeof(FoundationProperty).Assembly;
            Assembly foundationInterfacesAssembly = typeof(IFoundationModel).Assembly;
            List<Type> retVal = new List<Type>();
            Assembly[] sourceAssemblies = { foundationCommonAssembly, foundationInterfacesAssembly };

            foreach (Assembly sourceAssembly in sourceAssemblies)
            {
                Type[] allTypes = sourceAssembly.GetTypes();

                retVal.AddRange(allTypes.Where(lambda).OrderBy(t2 => t2.Name).ToList());
            }

            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected IEnumerable<MethodInfo> GetListOfTestMethods()
        {
            Type thisType = this.GetType();
            IEnumerable<MethodInfo> testMethods = thisType.GetMethods().Where(m => m.Name.StartsWith("Test_"));
            return testMethods;
        }
    }
}
