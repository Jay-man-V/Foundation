//-----------------------------------------------------------------------
// <copyright file="Core.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Core
{
    [DependencyInjectionSingleton]
    public class Core : ICore
    {
        private static IIoC TheIoC { get; } = new IoC();
        private static AppId TheApplicationId { get; set; }
        private static ICurrentLoggedOnUser? TheCurrentLoggedOnUser { get; set; }

        /// <inheritdoc cref="ICore.Instance"/>
        public static ICore? TheInstance { get; set; }

        /// <summary>
        /// Initialises the Core service by:
        /// <para>
        ///  * Loading the assemblies in to the Dependency Injection framework
        /// </para>
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="userProfileProcess">The user profile process.</param>
        public static ICore Initialise(AppId applicationId, IRunTimeEnvironmentSettings? runTimeEnvironmentSettings = null, IUserProfileProcess? userProfileProcess = null)
        {
            // https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host?tabs=appbuilder

            if (TheInstance == null)
            {
                TheApplicationId = applicationId;

                TheInstance = new Core();

                runTimeEnvironmentSettings ??= TheInstance.IoC.Get<IRunTimeEnvironmentSettings>();
                userProfileProcess ??= TheInstance.IoC.Get<IUserProfileProcess>();

                IUserProfile userProfile = userProfileProcess.GetLoggedOnUserProfile(applicationId);

                if (userProfile == null)
                {
                    throw new UserLogonException(runTimeEnvironmentSettings.UserLogonName);
                }

                TheCurrentLoggedOnUser = new CurrentLoggedOnUser(userProfile);

                // Create instances of all classes implementing the IApplicationStartup interface
                List<IApplicationStartup> applicationStartups = TheInstance.IoC.GetAll<IApplicationStartup>().ToList();
                applicationStartups.ForEach(obj => obj.ApplicationStarting());
            }

            return TheInstance;
        }

        /// <inheritdoc cref="ICore.ApplicationId"/>
        public AppId ApplicationId => TheApplicationId;

        /// <inheritdoc cref="ICore.IoC"/>
        public IIoC IoC => TheIoC;

        /// <inheritdoc cref="ICore.Instance"/>
        public ICore? Instance => TheInstance;

        /// <inheritdoc cref="ICore.CurrentLoggedOnUser"/>
        public ICurrentLoggedOnUser? CurrentLoggedOnUser => TheCurrentLoggedOnUser;
    }
}
