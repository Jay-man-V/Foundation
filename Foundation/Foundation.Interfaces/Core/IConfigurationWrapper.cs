//-----------------------------------------------------------------------
// <copyright file="IConfigurationWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IConfigurationWrapper
    {
        /// <summary>
        /// Extracts the value with the specified key and converts it to type T.
        /// </summary>
        /// <typeparam name="T">The type to convert the value to.</typeparam>
        /// <param name="key">The key of the configuration section's value to convert.</param>
        /// <returns>The converted value.</returns>
        T? GetValue<T>(String key);

        /// <summary>
        /// Gets the specified connection string from the specified configuration.
        /// Shorthand for <c>GetSection("ConnectionStrings")[name]</c>.
        /// </summary>
        /// <param name="name">The connection string key.</param>
        /// <returns>The connection string.</returns>
        String? GetConnectionString(String name);
    }
}
