//-----------------------------------------------------------------------
// <copyright file="TooManyRecordsDeletedException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Too Many Records Deleted Exception - Raised when the Delete command would affect too many records
    /// </summary>
    /// <seealso cref="ApplicationException" />
    public class TooManyRecordsDeletedException : ApplicationException
    {
        internal const String ErrorMessageTemplate1 = "Unable to delete record. Too many records found matching this record. Record Id: '{0}', Name: '{1}', Table: '{2}'";

        /// <summary>
        /// Initialises a new instance of the <see cref="TooManyRecordsDeletedException"/> class.
        /// </summary>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="foundationModel">The foundation model.</param>
        public TooManyRecordsDeletedException
        (
            EntityId entityId,
            String entityName,
            String tableName,
            IFoundationModel foundationModel
        ) :
            base
            (
                String.Format(ErrorMessageTemplate1, entityId.TheEntityId, entityName, tableName)
            )
        {
            EntityId = entityId;
            EntityName = entityName;
            TableName = tableName;
            FoundationModel = foundationModel;
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
        /// Gets the foundation model.
        /// </summary>
        /// <value>
        /// The foundation model.
        /// </value>
        public IFoundationModel FoundationModel { get; }
    }
}
