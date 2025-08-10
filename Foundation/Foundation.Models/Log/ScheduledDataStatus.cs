//-----------------------------------------------------------------------
// <copyright file="ScheduledDataStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;
using FEnums = Foundation.Interfaces;

namespace Foundation.Models
{
    /// <summary>
    /// Scheduled Task class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IScheduledDataStatus" />
    [DependencyInjectionTransient]
    public class ScheduledDataStatus : FoundationModel, IScheduledDataStatus, IEquatable<IScheduledDataStatus>
    {
        private DateTime _dataDate;
        private String _name = String.Empty;
        private EntityId _dataStatusId;

        /// <inheritdoc cref="IScheduledDataStatus.DataStatus"/>
        [NotMapped]
        public FEnums.DataStatus DataStatus => (FEnums.DataStatus)this._dataStatusId.ToInteger();

        /// <inheritdoc cref="IScheduledDataStatus.DataDate"/>
        [Column(nameof(FDC.ScheduledDataStatus.DataDate))]
        public DateTime DataDate
        {
            get => this._dataDate;
            set => this.SetPropertyValue(ref _dataDate, value);
        }

        /// <inheritdoc cref="IScheduledDataStatus.Name"/>
        [Column(nameof(FDC.ScheduledDataStatus.Name))]
        [MaxLength(FDC.ScheduledDataStatus.Lengths.Name)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be provided")]
        public String Name
        {
            get => this._name;
            set => this.SetPropertyValue(ref _name, value, FDC.ScheduledDataStatus.Lengths.Name);
        }

        /// <inheritdoc cref="IScheduledDataStatus.DataStatusId"/>
        [Column(nameof(FDC.ScheduledDataStatus.DataStatusId))]
        [RequiredEntityId(EntityName = "Data Status")]
        public EntityId DataStatusId
        {
            get => this._dataStatusId;
            set => this.SetPropertyValue(ref _dataStatusId, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(DataDate): retVal = DataDate; break;
                case nameof(Name): retVal = Name; break;
                case nameof(DataStatusId): retVal = DataStatusId; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            ScheduledDataStatus retVal = (ScheduledDataStatus)base.Clone();
            retVal.Initialising = true;

            retVal._dataDate = this._dataDate;
            retVal._name = this._name;
            retVal._dataStatusId = this._dataStatusId;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IScheduledDataStatus? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is ScheduledDataStatus scheduledDataStatus)
            {
                retVal = InternalEquals(this, scheduledDataStatus);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(DataDate);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Name);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(DataStatusId);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IScheduledDataStatus? left, IScheduledDataStatus? right)
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

                retVal &= EqualityComparer<DateTime>.Default.Equals(left.DataDate, right.DataDate);
                retVal &= EqualityComparer<String>.Default.Equals(left.Name, right.Name);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.DataStatusId, right.DataStatusId);
            }

            return retVal;
        }
    }
}
