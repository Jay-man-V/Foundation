//-----------------------------------------------------------------------
// <copyright file="ApplicationDefaultValues.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Resources
{
    /// <summary>
    /// Defines the application wide default values
    /// </summary>
    public static class ApplicationDefaultValues
    {
        public static EntityId SystemUserProfileEntityId => new EntityId(1);

        /// <summary>
        /// The default Valid To date/time that is used throughout the application
        /// <para>
        /// This is normally the '2199-Dec-31 23:59:59'
        /// </para>
        /// </summary>
        public static DateTime DefaultValidToDateTime => new DateTime(2199, 12, 31, 23, 59, 59, DateTimeKind.Utc);
    }
}
