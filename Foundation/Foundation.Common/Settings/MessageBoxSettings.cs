//-----------------------------------------------------------------------
// <copyright file="MessageBoxSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <inheritdoc cref="IMessageBoxSettings"/>
    /// <seealso cref="IMessageBoxSettings" />
    [DependencyInjectionTransient]
    public class MessageBoxSettings : IMessageBoxSettings
    {
        /// <inheritdoc cref="Button"/>
        public MessageBoxButton Button { get; set; }

        /// <inheritdoc cref="Caption"/>
        public String Caption { get; set; } = String.Empty;

        /// <inheritdoc cref="Icon"/>
        public MessageBoxImage Icon { get; set; }

        /// <inheritdoc cref="Text"/>
        public String Text { get; set; } = String.Empty;
    }
}
