//-----------------------------------------------------------------------
// <copyright file="NonWorkingDay.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Common.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Non-Working Day class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="INonWorkingDay" />
    [DependencyInjectionTransient]
    public class NonWorkingDay : FoundationModel, INonWorkingDay, IEquatable<INonWorkingDay>
    {
        private DateTime _date;
        private EntityId _countryId;
        private String _description = String.Empty;
        private String _notes = String.Empty;

        /// <inheritdoc cref="INonWorkingDay.Date"/>
        [Column(nameof(FDC.NonWorkingDay.Date))]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date must be provided")]
        public DateTime Date
        {
            get => this._date;
            set => this.SetPropertyValue(ref _date, value);
        }

        /// <inheritdoc cref="INonWorkingDay.CountryId"/>
        [Column(nameof(FDC.NonWorkingDay.CountryId))]
        [RequiredEntityId(EntityName = "Country")]
        public EntityId CountryId
        {
            get => this._countryId;
            set => this.SetPropertyValue(ref _countryId, value);
        }

        /// <inheritdoc cref="INonWorkingDay.Description"/>
        [Column(nameof(FDC.NonWorkingDay.Description))]
        [MaxLength(FDC.NonWorkingDay.Lengths.Description)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description must be provided")]
        public String Description
        {
            get => this._description;
            set => this.SetPropertyValue(ref _description, value, FDC.NonWorkingDay.Lengths.Description);
        }

        /// <inheritdoc cref="INonWorkingDay.Notes"/>
        [Column(nameof(FDC.NonWorkingDay.Notes))]
        [MaxLength(FDC.NonWorkingDay.Lengths.Notes)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Notes must be provided")]
        public String Notes
        {
            get => this._notes;
            set => this.SetPropertyValue(ref _notes, value, FDC.NonWorkingDay.Lengths.Notes);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(Date): retVal = Date; break;
                case nameof(CountryId): retVal = CountryId; break;
                case nameof(Description): retVal = Description; break;
                case nameof(Notes): retVal = Notes; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            NonWorkingDay retVal = (NonWorkingDay)base.Clone();
            retVal.Initialising = true;

            retVal._date = this._date;
            retVal._countryId = this._countryId;
            retVal._description = this._description;
            retVal._notes = this._notes;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(INonWorkingDay? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is NonWorkingDay nonWorkingDay)
            {
                retVal = InternalEquals(this, nonWorkingDay);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<DateTime>.Default.GetHashCode(Date);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(CountryId);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Description);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Notes);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(INonWorkingDay? left, INonWorkingDay? right)
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

                retVal &= EqualityComparer<DateTime>.Default.Equals(left.Date, right.Date);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.CountryId, right.CountryId);
                retVal &= EqualityComparer<String>.Default.Equals(left.Description, right.Description);
                retVal &= EqualityComparer<String>.Default.Equals(left.Notes, right.Notes);
            }

            return retVal;
        }
    }
}
