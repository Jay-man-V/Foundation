//-----------------------------------------------------------------------
// <copyright file="IFoundationModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Foundation model interface
    /// </summary>
    [DependencyInjectionIgnore]
    public interface IFoundationModel : IFoundationObjectId, IFoundationModelTracking, INotifyPropertyChanging, INotifyPropertyChanged, ICloneable, IChangeTracking
    {
        /// <summary>
        /// Gets or sets the Initialising
        /// </summary>
        Boolean Initialising { get; set; }

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        Byte[]? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        EntityStatus EntityStatus { get; set; }

        /// <summary>
        /// Gets the status id.
        /// </summary>
        /// <value>
        /// The status id.
        /// </value>
        EntityId StatusId { get; }

        /// <summary>
        /// Gets the created date.
        /// </summary>
        /// <value>
        /// The created date.
        /// </value>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets the created by user profile id.
        /// </summary>
        /// <value>
        /// The created by user profile id.
        /// </value>
        EntityId CreatedByUserProfileId { get; set; }

        /// <summary>
        /// Gets the last updated date.
        /// </summary>
        /// <value>
        /// The last updated date.
        /// </value>
        DateTime LastUpdatedOn { get; set; }

        /// <summary>
        /// Gets the last updated by user profile id.
        /// </summary>
        /// <value>
        /// The last updated by user profile id.
        /// </value>
        EntityId LastUpdatedByUserProfileId { get; set; }

        /// <summary>
        /// Gets or sets valid from date.
        /// </summary>
        /// <value>
        /// Valid from date.
        /// </value>
        DateTime? ValidFrom { get; set; }

        /// <summary>
        /// Gets or sets valid to date.
        /// </summary>
        /// <value>
        /// Valid to date.
        /// </value>
        DateTime? ValidTo { get; set; }

        /// <summary>
        /// Gets the property value
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Object? GetPropertyValue(String propertyName);
    }
}
