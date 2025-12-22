//-----------------------------------------------------------------------
// <copyright file="IDatePeriod.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Date Period model interface
    /// </summary>
    public interface IDatePeriod : IFoundationModel
    {
        /// <summary>Gets the Period.</summary>
        /// <value>The period.</value>
        DatePeriod Period { get; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        String Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        String Description { get; set; }
    }
}
