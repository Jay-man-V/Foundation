//-----------------------------------------------------------------------
// <copyright file="IReportRunRequest.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface Report Run Request definition
    /// </summary>
    public interface IReportRunRequest
    {
        /// <summary>
        /// Gets the name of the report.
        /// </summary>
        /// <value>
        /// The name of the report.
        /// </value>
        String ReportName { get; }

        /// <summary>
        /// Adds the parameter value.
        /// </summary>
        /// <param name="parameterName">Name of the parameter.</param>
        /// <param name="parameterValue">The parameter value.</param>
        void AddParameterValue(String parameterName, Object parameterValue);

        /// <summary>
        /// Gets the parameter values.
        /// </summary>
        /// <value>
        /// The parameter values.
        /// </value>
        IReadOnlyDictionary<String, Object> ParameterValues { get; }
    }
}
