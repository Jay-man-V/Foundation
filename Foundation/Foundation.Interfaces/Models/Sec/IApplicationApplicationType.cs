//-----------------------------------------------------------------------
// <copyright file="IApplicationApplicationType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Application/Application Type model interface
    /// </summary>
    public interface IApplicationApplicationType : IFoundationModel
    {
        /// <summary>Gets or sets the application identifier.</summary>
        /// <value>The application identifier.</value>
        AppId ApplicationId { get; set; }

        /// <summary>Gets or sets the application type identifier.</summary>
        /// <value>The application type identifier.</value>
        EntityId ApplicationTypeId { get; set; }
    }
}
