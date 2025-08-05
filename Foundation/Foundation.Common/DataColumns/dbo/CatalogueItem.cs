//-----------------------------------------------------------------------
// <copyright file="CatalogueItem.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Common.DataColumns
{
    /// <summary>
    /// Catalogue Item data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class CatalogueItem : FoundationEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public abstract class Lengths
        {
            /// <summary>
            /// The key name
            /// </summary>
            public const Int32 KeyName = 500;

            /// <summary>
            /// The key value
            /// </summary>
            public const Int32 KeyValue = Int32.MaxValue;
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public static String EntityName => nameof(CatalogueItem);

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public static String Name => "Name";

        /// <summary>
        /// Gets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public static String Description => "Description";

        /// <summary>
        /// Gets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public static String Image => "Image";

        /// <summary>
        /// Gets the buy cost.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public static String BuyCost => "BuyCost";

        /// <summary>
        /// Gets the vat rate id.
        /// </summary>
        /// <value>
        /// The vat rate id.
        /// </value>
        public static String VatRateId => "VatRateId";

        /// <summary>
        /// Gets the mark up rate id.
        /// </summary>
        /// <value>
        /// The mark up rate id.
        /// </value>
        public static String MarkUpRateId => "MarkUpRateId";
    }
}
