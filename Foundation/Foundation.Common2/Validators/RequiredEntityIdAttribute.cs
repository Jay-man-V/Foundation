//-----------------------------------------------------------------------
// <copyright file="RequiredEntityIdAttribute.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class RequiredEntityIdAttribute : RequiredAttribute
    {
        private String _entityName;

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredEntityIdAttribute"/> class.
        /// </summary>
        public RequiredEntityIdAttribute()
        {
            ErrorMessage = "Entity Id must be provided";
        }

        /// <summary>
        /// Gets or sets the name of the entity.
        /// </summary>
        /// <value>
        /// The name of the entity.
        /// </value>
        public String EntityName
        {
            get => _entityName;
            set
            {
                _entityName = value;
                ErrorMessage = $"{_entityName} Id must be provided";
            }
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="value">The data field value to validate.</param>
        /// <returns>
        ///   <see langword="true" /> if validation is successful; otherwise, <see langword="false" />.
        /// </returns>
        public override Boolean IsValid(Object value)
        {
            Boolean retVal = false;

            if (value is EntityId entityId)
            {
                retVal = entityId.TheEntityId > 0;
            }

            return retVal;
        }
    }
}
