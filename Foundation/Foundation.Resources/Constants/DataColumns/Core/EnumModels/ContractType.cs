//-----------------------------------------------------------------------
// <copyright file="ContractType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Resources.Constants.DataColumns
{
    /// <summary>
    /// Contract Type data columns
    /// </summary>
    /// <seealso cref="FoundationEntity" />
    public abstract class ContractType : EnumModel
    {
        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        public static String EntityName => nameof(ContractType);
    }
}
