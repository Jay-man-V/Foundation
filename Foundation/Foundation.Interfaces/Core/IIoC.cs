//-----------------------------------------------------------------------
// <copyright file="IIoC.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Microsoft.Extensions.DependencyInjection;

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IIoC
    {
        ///// <summary>
        ///// 
        ///// </summary>
        //IDependencyResolver DependencyResolver { get; }

        /// <summary>
        /// Resets the IoC setup to remove/clear all the loaded references
        /// </summary>
        void Reset();

        /// <summary>
        /// Initialises the IoC setup to include the assemblies as defined by <paramref name="typeNamespacePrefix"/> and <paramref name="searchPattern"/>
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="typeNamespacePrefix"></param>
        /// <param name="searchPattern"></param>
        void Initialise(IServiceCollection serviceCollection, String typeNamespacePrefix = "Foundation", String searchPattern = "Foundation.*.dll");

        /// <summary>
        /// Get service of type <typeparamref name="TService"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        TService Get<TService>();

        /// <summary>
        /// Gets the service object of the specified type.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="typeName"></param>
        /// <returns></returns>
        TService? Get<TService>(String typeName);

        /// <summary>
        /// Get an enumeration of services of type <typeparamref name="TService"/> from the <see cref="IServiceProvider"/>.
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <returns></returns>
        IEnumerable<TService> GetAll<TService>();

        /// <summary>
        /// Get service of type <paramref name="typeName"/> from the assembly <paramref name="assemblyName"/>
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="assemblyName"></param>
        /// <param name="typeName"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        TService Get<TService>(String assemblyName, String typeName, params Object[]? args) where TService : class;
    }
}
