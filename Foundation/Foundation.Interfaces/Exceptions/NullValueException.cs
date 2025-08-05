//-----------------------------------------------------------------------
// <copyright file="NullValueException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// NullValueException - raised when a value is Null when it is not expected to be
    /// </summary>
    public class NullValueException : ApplicationException
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="NullValueException"/> class.
        /// </summary>
        public NullValueException
        (
            String message
        ) :
            base
            (
                message
            )
        { }
    }
}
