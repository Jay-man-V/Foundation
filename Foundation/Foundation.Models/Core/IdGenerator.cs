//-----------------------------------------------------------------------
// <copyright file="IdGenerator.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Models.Core
{
    /// <summary>
    /// Id Generator class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IIdGenerator" />
    [DependencyInjectionTransient]
    public class IdGenerator : FoundationModel, IIdGenerator, IEquatable<IIdGenerator>
    {
        private AppId _applicationId;
        private EntityId _configurationScopeId;
        private String _idName = String.Empty;
        private Int32 _lastId;
        private Boolean _resetOnNewDate;

        /// <inheritdoc cref="IIdGenerator.ApplicationId"/>
        [Column(nameof(FDC.IdGenerator.ApplicationId))]
        [RequiredAppId(AllowEmptyStrings = false)]
        public AppId ApplicationId
        {
            get => this._applicationId;
            set => this.SetPropertyValue(ref _applicationId, value, FDC.WorldRegion.Lengths.Name);
        }

        /// <inheritdoc cref="IIdGenerator.ConfigurationScopeId"/>
        [Column(nameof(FDC.IdGenerator.ConfigurationScopeId))]
        public EntityId ConfigurationScopeId
        {
            get => this._configurationScopeId;
            set => this.SetPropertyValue(ref _configurationScopeId, value, FDC.WorldRegion.Lengths.Name);
        }

        /// <inheritdoc cref="IIdGenerator.IdName"/>
        [Column(nameof(FDC.IdGenerator.IdName))]
        [MaxLength(FDC.IdGenerator.Lengths.IdName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Id Name must be provided")]
        public String IdName
        {
            get => this._idName;
            set => this.SetPropertyValue(ref _idName, value, FDC.IdGenerator.Lengths.IdName);
        }

        /// <inheritdoc cref="IIdGenerator.LastId"/>
        [Column(nameof(FDC.IdGenerator.LastId))]
        public Int32 LastId
        {
            get => this._lastId;
            set => this.SetPropertyValue(ref _lastId, value);
        }

        /// <inheritdoc cref="IIdGenerator.ResetOnNewDate"/>
        [Column(nameof(FDC.IdGenerator.ResetOnNewDate))]
        public Boolean ResetOnNewDate
        {
            get => this._resetOnNewDate;
            set => this.SetPropertyValue(ref _resetOnNewDate, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ApplicationId): retVal = ApplicationId; break;
                case nameof(ConfigurationScopeId): retVal = ConfigurationScopeId; break;
                case nameof(IdName): retVal = IdName; break;
                case nameof(LastId): retVal = LastId; break;
                case nameof(ResetOnNewDate): retVal = ResetOnNewDate; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            IdGenerator retVal = (IdGenerator)base.Clone();
            retVal.Initialising = true;

            retVal._applicationId = this._applicationId;
            retVal._configurationScopeId = this._configurationScopeId;
            retVal._idName = this._idName;
            retVal._lastId = this._lastId;
            retVal._resetOnNewDate = this._resetOnNewDate;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IIdGenerator? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is IdGenerator idGenerator)
            {
                retVal = InternalEquals(idGenerator);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<AppId>.Default.GetHashCode(ApplicationId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ConfigurationScopeId);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(IdName);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(LastId);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(ResetOnNewDate);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IIdGenerator? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<AppId>.Default.Equals(this.ApplicationId, right.ApplicationId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(this.ConfigurationScopeId, right.ConfigurationScopeId);
                retVal &= EqualityComparer<String>.Default.Equals(this.IdName, right.IdName);
                retVal &= EqualityComparer<Int32>.Default.Equals(this.LastId, right.LastId);
                retVal &= EqualityComparer<Boolean>.Default.Equals(this.ResetOnNewDate, right.ResetOnNewDate);
            }

            return retVal;
        }
    }
}
