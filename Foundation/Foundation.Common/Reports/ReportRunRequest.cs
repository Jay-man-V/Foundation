//-----------------------------------------------------------------------
// <copyright file="ReportRunRequest.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections.ObjectModel;

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// Report Run Request definition
    /// </summary>
    public class ReportRunRequest : IReportRunRequest
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ReportRunRequest" /> class.
        /// </summary>
        /// <param name="reportName">Name of the report.</param>
        public ReportRunRequest(String reportName)
        {
            ReportName = reportName;

            MyParameterValues = [];
        }

        private Dictionary<String, Object> MyParameterValues { get; }

        /// <inheritdoc cref="ReportName"/>
        public String ReportName { get; }

        /// <inheritdoc cref="ParameterValues"/>
        public IReadOnlyDictionary<String, Object> ParameterValues => new ReadOnlyDictionary<String, Object>(MyParameterValues);

        /// <inheritdoc cref="AddParameterValue"/>
        public void AddParameterValue(String parameterName, Object parameterValue)
        {
            MyParameterValues[parameterName] = parameterValue;
        }
    }
}