//-----------------------------------------------------------------------
// <copyright file="ICurrentUser.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICurrentUser
    {
        /// <summary>
        /// The <see cref="UserProfile"/> for the user
        /// </summary>
        /// <value>
        ///   <see cref="UserProfile"/>.
        /// </value>
        IUserProfile UserProfile { get; }

        /// <summary>
        /// The <see cref="EntityId"/> of the user
        /// </summary>
        /// <value>
        ///   <see cref="EntityId"/>.
        /// </value>
        EntityId Id { get; }

        /// <summary>
        /// The Username of the user
        /// </summary>
        /// <value>
        ///   <see cref="string"/>.
        /// </value>
        String Username { get; }

        /// <summary>
        /// The DisplayName of the user
        /// </summary>
        /// <value>
        ///   <see cref="String"/>.
        /// </value>
        String DisplayName { get; }

        /// <summary>
        /// Gets a value indicating whether User is System Support.
        /// </summary>
        /// <value>
        ///   <c>true</c> if they are System Support; otherwise, <c>false</c>.
        /// </value>
        Boolean IsSystemSupport { get; }

#if DEBUG
        ///// <summary>
        ///// For Debug and Testing purposes, allows the Current User to be changed
        ///// </summary>
        ///// <param name="userProfile"></param>
        //void SetCurrentUser(IUserProfile userProfile);
#endif
    }
}
