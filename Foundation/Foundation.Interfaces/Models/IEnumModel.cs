//-----------------------------------------------------------------------
// <copyright file="IEnumModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The generic Enum model interface
    /// </summary>
    public interface IEnumModel : IFoundationModel
    {
        /// <summary>
        /// Gets or sets the display sequence number associated with the item.
        /// </summary>
        /// <remarks>
        /// The display sequence number can be used to determine the order of items.
        /// </remarks>
        public Int16 DisplaySequence { get; set; }

        /// <summary>
        /// Gets or sets the short, machine-friendly code that uniquely identifies the category.
        /// </summary>
        /// <remarks>
        /// Intended as a concise identifier for lookups, serialization and business rules. Should be short,
        /// unique within its scope and use a stable format (e.g. alphanumeric with optional '-' or '_') — avoid long or user-facing text.
        /// </remarks>
        public String Code { get; set; }

        /// <summary>
        /// Gets or sets a concise, human-readable description of the category.
        /// </summary>
        /// <remarks>
        /// Intended for brief display in lists or UI elements; keep this short and informative
        /// (usually a single sentence or a short phrase).
        /// </remarks>
        public String ShortDescription { get; set; }

        /// <summary>
        /// Gets or sets the detailed description of the item.
        /// </summary>
        /// <remarks>
        /// This property can hold a lengthy text that provides additional context or information
        /// about the item it describes.
        /// </remarks>
        public String LongDescription { get; set; }
    }
}
