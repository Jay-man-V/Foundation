//-----------------------------------------------------------------------
// <copyright file="Core.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics.CodeAnalysis;
using Foundation.Interfaces;

namespace Foundation.Core
{
    [DependencyInjectionSingleton]
    public class Core : ICore
    {
        private static readonly IIoC _container = new IoC();
        private static AppId _applicationId;
        private static Boolean _initialised;
        private static ICore? _theInstance;
        private static ICurrentLoggedOnUser? _currentLoggedOnUser;

        public static void Reset()
        {
            _theInstance = null;
        }

        /// <summary>
        /// Initialises the Core service by:
        /// <para>
        ///  * Loading the assemblies in to the Dependency Injection framework
        /// </para>
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="userProfileProcess">The user profile process.</param>
        [return: NotNull]
        public static ICore Initialise(AppId applicationId, IRunTimeEnvironmentSettings? runTimeEnvironmentSettings = null, IUserProfileProcess? userProfileProcess = null)
        {
            // https://learn.microsoft.com/en-us/dotnet/core/extensions/generic-host?tabs=appbuilder

            if (_theInstance == null)
            {
                _applicationId = applicationId;

                _theInstance = new Core();
                _theInstance.Container.Reset();
                _theInstance.Container.Initialise();

                runTimeEnvironmentSettings ??= _theInstance.Container.Get<IRunTimeEnvironmentSettings>();
                userProfileProcess ??= _theInstance.Container.Get<IUserProfileProcess>();

                // TODO: Complete when the Business Processes are set up/migrated
                //IUserProfile userProfile = userProfileProcess.GetLoggedOnUserProfile(applicationId);

                //if (userProfile == null)
                //{
                //    throw new UserLogonException(runTimeEnvironmentSettings.UserLogonName);
                //}

                //_currentLoggedOnUser = new CurrentLoggedOnUser(userProfile);

                // Create instances of all classes implementing the IApplicationStartup interface
                List<IApplicationStartup> applicationStartups = _theInstance.Container.GetAll<IApplicationStartup>().ToList();
                applicationStartups.ForEach(obj => obj.ApplicationStarting());

                _initialised = true;
            }

            return _theInstance;
        }

        /// <inheritdoc cref="ICore.ApplicationId"/>
        public AppId ApplicationId => _applicationId;

        /// <inheritdoc cref="ICore.Initialised"/>
        public Boolean Initialised => _initialised;

        /// <inheritdoc cref="ICore.Container"/>
        public IIoC Container => _container;

        /// <inheritdoc cref="ICore.TheInstance"/>
        public ICore? TheInstance => _theInstance;

        /// <inheritdoc cref="ICore.CurrentLoggedOnUser"/>
        public ICurrentLoggedOnUser? CurrentLoggedOnUser => _currentLoggedOnUser;
    }
}
