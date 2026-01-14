//-----------------------------------------------------------------------
// <copyright file="IScheduleIntervalMultiplierMatrix.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Schedule Interval Multiplier Matrix model interface
    /// </summary>
    public interface IScheduleIntervalMultiplierMatrix : IFoundationModel
    {
        /// <summary>
        /// Gets or sets the From Schedule Interval Identifier.
        /// </summary>
        /// <value></value>
        EntityId FromScheduleIntervalId { get; set; }

        /// <summary>
        /// Gets or sets the To Schedule Interval Identifier.
        /// </summary>
        /// <value></value>
        EntityId ToScheduleIntervalId { get; set; }

        /// <summary>
        /// Gets or sets the multiplier.
        /// </summary>
        /// <value>The multiplier.</value>
        Decimal Multiplier { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        String Description { get; set; }
    }
}
