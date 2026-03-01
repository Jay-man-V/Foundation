//-----------------------------------------------------------------------
// <copyright file="EnumModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Approval Status class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IEnumModel" />
    public class EnumModel : FoundationModel, IEnumModel, IEquatable<IEnumModel>
    {
        private Int16 _displaySequence = 0;
        private String _code = String.Empty;
        private String _shortDescription = String.Empty;
        private String _longDescription = String.Empty;

        /// <inheritdoc cref="IEnumModel.DisplaySequence"/>
        [Column(nameof(FDC.EnumModel.DisplaySequence))]
        public Int16 DisplaySequence
        {
            get => this._displaySequence;
            set => this.SetPropertyValue(ref _displaySequence, value);
        }

        /// <inheritdoc cref="IEnumModel.Code"/>
        [Column(nameof(FDC.EnumModel.Code))]
        [MaxLength(FDC.EnumModel.Lengths.Code)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code must be provided")]
        public String Code
        {
            get => this._code;
            set => this.SetPropertyValue(ref _code, value, FDC.EnumModel.Lengths.Code);
        }

        /// <inheritdoc cref="IEnumModel.ShortDescription"/>
        [Column(nameof(FDC.EnumModel.ShortDescription))]
        [MaxLength(FDC.EnumModel.Lengths.ShortDescription)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Short Description must be provided")]
        public String ShortDescription
        {
            get => this._shortDescription;
            set => this.SetPropertyValue(ref _shortDescription, value, FDC.EnumModel.Lengths.ShortDescription);
        }

        /// <inheritdoc cref="IEnumModel.LongDescription"/>
        [Column(nameof(FDC.EnumModel.LongDescription))]
        [MaxLength(FDC.EnumModel.Lengths.LongDescription)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Long Description must be provided")]
        public String LongDescription
        {
            get => this._longDescription;
            set => this.SetPropertyValue(ref _longDescription, value, FDC.EnumModel.Lengths.LongDescription);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(DisplaySequence): retVal = DisplaySequence; break;
                case nameof(Code): retVal = Code; break;
                case nameof(ShortDescription): retVal = ShortDescription; break;
                case nameof(LongDescription): retVal = LongDescription; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            EnumModel retVal = (EnumModel)base.Clone();
            retVal.Initialising = true;

            retVal._displaySequence = this._displaySequence;
            retVal._code = this._code;
            retVal._shortDescription = this._shortDescription;
            retVal._longDescription = this._longDescription;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IEnumModel? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is IEnumModel enumModel)
            {
                retVal = InternalEquals(enumModel);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<Int16>.Default.GetHashCode(DisplaySequence);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Code);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ShortDescription);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(LongDescription);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IEnumModel? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<Int16>.Default.Equals(this.DisplaySequence, right.DisplaySequence);
                retVal &= EqualityComparer<String>.Default.Equals(this.Code, right.Code);
                retVal &= EqualityComparer<String>.Default.Equals(this.ShortDescription, right.ShortDescription);
                retVal &= EqualityComparer<String>.Default.Equals(this.LongDescription, right.LongDescription);
            }

            return retVal;
        }
    }
}
