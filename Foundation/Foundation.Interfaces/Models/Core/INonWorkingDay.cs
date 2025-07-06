//-----------------------------------------------------------------------
// <copyright file="INonWorkingDay.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Non-Working Day model interface
    /// </summary>
    public interface INonWorkingDay : IFoundationModel
    {
        /// <summary>Gets or sets the date.</summary>
        /// <value>The date.</value>
        DateTime Date { get; set; }

        /// <summary>Gets or sets the country identifier.</summary>
        /// <value>The country identifier.</value>
        EntityId CountryId { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        String Description { get; set; }

        /// <summary>Gets or sets the notes.</summary>
        /// <value>The notes.</value>
        String Notes { get; set; }
    }
}
