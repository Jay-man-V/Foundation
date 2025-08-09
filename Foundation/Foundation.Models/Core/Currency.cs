//-----------------------------------------------------------------------
// <copyright file="Currency.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Interfaces;

using FDC = Foundation.Resources.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Currency class
    /// Refer to https://en.wikipedia.org/wiki/ISO_4217
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="ICurrency" />
    [DependencyInjectionTransient]
    public class Currency : FoundationModel, ICurrency, IEquatable<ICurrency>
    {
        private Boolean _prefixSymbol;
        private String _symbol = String.Empty;
        private String _isoCode = String.Empty;
        private String _isoNumber = String.Empty;
        private String _name = String.Empty;
        private Int32 _numberToBasic;

        /// <inheritdoc cref="ICurrency.PrefixSymbol"/>
        [Column(nameof(FDC.Currency.PrefixSymbol))]
        public Boolean PrefixSymbol
        {
            get => this._prefixSymbol;
            set => this.SetPropertyValue(ref _prefixSymbol, value);
        }

        /// <inheritdoc cref="ICurrency.Symbol"/>
        [Column(nameof(FDC.Currency.Symbol))]
        [MaxLength(FDC.Currency.Lengths.Symbol)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Symbol must be provided")]
        public String Symbol
        {
            get => this._symbol;
            set => this.SetPropertyValue(ref _symbol, value, FDC.Currency.Lengths.Symbol);
        }

        /// <inheritdoc cref="ICurrency.IsoCode"/>
        [Column(nameof(FDC.Currency.IsoCode))]
        [MaxLength(FDC.Currency.Lengths.IsoCode)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Iso Code must be provided")]
        public String IsoCode
        {
            get => this._isoCode;
            set => this.SetPropertyValue(ref _isoCode, value, FDC.Currency.Lengths.IsoCode);
        }

        /// <inheritdoc cref="ICurrency.IsoNumber"/>
        [Column(nameof(FDC.Currency.IsoNumber))]
        [MaxLength(FDC.Currency.Lengths.IsoNumber)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Iso Number must be provided")]
        public String IsoNumber
        {
            get => this._isoNumber;
            set => this.SetPropertyValue(ref _isoNumber, value, FDC.Currency.Lengths.IsoNumber);
        }

        /// <inheritdoc cref="ICurrency.Name"/>
        [Column(nameof(FDC.Currency.Name))]
        [MaxLength(FDC.Currency.Lengths.Name)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be provided")]
        public String Name
        {
            get => this._name;
            set => this.SetPropertyValue(ref _name, value, FDC.Currency.Lengths.Name);
        }

        /// <inheritdoc cref="ICurrency.NumberToBasic"/>
        [Column(nameof(FDC.Currency.NumberToBasic))]
        [Range(0, 10)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Number to Basic must be provided")]
        public Int32 NumberToBasic
        {
            get => this._numberToBasic;
            set => this.SetPropertyValue(ref _numberToBasic, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(PrefixSymbol): retVal = PrefixSymbol; break;
                case nameof(Symbol): retVal = Symbol; break;
                case nameof(IsoCode): retVal = IsoCode; break;
                case nameof(IsoNumber): retVal = IsoNumber; break;
                case nameof(Name): retVal = Name; break;
                case nameof(NumberToBasic): retVal = NumberToBasic; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            Currency retVal = (Currency)base.Clone();
            retVal.Initialising = true;

            retVal._prefixSymbol = this._prefixSymbol;
            retVal._symbol = this._symbol;
            retVal._isoCode = this._isoCode;
            retVal._isoNumber = this._isoNumber;
            retVal._name = this._name;
            retVal._numberToBasic = this._numberToBasic;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(ICurrency? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is Currency currency)
            {
                retVal = InternalEquals(this, currency);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(PrefixSymbol);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Symbol);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(IsoCode);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(IsoNumber);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Name);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(NumberToBasic);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(ICurrency? left, ICurrency? right)
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

                retVal &= EqualityComparer<Boolean>.Default.Equals(left.PrefixSymbol, right.PrefixSymbol);
                retVal &= EqualityComparer<String>.Default.Equals(left.Symbol, right.Symbol);
                retVal &= EqualityComparer<String>.Default.Equals(left.IsoCode, right.IsoCode);
                retVal &= EqualityComparer<String>.Default.Equals(left.IsoNumber, right.IsoNumber);
                retVal &= EqualityComparer<String>.Default.Equals(left.Name, right.Name);
                retVal &= EqualityComparer<Int32>.Default.Equals(left.NumberToBasic, right.NumberToBasic);
            }

            return retVal;
        }
    }
}
