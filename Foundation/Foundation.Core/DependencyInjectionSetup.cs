//-----------------------------------------------------------------------
// <copyright file="DependencyInjectionSetup.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.Loader;

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
        internal static IServiceCollection? ServiceCollection { get; private set; }

        /// <summary>
        /// Loads the list of assembly types from file system.
        /// </summary>
        /// <returns></returns>
        private static List<Type> LoadListOfAssemblyTypesFromFileSystem(String searchPattern)
        {
            List<Type> retVal = [];

            String localPath = Assembly.GetExecutingAssembly().Location;
            String? sourceLocationPath = Path.GetDirectoryName(localPath);

            if (sourceLocationPath == null)
            {
                String message = $"The assembly location '{localPath}' and its parent directory cannot be processed for all assemblies and Dependency Injection setup";
                throw new ArgumentNullException(nameof(sourceLocationPath), message);
            }

            String[] foundationAssemblyFilePaths = Directory.GetFiles(sourceLocationPath, searchPattern);
            foreach (String assemblyPath in foundationAssemblyFilePaths)
            {
                Assembly loadedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyPath);

                Type[] allTypes = loadedAssembly.GetTypes();
                List<Type> requiredTypes = allTypes.Where(t => !t.IsAbstract &&                 // Exclude abstract classes
                                                               !t.IsInterface &&                // Exclude interfaces
                                                               t.GetInterfaces().Length >= 1 && // Include classes that implement at least 1 interface
                                                               !t.GetCustomAttributes<DependencyInjectionIgnoreAttribute>().Any() &&        // Exclude classes marked to be ignored
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
        private static List<String> ExcludedTypes
        {
            get
            {
                List<String> excludedTypesList = ["UnitTests.NetFramework.ExcludedMe"];

                return excludedTypesList;
            }
        }

        /// <summary>
        /// Resets the dependency injection.
        /// </summary>
        /// <returns></returns>
        public static void ResetDependencyInjection()
        {
            if (ServiceCollection is not null)
            {
                ServiceCollection.Clear();
            }
        }

        /// <summary>
        /// Setups the dependency injection.
        /// </summary>
        /// <returns></returns>
        public static void SetupDependencyInjection(IServiceCollection serviceCollection, String typeNamespacePrefix, String searchPattern)
        {
            lock (SyncLock)
            {
                ServiceCollection = serviceCollection;

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

                AddTypesToCollection
                (
                    typeNamespacePrefix,
                    ServiceCollection,
                    singletonTypes,
                    (implementationType) => ServiceCollection.AddSingleton(implementationType),
                    (interfaceType, implementationType) => ServiceCollection.AddSingleton(interfaceType, implementationType)
                );

                AddTypesToCollection
                (
                    typeNamespacePrefix,
                    ServiceCollection,
                    scopedTypes,
                    (implementationType) => ServiceCollection.AddScoped(implementationType),
                    (interfaceType, implementationType) => ServiceCollection.AddScoped(interfaceType, implementationType)
                );

                AddTypesToCollection
                (
                    typeNamespacePrefix,
                    ServiceCollection,
                    transientTypes,
                    (implementationType) => ServiceCollection.AddTransient(implementationType),
                    (interfaceType, implementationType) => ServiceCollection.AddTransient(interfaceType, implementationType)
                );

                /*
                 * Special setups
                 */
                //ServiceCollection.AddScoped(typeof(SmtpClient), typeof(SmtpClient));
            }
        }

        private static void AddTypesToCollection
        (
            String typeNamespacePrefix,
            IServiceCollection targetServiceCollection,
            List<Type> sourceCollection,
            Action<Type> addImplementationAction,
            Action<Type, Type> addInterfaceWithImplementationAction
        )
        {
            foreach (Type implementationType in sourceCollection)
            {
                String? implementationTypeName = implementationType.FullName;
                if (!String.IsNullOrEmpty(implementationTypeName))
                {
#if (DEBUG)
                    if (implementationTypeName.Contains("MockApplicationStartup"))
                    {
                    }
#endif

                    //List<Type> interfaceTypes = implementationType.GetInterfaces().ToList();
                    List<Type> allInterfaceTypes = implementationType.GetInterfaces().ToList();
                    List<Type> baseInterfaceTypes;

                    if (implementationType.BaseType != null)
                    {
                        baseInterfaceTypes = implementationType.BaseType.GetInterfaces().ToList();
                    }
                    else
                    {
                        baseInterfaceTypes = [];
                    }
                    List<Type> interfaceTypes = allInterfaceTypes.Except(baseInterfaceTypes).ToList();

                    foreach (Type interfaceType in interfaceTypes)
                    {
                        String? interfaceFullName = interfaceType.FullName;
                        if (!String.IsNullOrEmpty(interfaceFullName))
                        {
                            String interfaceName = interfaceType.Name;
#if (DEBUG)
                            if (interfaceName.Contains("IMockApplicationStartup"))
                            {
                            }
#endif

                            Boolean excludedAttributesCheck = !interfaceType.GetCustomAttributes<DependencyInjectionIgnoreAttribute>(inherit: false).Any();
                            //Boolean excludedInterfaceCheck = !ExcludedInterfaces.Contains(interfaceName);
                            Boolean typeFullNameCheck = interfaceFullName.StartsWith(typeNamespacePrefix);

                            if (excludedAttributesCheck &&
                                typeFullNameCheck)
                            {
#if (DEBUG)
                                //Debug.WriteLine($"Service Type: {interfaceType}. Implementation Type: {implementationType}");
#endif
                                ServiceDescriptor sd = new ServiceDescriptor(interfaceType, implementationType);
                                if (!targetServiceCollection.Contains(sd))
                                {
                                    addImplementationAction(implementationType);
                                    addInterfaceWithImplementationAction(interfaceType, implementationType);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
