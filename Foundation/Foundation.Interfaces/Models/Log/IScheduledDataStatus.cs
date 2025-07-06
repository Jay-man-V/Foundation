//-----------------------------------------------------------------------
// <copyright file="ScheduledDataStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Scheduled Data Status model interface
    /// </summary>
    public interface IScheduledDataStatus : IFoundationModel
    {
        /// <summary>
        /// The data status
        /// </summary>
        DataStatus DataStatus { get; }

        /// <summary>
        /// The Date for which the data applies to
        /// </summary>
        DateTime DataDate { get; set; }

        /// <summary>
        /// The name of the data set
        /// </summary>
        String Name { get; set; }

        /// <summary>
        /// The status of the data
        /// </summary>
        EntityId DataStatusId { get; set; }
    }
}
