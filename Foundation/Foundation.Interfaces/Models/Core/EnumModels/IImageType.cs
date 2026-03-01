//-----------------------------------------------------------------------
// <copyright file="IImageType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Image Type model interface
    /// </summary>
    public interface IImageType : IEnumModel
    {
        /// <summary>Gets or sets the file extension.</summary>
        /// <value>The file extension.</value>
        String FileExtension { get; set; }
    }
}
