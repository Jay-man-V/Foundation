//-----------------------------------------------------------------------
// <copyright file="ConfigurationScope.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Models.Core.EnumModels
{
    /// <summary>
    /// Approval Status class
    /// </summary>
    /// <seealso cref="EnumModel" />
    /// <seealso cref="IConfigurationScope" />
    /// <seealso cref="IEquatable{IConfigurationScope}" />
    [DependencyInjectionTransient]
    public class ConfigurationScope : EnumModel, IConfigurationScope, IEquatable<IConfigurationScope>
    {
        //private String _name = String.Empty;
        //private String _description = String.Empty;
        private Int32 _usageSequence;

        ///// <inheritdoc cref="IConfigurationScope.Name"/>
        //[Column(nameof(FDC.ConfigurationScope.Name))]
        //[MaxLength(FDC.ConfigurationScope.Lengths.Name)]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Name must be provided")]
        //public String Name
        //{
        //    get => this._name;
        //    set => this.SetPropertyValue(ref _name, value, FDC.ConfigurationScope.Lengths.Name);
        //}

        ///// <inheritdoc cref="IConfigurationScope.Description"/>
        //[Column(nameof(FDC.ConfigurationScope.Description))]
        //[MaxLength(FDC.ConfigurationScope.Lengths.Description)]
        //[Required(AllowEmptyStrings = false, ErrorMessage = "Description must be provided")]
        //public String Description
        //{
        //    get => this._description;
        //    set => this.SetPropertyValue(ref _description, value, FDC.ConfigurationScope.Lengths.Description);
        //}

        /// <inheritdoc cref="IConfigurationScope.UsageSequence"/>
        [Column(nameof(FDC.ConfigurationScope.UsageSequence))]
        public Int32 UsageSequence
        {
            get => this._usageSequence;
            set => this.SetPropertyValue(ref _usageSequence, value);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(UsageSequence): retVal = UsageSequence; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            ConfigurationScope retVal = (ConfigurationScope)base.Clone();
            retVal.Initialising = true;

            retVal._usageSequence = this._usageSequence;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IConfigurationScope? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is ConfigurationScope configurationScope)
            {
                retVal = InternalEquals(configurationScope);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<Int32>.Default.GetHashCode(UsageSequence);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IConfigurationScope? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<Int32>.Default.Equals(this.UsageSequence, right.UsageSequence);
            }

            return retVal;
        }
    }
}
