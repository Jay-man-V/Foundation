//-----------------------------------------------------------------------
// <copyright file="IOffice.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Office model interface
    /// </summary>
    public interface IOffice : IFoundationModel
    {
        /// <summary>Gets or sets the code.</summary>
        /// <value>The code.</value>
        String Code { get; set; }

        /// <summary>Gets or sets the short name.</summary>
        /// <value>The short name.</value>
        String ShortName { get; set; }

        /// <summary>Gets or sets the contact detail identifier.</summary>
        /// <value>The contact detail identifier.</value>
        EntityId ContactDetailId { get; set; }

        /// <summary>Gets or sets the office week calendar identifier.</summary>
        /// <value>The office week calendar identifier.</value>
        EntityId OfficeWeekCalendarId { get; set; }
    }
}
