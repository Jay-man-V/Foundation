//-----------------------------------------------------------------------
// <copyright file="SequenceGenerator.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Sequence Generator class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="ISequenceGenerator" />
    [DependencyInjectionTransient]
    public class SequenceGenerator : FoundationModel, ISequenceGenerator, IEquatable<ISequenceGenerator>
    {
        private AppId _applicationId;
        private EntityId _configurationScopeId;
        private String _sequenceName = String.Empty;
        private Int32 _lastSequence;
        private Boolean _resetOnNewDate;

        /// <inheritdoc cref="ISequenceGenerator.ApplicationId"/>
        [Column(nameof(FDC.SequenceGenerator.ApplicationId))]
        [RequiredAppId(AllowEmptyStrings = false)]
        public AppId ApplicationId
        {
            get => this._applicationId;
            set => this.SetPropertyValue(ref _applicationId, value, FDC.WorldRegion.Lengths.Name);
        }

        /// <inheritdoc cref="ISequenceGenerator.ConfigurationScopeId"/>
        [Column(nameof(FDC.SequenceGenerator.ConfigurationScopeId))]
        public EntityId ConfigurationScopeId
        {
            get => this._configurationScopeId;
            set => this.SetPropertyValue(ref _configurationScopeId, value, FDC.WorldRegion.Lengths.Name);
        }

        /// <inheritdoc cref="ISequenceGenerator.SequenceName"/>
        [Column(nameof(FDC.SequenceGenerator.SequenceName))]
        [MaxLength(FDC.SequenceGenerator.Lengths.SequenceName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Sequence Name must be provided")]
        public String SequenceName
        {
            get => this._sequenceName;
            set => this.SetPropertyValue(ref _sequenceName, value, FDC.SequenceGenerator.Lengths.SequenceName);
        }

        /// <inheritdoc cref="ISequenceGenerator.LastSequence"/>
        [Column(nameof(FDC.SequenceGenerator.LastSequence))]
        public Int32 LastSequence
        {
            get => this._lastSequence;
            set => this.SetPropertyValue(ref _lastSequence, value);
        }

        /// <inheritdoc cref="ISequenceGenerator.ResetOnNewDate"/>
        [Column(nameof(FDC.SequenceGenerator.ResetOnNewDate))]
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
                case nameof(SequenceName): retVal = SequenceName; break;
                case nameof(LastSequence): retVal = LastSequence; break;
                case nameof(ResetOnNewDate): retVal = ResetOnNewDate; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            SequenceGenerator retVal = (SequenceGenerator)base.Clone();
            retVal.Initialising = true;

            retVal._applicationId = this._applicationId;
            retVal._configurationScopeId = this._configurationScopeId;
            retVal._sequenceName = this._sequenceName;
            retVal._lastSequence = this._lastSequence;
            retVal._resetOnNewDate = this._resetOnNewDate;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public bool Equals(ISequenceGenerator? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is SequenceGenerator sequenceGenerator)
            {
                retVal = InternalEquals(this, sequenceGenerator);
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
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(SequenceName);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(LastSequence);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(ResetOnNewDate);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(ISequenceGenerator? left, ISequenceGenerator? right)
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
                retVal &= EqualityComparer<String>.Default.Equals(left.SequenceName, right.SequenceName);
                retVal &= EqualityComparer<Int32>.Default.Equals(left.LastSequence, right.LastSequence);
                retVal &= EqualityComparer<Boolean>.Default.Equals(left.ResetOnNewDate, right.ResetOnNewDate);
            }

            return retVal;
        }
    }
}
