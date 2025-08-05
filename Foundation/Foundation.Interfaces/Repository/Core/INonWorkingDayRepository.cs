//-----------------------------------------------------------------------
// <copyright file="INonWorkingDayRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Non-Working Day Data Access interface
    /// </summary>
    public interface INonWorkingDayRepository : IFoundationModelRepository<INonWorkingDay>
    {
        /// <summary>Gets the specified country identifier.</summary>
        /// <param name="countryId">The country identifier.</param>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   The non-working day
        /// </returns>
        INonWorkingDay? Get(EntityId countryId, DateTime date);
    }
}
