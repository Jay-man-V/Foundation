//-----------------------------------------------------------------------
// <copyright file="LoggedOnUser.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Logged On User class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="ILoggedOnUser" />
    [DependencyInjectionTransient]
    [DebuggerDisplay("({GetType()}) - {UserProfileId} - {Username}")]
    public class LoggedOnUser : FoundationModel, ILoggedOnUser, IEquatable<ILoggedOnUser>
    {
        private AppId _applicationId;
        private EntityId _userProfileId;
        private DateTime _loggedOn;
        private DateTime _lastActive;
        private String _command = String.Empty;

        // Internal properties mapped from other objects
        private String _displayName = String.Empty;
        private String _username = String.Empty;
        private EntityId _roleId;
        private Boolean _isSystemSupport;

        /// <inheritdoc cref="ILoggedOnUser.ApplicationId"/>
        [Column(nameof(FDC.LoggedOnUser.ApplicationId))]
        [RequiredAppId]
        public AppId ApplicationId
        {
            get => this._applicationId;
            set => this.SetPropertyValue(ref _applicationId, value);
        }

        /// <inheritdoc cref="ILoggedOnUser.UserProfileId"/>
        [Column(nameof(FDC.LoggedOnUser.UserProfileId))]
        [RequiredEntityId(EntityName = "User Profile")]
        public EntityId UserProfileId
        {
            get => this._userProfileId;
            set => this.SetPropertyValue(ref _userProfileId, value);
        }

        /// <inheritdoc cref="ILoggedOnUser.LoggedOn"/>
        [Column(nameof(FDC.LoggedOnUser.LoggedOn))]
        public DateTime LoggedOn
        {
            get => this._loggedOn;
            set => this.SetPropertyValue(ref _loggedOn, value);
        }

        /// <inheritdoc cref="ILoggedOnUser.LastActive"/>
        [Column(nameof(FDC.LoggedOnUser.LastActive))]
        public DateTime LastActive
        {
            get => this._lastActive;
            set => this.SetPropertyValue(ref _lastActive, value);
        }

        /// <inheritdoc cref="ILoggedOnUser.Command"/>
        [Column(nameof(FDC.LoggedOnUser.Command)), MaxLength(FDC.LoggedOnUser.Lengths.Command)]
        [Required(AllowEmptyStrings = true)]
        public String Command
        {
            get => this._command;
            set => this.SetPropertyValue(ref _command, value, FDC.LoggedOnUser.Lengths.Command);
        }

        // Internal properties mapped from other objects

        /// <inheritdoc cref="ILoggedOnUser.DisplayName"/>
        [NotMapped]
        public String DisplayName
        {
            get => _displayName;
            internal set => this.SetPropertyValue(ref _displayName, value);
        }

        /// <inheritdoc cref="ILoggedOnUser.Username"/>
        [NotMapped]
        public String Username
        {
            get => _username;
            internal set => this.SetPropertyValue(ref _username, value);
        }

        /// <inheritdoc cref="ILoggedOnUser.RoleId"/>
        [NotMapped]
        public EntityId RoleId
        {
            get => _roleId;
            internal set => this.SetPropertyValue(ref _roleId, value);
        }

        /// <inheritdoc cref="ILoggedOnUser.IsSystemSupport"/>
        [NotMapped]
        public Boolean IsSystemSupport
        {
            get => _isSystemSupport;
            internal set => this.SetPropertyValue(ref _isSystemSupport, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ApplicationId): retVal = ApplicationId; break;
                case nameof(UserProfileId): retVal = UserProfileId; break;
                case nameof(LoggedOn): retVal = LoggedOn; break;
                case nameof(LastActive): retVal = LastActive; break;
                case nameof(Command): retVal = Command; break;
                case nameof(DisplayName): retVal = DisplayName; break;
                case nameof(Username): retVal = Username; break;
                case nameof(RoleId): retVal = RoleId; break;
                case nameof(IsSystemSupport): retVal = IsSystemSupport; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            LoggedOnUser retVal = (LoggedOnUser)base.Clone();
            retVal.Initialising = true;

            retVal._applicationId = this._applicationId;
            retVal._userProfileId = this._userProfileId;
            retVal._loggedOn = this._loggedOn;
            retVal._lastActive = this._lastActive;
            retVal._command = this._command;

            // Internal properties mapped from other objects
            retVal._displayName = this._displayName;
            retVal._username = this._username;
            retVal._roleId = this._roleId;
            retVal._isSystemSupport = this._isSystemSupport;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(ILoggedOnUser? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is LoggedOnUser loggedOnUser)
            {
                retVal = InternalEquals(this, loggedOnUser);
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
            hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(LoggedOn);
            hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(LastActive);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Command);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(DisplayName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Username);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(RoleId);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(IsSystemSupport);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(ILoggedOnUser? left, ILoggedOnUser? right)
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
                retVal &= EqualityComparer<DateTime>.Default.Equals(left.LoggedOn, right.LoggedOn);
                retVal &= EqualityComparer<DateTime>.Default.Equals(left.LastActive, right.LastActive);
                retVal &= EqualityComparer<String>.Default.Equals(left.Command, right.Command);

                retVal &= EqualityComparer<String>.Default.Equals(left.DisplayName, right.DisplayName);
                retVal &= EqualityComparer<String>.Default.Equals(left.Username, right.Username);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.RoleId, right.RoleId);
                retVal &= EqualityComparer<Boolean>.Default.Equals(left.IsSystemSupport, right.IsSystemSupport);
            }

            return retVal;
        }
    }
}
