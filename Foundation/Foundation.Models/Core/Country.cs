//-----------------------------------------------------------------------
// <copyright file="Country.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Common.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Country class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="ICountry" />
    [DependencyInjectionTransient]
    public class Country : FoundationModel, ICountry, IEquatable<ICountry>
    {
        private String _isoCode = String.Empty;
        private String _abbreviatedName = String.Empty;
        private String _fullName = String.Empty;
        private String _nativeName = String.Empty;
        private String _dialingCode = String.Empty;
        private String _postCodeFormat = String.Empty;
        private EntityId _currencyId;
        private EntityId _languageId;
        private EntityId _timeZoneId;
        private EntityId _worldRegionId;
        private Byte[]? _countryFlag;

        /// <inheritdoc cref="ICountry.IsoCode"/>
        [Column(nameof(FDC.Country.IsoCode))]
        [MaxLength(FDC.Country.Lengths.ISOCode)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Iso Code must be provided")]
        public String IsoCode
        {
            get => this._isoCode;
            set => this.SetPropertyValue(ref _isoCode, value, FDC.Country.Lengths.ISOCode);
        }

        /// <inheritdoc cref="ICountry.AbbreviatedName"/>
        [Column(nameof(FDC.Country.AbbreviatedName))]
        [MaxLength(FDC.Country.Lengths.AbbreviatedName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Abbreviated Name must be provided")]
        public String AbbreviatedName
        {
            get => this._abbreviatedName;
            set => this.SetPropertyValue(ref _abbreviatedName, value, FDC.Country.Lengths.AbbreviatedName);
        }

        /// <inheritdoc cref="ICountry.FullName"/>
        [Column(nameof(FDC.Country.FullName))]
        [MaxLength(FDC.Country.Lengths.FullName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Full Name must be provided")]
        public String FullName
        {
            get => this._fullName;
            set => this.SetPropertyValue(ref _fullName, value, FDC.Country.Lengths.FullName);
        }

        /// <inheritdoc cref="ICountry.NativeName"/>
        [Column(nameof(FDC.Country.NativeName))]
        [MaxLength(FDC.Country.Lengths.NativeName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Native Name must be provided")]
        public String NativeName
        {
            get => this._nativeName;
            set => this.SetPropertyValue(ref _nativeName, value, FDC.Country.Lengths.NativeName);
        }

        /// <inheritdoc cref="ICountry.DialingCode"/>
        [Column(nameof(FDC.Country.DialingCode))]
        [MaxLength(FDC.Country.Lengths.DiallingCode)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Dialing Code must be provided")]
        public String DialingCode
        {
            get => this._dialingCode;
            set => this.SetPropertyValue(ref _dialingCode, value, FDC.Country.Lengths.DiallingCode);
        }

        /// <inheritdoc cref="ICountry.PostCodeFormat"/>
        [Column(nameof(FDC.Country.PostCodeFormat))]
        [MaxLength(FDC.Country.Lengths.PostCodeFormat)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Post Code Format must be provided")]
        public String PostCodeFormat
        {
            get => this._postCodeFormat;
            set => this.SetPropertyValue(ref _postCodeFormat, value, FDC.Country.Lengths.PostCodeFormat);
        }

        /// <inheritdoc cref="ICountry.CurrencyId"/>
        [Column(nameof(FDC.Country.CurrencyId))]
        [RequiredEntityId(EntityName = "Currency")]
        public EntityId CurrencyId
        {
            get => this._currencyId;
            set => this.SetPropertyValue(ref _currencyId, value);
        }

        /// <inheritdoc cref="ICountry.LanguageId"/>
        [Column(nameof(FDC.Country.LanguageId))]
        [RequiredEntityId(EntityName = "Language")]
        public EntityId LanguageId
        {
            get => this._languageId;
            set => this.SetPropertyValue(ref _languageId, value);
        }

        /// <inheritdoc cref="ICountry.TimeZoneId"/>
        [Column(nameof(FDC.Country.TimeZoneId))]
        [RequiredEntityId(EntityName = "Time Zone")]
        public EntityId TimeZoneId
        {
            get => this._timeZoneId;
            set => this.SetPropertyValue(ref _timeZoneId, value);
        }

        /// <inheritdoc cref="ICountry.WorldRegionId"/>
        [Column(nameof(FDC.Country.WorldRegionId))]
        [RequiredEntityId(EntityName = "World Region")]
        public EntityId WorldRegionId
        {
            get => this._worldRegionId;
            set => this.SetPropertyValue(ref _worldRegionId, value);
        }

        /// <inheritdoc cref="ICountry.CountryFlag"/>
        [Column(nameof(FDC.Country.CountryFlag))]
        [Required(ErrorMessage = "Country Flag must be provided")]
        public Byte[]? CountryFlag
        {
            get => this._countryFlag;
            set => this.SetPropertyValue(ref _countryFlag, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(IsoCode): retVal = IsoCode; break;
                case nameof(AbbreviatedName): retVal = AbbreviatedName; break;
                case nameof(FullName): retVal = FullName; break;
                case nameof(NativeName): retVal = NativeName; break;
                case nameof(DialingCode): retVal = DialingCode; break;
                case nameof(PostCodeFormat): retVal = PostCodeFormat; break;
                case nameof(CurrencyId): retVal = CurrencyId; break;
                case nameof(LanguageId): retVal = LanguageId; break;
                case nameof(TimeZoneId): retVal = TimeZoneId; break;
                case nameof(WorldRegionId): retVal = WorldRegionId; break;
                case nameof(CountryFlag): retVal = CountryFlag; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            Country retVal = (Country)base.Clone();
            retVal.Initialising = true;

            retVal._isoCode = this._isoCode;
            retVal._abbreviatedName = this._abbreviatedName;
            retVal._fullName = this._fullName;
            retVal._nativeName = this._nativeName;
            retVal._dialingCode = this._dialingCode;
            retVal._postCodeFormat = this._postCodeFormat;
            retVal._currencyId = this._currencyId;
            retVal._languageId = this._languageId;
            retVal._timeZoneId = this._timeZoneId;
            retVal._worldRegionId = this._worldRegionId;
            retVal._countryFlag = this._countryFlag;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(ICountry? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj.IsNotNull() &&
                obj is Country country)
            {
                retVal = InternalEquals(this, country);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(IsoCode);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(AbbreviatedName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(FullName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(NativeName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(DialingCode);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(PostCodeFormat);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(CurrencyId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(LanguageId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(TimeZoneId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(WorldRegionId);

            if (CountryFlag != null)
            {
                hashCode = hashCode * constant + StructuralComparisons.StructuralEqualityComparer.GetHashCode(CountryFlag);
            }

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(ICountry? left, ICountry? right)
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

                retVal &= EqualityComparer<String>.Default.Equals(left.IsoCode, right.IsoCode);
                retVal &= EqualityComparer<String>.Default.Equals(left.AbbreviatedName, right.AbbreviatedName);
                retVal &= EqualityComparer<String>.Default.Equals(left.FullName, right.FullName);
                retVal &= EqualityComparer<String>.Default.Equals(left.NativeName, right.NativeName);
                retVal &= EqualityComparer<String>.Default.Equals(left.DialingCode, right.DialingCode);
                retVal &= EqualityComparer<String>.Default.Equals(left.PostCodeFormat, right.PostCodeFormat);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.CurrencyId, right.CurrencyId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.LanguageId, right.LanguageId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.TimeZoneId, right.TimeZoneId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.WorldRegionId, right.WorldRegionId);
                retVal &= StructuralComparisons.StructuralEqualityComparer.Equals(left.CountryFlag, left.CountryFlag);
            }

            return retVal;
        }
    }
}
