//-----------------------------------------------------------------------
// <copyright file="ApplicationConcurrencyException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Application Concurrency Exception - raised when there is an issue with saving data to the database
    /// </summary>
    /// <seealso cref="ApplicationException" />
    public class ApplicationConcurrencyException : ApplicationException
    {
        internal const String ErrorMessageTemplate1 = "Unable to update record. It may have been updated by someone else since it was loaded. Record Id: '{0}', Name: '{1}', Table: '{2}'";
        internal const String ErrorMessageTemplate2 = "Unable to update record. It may have been updated by someone else since it was loaded. Record Id: '{0}', Name: '{1}', Table: '{2}', Last saved by: '{3}', Last saved time: '{4:dd-MMM-yyyy HH:mm:ss}'";

        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationConcurrencyException"/> class.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="lastSavedEntity">The last saved entity.</param>
        public ApplicationConcurrencyException
        (
            EntityId entityId,
            String entityName,
            String tableName,
            IFoundationModel lastSavedEntity
        )
            : base
            (
                String.Format(ErrorMessageTemplate1, entityId, entityName, tableName)
            )
        {
            EntityId = entityId;
            TableName = tableName;
            EntityName = entityName;
            LastUpdatedBy = "<unknown>";
            LastSavedEntity = lastSavedEntity;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationConcurrencyException"/> class.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="lastUpdatedBy">The last updated by.</param>
        /// <param name="lastUpdatedOn">The last updated on.</param>
        /// <param name="lastSavedEntity">The last saved entity.</param>
        public ApplicationConcurrencyException
        (
            EntityId entityId,
            String entityName,
            String tableName,
            String lastUpdatedBy,
            DateTime lastUpdatedOn,
            IFoundationModel lastSavedEntity
        )
            : base
            (
                String.Format(ErrorMessageTemplate2, entityId, entityName, tableName, lastUpdatedBy, lastUpdatedOn)
            )
        {
            EntityId = entityId;
            TableName = tableName;
            EntityName = entityName;
            LastUpdatedBy = lastUpdatedBy;
            LastUpdatedOn = lastUpdatedOn;
            LastSavedEntity = lastSavedEntity;
        }

        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public EntityId EntityId { get; }

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>
        /// The name of the table.
        /// </value>
        public String TableName { get; }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public String EntityName { get; }

        /// <summary>
        /// Gets the last updated by.
        /// </summary>
        /// <value>
        /// The last updated by.
        /// </value>
        public String LastUpdatedBy { get; }

        /// <summary>
        /// Gets the last updated on.
        /// </summary>
        /// <value>
        /// The last updated on.
        /// </value>
        public DateTime LastUpdatedOn { get; }

        /// <summary>
        /// Gets the last saved entity.
        /// </summary>
        /// <value>
        /// The last saved entity.
        /// </value>
        public IFoundationModel LastSavedEntity { get; }
    }
}
