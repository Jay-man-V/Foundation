//-----------------------------------------------------------------------
// <copyright file="WorldRegion.cs" company="JDV Software Ltd">
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
    /// World Region class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IWorldRegion" />
    [DependencyInjectionTransient]
    public class WorldRegion : FoundationModel, IWorldRegion, IEquatable<IWorldRegion>
    {
        private String _name = String.Empty;

        /// <inheritdoc cref="IWorldRegion.Name"/>
        [Column(nameof(FDC.WorldRegion.Name))]
        [MaxLength(FDC.WorldRegion.Lengths.Name)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be provided")]
        public String Name
        {
            get => this._name;
            set => this.SetPropertyValue(ref _name, value, FDC.WorldRegion.Lengths.Name);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(Name): retVal = Name; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            WorldRegion retVal = (WorldRegion)base.Clone();
            retVal.Initialising = true;

            retVal._name = this._name;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IWorldRegion? other)
        {
            Boolean retVal = InternalEquals(other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is WorldRegion worldRegion)
            {
                retVal = InternalEquals(worldRegion);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Name);

            return hashCode;
        }

        /// <summary>
        /// Compares the given object with this object for equality.
        /// </summary>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private Boolean InternalEquals(IWorldRegion? right)
        {
            Boolean retVal = base.InternalEquals(right);

            if (right != null)
            {
                retVal &= EqualityComparer<String>.Default.Equals(this.Name, right.Name);
            }

            return retVal;
        }
    }
}
