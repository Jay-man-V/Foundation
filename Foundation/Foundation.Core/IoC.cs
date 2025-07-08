//-----------------------------------------------------------------------
// <copyright file="IoC.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Reflection;
//using System.Web.Http.Dependencies;

using Microsoft.Extensions.DependencyInjection;

using Foundation.Interfaces;

namespace Foundation.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class IoC : IIoC
    {
        private static IServiceProvider? Container { get; set; }
//        private static IDependencyResolver _dependencyResolver;

        /// <summary>
        /// 
        /// </summary>
        public IoC()
        {
            Initialise();

//            _dependencyResolver = new DependencyResolver(_container);
        }

//        /// <inheritdoc cref="IIoC.DependencyResolver"/>
//        public IDependencyResolver DependencyResolver => _dependencyResolver;

        /// <inheritdoc cref="IIoC.Reset()"/>
        public void Reset()
        {
            DependencyInjectionSetup.ResetDependencyInjection();
        }

        /// <inheritdoc cref="IIoC.Initialise(String, String)"/>
        public void Initialise(String typeNamespacePrefix = "Foundation", String searchPattern = "Foundation.*.dll")
        {
            Container = DependencyInjectionSetup.SetupDependencyInjection(typeNamespacePrefix, searchPattern);
        }

        /// <inheritdoc cref="IIoC.Get{TService}()"/>
        public TService? Get<TService>()
        {
            if (Container == null)
            {
                String message = "IoC has not been initialised";
                throw new InvalidOperationException(message);
            }

            TService? retVal = Container.GetService<TService>();

            return retVal;
        }

        /// <inheritdoc cref="IIoC.Get{TService}(String)"/>
        public TService? Get<TService>(String typeName)
        {
            TService? retVal = default;

            if (Container == null)
            {
                String message = "IoC has not been initialised";
                throw new InvalidOperationException(message);
            }

            Type? type = Type.GetType(typeName);

            if (type != null)
            {
                retVal = (TService?)Container.GetService(type);
            }

            return retVal;
        }

        /// <inheritdoc cref="IIoC.GetAll{TService}()"/>
        public IEnumerable<TService> GetAll<TService>()
        {
            if (Container == null)
            {
                String message = "IoC has not been initialised";
                throw new InvalidOperationException(message);
            }

            IEnumerable<TService> retVal = Container.GetServices<TService>();

            return retVal;
        }

        /// <inheritdoc cref="IIoC.Get{TService}(String, String, Object[])"/>
        public TService Get<TService>(String assemblyName, String typeName, params Object[] args) where TService : class
        {
            if (Container == null)
            {
                String message = "IoC has not been initialised";
                throw new InvalidOperationException(message);
            }

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

            TService? retVal = Container.GetService(assemblyType) as TService;

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
