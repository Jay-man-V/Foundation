//-----------------------------------------------------------------------
// <copyright file="IReportRunResponse.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface Report Run Response definition
    /// </summary>
    public interface IReportRunResponse
    {
        /// <summary>
        /// Gets the report run request.
        /// </summary>
        /// <value>
        /// The report run request.
        /// </value>
        IReportRunRequest ReportRunRequest { get; }

        /// <summary>
        /// Gets the execution start date time.
        /// </summary>
        /// <value>
        /// The execution start date time.
        /// </value>
        DateTime ExecutionStartedOn { get; }

        /// <summary>
        /// Gets the execution end date time.
        /// </summary>
        /// <value>
        /// The execution end date time.
        /// </value>
        DateTime ExecutionFinishedOn { get; }

        /// <summary>
        /// Gets the report data.
        /// </summary>
        /// <value>
        /// The report data.
        /// </value>
        Object ReportData { get; }
    }
}
