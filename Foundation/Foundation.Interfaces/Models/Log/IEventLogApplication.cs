//-----------------------------------------------------------------------
// <copyright file="IEventLogApplication.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Event Log Application model interface
    /// </summary>
    public interface IEventLogApplication : IFoundationModel
    {
        /// <summary>Gets or sets the application identifier.</summary>
        /// <value>The application identifier.</value>
        AppId ApplicationId { get; set; }

        /// <summary>Gets or sets the short name.</summary>
        /// <value>The short name.</value>
        String ShortName { get; set; }

        /// <summary>Gets or sets the name of the process.</summary>
        /// <value>The name of the process.</value>
        String ProcessName { get; set; }
    }
}
