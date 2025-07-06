//-----------------------------------------------------------------------
// <copyright file="IOfficeWeekCalendar.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Office Week Calendar model interface
    /// </summary>
    public interface IOfficeWeekCalendar : IFoundationModel
    {
        /// <summary>Gets or sets the code.</summary>
        /// <value>The code.</value>
        String Code { get; set; }

        /// <summary>Gets or sets the short name.</summary>
        /// <value>The short name.</value>
        String ShortName { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="IOfficeWeekCalendar" /> is mon.</summary>
        /// <value>
        ///   <c>true</c> if mon; otherwise, <c>false</c>.</value>
        Boolean Mon { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="IOfficeWeekCalendar" /> is tue.</summary>
        /// <value>
        ///   <c>true</c> if tue; otherwise, <c>false</c>.</value>
        Boolean Tue { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="IOfficeWeekCalendar" /> is wed.</summary>
        /// <value>
        ///   <c>true</c> if wed; otherwise, <c>false</c>.</value>
        Boolean Wed { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="IOfficeWeekCalendar" /> is thu.</summary>
        /// <value>
        ///   <c>true</c> if thu; otherwise, <c>false</c>.</value>
        Boolean Thu { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="IOfficeWeekCalendar" /> is fri.</summary>
        /// <value>
        ///   <c>true</c> if fri; otherwise, <c>false</c>.</value>
        Boolean Fri { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="IOfficeWeekCalendar" /> is sat.</summary>
        /// <value>
        ///   <c>true</c> if sat; otherwise, <c>false</c>.</value>
        Boolean Sat { get; set; }

        /// <summary>Gets or sets a value indicating whether this <see cref="IOfficeWeekCalendar" /> is sun.</summary>
        /// <value>
        ///   <c>true</c> if sun; otherwise, <c>false</c>.</value>
        Boolean Sun { get; set; }
    }
}
