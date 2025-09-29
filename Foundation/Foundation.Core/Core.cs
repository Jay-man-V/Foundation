//-----------------------------------------------------------------------
// <copyright file="Core.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.IO;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

using Foundation.Interfaces;

namespace Foundation.Core
{
    [DependencyInjectionSingleton]
    public class Core : ICore
    {
        //https://learn.microsoft.com/en-us/dotnet/core/extensions/configuration-providers

        private static ConfigurationManager TheConfigurationManager { get; } = new ConfigurationManager();
        private static IConfigurationWrapper ConfigurationWrapper { get; } = new ConfigurationWrapper(TheConfigurationManager);
        private static IHost? TheHost { get; set; }
        private static HostApplicationBuilder? HostApplicationBuilder { get; set; }
        private static IIoC? TheIoC { get; set; }
        private static String TheApplicationName { get; set; } = "<not set>";
        private static AppId TheApplicationId { get; set; }
        private static TraceLevel TheTraceLevel { get; set; }

        private static ICurrentUser? TheCurrentLoggedOnUser { get; set; }
        private static String UserFullLogonName { get; set; } = "<not set>";

        internal static ICore? CoreInstance { get; set; }

        public static ICore TheInstance
        {
            get
            {
                if (CoreInstance is null)
                {
                    String message = "Foundation.Core has not been initialised";
                    throw new InvalidOperationException(message);
                }

                return CoreInstance;
            }
            set => CoreInstance = value;
        }

        /// <summary>
        /// Initialises the Core service by:
        /// <para>
        ///  * Loading the assemblies in to the Dependency Injection framework
        /// </para>
        /// <para>
        ///  * Initialise application settings
        /// </para>
        /// <para>
        ///  * Initialise logged on user
        /// </para>
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="applicationProcess">The application process.</param>
        /// <param name="userProfileProcess">The user profile process.</param>
        /// <param name="loggedOnUserProcess">The logged on user process.</param>
        /// <param name="typeNamespacePrefix"></param>
        /// <param name="searchPattern"></param>
        public static ICore Initialise
        (
            AppId? applicationId = null,
            IRunTimeEnvironmentSettings? runTimeEnvironmentSettings = null,
            IApplicationProcess? applicationProcess = null,
            IUserProfileProcess? userProfileProcess = null,
            ILoggedOnUserProcess? loggedOnUserProcess = null,
            String typeNamespacePrefix = "",
            String searchPattern = ""
        )
        {
            // https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host?tabs=appbuilder
            // https://stackoverflow.com/questions/46940710/getting-value-from-appsettings-json-in-net-core - Options pattern

            if (CoreInstance == null)
            {
                HostApplicationBuilderSettings settings = new HostApplicationBuilderSettings
                {
                    Configuration = TheConfigurationManager,
                    ContentRootPath = Directory.GetCurrentDirectory(),
                };

                settings.Configuration.AddJsonFile("appSettings.json");

                HostApplicationBuilder = Host.CreateApplicationBuilder(settings);

                TheIoC = new IoC(HostApplicationBuilder.Services);
                IoC ioc = (IoC)TheIoC;
                TheIoC.Initialise();

                if (!(String.IsNullOrEmpty(typeNamespacePrefix) ||
                      String.IsNullOrEmpty(searchPattern)))
                {
                    TheIoC.Initialise(typeNamespacePrefix, searchPattern);
                }

                TheHost = HostApplicationBuilder.Build();

                ioc.ServiceProvider = TheHost.Services;

                TheTraceLevel = new TraceSwitch("TraceLevelSwitch", "Default Trace Level").Level;

                if (applicationId == null)
                {
                    Int32 tempApplicationId = TheConfigurationManager.GetValue<Int32>("Foundation.Settings:ApplicationId");
                    applicationId = new AppId(tempApplicationId);
                }

                TheApplicationId = applicationId.Value;

                TheInstance = new Core();

                runTimeEnvironmentSettings ??= TheInstance.IoC.Get<IRunTimeEnvironmentSettings>();
                applicationProcess ??= TheInstance.IoC.Get<IApplicationProcess>();
                userProfileProcess ??= TheInstance.IoC.Get<IUserProfileProcess>();
                loggedOnUserProcess ??= TheInstance.IoC.Get<ILoggedOnUserProcess>();

                UserFullLogonName = runTimeEnvironmentSettings.UserFullLogonName;

                InitialiseApplicationSettings(applicationProcess);
                InitialiseLoggedOnUser(userProfileProcess, loggedOnUserProcess);
            }

            return TheInstance;
        }

        /// <summary>
        /// Create instances of all classes implementing the IApplicationStartup interface
        /// </summary>
        public static void ExecuteApplicationStartups()
        {
            List<IApplicationStartup> applicationStartups = TheInstance.IoC.GetAll<IApplicationStartup>().ToList();
            foreach (IApplicationStartup applicationStartup in applicationStartups)
            {
                applicationStartup.ApplicationStarting();
            }
        }

        private static void InitialiseLoggedOnUser(IUserProfileProcess userProfileProcess, ILoggedOnUserProcess loggedOnUserProcess)
        {
            IUserProfile userProfile = userProfileProcess.GetLoggedOnUserProfile(TheApplicationId);

            if (userProfile == null)
            {
                throw new UserLogonException(TheApplicationId, UserFullLogonName);
            }

            TheCurrentLoggedOnUser = new CurrentUser(userProfile);

            loggedOnUserProcess.LogOnUser(TheApplicationId, TheCurrentLoggedOnUser.UserProfile);
        }

        private static void InitialiseApplicationSettings(IApplicationProcess applicationProcess)
        {
            IApplication? application = applicationProcess.Get(TheApplicationId);

            if (application == null)
            {
                String message = $"An application with Id '{TheApplicationId}' cannot be loaded";
                throw new ArgumentException(message);
            }

            TheApplicationName = application.Name;
        }

        /// <inheritdoc cref="ICore.ApplicationName"/>
        public String ApplicationName => TheApplicationName;

        /// <inheritdoc cref="ICore.ApplicationId"/>
        public AppId ApplicationId => TheApplicationId;

        /// <inheritdoc cref="ICore.TraceLevel"/>
        public TraceLevel TraceLevel => TheTraceLevel;

        /// <inheritdoc cref="ICore.IoC"/>
        public IIoC IoC => TheIoC!;

        /// <inheritdoc cref="ICore.ConfigurationManager"/>
        public IConfigurationWrapper ConfigurationManager => ConfigurationWrapper;

        /// <inheritdoc cref="ICore.Instance"/>
        public ICore Instance => TheInstance;

        /// <inheritdoc cref="ICore.CurrentLoggedOnUser"/>
        public ICurrentUser CurrentLoggedOnUser => TheCurrentLoggedOnUser!; // Ignoring compiler warnings for Null Reference, set routines already check/raise for null
    }
}
