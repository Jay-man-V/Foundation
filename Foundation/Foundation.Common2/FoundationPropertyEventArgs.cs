//-----------------------------------------------------------------------
// <copyright file="FoundationPropertyEventArgs.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Common
{
    /// <summary>
    /// Defines the Foundation Property Event Arguments
    /// </summary>
    /// <seealso cref="EventArgs" />
    public class FoundationPropertyEventArgs : EventArgs
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="FoundationPropertyEventArgs"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public FoundationPropertyEventArgs(String propertyName, Object oldValue, Object newValue)
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
        public Object NewValue { get; protected set; }
    }

    /// <summary>
    /// Defines the Foundation Property Changing Event Arguments
    /// </summary>
    /// <seealso cref="FoundationPropertyEventArgs" />
    public class FoundationPropertyChangingEventArgs : FoundationPropertyEventArgs
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="FoundationPropertyChangingEventArgs"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public FoundationPropertyChangingEventArgs(String propertyName, Object oldValue, Object newValue)
            : base(propertyName, oldValue, newValue)
        {
            Cancel = false;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="FoundationPropertyChangingEventArgs"/> is cancel.
        /// </summary>
        /// <value>
        ///   <c>true</c> if cancel; otherwise, <c>false</c>.
        /// </value>
        public Boolean Cancel { get; set; }
    }

    /// <summary>
    /// Defines the Foundation Property Changed Event Arguments
    /// </summary>
    /// <seealso cref="Foundation.Common.FoundationPropertyEventArgs" />
    public class FoundationPropertyChangedEventArgs : FoundationPropertyEventArgs
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="FoundationPropertyChangedEventArgs"/> class.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        public FoundationPropertyChangedEventArgs(String propertyName, Object oldValue, Object newValue)
            : base(propertyName, oldValue, newValue)
        {
            // Does nothing
        }
    }
}
