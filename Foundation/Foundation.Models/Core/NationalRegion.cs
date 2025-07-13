//-----------------------------------------------------------------------
// <copyright file="NationalRegion.cs" company="JDV Software Ltd">
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
    /// National Region class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="INationalRegion" />
    [DependencyInjectionTransient]
    public class NationalRegion : FoundationModel, INationalRegion, IEquatable<INationalRegion>
    {
        private EntityId _countryId;
        private String _abbreviation = String.Empty;
        private String _shortName = String.Empty;
        private String _fullName = String.Empty;

        /// <inheritdoc cref="INationalRegion.CountryId"/>
        [Column(nameof(FDC.NationalRegion.CountryId))]
        [RequiredEntityId(EntityName = "Country")]
        public EntityId CountryId
        {
            get => this._countryId;
            set => this.SetPropertyValue(ref _countryId, value);
        }

        /// <inheritdoc cref="INationalRegion.Abbreviation"/>
        [Column(nameof(FDC.NationalRegion.Abbreviation))]
        [MaxLength(FDC.NationalRegion.Lengths.Abbreviation)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Abbreviation must be provided")]
        public String Abbreviation
        {
            get => this._abbreviation;
            set => this.SetPropertyValue(ref _abbreviation, value, FDC.NationalRegion.Lengths.Abbreviation);
        }

        /// <inheritdoc cref="INationalRegion.ShortName"/>
        [Column(nameof(FDC.NationalRegion.ShortName))]
        [MaxLength(FDC.NationalRegion.Lengths.ShortName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Short Name must be provided")]
        public String ShortName
        {
            get => this._shortName;
            set => this.SetPropertyValue(ref _shortName, value, FDC.NationalRegion.Lengths.ShortName);
        }

        /// <inheritdoc cref="INationalRegion.FullName"/>
        [Column(nameof(FDC.NationalRegion.FullName))]
        [MaxLength(FDC.NationalRegion.Lengths.FullName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Full Name must be provided")]
        public String FullName
        {
            get => this._fullName;
            set => this.SetPropertyValue(ref _fullName, value, FDC.NationalRegion.Lengths.FullName);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(CountryId): retVal = CountryId; break;
                case nameof(Abbreviation): retVal = Abbreviation; break;
                case nameof(ShortName): retVal = ShortName; break;
                case nameof(FullName): retVal = FullName; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            NationalRegion retVal = (NationalRegion)base.Clone();
            retVal.Initialising = true;

            retVal._countryId = this._countryId;
            retVal._abbreviation = this._abbreviation;
            retVal._shortName = this._shortName;
            retVal._fullName = this._fullName;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(INationalRegion? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is NationalRegion nationalRegion)
            {
                retVal = InternalEquals(this, nationalRegion);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(CountryId);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Abbreviation);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ShortName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(FullName);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(INationalRegion? left, INationalRegion? right)
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

                retVal &= EqualityComparer<EntityId>.Default.Equals(left.CountryId, right.CountryId);
                retVal &= EqualityComparer<String>.Default.Equals(left.Abbreviation, right.Abbreviation);
                retVal &= EqualityComparer<String>.Default.Equals(left.ShortName, right.ShortName);
                retVal &= EqualityComparer<String>.Default.Equals(left.FullName, right.FullName);
            }

            return retVal;
        }
    }
}
