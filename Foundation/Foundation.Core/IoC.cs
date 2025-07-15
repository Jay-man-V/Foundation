//-----------------------------------------------------------------------
// <copyright file="IoC.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;
using System.Reflection;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Foundation.Interfaces;

namespace Foundation.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class IoC : IIoC
    {
        private IHost TheHost { get; set; }
        private HostApplicationBuilder HostApplicationBuilder { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public IoC()
        {
            HostApplicationBuilder = SetupApplicationBuilder();

            Initialise(HostApplicationBuilder.Services);

            TheHost = HostApplicationBuilder.Build();
        }

        private HostApplicationBuilder SetupApplicationBuilder()
        {
            HostApplicationBuilderSettings settings = new()
            {
                Configuration = new ConfigurationManager(),
                ContentRootPath = Directory.GetCurrentDirectory(),
            };

            settings.Configuration.AddJsonFile("appSettings.json");

            HostApplicationBuilder = Host.CreateApplicationBuilder(settings);

            return HostApplicationBuilder;
        }

        /// <inheritdoc cref="IIoC.Reset()"/>
        public void Reset()
        {
            DependencyInjectionSetup.ResetDependencyInjection();
        }

        /// <inheritdoc cref="IIoC.Initialise(IServiceCollection, String, String)"/>
        public void Initialise(IServiceCollection serviceCollection, String typeNamespacePrefix = "Foundation", String searchPattern = "Foundation.*.dll")
        {
            DependencyInjectionSetup.SetupDependencyInjection(serviceCollection, typeNamespacePrefix, searchPattern);
        }

        /// <inheritdoc cref="IIoC.Get{TService}()"/>
        public TService Get<TService>()
        {
            TService? retVal = TheHost.Services.GetService<TService>();

            if (retVal == null)
            {
                String message = $"Unable to get instance of {typeof(TService)}";
                throw new InvalidOperationException(message);
            }

            return retVal;
        }

        /// <inheritdoc cref="IIoC.Get{TService}(String)"/>
        public TService? Get<TService>(String typeName)
        {
            TService? retVal = default;

            Type? type = Type.GetType(typeName);

            if (type != null)
            {
                retVal = (TService?)TheHost.Services.GetService(type);
            }

            return retVal;
        }

        /// <inheritdoc cref="IIoC.GetAll{TService}()"/>
        public IEnumerable<TService> GetAll<TService>()
        {
            IEnumerable<TService> retVal = TheHost.Services.GetServices<TService>();

            return retVal;
        }

        /// <inheritdoc cref="IIoC.Get{TService}(String, String, Object[]?)"/>
        public TService Get<TService>(String assemblyName, String typeName, params Object[]? args) where TService : class
        {
            List<Assembly> loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().OrderBy(a => a.FullName).ToList();
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

            TService? retVal = TheHost.Services.GetService(assemblyType) as TService;

            if (retVal == null)
            {
                retVal = Activator.CreateInstance(assemblyType, args) as TService;

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
