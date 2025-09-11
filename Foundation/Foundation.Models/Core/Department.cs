//-----------------------------------------------------------------------
// <copyright file="Department.cs" company="JDV Software Ltd">
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
    /// Department class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IDepartment" />
    [DependencyInjectionTransient]
    public class Department : FoundationModel, IDepartment, IEquatable<IDepartment>
    {
        private String _code = String.Empty;
        private String _shortName = String.Empty;
        private String _description = String.Empty;

        /// <inheritdoc cref="IDepartment.Code"/>
        [Column(nameof(FDC.Department.Code))]
        [MaxLength(FDC.Department.Lengths.Code)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code must be provided")]
        public String Code
        {
            get => this._code;
            set => this.SetPropertyValue(ref _code, value, FDC.Department.Lengths.Code);
        }

        /// <inheritdoc cref="IDepartment.ShortName"/>
        [Column(nameof(FDC.Department.ShortName))]
        [MaxLength(FDC.Department.Lengths.ShortName)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Short Name must be provided")]
        public String ShortName
        {
            get => this._shortName;
            set => this.SetPropertyValue(ref _shortName, value, FDC.Department.Lengths.ShortName);
        }

        /// <inheritdoc cref="IDepartment.Description"/>
        [Column(nameof(FDC.Department.Description))]
        [MaxLength(FDC.Department.Lengths.Description)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description must be provided")]
        public String Description
        {
            get => this._description;
            set => this.SetPropertyValue(ref _description, value, FDC.Department.Lengths.Description);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(Code): retVal = Code; break;
                case nameof(ShortName): retVal = ShortName; break;
                case nameof(Description): retVal = Description; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            Department retVal = (Department)base.Clone();
            retVal.Initialising = true;

            retVal._code = this._code;
            retVal._shortName = this._shortName;
            retVal._description = this._description;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IDepartment? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is Department department)
            {
                retVal = InternalEquals(department);
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
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Description);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IDepartment? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<String>.Default.Equals(this.Code, right.Code);
                retVal &= EqualityComparer<String>.Default.Equals(this.ShortName, right.ShortName);
                retVal &= EqualityComparer<String>.Default.Equals(this.Description, right.Description);
            }

            return retVal;
        }
    }
}
