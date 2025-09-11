//-----------------------------------------------------------------------
// <copyright file="LogSeverity.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;
using FEnums = Foundation.Interfaces;

namespace Foundation.Models
{
    /// <summary>
    /// Log Severity class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="ILogSeverity" />
    [DependencyInjectionTransient]
    public class LogSeverity : FoundationModel, ILogSeverity, IEquatable<ILogSeverity>
    {
        private String _code = String.Empty;
        private String _description = String.Empty;

        /// <inheritdoc cref="ILogSeverity.Severity"/>
        [NotMapped]
        public FEnums.LogSeverity Severity => (FEnums.LogSeverity)Id.ToInteger();

        /// <inheritdoc cref="ILogSeverity.Code"/>
        [Column(nameof(FDC.LogSeverity.Code)), MaxLength(FDC.LogSeverity.Lengths.Code)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Code must be provided")]
        public String Code
        {
            get => this._code;
            set => this.SetPropertyValue(ref _code, value, FDC.LogSeverity.Lengths.Code);
        }

        /// <inheritdoc cref="ILogSeverity.Description"/>
        [Column(nameof(FDC.LogSeverity.Description)), MaxLength(FDC.LogSeverity.Lengths.Description)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Description must be provided")]
        public String Description
        {
            get => this._description;
            set => this.SetPropertyValue(ref _description, value, FDC.LogSeverity.Lengths.Description);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(Code): retVal = Code; break;
                case nameof(Description): retVal = Description; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            LogSeverity retVal = (LogSeverity)base.Clone();
            retVal.Initialising = true;

            retVal._code = this._code;
            retVal._description = this._description;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(ILogSeverity? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is LogSeverity logSeverity)
            {
                retVal = InternalEquals(logSeverity);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode()"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Code);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Description);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(ILogSeverity? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<String>.Default.Equals(this.Code, right.Code);
                retVal &= EqualityComparer<String>.Default.Equals(this.Description, right.Description);
            }

            return retVal;
        }
    }
}
