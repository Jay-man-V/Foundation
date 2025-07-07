//-----------------------------------------------------------------------
// <copyright file="CurrentLoggedOnUser.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Core
{
    /// <summary>
    /// Details of the currently logged on user
    /// </summary>
    public class CurrentLoggedOnUser : ICurrentLoggedOnUser
    {
        internal CurrentLoggedOnUser(IUserProfile userProfile)
        {
            UserProfile = userProfile;
        }

        /// <inheritdoc cref="ICurrentLoggedOnUser.UserProfile"/>
        public IUserProfile UserProfile { get; internal set; }

        /// <inheritdoc cref="ICurrentLoggedOnUser.Id"/>
        public EntityId Id => UserProfile.Id;

        /// <inheritdoc cref="ICurrentLoggedOnUser.Username"/>
        public String Username => UserProfile.Username;

        /// <inheritdoc cref="ICurrentLoggedOnUser.DisplayName"/>
        public String DisplayName => UserProfile.DisplayName;

        /// <inheritdoc cref="ICurrentLoggedOnUser.IsSystemSupport"/>
        public Boolean IsSystemSupport => UserProfile.IsSystemSupport;

#if DEBUG
        /// <inheritdoc cref="ICurrentLoggedOnUser.SetLoggedOnUser"/>
        public void SetLoggedOnUser(IUserProfile userProfile)
        {
            UserProfile = userProfile;
        }
#endif
    }
}