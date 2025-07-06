//-----------------------------------------------------------------------
// <copyright file="ApplicationRole.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Common.DataColumns;
using FEnums = Foundation.Interfaces;

namespace Foundation.Models
{
    /// <summary>
    /// Application Role class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IApplicationRole" />
    [DependencyInjectionTransient]
    public class ApplicationRole : FoundationModel, IApplicationRole, IEquatable<IApplicationRole>
    {
        private AppId _applicationId;
        private EntityId _roleId;

        /// <inheritdoc cref="IApplicationRole.Role"/>
        [NotMapped]
        public FEnums.ApplicationRole Role => (FEnums.ApplicationRole)Id.ToInteger();

        /// <inheritdoc cref="IApplicationRole.ApplicationId"/>
        [Column(nameof(FDC.ApplicationRole.ApplicationId))]
        [RequiredAppId]
        public AppId ApplicationId
        {
            get => this._applicationId;
            set => this.SetPropertyValue(ref _applicationId, value);
        }

        /// <inheritdoc cref="IApplicationRole.RoleId"/>
        [Column(nameof(FDC.ApplicationRole.RoleId))]
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
                case nameof(RoleId): retVal = RoleId; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            ApplicationRole retVal = (ApplicationRole)base.Clone();
            retVal.Initialising = true;

            retVal._applicationId = this._applicationId;
            retVal._roleId = this._roleId;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IApplicationRole? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj.IsNotNull() &&
                obj is ApplicationRole applicationRole)
            {
                retVal = InternalEquals(this, applicationRole);
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

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IApplicationRole? left, IApplicationRole? right)
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
            }

            return retVal;
        }
    }
}
