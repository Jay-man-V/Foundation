//-----------------------------------------------------------------------
// <copyright file="IoC.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;

using Microsoft.Extensions.DependencyInjection;

using Foundation.Interfaces;

namespace Foundation.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class IoC : IIoC
    {
        public IoC(IServiceCollection serviceCollection)
        {
            ServiceCollection = serviceCollection;
        }

        internal IServiceCollection ServiceCollection { get; set; }
        internal IServiceProvider? ServiceProvider { get; set; }

        /// <inheritdoc cref="IIoC.Reset()"/>
        public void Reset()
        {
            DependencyInjectionSetup.ResetDependencyInjection();
        }

        /// <inheritdoc cref="IIoC.Initialise(String, String)"/>
        public void Initialise(String typeNamespacePrefix = "Foundation", String searchPattern = "Foundation.*.dll")
        {
            DependencyInjectionSetup.SetupDependencyInjection(ServiceCollection, typeNamespacePrefix, searchPattern);
        }

        /// <inheritdoc cref="IIoC.Get{TService}()"/>
        public TService Get<TService>()
        {
            if (ServiceProvider == null)
            {
                String message = "IoC Service Provider has not been initialised.";
                throw new ArgumentNullException(nameof(ServiceProvider), message);
            }

            TService? retVal = ServiceProvider.GetService<TService>();

            if (retVal == null)
            {
                String message = $"Unable to get instance of {typeof(TService)}";
                throw new InvalidOperationException(message);
            }

            return retVal;
        }

        /// <inheritdoc cref="IIoC.Get{TService}(String)"/>
        public TService Get<TService>(String typeName)
        {
            TService? retVal = default;

            if (ServiceProvider == null)
            {
                String message = "IoC Service Provider has not been initialised.";
                throw new ArgumentNullException(nameof(ServiceProvider), message);
            }

            Type? type = Type.GetType(typeName);

            if (type != null)
            {
                retVal = (TService?)ServiceProvider.GetService(type);
            }

            if (retVal == null)
            {
                String errorMessage = $"Unable to get instance of '{typeName}'";
                throw new InvalidOperationException(errorMessage);
            }

            return retVal;
        }

        /// <inheritdoc cref="IIoC.GetAll{TService}()"/>
        public IEnumerable<TService> GetAll<TService>()
        {
            if (ServiceProvider == null)
            {
                String message = "IoC Service Provider has not been initialised.";
                throw new ArgumentNullException(nameof(ServiceProvider), message);
            }

            IEnumerable<TService> retVal = ServiceProvider.GetServices<TService>();

            return retVal;
        }

        /// <inheritdoc cref="IIoC.Get{TService}(String, String)"/>
        public TService Get<TService>(String assemblyName, String typeName) where TService : class
        {
            Assembly[] loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies(); //.OrderBy(a => a.FullName).ToList();
            Assembly? controllerAssembly = loadedAssemblies.FirstOrDefault(a => a.GetName().Name == assemblyName);

            if (controllerAssembly == null)
            {
                String message = $"Cannot locate the Assembly: '{assemblyName}'";
                throw new ArgumentNullException(nameof(assemblyName), message);
            }

            Type? assemblyType = controllerAssembly.GetType(typeName);

            if (assemblyType == null)
            {
                String message = $"Cannot load assembly type: '{typeName}' from the Assembly: '{controllerAssembly}'";
                throw new ArgumentNullException(nameof(assemblyType), message);
            }

            if (ServiceProvider == null)
            {
                String message = "IoC Service Provider has not been initialised.";
                throw new ArgumentNullException(nameof(ServiceProvider), message);
            }

            TService? retVal = ServiceProvider.GetService(assemblyType) as TService;

            if (retVal == null)
            {
                retVal = Activator.CreateInstance(assemblyType, null) as TService;

                if (retVal == null)
                {
                    String message = $"Cannot create type: '{typeName}' from the Assembly: '{controllerAssembly}'";
                    throw new ArgumentNullException(nameof(assemblyType), message);
                }
            }

            return retVal;
        }
    }
}
