//-----------------------------------------------------------------------
// <copyright file="ApplicationConfiguration.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Common.DataColumns;
using FEnums = Foundation.Interfaces;

namespace Foundation.Models
{
    /// <summary>
    /// Application Configuration class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IApplicationConfiguration" />
    [DependencyInjectionTransient]
    public class ApplicationConfiguration : FoundationModel, IApplicationConfiguration, IEquatable<IApplicationConfiguration>, IEquatable<ApplicationConfiguration>
    {
        private AppId _applicationId;
        private EntityId _configurationScopeId;
        private String _key = String.Empty;
        private Object? _value;

        /// <inheritdoc cref="IApplicationConfiguration.ConfigurationScope"/>
        [NotMapped]
        public FEnums.ConfigurationScope ConfigurationScope => (FEnums.ConfigurationScope)this._configurationScopeId.ToInteger();

        /// <inheritdoc cref="IApplicationConfiguration.ApplicationId"/>
        [Column(nameof(FDC.ApplicationConfiguration.ApplicationId))]
        [RequiredAppId]
        public AppId ApplicationId
        {
            get => this._applicationId;
            set => this.SetPropertyValue(ref _applicationId, value);
        }

        /// <inheritdoc cref="IApplicationConfiguration.ConfigurationScopeId"/>
        [Column(nameof(FDC.ApplicationConfiguration.ConfigurationScopeId))]
        [RequiredEntityId(EntityName = "Configuration Scope")]
        public EntityId ConfigurationScopeId
        {
            get => this._configurationScopeId;
            set => this.SetPropertyValue(ref _configurationScopeId, value);
        }

        /// <inheritdoc cref="IApplicationConfiguration.Key"/>
        [Column(nameof(FDC.ApplicationConfiguration.Key))]
        [MaxLength(FDC.ApplicationConfiguration.Lengths.Key)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Key must be provided")]
        public String Key
        {
            get => this._key;
            set => this.SetPropertyValue(ref _key, value, FDC.ApplicationConfiguration.Lengths.Key);
        }

        /// <inheritdoc cref="IApplicationConfiguration.Value"/>
        [Column(nameof(FDC.ApplicationConfiguration.Value))]
        [MaxLength(FDC.ApplicationConfiguration.Lengths.Value)]
        public Object? Value
        {
            get => this._value;
            set => this.SetPropertyValue(ref _value, value, FDC.ApplicationConfiguration.Lengths.Value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ApplicationId): retVal = ApplicationId; break;
                case nameof(ConfigurationScopeId): retVal = ConfigurationScopeId; break;
                case nameof(Key): retVal = Key; break;
                case nameof(Value): retVal = Value; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            ApplicationConfiguration retVal = (ApplicationConfiguration)base.Clone();
            retVal.Initialising = true;

            retVal._applicationId = this._applicationId;
            retVal._configurationScopeId = this._configurationScopeId;
            retVal._key = this._key;
            retVal._value = this._value;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IApplicationConfiguration? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(ApplicationConfiguration? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;
            if (obj is IApplicationConfiguration applicationConfiguration)
            {
                retVal = InternalEquals(this, applicationConfiguration);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            unchecked
            {
                hashCode = hashCode * constant + EqualityComparer<AppId>.Default.GetHashCode(ApplicationId);
                hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ConfigurationScopeId);
                hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Key);

                if (Value != null)
                {
                    hashCode = hashCode * constant + EqualityComparer<Object>.Default.GetHashCode(Value);
                }
            }

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IApplicationConfiguration? left, IApplicationConfiguration? right)
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
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.ConfigurationScopeId, right.ConfigurationScopeId);
                retVal &= EqualityComparer<String>.Default.Equals(left.Key, right.Key);
                retVal &= EqualityComparer<Object>.Default.Equals(left.Value, right.Value);
            }

            return retVal;
        }
    }
}
