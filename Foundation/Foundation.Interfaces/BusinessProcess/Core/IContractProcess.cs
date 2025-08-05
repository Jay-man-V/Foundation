//-----------------------------------------------------------------------
// <copyright file="IContractProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Contract Business process 
    /// </summary>
    public interface IContractProcess : ICommonBusinessProcess<IContract>
    {
        /// <summary>
        /// Applies the given filter criteria (<paramref name="contractType"/>) to the supplied
        /// <paramref name="contracts"/> and returns the result
        /// </summary>
        /// <param name="contracts">The full list of <see cref="IContract"/></param>
        /// <param name="contractType">The <see cref="IContractType"/> to filter by</param>
        /// <returns>Filtered <see cref="List{IContract}"/></returns>
        List<IContract> ApplyFilter(List<IContract> contracts, IContractType contractType);
    }
}
