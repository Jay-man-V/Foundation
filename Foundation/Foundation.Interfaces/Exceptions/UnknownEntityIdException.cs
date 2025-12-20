//-----------------------------------------------------------------------
// <copyright file="UnknownEntityIdException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// UnknownEntityIdException - raised when an EntityId is not known.
    /// </summary>
    public class UnknownEntityIdException : ApplicationException
    {
        internal const String ErrorMessageTemplate1 = "Cannot locate entity with Id '{0}' for entity type '{1}'";

        /// <summary>
        /// Initialises a new instance of the <see cref="NullValueException"/> class.
        /// </summary>
        public UnknownEntityIdException
        (
            AppId appId
        ) :
            this
            (
                typeof(IApplication), appId.TheAppId
            )
        {
            EntityType = typeof(IApplication);
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="NullValueException"/> class.
        /// </summary>
        public UnknownEntityIdException
        (
            LogId logId
        ) :
            this
            (
                typeof(IEventLog), logId.TheLogId
            )
        {
            EntityType = typeof(IEventLog);
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="NullValueException"/> class.
        /// </summary>
        public UnknownEntityIdException
        (
            Type entityType,
            EntityId entityId
        ) :
            this
            (
                entityType, entityId.TheEntityId
            )
        {
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="NullValueException"/> class.
        /// </summary>
        private UnknownEntityIdException
        (
            Type entityType,
            Int64 entityId
        ) :
            base
            (
                String.Format(ErrorMessageTemplate1, entityType, entityId)
            )
        {
            EntityType = entityType;
            EntityId = entityId;
        }

        public Type EntityType { get; }
        public Int64 EntityId { get; }
    }
}
