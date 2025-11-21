//-----------------------------------------------------------------------
// <copyright file="SharedVariables.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.Concurrent;

using Foundation.Interfaces;

namespace Foundation.Core
{
    /// <summary>
    /// For storing shared variables
    /// </summary>
    [DependencyInjectionSingleton]
    public class SharedVariables : ISharedVariables
    {
        private ConcurrentDictionary<String, Object> Variables { get; } = new ConcurrentDictionary<String, Object>();

        /// <inheritdoc cref="ISharedVariables.Get{T}(String)"/>
        public T? Get<T>(String key)
        {
            T? retVal = default;

            if (!Variables.TryGetValue(key, out Object? value)) return retVal;

            if (value is T variable)
            {
                retVal = variable;
            }

            return retVal;
        }

        /// <inheritdoc cref="ISharedVariables.Set{T}(String, T)"/>
        public void Set<T>(String key, T value)
        {
            Variables.AddOrUpdate(key, value, (_, _) => value);
        }
    }
}