//-----------------------------------------------------------------------
// <copyright file="IVatRate.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace JDV.Accounts.Interfaces
{
    /// <summary>
    /// The Vat Rate model interface
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IVatRate : IAccountsModel
    {
        /// <summary>
        /// Gets or sets the rate used for calculations.
        /// </summary>
        /// <remarks>
        /// This property represents a decimal value that may be used in financial calculations
        /// or other computations requiring a rate. Ensure that the rate is set to a valid value before performing
        /// operations that depend on it.
        /// </remarks>
        public Decimal Rate { get; set; }

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

        /// <summary>
        /// Gets or sets the lower limit for a specified range.
        /// </summary>
        /// <remarks>
        /// This property can be set to null, indicating that there is no lower limit. When a
        /// value is provided, it defines the minimum acceptable value for the range.
        /// </remarks>
        public Decimal? LowerLimit { get; set; }

        /// <summary>
        /// Gets or sets the upper limit value, which can be used to define a maximum threshold for calculations or
        /// validations.
        /// </summary>
        /// <remarks>
        /// This property accepts a nullable decimal value. If set to null, it indicates that no
        /// upper limit is defined.
        /// </remarks>
        public Decimal? UpperLimit { get; set; }
    }
}
