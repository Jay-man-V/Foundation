//-----------------------------------------------------------------------
// <copyright file="Role.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;
using FEnums = Foundation.Interfaces;

namespace Foundation.Models.Sec
{
    /// <summary>
    /// Role class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IRole" />
    [DependencyInjectionTransient]
    [DebuggerDisplay("{Id}::{ApplicationRole.ToString()}")]
    public class Role : FoundationModel, IRole, IEquatable<IRole>
    {
        private String _name = String.Empty;
        private String _description = String.Empty;
        private Boolean _systemSupportOnly;

        /// <inheritdoc cref="IRole.ApplicationRole"/>
        [NotMapped]
        public FEnums.ApplicationRole ApplicationRole => (FEnums.ApplicationRole)Id.ToInteger();

        /// <inheritdoc cref="IRole.Name"/>
        [Column(nameof(FDC.Role.Name)), MaxLength(FDC.Role.Lengths.Name)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be provided")]
        public String Name
        {
            get => this._name;
            set => this.SetPropertyValue(ref _name, value, FDC.Role.Lengths.Name);
        }

        /// <inheritdoc cref="IRole.Description"/>
        [Column(nameof(FDC.Role.Description)), MaxLength(FDC.Role.Lengths.Description)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description must be provided")]
        public String Description
        {
            get => this._description;
            set => this.SetPropertyValue(ref _description, value, FDC.Role.Lengths.Description);
        }

        /// <inheritdoc cref="IRole.SystemSupportOnly"/>
        [Column(nameof(FDC.Role.SystemSupportOnly))]
        public Boolean SystemSupportOnly
        {
            get => this._systemSupportOnly;
            internal set => this.SetPropertyValue(ref _systemSupportOnly, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(Name): retVal = Name; break;
                case nameof(Description): retVal = Description; break;
                case nameof(SystemSupportOnly): retVal = SystemSupportOnly; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            Role retVal = (Role)base.Clone();
            retVal.Initialising = true;

            retVal._name = this._name;
            retVal._description = this._description;
            retVal._systemSupportOnly = this._systemSupportOnly;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IRole? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is Role role)
            {
                retVal = InternalEquals(role);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<FEnums.ApplicationRole>.Default.GetHashCode(ApplicationRole);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Name);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Description);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(SystemSupportOnly);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IRole? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<EntityId>.Default.Equals(this.Id, right.Id);
                retVal &= EqualityComparer<String>.Default.Equals(this.Name, right.Name);
                retVal &= EqualityComparer<String>.Default.Equals(this.Description, right.Description);
                retVal &= EqualityComparer<Boolean>.Default.Equals(this.SystemSupportOnly, right.SystemSupportOnly);
            }

            return retVal;
        }
    }
}
