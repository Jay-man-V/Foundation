//-----------------------------------------------------------------------
// <copyright file="ICategory.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace JDV.Accounts.Interfaces
{
    /// <summary>
    /// The Category model interface
    /// </summary>
    [DependencyInjectionIgnore]
    public interface ICategory : IAccountsModel, IEnumModel
    {
        /// <summary>
        /// Gets or sets the identifier of the parent category to which this category belongs.
        /// </summary>
        /// <remarks>
        /// This property is used to establish a hierarchical relationship between categories. If
        /// the value is null, it indicates that the category does not have a parent.
        /// </remarks>
        public EntityId ParentCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the category type associated with the entity.
        /// </summary>
        /// <remarks>
        /// This property specifies the category type of the entity, which can affect its
        /// classification and behavior within the system. Assigning a valid identifier is required to ensure correct
        /// categorization.
        /// </remarks>
        public EntityId CategoryTypeId { get; set; }
    }
}
