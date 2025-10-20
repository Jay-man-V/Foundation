//-----------------------------------------------------------------------
// <copyright file="IApplicationConfiguration.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Application Configuration model interface
    /// </summary>
    public interface IApplicationConfiguration : IFoundationModel
    {
        /// <summary>Gets the configuration scope.</summary>
        /// <value>The configuration scope.</value>
        ConfigurationScope ConfigurationScope { get; }

        /// <summary>
        /// Gets or sets the application identifier.
        /// </summary>
        /// <value>The application identifier.</value>
        AppId ApplicationId { get; set; }

        /// <summary>
        /// Gets or sets the configuration scope identifier.
        /// </summary>
        /// <value>The configuration scope identifier.</value>
        EntityId ConfigurationScopeId { get; set; }

        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>The key.</value>
        String Key { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>The value.</value>
        Object? Value { get; set; }

        /// <summary>
        /// Whether the configuration value is encrypted.
        /// </summary>
        Boolean IsEncrypted { get; set; }
    }
}
