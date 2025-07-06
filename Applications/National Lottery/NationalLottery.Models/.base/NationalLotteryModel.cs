//-----------------------------------------------------------------------
// <copyright file="NationalLotteryModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Models;
using System.Collections.Generic;

using System.ComponentModel.DataAnnotations.Schema;

namespace NationalLottery.Models
{
    /// <summary>
    /// National Lottery model
    /// </summary>
    /// <seealso cref="FoundationModel" />
    public abstract class NationalLotteryModel : FoundationModel
    {
        /// <inheritdoc cref="FoundationModel.ChangedProperties"/>
        [NotMapped]
        protected internal new IReadOnlyList<FoundationProperty> ChangedProperties => base.ChangedProperties;
    }
}
