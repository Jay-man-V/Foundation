//-----------------------------------------------------------------------
// <copyright file="DependencyInjectionSetup.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using Foundation.Interfaces;

namespace Foundation.Core
{
    /// <summary>
    /// Sets up the Dependency Injection functionality
    /// </summary>
    public static class DependencyInjectionSetup
    {
        private static readonly Object SyncLock = new Object();
        internal static ServiceCollection ServiceCollection { get; private set; }

        /// <summary>
        /// Loads the list of assembly types from file system.
        /// </summary>
        /// <returns></returns>
        private static List<Type> LoadListOfAssemblyTypesFromFileSystem(String searchPattern)
        {
            List<Type> retVal = new List<Type>();

            String localPath = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
            String sourceLocationPath = Path.GetDirectoryName(localPath);

            String[] foundationAssemblyFilePaths = Directory.GetFiles(sourceLocationPath, searchPattern);
            foreach (String assemblyPath in foundationAssemblyFilePaths)
            {
                //Assembly loadedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);
                Assembly loadedAssembly = Assembly.LoadFrom(assemblyPath);

                Type[] allTypes = loadedAssembly.GetTypes();
                List<Type> requiredTypes = allTypes.Where(t => !t.IsAbstract &&                 // Exclude abstract classes
                                                               !t.IsInterface &&                // Exclude interfaces
                                                               t.GetInterfaces().Length >= 1 && // Include classes that implement at least 1 interface
                                                               (
                                                                   t.GetCustomAttributes<DependencyInjectionSingletonAttribute>().Any() ||  // Include Singleton classes
                                                                   t.GetCustomAttributes<DependencyInjectionTransientAttribute>().Any() ||  // Include Transient classes
                                                                   t.GetCustomAttributes<DependencyInjectionScopedAttribute>().Any()        // Include scoped classes
                                                               )
                                                         ).ToList();

                retVal.AddRange(requiredTypes);
            }

            return retVal;
        }

        /// <summary>
        /// List of excluded types, classes that will be removed from consideration of Dependency Injection
        /// </summary>
        public static List<String> ExcludedTypes
        {
            get
            {
                List<String> excludedTypesList = new List<String>
                {
                    //"Foundation.Common",
                    "UnitTests.NetFramework.ExcludedMe"
                };

                return excludedTypesList;
            }
        }

        /// <summary>
        /// List of excluded interfaces, interfaces that will be removed from consideration of Dependency Injection
        /// </summary>
        public static List<String> ExcludedInterfaces
        {
            get
            {
                List<String> excludedInterfaces = new List<String>
                {
                    "ICommonBusinessProcess",
                    "ICommonBusinessProcess`1",
                    "IFoundationDataAccess",
                    "IFoundationModel",
                    "IFoundationModelDataAccess`1",
                    "IFoundationObjectId",
                    "IFoundationModelTracking",
                    //"IGenericDataGridViewModelBase`1",
                    "IViewModel",
                };

                return excludedInterfaces;
            }
        }

        /// <summary>
        /// Resets the dependency injection.
        /// </summary>
        /// <returns></returns>
        public static void ResetDependencyInjection()
        {
            ServiceCollection.Clear();
            ServiceCollection = null;
        }

        /// <summary>
        /// Setups the dependency injection.
        /// </summary>
        /// <returns></returns>
        public static IServiceProvider SetupDependencyInjection(String typeNamespacePrefix, String searchPattern)
        {
            ServiceProvider retVal;

            lock (SyncLock)
            {
                if (ServiceCollection == null)
                {
                    ServiceCollection = new ServiceCollection();
                }

                // Find all the classes we are interested in using with Dependency Injection/IoC
                List<Type> allTypes = LoadListOfAssemblyTypesFromFileSystem(searchPattern);

                // Remove the types in the Excluded Types List
                // and those that are marked for ignoring
                // and those that don't implement an Interface
                List<Type> filteredTypes = allTypes.Where(at => !String.IsNullOrEmpty(at.Namespace) &&
                                                                at.Namespace.StartsWith(typeNamespacePrefix) &&
                                                                at.GetInterfaces().Length > 0 &&
                                                                !ExcludedTypes.Any(el => at.Namespace.StartsWith(el))
                                                         ).ToList();

                const Boolean searchInherited = false;

                // Identify classes marked with special attributes

                // DependencyInjectionSingleton - Singleton classes must be explicitly defined as such
                List<Type> singletonTypes = filteredTypes.Where(ft => ft.GetCustomAttributes<DependencyInjectionSingletonAttribute>(searchInherited).Any()).OrderBy(ft => ft.Name).ToList();

                // DependencyInjectionScoped - Scoped classes must be explicitly defined as such
                List<Type> scopedTypes = filteredTypes.Where(ft => ft.GetCustomAttributes<DependencyInjectionScopedAttribute>(searchInherited).Any()).OrderBy(ft => ft.Name).ToList();

                // All the others - All classes are to be considered Transient
                List<Type> transientTypes = filteredTypes.Where(ft => ft.GetCustomAttributes<DependencyInjectionTransientAttribute>(searchInherited).Any()).OrderBy(ft => ft.Name).ToList();

                foreach (Type implementationType in singletonTypes)
                {
                    String implementationTypeName = implementationType.FullName;
                    List<Type> interfaceTypes = implementationType.GetInterfaces().ToList();
                    foreach (Type interfaceType in interfaceTypes)
                    {
                        String interfaceFullName = interfaceType.FullName;
                        String interfaceName = interfaceType.Name;

                        Boolean excludedInterfaceCheck = !ExcludedInterfaces.Contains(interfaceName);
                        Boolean typeFullNameCheck = interfaceFullName == null ||
                                                    (
                                                        !String.IsNullOrEmpty(interfaceFullName) &&
                                                        interfaceFullName.StartsWith(typeNamespacePrefix)
                                                    );

                        if (excludedInterfaceCheck &&
                            typeFullNameCheck)
                        {
                            //#if(DEBUG)
                            //                            Debug.WriteLine($"Service Type: {typeInterface}. Implementation Type: {implementationType}");
                            //#endif
                            ServiceDescriptor sd = new ServiceDescriptor(interfaceType, implementationType);
                            if (!ServiceCollection.Contains(sd))
                            {
                                ServiceCollection.AddSingleton(implementationType);
                                ServiceCollection.AddSingleton(interfaceType, implementationType);
                            }
                        }
                    }
                }

                foreach (Type implementationType in scopedTypes)
                {
                    List<Type> interfaceTypes = implementationType.GetInterfaces().ToList();
                    foreach (Type interfaceType in interfaceTypes)
                    {
                        String implementationTypeName = implementationType.FullName;
                        String interfaceFullName = interfaceType.FullName;
                        String interfaceName = interfaceType.Name;

                        Boolean excludedInterfaceCheck = !ExcludedInterfaces.Contains(interfaceName);
                        Boolean typeFullNameCheck = interfaceFullName == null ||
                                                    (
                                                        !String.IsNullOrEmpty(interfaceFullName) &&
                                                        interfaceFullName.StartsWith(typeNamespacePrefix)
                                                    );

                        if (excludedInterfaceCheck &&
                            typeFullNameCheck)
                        {
                            //#if(DEBUG)
                            //                            Debug.WriteLine($"Service Type: {typeInterface}. Implementation Type: {implementationType}");
                            //#endif
                            ServiceDescriptor sd = new ServiceDescriptor(interfaceType, implementationType);
                            if (!ServiceCollection.Contains(sd))
                            {
                                ServiceCollection.AddScoped(implementationType);
                                ServiceCollection.AddScoped(interfaceType, implementationType);
                            }
                        }
                    }
                }

                foreach (Type implementationType in transientTypes)
                {
                    String implementationTypeName = implementationType.FullName;

#if(DEBUG)
                    if (implementationTypeName == "Foundation.Tests.Unit.Mocks.MockScheduledTask")
                    {
                        //Debug.WriteLine("Foundation.Tests.Unit.Mocks.MockScheduledTask");
                    }
#endif

                    List<Type> interfaceTypes = implementationType.GetInterfaces().ToList();
                    foreach (Type interfaceType in interfaceTypes)
                    {
                        String interfaceFullName = interfaceType.FullName;
                        String interfaceName = interfaceType.Name;

                        Boolean excludedInterfaceCheck = !ExcludedInterfaces.Contains(interfaceName);
                        Boolean typeFullNameCheck = interfaceFullName != null &&
                                                    (
                                                        !String.IsNullOrEmpty(interfaceFullName) &&
                                                        interfaceFullName.StartsWith(typeNamespacePrefix)
                                                    );

                        if (excludedInterfaceCheck &&
                            typeFullNameCheck)
                        {
                            //#if(DEBUG)
                            //                            Debug.WriteLine($"Service Type: {typeInterface}. Implementation Type: {implementationType}");
                            //#endif
                            ServiceDescriptor sd = new ServiceDescriptor(interfaceType, implementationType);
                            if (!ServiceCollection.Contains(sd))
                            {
                                ServiceCollection.AddTransient(implementationType);
                                ServiceCollection.AddTransient(interfaceType, implementationType);
                            }
                        }
                    }
                }

                /*
                 * Special setups
                 */
                //ServiceCollection.AddScoped(typeof(SmtpClient), typeof(SmtpClient));

                retVal = ServiceCollection.BuildServiceProvider();
            }

            return retVal;
        }
    }
}
