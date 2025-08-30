//-----------------------------------------------------------------------
// <copyright file="CurrentUser.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.Core
{
    /// <summary>
    /// Details of the current user
    /// </summary>
    public class CurrentUser : ICurrentUser
    {
        internal CurrentUser(IUserProfile userProfile)
        {
            UserProfile = userProfile;
        }

        /// <inheritdoc cref="ICurrentUser.UserProfile"/>
        public IUserProfile UserProfile { get; internal set; }

        /// <inheritdoc cref="ICurrentUser.Id"/>
        public EntityId Id => UserProfile.Id;

        /// <inheritdoc cref="ICurrentUser.Username"/>
        public String Username => UserProfile.Username;

        /// <inheritdoc cref="ICurrentUser.DisplayName"/>
        public String DisplayName => UserProfile.DisplayName;

        /// <inheritdoc cref="ICurrentUser.IsSystemSupport"/>
        public Boolean IsSystemSupport => UserProfile.IsSystemSupport;

#if DEBUG
        ///// <inheritdoc cref="ICurrentUser.SetCurrentUser"/>
        //public void SetCurrentUser(IUserProfile userProfile)
        //{
        //    UserProfile = userProfile;
        //}
#endif
    }
}