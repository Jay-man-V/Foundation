//-----------------------------------------------------------------------
// <copyright file="INationalLotteryModelRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace NationalLottery.Interfaces
{
    /// <summary>
    /// National Lottery Model data access
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    /// <seealso cref="IFoundationModelRepository&lt;T&gt;" />
    public interface INationalLotteryModelRepository<TModel> : IFoundationModelRepository<TModel> where TModel : INationalLotteryModel
    {
    }
}
