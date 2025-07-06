//-----------------------------------------------------------------------
// <copyright file="RequiredLogIdAttribute.cs" company="JDV Software Ltd">
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
    public class RequiredLogIdAttribute : RequiredAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredLogIdAttribute"/> class.
        /// </summary>
        public RequiredLogIdAttribute()
        {
            ErrorMessage = "Log Id must be provided";
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="value">The data field value to validate.</param>
        /// <returns>
        ///   <see langword="true" /> if validation is successful; otherwise, <see langword="false" />.
        /// </returns>
        public override Boolean IsValid(Object? value)
        {
            Boolean retVal = false;

            if (value is LogId logId)
            {
                retVal = logId.TheLogId > 0;
            }

            return retVal;
        }
    }
}
