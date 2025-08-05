//-----------------------------------------------------------------------
// <copyright file="IContactDetailProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Contact Detail Business process 
    /// </summary>
    public interface IContactDetailProcess : ICommonBusinessProcess<IContactDetail>
    {
        /// <summary>
        /// Applies the given filter criteria (<paramref name="contactType"/> and <paramref name="parentContactDetail"/>) to the supplied
        /// <paramref name="contactDetails"/> and returns the result
        /// </summary>
        /// <param name="contactDetails">The full list of <see cref="IContactDetail"/></param>
        /// <param name="contactType">The <see cref="IContactType"/> to filter by</param>
        /// <param name="parentContactDetail">The <see cref="IContactDetail"/> as a Parent Contact to filter by</param>
        /// <returns>Filtered <see cref="List{IContactDetail}"/></returns>
        List<IContactDetail> ApplyFilter(List<IContactDetail> contactDetails, IContactType contactType, IContactDetail parentContactDetail);

        /// <summary>
        /// Given the <paramref name="contactDetails"/> function will create a new list of <see cref="IContactDetail"/> that are Parents
        /// </summary>
        /// <param name="contactDetails">The full list of contact details</param>
        /// <returns>List of <see cref="IContactDetail"/> that are Parents</returns>
        List<IContactDetail> MakeListOfParentContacts(List<IContactDetail> contactDetails);
    }
}
