//-----------------------------------------------------------------------
// <copyright file="ISharedVariables.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// For storing shared variables
    /// </summary>
    public interface ISharedVariables
    {
        /// <summary>
        /// Retrieves a shared variable by key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        T? Get<T>(String key);

        /// <summary>
        /// Adds or updates a shared variable by key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void Set<T>(String key, T value);
    }
}
