//-----------------------------------------------------------------------
// <copyright file="IProduct.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;

using Foundation.Interfaces;

namespace JDV.Accounts.Interfaces
{
    /// <summary>
    /// The Product model interface
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IProduct : IAccountsModel
    {
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
        /// Gets or sets the retail selling price for the product.
        /// </summary>
        /// <remarks>
        /// Represents the unit price charged to customers. Use `decimal` for currency precision;
        /// handle rounding and currency context elsewhere in the application. Value should be non-negative.
        /// </remarks>
        public Decimal SellPrice { get; set; }

        /// <summary>
        /// Gets or sets the purchase cost per unit for the product.
        /// </summary>
        /// <remarks>
        /// Represents the supplier/acquisition cost used for margin and cost calculations. Use `Decimal` for currency precision;
        /// do not include taxes or other overheads. Value should be non-negative and validated by business rules.
        /// </remarks>
        public Decimal PurchaseCost { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the product type associated with this product.
        /// </summary>
        /// <remarks>
        /// Used to classify the product and drive product-specific behavior (pricing, validation, UI). 
        /// identifier corresponds to a valid product type in the database.
        /// </remarks>
        public EntityId ProductTypeId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the VAT (tax) rate applied to this product.
        /// </summary>
        /// <remarks>
        /// References a VAT rate entity used when computing taxes for sales.
        /// Ensure the referenced `EntityId` maps to a valid VAT rate; tax calculation, rounding and jurisdictional rules
        /// should be handled by the billing/tax services elsewhere in the application.
        /// </remarks>
        public EntityId VatRateId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the category assigned to this product.
        /// </summary>
        /// <remarks>
        /// References a category entity used for grouping, filtering and reporting.
        /// Ensure the `EntityId` refers to a valid category; existence and business-rule validation are enforced elsewhere.
        /// </remarks>
        public EntityId CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the first subcategory assigned to this product.
        /// </summary>
        /// <remarks>
        /// References a subcategory entity used for additional grouping and filtering.
        /// Ensure the `EntityId` refers to a valid subcategory; existence and business-rule validation are enforced elsewhere.
        /// </remarks>
        public EntityId SubCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the second subcategory assigned to this product.
        /// </summary>
        /// <remarks>
        /// References a subcategory entity used for additional grouping and filtering.
        /// Ensure the `EntityId` refers to a valid subcategory; existence and business-rule validation are enforced elsewhere.
        /// </remarks>
        public EntityId SubCategory2Id { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the charge frequency applied to this product.
        /// </summary>
        /// <remarks>
        /// References a charge-frequency entity (for example: one-time, monthly, yearly) used to determine billing or recurring charge intervals.
        /// Ensure the referenced `EntityId` maps to a valid charge-frequency record; billing calculation and validation belong to billing services.
        /// </remarks>
        public EntityId ChargeFrequencyId { get; set; }
    }
}
