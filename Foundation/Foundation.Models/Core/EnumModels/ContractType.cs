//-----------------------------------------------------------------------
// <copyright file="ContractType.cs" company="JDV Software Ltd">
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
    /// Contract Type class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IContractType" />
    /// <seealso cref="IEquatable{ContractType}" />
    [DependencyInjectionTransient]
    public class ContractType : FoundationModel, IContractType, IEquatable<IContractType>
    {
        private String _name = String.Empty;
        private String _description = String.Empty;

        /// <inheritdoc cref="IContractType.Name"/>
        [Column(nameof(FDC.ContractType.Name))]
        [MaxLength(FDC.ContractType.Lengths.Name)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be provided")]
        public String Name
        {
            get => this._name;
            set => this.SetPropertyValue(ref _name, value, FDC.ContractType.Lengths.Name);
        }

        /// <inheritdoc cref="IContractType.Description"/>
        [Column(nameof(FDC.ContractType.Description))]
        [MaxLength(FDC.ContractType.Lengths.Description)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description must be provided")]
        public String Description
        {
            get => this._description;
            set => this.SetPropertyValue(ref _description, value, FDC.ContractType.Lengths.Description);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(Name): retVal = Name; break;
                case nameof(Description): retVal = Description; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            ContractType retVal = (ContractType)base.Clone();
            retVal.Initialising = true;

            retVal._name = this._name;
            retVal._description = this._description;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IContractType? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is ContractType contractType)
            {
                retVal = InternalEquals(contractType);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Name);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Description);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IContractType? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<String>.Default.Equals(this.Name, right.Name);
                retVal &= EqualityComparer<String>.Default.Equals(this.Description, right.Description);
            }

            return retVal;
        }
    }
}
