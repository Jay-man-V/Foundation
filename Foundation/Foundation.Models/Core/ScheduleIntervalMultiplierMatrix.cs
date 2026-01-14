//-----------------------------------------------------------------------
// <copyright file="ScheduleIntervalMultiplierMatrix.cs" company="JDV Software Ltd">
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
    /// Time Zone class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IScheduleIntervalMultiplierMatrix" />
    [DependencyInjectionTransient]
    public class ScheduleIntervalMultiplierMatrix : FoundationModel, IScheduleIntervalMultiplierMatrix, IEquatable<IScheduleIntervalMultiplierMatrix>
    {
        private EntityId _fromScheduleIntervalId;
        private EntityId _toScheduleIntervalId;
        private Decimal _multiplier;
        private String _description = String.Empty;

        /// <inheritdoc cref="IScheduleIntervalMultiplierMatrix.FromScheduleIntervalId"/>
        [Column(nameof(FDC.ScheduleIntervalMultiplierMatrix.FromScheduleIntervalId))]
        [RequiredEntityId(EntityName = "From Schedule Interval", ErrorMessage = "From Schedule Interval Id must be provided")]
        public EntityId FromScheduleIntervalId
        {
            get => this._fromScheduleIntervalId;
            set => this.SetPropertyValue(ref _fromScheduleIntervalId, value);
        }

        /// <inheritdoc cref="IScheduleIntervalMultiplierMatrix.ToScheduleIntervalId"/>
        [Column(nameof(FDC.ScheduleIntervalMultiplierMatrix.ToScheduleIntervalId))]
        [RequiredEntityId(EntityName = "To Schedule Interval", ErrorMessage = "To Schedule Interval Id must be provided")]
        public EntityId ToScheduleIntervalId
        {
            get => this._toScheduleIntervalId;
            set => this.SetPropertyValue(ref _toScheduleIntervalId, value);
        }

        /// <inheritdoc cref="IScheduleIntervalMultiplierMatrix.Multiplier"/>
        [Column(nameof(FDC.ScheduleIntervalMultiplierMatrix.Multiplier))]
        [Required(ErrorMessage = "Multiplier must be provided")]
        [Range(0, Int32.MaxValue)]
        public Decimal Multiplier
        {
            get => this._multiplier;
            set => this.SetPropertyValue(ref _multiplier, value);
        }

        /// <inheritdoc cref="IScheduleIntervalMultiplierMatrix.Description"/>
        [Column(nameof(FDC.ScheduleIntervalMultiplierMatrix.Description))]
        [MaxLength(FDC.ScheduleIntervalMultiplierMatrix.Lengths.Description)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description must be provided")]
        public String Description
        {
            get => this._description;
            set => this.SetPropertyValue(ref _description, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(FromScheduleIntervalId): retVal = FromScheduleIntervalId; break;
                case nameof(ToScheduleIntervalId): retVal = ToScheduleIntervalId; break;
                case nameof(Multiplier): retVal = Multiplier; break;
                case nameof(Description): retVal = Description; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            ScheduleIntervalMultiplierMatrix retVal = (ScheduleIntervalMultiplierMatrix)base.Clone();
            retVal.Initialising = true;

            retVal._fromScheduleIntervalId = this._fromScheduleIntervalId;
            retVal._toScheduleIntervalId = this._toScheduleIntervalId;
            retVal._multiplier = this._multiplier;
            retVal._description = this._description;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IScheduleIntervalMultiplierMatrix? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is ScheduleIntervalMultiplierMatrix scheduleIntervalMultiplierMatrix)
            {
                retVal = InternalEquals(scheduleIntervalMultiplierMatrix);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(FromScheduleIntervalId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ToScheduleIntervalId);
            hashCode = hashCode * constant + EqualityComparer<Decimal>.Default.GetHashCode(Multiplier);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Description);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IScheduleIntervalMultiplierMatrix? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<EntityId>.Default.Equals(this.FromScheduleIntervalId, right.FromScheduleIntervalId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(this.ToScheduleIntervalId, right.ToScheduleIntervalId);
                retVal &= EqualityComparer<Decimal>.Default.Equals(this.Multiplier, right.Multiplier);
                retVal &= EqualityComparer<String>.Default.Equals(this.Description, right.Description);
            }

            return retVal;
        }
    }
}
