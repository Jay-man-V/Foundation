//-----------------------------------------------------------------------
// <copyright file="ImageType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Foundation.Interfaces;

using FDC = Foundation.Resources.DataColumns;

namespace Foundation.Models
{
    /// <summary>
    /// Image Type class
    /// </summary>
    /// <seealso cref="FoundationModel" />
    /// <seealso cref="IImageType" />
    [DependencyInjectionTransient]
    public class ImageType : FoundationModel, IImageType, IEquatable<IImageType>
    {
        private String _name = String.Empty;
        private String _fileExtension = String.Empty;

        /// <inheritdoc cref="IImageType.Name"/>
        [Column(nameof(FDC.ImageType.Name))]
        [MaxLength(FDC.ImageType.Lengths.Name)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name must be provided")]
        public String Name
        {
            get => this._name;
            set => this.SetPropertyValue(ref _name, value, FDC.ImageType.Lengths.Name);
        }

        /// <inheritdoc cref="IImageType.FileExtension"/>
        [Column(nameof(FDC.ImageType.FileExtension))]
        [MaxLength(FDC.ImageType.Lengths.FileExtension)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "File Extension must be provided")]
        public String FileExtension
        {
            get => this._fileExtension;
            set => this.SetPropertyValue(ref _fileExtension, value, FDC.ImageType.Lengths.FileExtension);
        }

        /// <inheritdoc cref="IFoundationModel.GetPropertyValue(String)"/>
        public override Object? GetPropertyValue(String propertyName)
        {
            Object? retVal = base.GetPropertyValue(propertyName);

            switch (propertyName)
            {
                case nameof(Name): retVal = Name; break;
                case nameof(FileExtension): retVal = FileExtension; break;
            }

            return retVal;
        }

        /// <inheritdoc cref="ICloneable.Clone()"/>
        public override Object Clone()
        {
            ImageType retVal = (ImageType)base.Clone();
            retVal.Initialising = true;

            retVal._name = this._name;
            retVal._fileExtension = this._fileExtension;

            retVal.Initialising = false;

            return retVal;
        }

        /// <inheritdoc cref="IEquatable{TModel}.Equals(TModel)"/>
        public Boolean Equals(IImageType? other)
        {
            Boolean retVal = InternalEquals(this, other);

            return retVal;
        }

        /// <inheritdoc cref="Object.Equals(Object)"/>
        public override Boolean Equals(Object? obj)
        {
            Boolean retVal = false;

            if (obj is ImageType imageType)
            {
                retVal = InternalEquals(this, imageType);
            }

            return retVal;
        }

        /// <inheritdoc cref="Object.GetHashCode"/>
        public override Int32 GetHashCode()
        {
            Int32 constant = -1521134295;
            Int32 hashCode = base.GetHashCode();

            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(Name);
            hashCode = hashCode * constant + EqualityComparer<String>.Default.GetHashCode(FileExtension);

            return hashCode;
        }

        /// <summary>
        /// Compares the two objects for equality.
        /// </summary>
        /// <param name="left">The left object.</param>
        /// <param name="right">The right object.</param>
        /// <returns></returns>
        private static Boolean InternalEquals(IImageType? left, IImageType? right)
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

                retVal &= EqualityComparer<String>.Default.Equals(left.Name, right.Name);
                retVal &= EqualityComparer<String>.Default.Equals(left.FileExtension, right.FileExtension);
            }

            return retVal;
        }
    }
}
