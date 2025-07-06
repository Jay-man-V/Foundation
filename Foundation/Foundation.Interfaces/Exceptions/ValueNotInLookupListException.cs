//-----------------------------------------------------------------------
// <copyright file="ValueNotInLookupListException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Value Not In Lookup List Exception - raised when there is a issue with saving data to the database
    /// </summary>
    /// <seealso cref="ApplicationException" />
    public class ValueNotInLookupListException : ApplicationException
    {
        internal const String ErrorMessageTemplate1 = "Unable to locate '{0}' in the list '{1}' with Id '{2}' for the Entity '{3}':'{4}'";

        /// <summary>
        /// Initialises a new instance of the <see cref="ValueNotInLookupListException"/> class.
        /// </summary>
        /// <param name="sourceField">Name of the property in <paramref name="sourceModel"/></param>
        /// <param name="lookUpListName">Name of the list being queried</param>
        /// <param name="requestedId">Identity of the requested item</param>
        /// <param name="sourceModel">The model being used as the source</param>
        public ValueNotInLookupListException
        (
            String sourceField,
            String lookUpListName,
            EntityId requestedId,
            IFoundationModel sourceModel
        ) :
            base
            (
                String.Format(ErrorMessageTemplate1, sourceField, lookUpListName, requestedId, sourceModel.GetType(), sourceModel.Id)
            )
        {
            SourceField = sourceField;
            LookUpListName = lookUpListName;
            RequestedId = requestedId;
            SourceModel = sourceModel;
        }

        /// <summary>
        /// 
        /// </summary>
        public String SourceField { get; }

        /// <summary>
        /// 
        /// </summary>
        public String LookUpListName { get; }

        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public EntityId RequestedId { get; }

        /// <summary>
        /// Gets the last saved entity.
        /// </summary>
        /// <value>
        /// The last saved entity.
        /// </value>
        public IFoundationModel SourceModel { get; }
    }
}
