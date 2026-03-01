//-----------------------------------------------------------------------
// <copyright file="ImageType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// ImageType data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ImageType : EnumModel
    {
        /// <summary>
        /// 
        /// </summary>
        public new abstract class Lengths : EnumModel.Lengths
        {
            /// <summary>
            /// The file extension
            /// </summary>
            public const Int32 FileExtension = 50;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public static String EntityName => nameof(ImageType);

        /// <summary>
        /// Gets the file extension.
        /// </summary>
        /// <value>
        /// The file extension.
        /// </value>
        public static String FileExtension => "FileExtension";
    }
}
