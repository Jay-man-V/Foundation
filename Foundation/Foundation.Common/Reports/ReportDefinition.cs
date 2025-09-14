//-----------------------------------------------------------------------
// <copyright file="ReportDefinition.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the Report Definition
    /// </summary>
    /// <seealso cref="IReportDefinition" />
    public class ReportDefinition : IReportDefinition
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ReportDefinition"/> class.
        /// </summary>
        /// <param name="dateTimeService">The date time service.</param>
        public ReportDefinition(IDateTimeService dateTimeService)
        {
            DateTimeService = dateTimeService;

            Title = String.Empty;
            SubTitle = String.Empty;
            PageHeader = String.Empty;
            PageFooter = String.Empty;
            GeneratedOn = DateTimeService.SystemDateTimeNow;
            RequestedBy = String.Empty;
            Columns = [];
            DataSource = null;
        }

        /// <summary>
        /// Gets the date time service.
        /// </summary>
        /// <value>
        /// The date time service.
        /// </value>
        private IDateTimeService DateTimeService { get; }

        /// <inheritdoc cref="Title"/>
        public String Title { get; set; }

        /// <inheritdoc cref="SubTitle"/>
        public String SubTitle { get; set; }

        /// <inheritdoc cref="PageHeader"/>
        public String PageHeader { get; set; }

        /// <inheritdoc cref="PageFooter"/>
        public String PageFooter { get; set; }

        /// <inheritdoc cref="GeneratedOn"/>
        public DateTime GeneratedOn { get; set; }

        /// <inheritdoc cref="RequestedBy"/>
        public String RequestedBy { get; set; }

        /// <inheritdoc cref="Columns"/>
        public List<IGridColumnDefinition> Columns { get; set; }

        /// <inheritdoc cref="DataSource"/>
        public Object? DataSource { get; set; }
    }
}
