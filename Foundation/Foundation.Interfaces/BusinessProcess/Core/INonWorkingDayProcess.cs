//-----------------------------------------------------------------------
// <copyright file="INonWorkingDayProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Non-Working Business process 
    /// </summary>
    public interface INonWorkingDayProcess : ICommonBusinessProcess<INonWorkingDay>
    {
        /// <summary>
        /// Applies the given filter criteria (<paramref name="year"/> and <paramref name="description"/>) to the supplied
        /// <paramref name="nonWorkingDays"/> and returns the result
        /// </summary>
        /// <param name="nonWorkingDays">The full list of <see cref="INonWorkingDay"/></param>
        /// <param name="country">The country to filter by</param>
        /// <param name="year">The year to filter by</param>
        /// <param name="description">The description to filter by</param>
        /// <returns>Filtered <see cref="List{INonWorkingDay}"/></returns>
        List<INonWorkingDay> ApplyFilter(List<INonWorkingDay> nonWorkingDays, ICountry country, String year, String description);

        /// <summary>
        /// Given the <paramref name="nonWorkingDays"/> function will create a new list of EntityIds that are Countries
        /// </summary>
        /// <param name="nonWorkingDays">The full list of non-working days</param>
        /// <returns>List of EntityIds that are countries</returns>
        List<ICountry> GetListOfNonWorkingDayCountries(IEnumerable<INonWorkingDay> nonWorkingDays);

        /// <summary>
        /// Given the <paramref name="nonWorkingDays"/> function will create a new list of Strings that are Years
        /// </summary>
        /// <param name="nonWorkingDays">The full list of non-working days</param>
        /// <returns>List of Strings that are years</returns>
        List<String> GetListOfNonWorkingDayYears(List<INonWorkingDay> nonWorkingDays);

        /// <summary>
        /// Given the <paramref name="nonWorkingDays"/> function will create a new list of Strings that are Descriptions
        /// </summary>
        /// <param name="nonWorkingDays">The full list of non-working days</param>
        /// <returns>List of Strings that are descriptions</returns>
        List<String> GetListOfNonWorkingDayDescriptions(List<INonWorkingDay> nonWorkingDays);

        /// <summary>
        /// Updates the Bank Holiday calendar by downloading the latest information from the Government source
        /// </summary>
        /// <param name="country"></param>
        void UpdateBankHolidayCalendarFromGovernmentSource(ICountry country);
    }
}
