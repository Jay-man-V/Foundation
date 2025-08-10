//-----------------------------------------------------------------------
// <copyright file="Contract.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Common;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Contract class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IContract" />
    /// <seealso cref="IEquatable{Contract}" />
    [DependencyInjectionTransient]
    public class Contract : FoundationModel, IContract, IEquatable<IContract>
    {
        private EntityId _contractTypeId;
        private String _contractReference = String.Empty;
        private String _shortName = String.Empty;
        private String _fullName = String.Empty;
        private DateTime _startDate;
        private DateTime _endDate;

        /// <inheritdoc cref="IContract.ContractTypeId"/>
        [Column(nameof(FDC.Contract.ContractTypeId))]
        [RequiredEntityId(EntityName = "Contract Type")]
        public EntityId ContractTypeId
        {
            get => this._contractTypeId;
            set => this.SetPropertyValue(ref _contractTypeId, value);
        }

        /// <inheritdoc cref="IContract.ContractReference"/>
        [Column(nameof(FDC.Contract.ContractReference))]
        [MaxLength(FDC.Contract.Lengths.ContractReference)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contract Reference must be provided")]
        public String ContractReference
        {
            get => this._contractReference;
            set => this.SetPropertyValue(ref _contractReference, value, FDC.Contract.Lengths.ContractReference);
        }

        /// <inheritdoc cref="IContract.ShortName"/>
        [Column(nameof(FDC.Contract.ShortName))]
        [MaxLength(FDC.Contract.Lengths.ShortName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Short Name must be provided")]
        public String ShortName
        {
            get => this._shortName;
            set => this.SetPropertyValue(ref _shortName, value, FDC.Contract.Lengths.ShortName);
        }

        /// <inheritdoc cref="IContract.FullName"/>
        [Column(nameof(FDC.Contract.FullName))]
        [MaxLength(FDC.Contract.Lengths.FullName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Full Name must be provided")]
        public String FullName
        {
            get => this._fullName;
            set => this.SetPropertyValue(ref _fullName, value, FDC.Contract.Lengths.FullName);
        }

        /// <inheritdoc cref="IContract.StartDate"/>
        [Column(nameof(FDC.Contract.StartDate))]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Start Date must be provided")]
        public DateTime StartDate
        {
            get => this._startDate;
            set => this.SetPropertyValue(ref _startDate, value);
        }

        /// <inheritdoc cref="IContract.EndDate"/>
        [Column(nameof(FDC.Contract.EndDate))]
        [Required(AllowEmptyStrings = false, ErrorMessage = "End Date must be provided")]
        public DateTime EndDate
        {
            get => this._endDate;
            set => this.SetPropertyValue(ref _endDate, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(ContractTypeId): retVal = ContractTypeId; break;
                case nameof(ContractReference): retVal = ContractReference; break;
                case nameof(ShortName): retVal = ShortName; break;
                case nameof(FullName): retVal = FullName; break;
                case nameof(StartDate): retVal = StartDate; break;
                case nameof(EndDate): retVal = EndDate; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            Contract retVal = (Contract)base.Clone();
            retVal.Initialising = true;

            retVal._contractTypeId = this._contractTypeId;
            retVal._contractReference = this._contractReference;
            retVal._shortName = this._shortName;
            retVal._fullName = this._fullName;
            retVal._startDate = this._startDate;
            retVal._endDate = this._endDate;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IContract? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is Contract contract)
            {
                retVal = InternalEquals(this, contract);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<EntityId>.Default.GetHashCode(ContractTypeId);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(ContractReference);
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
        private static Boolean InternalEquals(IContract? left, IContract? right)
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

                retVal &= EqualityComparer<EntityId>.Default.Equals(left.ContractTypeId, right.ContractTypeId);
                retVal &= EqualityComparer<String>.Default.Equals(left.ContractReference, right.ContractReference);
                retVal &= EqualityComparer<String>.Default.Equals(left.ShortName, right.ShortName);
                retVal &= EqualityComparer<String>.Default.Equals(left.FullName, right.FullName);
            }

            return retVal;
        }
    }
}
