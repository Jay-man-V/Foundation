//-----------------------------------------------------------------------
// <copyright file="ILogSeverity.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Log Severity model interface
    /// </summary>
    public interface ILogSeverity : IFoundationModel
    {
        /// <summary>Gets the severity.</summary>
        /// <value>The severity.</value>
        LogSeverity Severity { get; }

        /// <summary>Gets or sets the code.</summary>
        /// <value>The code.</value>
        String Code { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        String Description { get; set; }
    }
}
