//-----------------------------------------------------------------------
// <copyright file="RequiredAppIdAttribute.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

using Foundation.Interfaces;

namespace Foundation.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class RequiredAppIdAttribute : RequiredAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredAppIdAttribute"/> class.
        /// </summary>
        public RequiredAppIdAttribute()
        {
            ErrorMessage = "Application Id must be provided";
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

            if (value is AppId appId)
            {
                retVal = appId.TheAppId > 0;
            }

            return retVal;
        }
    }
}
