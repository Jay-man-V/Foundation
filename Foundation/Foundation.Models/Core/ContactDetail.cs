//-----------------------------------------------------------------------
// <copyright file="ContactDetail.cs" company="JDV Software Ltd">
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
    /// Contact Detail class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IContactDetail" />
    [DependencyInjectionTransient]
    public class ContactDetail : FoundationModel, IContactDetail, IEquatable<IContactDetail>
    {
        private EntityId _parentContactId;
        private EntityId _contractId;
        private EntityId _contactTypeId;
        private EntityId _nationalRegionId;
        private EntityId _countryId;
        private String _shortName = String.Empty;
        private String _displayName = String.Empty;
        private String _legalName = String.Empty;
        private String _buildingName = String.Empty;
        private String _street1 = String.Empty;
        private String _street2 = String.Empty;
        private String _town = String.Empty;
        private String _county = String.Empty;
        private String _postCode = String.Empty;
        private String _telephone1 = String.Empty;
        private String _telephone2 = String.Empty;
        private EmailAddress _emailAddress;

        /// <inheritdoc cref="IContactDetail.ParentContactId"/>
        [Column(nameof(FDC.ContactDetail.ParentContactId))]
        //[Range(-1, EntityId.MaxValue)]
        public EntityId ParentContactId
        {
            get => this._parentContactId;
            set => this.SetPropertyValue(ref _parentContactId, value);
        }

        /// <inheritdoc cref="IContactDetail.ContractId"/>
        [Column(nameof(FDC.ContactDetail.ContractId))]
        [RequiredEntityId (EntityName = "Contract")]
        public EntityId ContractId
        {
            get => this._contractId;
            set => this.SetPropertyValue(ref _contractId, value);
        }

        /// <inheritdoc cref="IContactDetail.ContactTypeId"/>
        [Column(nameof(FDC.ContactDetail.ContactTypeId))]
        [RequiredEntityId(EntityName = "Contract Type")]
        public EntityId ContactTypeId
        {
            get => this._contactTypeId;
            set => this.SetPropertyValue(ref _contactTypeId, value);
        }

        /// <inheritdoc cref="IContactDetail.NationalRegionId"/>
        [Column(nameof(FDC.ContactDetail.NationalRegionId))]
        [RequiredEntityId(EntityName = "National Region")]
        public EntityId NationalRegionId
        {
            get => this._nationalRegionId;
            set => this.SetPropertyValue(ref _nationalRegionId, value);
        }

        /// <inheritdoc cref="IContactDetail.CountryId"/>
        [Column(nameof(FDC.ContactDetail.CountryId))]
        [RequiredEntityId(EntityName = "Country")]
        public EntityId CountryId
        {
            get => this._countryId;
            set => this.SetPropertyValue(ref _countryId, value);
        }

        /// <inheritdoc cref="IContactDetail.ShortName"/>
        [Column(nameof(FDC.ContactDetail.ShortName))]
        [MaxLength(FDC.ContactDetail.Lengths.ShortName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Short Name must be provided")]
        public String ShortName
        {
            get => this._shortName;
            set => this.SetPropertyValue(ref _shortName, value, FDC.ContactDetail.Lengths.ShortName);
        }

        /// <inheritdoc cref="IContactDetail.DisplayName"/>
        [Column(nameof(FDC.ContactDetail.DisplayName))]
        [MaxLength(FDC.ContactDetail.Lengths.DisplayName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Display Name must be provided")]
        public String DisplayName
        {
            get => this._displayName;
            set => this.SetPropertyValue(ref _displayName, value, FDC.ContactDetail.Lengths.DisplayName);
        }

        /// <inheritdoc cref="IContactDetail.LegalName"/>
        [Column(nameof(FDC.ContactDetail.LegalName))]
        [MaxLength(FDC.ContactDetail.Lengths.LegalName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Legal Name must be provided")]
        public String LegalName
        {
            get => this._legalName;
            set => this.SetPropertyValue(ref _legalName, value, FDC.ContactDetail.Lengths.LegalName);
        }

        /// <inheritdoc cref="IContactDetail.BuildingName"/>
        [Column(nameof(FDC.ContactDetail.BuildingName))]
        [MaxLength(FDC.ContactDetail.Lengths.BuildingName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Building Name must be provided")]
        public String BuildingName
        {
            get => this._buildingName;
            set => this.SetPropertyValue(ref _buildingName, value, FDC.ContactDetail.Lengths.BuildingName);
        }

        /// <inheritdoc cref="IContactDetail.Street1"/>
        [Column(nameof(FDC.ContactDetail.Street1))]
        [MaxLength(FDC.ContactDetail.Lengths.Street1)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street 1 must be provided")]
        public String Street1
        {
            get => this._street1;
            set => this.SetPropertyValue(ref _street1, value, FDC.ContactDetail.Lengths.Street1);
        }

        /// <inheritdoc cref="IContactDetail.Street2"/>
        [Column(nameof(FDC.ContactDetail.Street2))]
        [MaxLength(FDC.ContactDetail.Lengths.Street2)]
        public String Street2
        {
            get => this._street2;
            set => this.SetPropertyValue(ref _street2, value, FDC.ContactDetail.Lengths.Street2);
        }

        /// <inheritdoc cref="IContactDetail.Town"/>
        [Column(nameof(FDC.ContactDetail.Town))]
        [MaxLength(FDC.ContactDetail.Lengths.Town)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Town must be provided")]
        public String Town
        {
            get => this._town;
            set => this.SetPropertyValue(ref _town, value, FDC.ContactDetail.Lengths.Town);
        }

        /// <inheritdoc cref="IContactDetail.County"/>
        [Column(nameof(FDC.ContactDetail.County))]
        [MaxLength(FDC.ContactDetail.Lengths.County)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "County must be provided")]
        public String County
        {
            get => this._county;
            set => this.SetPropertyValue(ref _county, value, FDC.ContactDetail.Lengths.County);
        }

        /// <inheritdoc cref="IContactDetail.PostCode"/>
        [Column(nameof(FDC.ContactDetail.PostCode))]
        [MaxLength(FDC.ContactDetail.Lengths.PostCode)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Post Code must be provided")]
        public String PostCode
        {
            get => this._postCode;
            set => this.SetPropertyValue(ref _postCode, value, FDC.ContactDetail.Lengths.PostCode);
        }

        /// <inheritdoc cref="IContactDetail.Telephone1"/>
        [Column(nameof(FDC.ContactDetail.Telephone1))]
        [MaxLength(FDC.ContactDetail.Lengths.Telephone1)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Telephone 1 must be provided")]
        public String Telephone1
        {
            get => this._telephone1;
            set => this.SetPropertyValue(ref _telephone1, value, FDC.ContactDetail.Lengths.Telephone1);
        }

        /// <inheritdoc cref="IContactDetail.Telephone2"/>
        [Column(nameof(FDC.ContactDetail.Telephone2))]
        [MaxLength(FDC.ContactDetail.Lengths.Telephone2)]
        public String Telephone2
        {
            get => this._telephone2;
            set => this.SetPropertyValue(ref _telephone2, value, FDC.ContactDetail.Lengths.Telephone2);
        }

        /// <inheritdoc cref="IContactDetail.EmailAddress"/>
        [Column(nameof(FDC.ContactDetail.EmailAddress))]
        [EmailAddressMaxLength(FDC.ContactDetail.Lengths.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "EmailAddress must be provided")]
        public EmailAddress EmailAddress
        {
            get => this._emailAddress;
            set => this.SetPropertyValue(ref _emailAddress, value, FDC.ContactDetail.Lengths.EmailAddress);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ParentContactId): retVal = ParentContactId; break;
                case nameof(ContractId): retVal = ContractId; break;
                case nameof(ContactTypeId): retVal = ContactTypeId; break;
                case nameof(NationalRegionId): retVal = NationalRegionId; break;
                case nameof(CountryId): retVal = CountryId; break;
                case nameof(ShortName): retVal = ShortName; break;
                case nameof(DisplayName): retVal = DisplayName; break;
                case nameof(LegalName): retVal = LegalName; break;
                case nameof(BuildingName): retVal = BuildingName; break;
                case nameof(Street1): retVal = Street1; break;
                case nameof(Street2): retVal = Street2; break;
                case nameof(Town): retVal = Town; break;
                case nameof(County): retVal = County; break;
                case nameof(PostCode): retVal = PostCode; break;
                case nameof(Telephone1): retVal = Telephone1; break;
                case nameof(Telephone2): retVal = Telephone2; break;
                case nameof(EmailAddress): retVal = EmailAddress; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            ContactDetail retVal = (ContactDetail)base.Clone();
            retVal.Initialising = true;

            retVal._parentContactId = this._parentContactId;
            retVal._contractId = this._contractId;
            retVal._contactTypeId = this._contactTypeId;
            retVal._nationalRegionId = this._nationalRegionId;
            retVal._countryId = this._countryId;
            retVal._shortName = this._shortName;
            retVal._displayName = this._displayName;
            retVal._legalName = this._legalName;
            retVal._buildingName = this._buildingName;
            retVal._street1 = this._street1;
            retVal._street2 = this._street2;
            retVal._town = this._town;
            retVal._county = this._county;
            retVal._postCode = this._postCode;
            retVal._telephone1 = this._telephone1;
            retVal._telephone2 = this._telephone2;
            retVal._emailAddress = this._emailAddress;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IContactDetail? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is ContactDetail contactDetail)
            {
                retVal = InternalEquals(this, contactDetail);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ParentContactId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ContractId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ContactTypeId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(NationalRegionId);
            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(CountryId);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ShortName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(DisplayName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(LegalName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(BuildingName);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Street1);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Street2);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Town);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(County);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(PostCode);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Telephone1);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Telephone2);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(EmailAddress);


            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IContactDetail? left, IContactDetail? right)
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

                retVal &= EqualityComparer<EntityId>.Default.Equals(left.ParentContactId, right.ParentContactId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.ContractId, right.ContractId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.ContactTypeId, right.ContactTypeId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.NationalRegionId, right.NationalRegionId);
                retVal &= EqualityComparer<EntityId>.Default.Equals(left.CountryId, right.CountryId);
                retVal &= EqualityComparer<String>.Default.Equals(left.ShortName, right.ShortName);
                retVal &= EqualityComparer<String>.Default.Equals(left.DisplayName, right.DisplayName);
                retVal &= EqualityComparer<String>.Default.Equals(left.LegalName, right.LegalName);
                retVal &= EqualityComparer<String>.Default.Equals(left.BuildingName, right.BuildingName);
                retVal &= EqualityComparer<String>.Default.Equals(left.Street1, right.Street1);
                retVal &= EqualityComparer<String>.Default.Equals(left.Street2, right.Street2);
                retVal &= EqualityComparer<String>.Default.Equals(left.Town, right.Town);
                retVal &= EqualityComparer<String>.Default.Equals(left.County, right.County);
                retVal &= EqualityComparer<String>.Default.Equals(left.PostCode, right.PostCode);
                retVal &= EqualityComparer<String>.Default.Equals(left.Telephone1, right.Telephone1);
                retVal &= EqualityComparer<String>.Default.Equals(left.Telephone2, right.Telephone2);
                retVal &= EqualityComparer<String>.Default.Equals(left.EmailAddress, right.EmailAddress);
            }

            return retVal;
        }
    }
}
