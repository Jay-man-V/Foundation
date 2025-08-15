//-----------------------------------------------------------------------
// <copyright file="IIdGenerator.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Id Generator model interface
    /// </summary>
    public interface IIdGenerator : IFoundationModel
    {
        /// <summary>
        /// Gets or sets the Application Id.
        /// </summary>
        /// <value>
        /// The application id.
        /// </value>
        AppId ApplicationId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        EntityId ConfigurationScopeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        String IdName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        Int32 LastId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        Boolean ResetOnNewDate { get; set; }
    }
}
