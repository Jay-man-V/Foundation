//-----------------------------------------------------------------------
// <copyright file="ISequenceGenerator.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The World Region model interface
    /// </summary>
    public interface ISequenceGenerator : IFoundationModel
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
        String SequenceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        Int32 LastSequence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <value>
        /// 
        /// </value>
        Boolean ResetOnNewDate { get; set; }
    }
}
