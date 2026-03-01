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
    public interface ILogSeverity : IEnumModel
    {
        /// <summary>Gets the severity.</summary>
        /// <value>The severity.</value>
        LogSeverity Severity { get; }
    }
}
