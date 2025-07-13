//-----------------------------------------------------------------------
// <copyright file="UserProfile.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Common.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// User Profile class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IUserProfile" />
    [DebuggerDisplay("{Username} - {DisplayName}")]
    [DependencyInjectionTransient]
    public class UserProfile : FoundationModel, IUserProfile, IEquatable<IUserProfile>
    {
        private String _externalKeyId = String.Empty;
        private String _domainName = String.Empty;
        private String _username = String.Empty;
        private String _displayName = String.Empty;
        private Boolean _isSystemSupport;
        private EntityId _contactDetailId;

        /// <summary>
        /// Initialises a new instance of the <see cref="UserProfile"/> class.
        /// </summary>
        public UserProfile()
        {
            Roles = new List<IRole>();
        }

        /// <inheritdoc cref="IUserProfile.Roles"/>
        [NotMapped]
        public IList<IRole> Roles { get; private set; }

        /// <inheritdoc cref="IUserProfile.ExternalKeyId"/>
        [Column(nameof(FDC.UserProfile.ExternalKeyId)), MaxLength(FDC.UserProfile.Lengths.ExternalKeyId)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "External Key Id must be provided")]
        public String ExternalKeyId
        {
            get => this._externalKeyId;
            set => this.SetPropertyValue(ref _externalKeyId, value, FDC.UserProfile.Lengths.ExternalKeyId);
        }

        /// <inheritdoc cref="IUserProfile.DomainName"/>
        [Column(nameof(FDC.UserProfile.DomainName)), MaxLength(FDC.UserProfile.Lengths.DomainName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Domain Name must be provided")]
        public String DomainName
        {
            get => this._domainName;
            set => this.SetPropertyValue(ref _domainName, value, FDC.UserProfile.Lengths.DomainName);
        }

        /// <inheritdoc cref="IUserProfile.Username"/>
        [Column(nameof(FDC.UserProfile.Username)), MaxLength(FDC.UserProfile.Lengths.Username)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username must be provided")]
        public String Username
        {
            get => this._username;
            set => this.SetPropertyValue(ref _username, value, FDC.UserProfile.Lengths.Username);
        }

        /// <inheritdoc cref="IUserProfile.DisplayName"/>
        [Column(nameof(FDC.UserProfile.DisplayName)), MaxLength(FDC.UserProfile.Lengths.DisplayName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Display Name must be provided")]
        public String DisplayName
        {
            get => this._displayName;
            set => this.SetPropertyValue(ref _displayName, value, FDC.UserProfile.Lengths.DisplayName);
        }

        /// <inheritdoc cref="IUserProfile.IsSystemSupport"/>
        [Column(nameof(FDC.UserProfile.IsSystemSupport))]
        public Boolean IsSystemSupport
        {
            get => this._isSystemSupport;
            set => this.SetPropertyValue(ref _isSystemSupport, value);
        }

        /// <inheritdoc cref="IUserProfile.ContactDetailId"/>
        [Column(nameof(FDC.UserProfile.ContactDetailId))]
        [RequiredEntityId(EntityName = "Contact Detail")]
        public EntityId ContactDetailId
        {
            get => this._contactDetailId;
            set => this.SetPropertyValue(ref _contactDetailId, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ExternalKeyId): retVal = ExternalKeyId; break;
                case nameof(DomainName): retVal = DomainName; break;
                case nameof(Username): retVal = Username; break;
                case nameof(DisplayName): retVal = DisplayName; break;
                case nameof(IsSystemSupport): retVal = IsSystemSupport; break;
                case nameof(ContactDetailId): retVal = ContactDetailId; break;
                case nameof(Roles): retVal = Roles; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            UserProfile retVal = (UserProfile)base.Clone();
            retVal.Initialising = true;

            retVal._externalKeyId = this._externalKeyId;
            retVal._domainName = this._domainName;
            retVal._username = this._username;
            retVal._displayName = this._displayName;
            retVal._isSystemSupport = this._isSystemSupport;
            retVal._contactDetailId = this._contactDetailId;

            retVal.Roles = this.Roles.Clone();

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IUserProfile? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }


        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is UserProfile userProfile)
            {
                retVal = InternalEquals(this, userProfile);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ExternalKeyId);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(DomainName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Username);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(DisplayName);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(IsSystemSupport);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ContactDetailId);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IUserProfile? left, IUserProfile? right)
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

                retVal &= EqualityComparer<String>.Default.Equals(left.ExternalKeyId, right.ExternalKeyId);
                retVal &= EqualityComparer<String>.Default.Equals(left.DomainName, right.DomainName);
                retVal &= EqualityComparer<String>.Default.Equals(left.Username, right.Username);
                retVal &= EqualityComparer<String>.Default.Equals(left.DisplayName, right.DisplayName);
                retVal &= EqualityComparer<Boolean>.Default.Equals(left.IsSystemSupport, right.IsSystemSupport);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.ContactDetailId, right.ContactDetailId);
            }

            return retVal;
        }
    }
}
