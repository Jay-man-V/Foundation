//-----------------------------------------------------------------------
// <copyright file="EmailAddressMaxLengthAttribute.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the Id Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class EmailAddressMaxLengthAttribute : MaxLengthAttribute
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EmailAddressMaxLengthAttribute" /> class.
        /// </summary>
        /// <param name="maxLength">The maximum length.</param>
        public EmailAddressMaxLengthAttribute(Int32 maxLength) : base (maxLength)
        {
        }

        /// <summary>
        /// Returns true if ... is valid.
        /// </summary>
        /// <param name="value">The object to validate.</param>
        /// <returns>
        ///   <see langword="true" /> if the value is null, or if the value is less than or equal to the specified maximum length; otherwise, <see langword="false" />.
        /// </returns>
        public override Boolean IsValid([NotNullWhen(true)] Object? value)
        {
            Boolean retVal = false;

            if (value is EmailAddress emailAddress &&
                !String.IsNullOrEmpty(emailAddress.ToString()) &&
                emailAddress.ToString().Length > 0)
            {
                retVal = emailAddress.IsValid;
            }

            return retVal;
        }
    }
}
