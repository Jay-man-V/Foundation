//-----------------------------------------------------------------------
// <copyright file="Office.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Office class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IOffice" />
    [DependencyInjectionTransient]
    public class Office : FoundationModel, IOffice, IEquatable<IOffice>
    {
        private String _code = String.Empty;
        private String _shortName = String.Empty;
        private EntityId _contactDetailId;
        private EntityId _officeWeekCalendarId;

        /// <inheritdoc cref="IOffice.Code"/>
        [Column(nameof(FDC.Office.Code))]
        [MaxLength(FDC.Office.Lengths.Code)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code must be provided")]
        public String Code
        {
            get => this._code;
            set => this.SetPropertyValue(ref _code, value, FDC.Office.Lengths.Code);
        }

        /// <inheritdoc cref="IOffice.ShortName"/>
        [Column(nameof(FDC.Office.ShortName))]
        [MaxLength(FDC.Office.Lengths.ShortName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Short Name must be provided")]
        public String ShortName
        {
            get => this._shortName;
            set => this.SetPropertyValue(ref _shortName, value, FDC.Office.Lengths.ShortName);
        }

        /// <inheritdoc cref="IOffice.ContactDetailId"/>
        [Column(nameof(FDC.Office.ContactDetailId))]
        [RequiredEntityId(EntityName = "Contact Detail")]
        public EntityId ContactDetailId
        {
            get => this._contactDetailId;
            set => this.SetPropertyValue(ref _contactDetailId, value);
        }

        /// <inheritdoc cref="IOffice.OfficeWeekCalendarId"/>
        [Column(nameof(FDC.Office.OfficeWeekCalendarId))]
        [RequiredEntityId(EntityName = "Office Week Calendar")]
        public EntityId OfficeWeekCalendarId
        {
            get => this._officeWeekCalendarId;
            set => this.SetPropertyValue(ref _officeWeekCalendarId, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(Code): retVal = Code; break;
                case nameof(ShortName): retVal = ShortName; break;
                case nameof(ContactDetailId): retVal = ContactDetailId; break;
                case nameof(OfficeWeekCalendarId): retVal = OfficeWeekCalendarId; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            Office retVal = (Office)base.Clone();
            retVal.Initialising = true;

            retVal._code = this._code;
            retVal._shortName = this._shortName;
            retVal._contactDetailId = this._contactDetailId;
            retVal._officeWeekCalendarId = this._officeWeekCalendarId;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IOffice? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is Office office)
            {
                retVal = InternalEquals(this, office);
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
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ContactDetailId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(OfficeWeekCalendarId);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IOffice? left, IOffice? right)
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

                retVal &= EqualityComparer<String>.Default.Equals(left.Code, right.Code);
                retVal &= EqualityComparer<String>.Default.Equals(left.ShortName, right.ShortName);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.ContactDetailId, right.ContactDetailId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.OfficeWeekCalendarId, right.OfficeWeekCalendarId);
            }

            return retVal;
        }
    }
}
