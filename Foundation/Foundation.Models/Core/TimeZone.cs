//-----------------------------------------------------------------------
// <copyright file="TimeZone.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Models.Core
{
    /// <summary>
    /// Time Zone class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="ITimeZone" />
    [DependencyInjectionTransient]
    public class TimeZone : FoundationModel, ITimeZone, IEquatable<ITimeZone>
    {
        private String _code = String.Empty;
        private String _description = String.Empty;
        private Int32 _offset;
        private Boolean _hasDaylightSavings;

        /// <inheritdoc cref="ITimeZone.Code"/>
        [Column(nameof(FDC.TimeZone.Code))]
        [MaxLength(FDC.TimeZone.Lengths.Code)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code must be provided")]
        public String Code
        {
            get => this._code;
            set => this.SetPropertyValue(ref _code, value, FDC.TimeZone.Lengths.Code);
        }

        /// <inheritdoc cref="ITimeZone.Description"/>
        [Column(nameof(FDC.TimeZone.Description))]
        [MaxLength(FDC.TimeZone.Lengths.Description)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description must be provided")]
        public String Description
        {
            get => this._description;
            set => this.SetPropertyValue(ref _description, value, FDC.TimeZone.Lengths.Description);
        }

        /// <inheritdoc cref="ITimeZone.Offset"/>
        [Column(nameof(FDC.TimeZone.Offset))]
        [Range(-12, 14)]
        public Int32 Offset
        {
            get => this._offset;
            set => this.SetPropertyValue(ref _offset, value);
        }

        /// <inheritdoc cref="ITimeZone.HasDaylightSavings"/>
        [Column(nameof(FDC.TimeZone.HasDaylightSavings))]
        public Boolean HasDaylightSavings
        {
            get => this._hasDaylightSavings;
            set => this.SetPropertyValue(ref _hasDaylightSavings, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(Code): retVal = Code; break;
                case nameof(Description): retVal = Description; break;
                case nameof(Offset): retVal = Offset; break;
                case nameof(HasDaylightSavings): retVal = HasDaylightSavings; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            TimeZone retVal = (TimeZone)base.Clone();
            retVal.Initialising = true;

            retVal._code = this._code;
            retVal._description = this._description;
            retVal._offset = this._offset;
            retVal._hasDaylightSavings = this._hasDaylightSavings;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(ITimeZone? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is TimeZone timeZone)
            {
                retVal = InternalEquals(timeZone);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Code);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Description);
            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(Offset);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(HasDaylightSavings);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(ITimeZone? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<String>.Default.Equals(this.Code, right.Code);
                retVal &= EqualityComparer<String>.Default.Equals(this.Description, right.Description);
                retVal &= EqualityComparer<Int32>.Default.Equals(this.Offset, right.Offset);
                retVal &= EqualityComparer<Boolean>.Default.Equals(this.HasDaylightSavings, right.HasDaylightSavings);
            }

            return retVal;
        }
    }
}
