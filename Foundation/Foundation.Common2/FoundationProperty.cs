//-----------------------------------------------------------------------
// <copyright file="FoundationProperty.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the Foundation Property
    /// </summary>
    /// <seealso cref="ICloneable" />
    public class FoundationProperty : ICloneable
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="FoundationProperty"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public FoundationProperty(String propertyName, Object oldValue, Object newValue)
        {
            PropertyName = propertyName;
            OldValue = oldValue;
            NewValue = newValue;
        }

        /// <summary>
        /// Gets or sets the name of the property.
        /// </summary>
        /// <value>
        /// The name of the property.
        /// </value>
        public String PropertyName { get; protected set; }

        /// <summary>
        /// Gets or sets the old value.
        /// </summary>
        /// <value>
        /// The old value.
        /// </value>
        public Object OldValue { get; protected set; }

        /// <summary>
        /// Creates new value.
        /// </summary>
        /// <value>
        /// The new value.
        /// </value>
        public Object NewValue { get; set; }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public Object Clone()
        {
            Object[] args = { PropertyName, OldValue, NewValue };

            FoundationProperty retVal = Activator.CreateInstance(this.GetType(), args) as FoundationProperty;

            return retVal;
        }
    }
}
