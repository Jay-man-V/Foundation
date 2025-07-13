//-----------------------------------------------------------------------
// <copyright file="ApplicationUserRole.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Common.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Application/User/Role class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IApplicationUserRole" />
    [DependencyInjectionTransient]
    public class ApplicationUserRole : FoundationModel, IApplicationUserRole, IEquatable<IApplicationUserRole>
    {
        private AppId _applicationId;
        private EntityId _userProfileId;
        private EntityId _roleId;

        /// <inheritdoc cref="IApplicationUserRole.ApplicationId"/>
        [Column(nameof(FDC.ApplicationUserRole.ApplicationId))]
        [RequiredAppId]
        public AppId ApplicationId
        {
            get => this._applicationId;
            set => this.SetPropertyValue(ref _applicationId, value);
        }

        /// <inheritdoc cref="IApplicationUserRole.UserProfileId"/>
        [Column(nameof(FDC.ApplicationUserRole.UserProfileId))]
        [RequiredEntityId(EntityName = "User Profile")]
        public EntityId UserProfileId
        {
            get => this._userProfileId;
            set => this.SetPropertyValue(ref _userProfileId, value);
        }

        /// <inheritdoc cref="IApplicationUserRole.RoleId"/>
        [Column(nameof(FDC.ApplicationUserRole.RoleId))]
        [RequiredEntityId(EntityName = "Role")]
        public EntityId RoleId
        {
            get => this._roleId;
            set => this.SetPropertyValue(ref _roleId, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ApplicationId): retVal = ApplicationId; break;
                case nameof(UserProfileId): retVal = UserProfileId; break;
                case nameof(RoleId): retVal = RoleId; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            ApplicationUserRole retVal = (ApplicationUserRole)base.Clone();
            retVal.Initialising = true;

            retVal._applicationId = this._applicationId;
            retVal._userProfileId = this._userProfileId;
            retVal._roleId = this._roleId;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IApplicationUserRole? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is ApplicationUserRole applicationUserRole)
            {
                retVal = InternalEquals(this, applicationUserRole);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<AppId>.Default.GetHashCode(ApplicationId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(UserProfileId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(RoleId);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IApplicationUserRole? left, IApplicationUserRole? right)
        {
            Boolean retVal;

            if (left == null && right == null)
            {
                retVal = true;
            }
            else if (left == null || right == null)
            {
                retVal = false;
            }
            else
            {
                retVal = FoundationModel.InternalEquals(left, right);

                retVal &= EqualityComparer<AppId>.Default.Equals(left.ApplicationId, right.ApplicationId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.UserProfileId, right.UserProfileId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.RoleId, right.RoleId);
            }

            return retVal;
        }
    }
}
