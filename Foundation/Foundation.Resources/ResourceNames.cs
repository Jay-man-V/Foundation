//-----------------------------------------------------------------------
// <copyright file="ResourceNames.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Resources
{
    /// <summary>
    /// Defines the resource names
    /// </summary>
    public class ResourceNames
    {
        /// <summary>
        /// Defines the EMail Template Resource Names
        /// </summary>
        public static class EMailTemplates
        {
            /// <summary>
            /// Gets the formal email template.
            /// </summary>
            /// <value>The formal email template.</value>
            public static String FormalEmailTemplate => "Foundation.Resources.EmailTemplates.Formal Template.html";
        }

        /// <summary>
        /// Defines the Report Template Resource Names
        /// </summary>
        public static class ReportTemplates
        {
            /// <summary>
            /// Gets the excel simple report template landscape.
            /// </summary>
            /// <value>The excel simple report template landscape.</value>
            public static String ExcelSimpleReportTemplateLandscape => @"ReportTemplates\Excel Simple Report Template - Landscape.xltx";

            /// <summary>
            /// Gets the excel simple report template portrait.
            /// </summary>
            /// <value>The excel simple report template portrait.</value>
            public static String ExcelSimpleReportTemplatePortrait => @"ReportTemplates\Excel Simple Report Template - Portrait.xltx";
        }

        /// <summary>
        ///   <br />
        /// </summary>
        public static class Logos
        {
            /// <summary>
            /// Gets the company logo.
            /// </summary>
            /// <value>The company logo.</value>
            public static String CompanyLogo => "Foundation.Resources.Images.Logos.JDV Software Logo.png";
        }
    }
}
