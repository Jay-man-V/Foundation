//-----------------------------------------------------------------------
// <copyright file="ReportRunResponse.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Report Run Response definition
    /// </summary>
    public class ReportRunResponse : IReportRunResponse
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ReportRunResponse" /> class.
        /// </summary>
        /// <param name="reportRunRequest">The report run request.</param>
        /// <param name="startedOn">The start date time.</param>
        /// <param name="finishedOn">The end date time.</param>
        /// <param name="reportData">The report data.</param>
        public ReportRunResponse(IReportRunRequest reportRunRequest, DateTime startedOn, DateTime finishedOn, Object reportData)
        {
            ReportRunRequest = reportRunRequest;
            ExecutionStartedOn = startedOn;
            ExecutionFinishedOn = finishedOn;
            ReportData = reportData;
        }

        /// <inheritdoc cref="ReportRunRequest"/>
        public IReportRunRequest ReportRunRequest { get; }

        /// <inheritdoc cref="ExecutionStartedOn"/>
        public DateTime ExecutionStartedOn { get; }

        /// <inheritdoc cref="ExecutionFinishedOn"/>
        public DateTime ExecutionFinishedOn { get; }

        /// <inheritdoc cref="ReportData"/>
        public Object ReportData { get;  }
    }
}