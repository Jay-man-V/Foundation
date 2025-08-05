//-----------------------------------------------------------------------
// <copyright file="UnableToReadNewIdentityException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Unable To Read New Identity Exception - raised when it has not been possible to read the identity of a newly added row
    /// </summary>
    /// <seealso cref="ApplicationException" />
    public class UnableToReadNewIdentityException : ApplicationException
    {
        internal const String ErrorMessageTemplate1 = "Unable to read the details of the newly created record. Record Name: '{0}', Table: '{1}'";

        /// <summary>
        /// Initialises a new instance of the <see cref="UnableToReadNewIdentityException"/> class.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="tableName">Name of the table.</param>
        /// <param name="foundationModel">The foundation model.</param>
        public UnableToReadNewIdentityException
        (
            String entityName,
            String tableName,
            IFoundationModel foundationModel
        ) :
            base
            (
                String.Format(ErrorMessageTemplate1, entityName, tableName)
            )
        {
            EntityName = entityName;
            TableName = tableName;
            FoundationModel = foundationModel;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="UnableToReadNewIdentityException"/> class.
        /// </summary>
        /// <param name="entityName">Name of the entity.</param>
        /// <param name="tableName">Name of the table.</param>
        public UnableToReadNewIdentityException
        (
            String entityName,
            String tableName
        ) :
            base
            (
                String.Format(ErrorMessageTemplate1, entityName, tableName)
            )
        {
            EntityName = entityName;
            TableName = tableName;
        }

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
        public IFoundationModel? FoundationModel { get; }
    }
}
