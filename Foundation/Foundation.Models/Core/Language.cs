//-----------------------------------------------------------------------
// <copyright file="Language.cs" company="JDV Software Ltd">
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
    /// Language class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="ILanguage" />
    [DependencyInjectionTransient]
    public class Language : FoundationModel, ILanguage, IEquatable<ILanguage>
    {
        private String _englishName = String.Empty;
        private String _nativeName = String.Empty;
        private String _cultureCode = String.Empty;
        private String _uiCultureCode = String.Empty;

        /// <inheritdoc cref="ILanguage.EnglishName"/>
        [Column(nameof(FDC.Language.EnglishName))]
        [MaxLength(FDC.Language.Lengths.EnglishName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "English Name must be provided")]
        public String EnglishName
        {
            get => this._englishName;
            set => this.SetPropertyValue(ref _englishName, value, FDC.Language.Lengths.EnglishName);
        }

        /// <inheritdoc cref="ILanguage.NativeName"/>
        [Column(nameof(FDC.Language.NativeName))]
        [MaxLength(FDC.Language.Lengths.NativeName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Native Name must be provided")]
        public String NativeName
        {
            get => this._nativeName;
            set => this.SetPropertyValue(ref _nativeName, value, FDC.Language.Lengths.NativeName);
        }

        /// <inheritdoc cref="ILanguage.CultureCode"/>
        [Column(nameof(FDC.Language.CultureCode))]
        [MaxLength(FDC.Language.Lengths.CultureCode)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Culture Code must be provided")]
        public String CultureCode
        {
            get => this._cultureCode;
            set => this.SetPropertyValue(ref _cultureCode, value, FDC.Language.Lengths.CultureCode);
        }

        /// <inheritdoc cref="ILanguage.UiCultureCode"/>
        [Column(nameof(FDC.Language.UiCultureCode))]
        [MaxLength(FDC.Language.Lengths.UiCultureCode)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ui Culture Code must be provided")]
        public String UiCultureCode
        {
            get => this._uiCultureCode;
            set => this.SetPropertyValue(ref _uiCultureCode, value, FDC.Language.Lengths.UiCultureCode);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(EnglishName): retVal = EnglishName; break;
                case nameof(NativeName): retVal = NativeName; break;
                case nameof(CultureCode): retVal = CultureCode; break;
                case nameof(UiCultureCode): retVal = UiCultureCode; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            Language retVal = (Language)base.Clone();
            retVal.Initialising = true;

            retVal._englishName = this._englishName;
            retVal._nativeName = this._nativeName;
            retVal._cultureCode = this._cultureCode;
            retVal._uiCultureCode = this._uiCultureCode;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(ILanguage? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is Language language)
            {
                retVal = InternalEquals(this, language);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(EnglishName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(NativeName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(CultureCode);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(UiCultureCode);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(ILanguage? left, ILanguage? right)
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

                retVal &= EqualityComparer<String>.Default.Equals(left.EnglishName, right.EnglishName);
                retVal &= EqualityComparer<String>.Default.Equals(left.NativeName, right.NativeName);
                retVal &= EqualityComparer<String>.Default.Equals(left.CultureCode, right.CultureCode);
                retVal &= EqualityComparer<String>.Default.Equals(left.UiCultureCode, right.UiCultureCode);
            }

            return retVal;
        }
    }
}
