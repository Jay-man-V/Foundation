//-----------------------------------------------------------------------
// <copyright file="OfficeWeekCalendar.cs" company="JDV Software Ltd">
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
    /// Office Week Calendar class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IOfficeWeekCalendar" />
    [DependencyInjectionTransient]
    public class OfficeWeekCalendar : FoundationModel, IOfficeWeekCalendar, IEquatable<IOfficeWeekCalendar>
    {
        private String _code = String.Empty;
        private String _shortName = String.Empty;
        private Boolean _mon;
        private Boolean _tue;
        private Boolean _wed;
        private Boolean _thu;
        private Boolean _fri;
        private Boolean _sat;
        private Boolean _sun;

        /// <inheritdoc cref="IOfficeWeekCalendar.Code"/>
        [Column(nameof(FDC.OfficeWeekCalendar.Code))]
        [MaxLength(FDC.OfficeWeekCalendar.Lengths.Code)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code must be provided")]
        public String Code
        {
            get => this._code;
            set => this.SetPropertyValue(ref _code, value, FDC.OfficeWeekCalendar.Lengths.Code);
        }

        /// <inheritdoc cref="IOfficeWeekCalendar.ShortName"/>
        [Column(nameof(FDC.OfficeWeekCalendar.ShortName))]
        [MaxLength(FDC.OfficeWeekCalendar.Lengths.ShortName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Short Name must be provided")]
        public String ShortName
        {
            get => this._shortName;
            set => this.SetPropertyValue(ref _shortName, value, FDC.OfficeWeekCalendar.Lengths.ShortName);
        }

        /// <inheritdoc cref="IOfficeWeekCalendar.Mon"/>
        [Column(nameof(FDC.OfficeWeekCalendar.Mon))]
        public Boolean Mon
        {
            get => this._mon;
            set => this.SetPropertyValue(ref _mon, value);
        }

        /// <inheritdoc cref="IOfficeWeekCalendar.Tue"/>
        [Column(nameof(FDC.OfficeWeekCalendar.Tue))]
        public Boolean Tue
        {
            get => this._tue;
            set => this.SetPropertyValue(ref _tue, value);
        }

        /// <inheritdoc cref="IOfficeWeekCalendar.Wed"/>
        [Column(nameof(FDC.OfficeWeekCalendar.Wed))]
        public Boolean Wed
        {
            get => this._wed;
            set => this.SetPropertyValue(ref _wed, value);
        }

        /// <inheritdoc cref="IOfficeWeekCalendar.Thu"/>
        [Column(nameof(FDC.OfficeWeekCalendar.Thu))]
        public Boolean Thu
        {
            get => this._thu;
            set => this.SetPropertyValue(ref _thu, value);
        }

        /// <inheritdoc cref="IOfficeWeekCalendar.Fri"/>
        [Column(nameof(FDC.OfficeWeekCalendar.Fri))]
        public Boolean Fri
        {
            get => this._fri;
            set => this.SetPropertyValue(ref _fri, value);
        }

        /// <inheritdoc cref="IOfficeWeekCalendar.Sat"/>
        [Column(nameof(FDC.OfficeWeekCalendar.Sat))]
        public Boolean Sat
        {
            get => this._sat;
            set => this.SetPropertyValue(ref _sat, value);
        }

        /// <inheritdoc cref="IOfficeWeekCalendar.Sun"/>
        [Column(nameof(FDC.OfficeWeekCalendar.Sun))]
        public Boolean Sun
        {
            get => this._sun;
            set => this.SetPropertyValue(ref _sun, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(Code): retVal = Code; break;
                case nameof(ShortName): retVal = ShortName; break;
                case nameof(Mon): retVal = Mon; break;
                case nameof(Tue): retVal = Tue; break;
                case nameof(Wed): retVal = Wed; break;
                case nameof(Thu): retVal = Thu; break;
                case nameof(Fri): retVal = Fri; break;
                case nameof(Sat): retVal = Sat; break;
                case nameof(Sun): retVal = Sun; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            OfficeWeekCalendar retVal = (OfficeWeekCalendar)base.Clone();
            retVal.Initialising = true;

            retVal._code = this._code;
            retVal._shortName = this._shortName;
            retVal._mon = this._mon;
            retVal._tue = this._tue;
            retVal._wed = this._wed;
            retVal._thu = this._thu;
            retVal._fri = this._fri;
            retVal._sat = this._sat;
            retVal._sun = this._sun;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IOfficeWeekCalendar? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is OfficeWeekCalendar officeWeekCalendar)
            {
                retVal = InternalEquals(officeWeekCalendar);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Code);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ShortName);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(Mon);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(Tue);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(Wed);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(Thu);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(Fri);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(Sat);
            hashCode = hashCode * constant + EqualityComparer<Boolean>.Default.GetHashCode(Sun);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IOfficeWeekCalendar? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<String>.Default.Equals(this.Code, right.Code);
                retVal &= EqualityComparer<String>.Default.Equals(this.ShortName, right.ShortName);
                retVal &= EqualityComparer<Boolean>.Default.Equals(this.Mon, right.Mon);
                retVal &= EqualityComparer<Boolean>.Default.Equals(this.Tue, right.Tue);
                retVal &= EqualityComparer<Boolean>.Default.Equals(this.Wed, right.Wed);
                retVal &= EqualityComparer<Boolean>.Default.Equals(this.Thu, right.Thu);
                retVal &= EqualityComparer<Boolean>.Default.Equals(this.Fri, right.Fri);
                retVal &= EqualityComparer<Boolean>.Default.Equals(this.Sat, right.Sat);
                retVal &= EqualityComparer<Boolean>.Default.Equals(this.Sun, right.Sun);
            }

            return retVal;
        }
    }
}
