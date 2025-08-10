//-----------------------------------------------------------------------
// <copyright file="PermissionMatrix.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Permission Matrix class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IPermissionMatrix" />
    [DependencyInjectionTransient]
    public class PermissionMatrix : FoundationModel, IPermissionMatrix, IEquatable<IPermissionMatrix>
    {
        private AppId _applicationId;
        private EntityId _roleId;
        private EntityId _userProfileId;
        private String _functionKey = String.Empty;
        private String _permission = String.Empty;

        /// <inheritdoc cref="IPermissionMatrix.ApplicationId"/>
        [Column(nameof(FDC.PermissionMatrix.ApplicationId))]
        [RequiredAppId]
        public AppId ApplicationId
        {
            get => this._applicationId;
            set => this.SetPropertyValue(ref _applicationId, value);
        }

        /// <inheritdoc cref="IPermissionMatrix.RoleId"/>
        [Column(nameof(FDC.PermissionMatrix.RoleId))]
        [RequiredEntityId(EntityName = "Role")]
        public EntityId RoleId
        {
            get => this._roleId;
            set => this.SetPropertyValue(ref _roleId, value);
        }

        /// <inheritdoc cref="IPermissionMatrix.UserProfileId"/>
        [Column(nameof(FDC.PermissionMatrix.UserProfileId))]
        [RequiredEntityId(EntityName = "User Profile")]
        public EntityId UserProfileId
        {
            get => this._userProfileId;
            set => this.SetPropertyValue(ref _userProfileId, value);
        }

        /// <inheritdoc cref="IPermissionMatrix.FunctionKey"/>
        [Column(nameof(FDC.PermissionMatrix.FunctionKey)), MaxLength(FDC.PermissionMatrix.Lengths.FunctionKey)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Function Key must be provided")]
        public String FunctionKey
        {
            get => this._functionKey;
            set => this.SetPropertyValue(ref _functionKey, value, FDC.PermissionMatrix.Lengths.FunctionKey);
        }

        /// <inheritdoc cref="IPermissionMatrix.Permission"/>
        [Column(nameof(FDC.PermissionMatrix.Permission)), MaxLength(FDC.PermissionMatrix.Lengths.Permission)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Permission must be provided")]
        public String Permission
        {
            get => this._permission;
            set => this.SetPropertyValue(ref _permission, value, FDC.PermissionMatrix.Lengths.Permission);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ApplicationId): retVal = ApplicationId; break;
                case nameof(RoleId): retVal = RoleId; break;
                case nameof(UserProfileId): retVal = UserProfileId; break;
                case nameof(FunctionKey): retVal = FunctionKey; break;
                case nameof(Permission): retVal = Permission; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            PermissionMatrix retVal = (PermissionMatrix)base.Clone();
            retVal.Initialising = true;

            retVal._applicationId = this._applicationId;
            retVal._roleId = this._roleId;
            retVal._userProfileId = this._userProfileId;
            retVal._functionKey = this._functionKey;
            retVal._permission = this._permission;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IPermissionMatrix? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is PermissionMatrix permissionMatrix)
            {
                retVal = InternalEquals(this, permissionMatrix);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<AppId>.Default.GetHashCode(ApplicationId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(RoleId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(UserProfileId);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(FunctionKey);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Permission);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IPermissionMatrix? left, IPermissionMatrix? right)
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
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.RoleId, right.RoleId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.UserProfileId, right.UserProfileId);
                retVal &= EqualityComparer<String>.Default.Equals(left.FunctionKey, right.FunctionKey);
                retVal &= EqualityComparer<String>.Default.Equals(left.Permission, right.Permission);
            }

            return retVal;
        }
    }
}
